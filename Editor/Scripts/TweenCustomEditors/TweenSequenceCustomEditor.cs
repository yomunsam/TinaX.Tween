using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinaX.Tween.Components;
using TinaXEditor.Utils;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace TinaXEditor.Tween.CustomEditors
{
    [CustomEditor(typeof(TweenSequence))]
    public class TweenSequenceCustomEditor : TweenComponentBaseCustomEditor
    {
        SerializedProperty _Seq;
        
        public ReorderableList SequencesList;
        private bool m_RefreshDataFlag = false;

        protected override void OnEnable()
        {
            base.OnEnable();

            //定义标题
            switch (Application.systemLanguage)
            {
                default:
                    Title = "Tween Queue";
                    break;
                case SystemLanguage.Chinese:
                case SystemLanguage.ChineseSimplified:
                    Title = "补间动画序列";
                    break;
            }
        }


        public override void OnInspectorGUI()
        {
            if (!m_RefreshDataFlag || _Seq == null)
                _RefreshData();
            //base.OnInspectorGUI();

            var _serializedObject = this.serializedObject;
            UIDraw.DrawTitle(this.Title);
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();
            SequencesList.DoLayoutList();
            if (GUILayout.Button(EditorGUIUtil.IsCmnHans ? "打开独立编辑窗口" : "Open Edit Window"))
            {
                TweenSequenceEditWindow.TargetCustomEditor = this;
                TweenSequenceEditWindow.OpenUI();
            }
            EditorGUILayout.Space();
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();

            //UIDraw.DrawDuration(ref _serializedObject);
            UIDraw.DrawPlayOnAwake(ref _serializedObject);
            UIDraw.DrawDelayBefore(ref _serializedObject);
            UIDraw.DrawDescription(ref _serializedObject);

            EditorGUILayout.Space();
            UIDraw.DrawEvents_FinishAndStop(ref _serializedObject);

            _serializedObject.ApplyModifiedProperties();
        }

        private void _RefreshData()
        {
            _Seq = this.serializedObject.FindProperty("_Sequences");

            SequencesList = new ReorderableList(this.serializedObject, _Seq, true, true, true, true);
            SequencesList.drawElementCallback = (rect, index, isActive, isFocus) =>
            {
                rect.height = EditorGUIUtility.singleLineHeight;
                rect.y += 2;
                SerializedProperty itemData = _Seq.GetArrayElementAtIndex(index);
                SerializedProperty itemData_Tweens = itemData.FindPropertyRelative("Tweens");
                SerializedProperty itemData_Delay = itemData.FindPropertyRelative("DelayAfter");
                if (itemData_Tweens.arraySize > 0)
                {
                    for (var i = 0; i < itemData_Tweens.arraySize; i++)
                    {
                        var rect_item = rect;
                        rect_item.y += i * (EditorGUIUtility.singleLineHeight + 2);
                        var tween_item = itemData_Tweens.GetArrayElementAtIndex(i);
                        var tween_component = tween_item.FindPropertyRelative("TweenComponent");
                        var ready = tween_item.FindPropertyRelative("ReadyOnSequenceStart");

                        var rect_obj = rect_item;
                        rect_obj.width -= 80;
                        tween_component.objectReferenceValue = EditorGUI.ObjectField(rect_obj, tween_component.objectReferenceValue, typeof(TweenComponentBase), true);


                        var rect_ready = rect_item;
                        rect_ready.x += rect_obj.width + 4;
                        rect_ready.width = 55;
                        ready.boolValue = EditorGUI.ToggleLeft(rect_ready, new GUIContent("Ready", "If ready, The target of this animation will be set to the origin value at the beginning of the sequence"), ready.boolValue);

                        var rect_del = rect_item;
                        rect_del.x += rect_obj.width + 4 + rect_ready.width + 2;
                        rect_del.width = 19;
                        if (GUI.Button(rect_del, new GUIContent("×", "Delete")))
                        {
                            itemData_Tweens.DeleteArrayElementAtIndex(i);
                        }
                    }
                }
                //add btn
                var rect_btn_add = rect;
                rect_btn_add.y += (itemData_Tweens.arraySize) * (EditorGUIUtility.singleLineHeight + 2);
                rect_btn_add.width = 80;
                if (GUI.Button(rect_btn_add, "Add"))
                {
                    var __index = itemData_Tweens.arraySize;
                    itemData_Tweens.InsertArrayElementAtIndex(__index);
                    var this_data = itemData_Tweens.GetArrayElementAtIndex(__index);
                    this_data.FindPropertyRelative("TweenComponent").objectReferenceValue = null;
                    this_data.FindPropertyRelative("ReadyOnSequenceStart").boolValue = false;
                }
                var rect_delay = rect;
                rect_delay.y += (itemData_Tweens.arraySize + 1) * (EditorGUIUtility.singleLineHeight + 2);
                itemData_Delay.floatValue = EditorGUI.FloatField(rect_delay, new GUIContent("Delay After:"), itemData_Delay.floatValue);

            };
            SequencesList.elementHeightCallback = (index) =>
            {
                var count = _Seq.GetArrayElementAtIndex(index).FindPropertyRelative("Tweens").arraySize;
                return (EditorGUIUtility.singleLineHeight + 2) * (count + 2) + 5;
            };
            SequencesList.onAddCallback = (list) =>
            {
                if (list.serializedProperty != null)
                {
                    list.serializedProperty.arraySize++;
                    list.index = list.serializedProperty.arraySize - 1;

                    SerializedProperty itemData = list.serializedProperty.GetArrayElementAtIndex(list.index);
                    SerializedProperty item_tweens = itemData.FindPropertyRelative("Tweens");
                    SerializedProperty item_delay = itemData.FindPropertyRelative("DelayAfter");
                    item_tweens.ClearArray();
                    item_delay.floatValue = 0;
                }
                else
                {
                    ReorderableList.defaultBehaviours.DoAddButton(list);
                }
            };
            SequencesList.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, EditorGUIUtil.IsCmnHans ? "补间动画序列" : "Tween Sequences");
            };
            m_RefreshDataFlag = true;
        }

    }

    /// <summary>
    /// 独立编辑窗
    /// </summary>
    public class TweenSequenceEditWindow : EditorWindow
    {
        public static TweenSequenceCustomEditor TargetCustomEditor;

        private static TweenSequenceEditWindow wnd;

        public static void OpenUI()
        {
            if (wnd == null)
            {
                wnd = GetWindow<TweenSequenceEditWindow>();
                wnd.titleContent = new GUIContent(EditorGUIUtil.IsCmnHans ? "序列编辑器" : "Sequences Editor");
            }
            else
            {
                wnd.Show();
                wnd.Focus();
            }
        }

        private void OnGUI()
        {
            if(TargetCustomEditor == null)
            {
                GUILayout.FlexibleSpace();
                GUILayout.Label(EditorGUIUtil.IsCmnHans ? "编辑器目标丢失，请重新打开本窗口." : "Editor target lost, please reopen it.");
                GUILayout.FlexibleSpace();

                return;
            }
            TargetCustomEditor.SequencesList.DoLayoutList();
            TargetCustomEditor.serializedObject.ApplyModifiedProperties();
        }

        private void OnDestroy()
        {
            wnd = null;
            TargetCustomEditor = null;
        }

    }
}
