using System;
using TinaX.Tween.Components;
using TinaXEditor.Utils;
using UnityEditor;

namespace TinaXEditor.Tween.CustomEditors
{
    [CustomEditor(typeof(TweenComponentBase), true)]
    public class TweenComponentBaseCustomEditor : Editor
    {
        public string Title { get; protected set; } = "Tween";
        protected Action<SerializedProperty, SerializedProperty> SetOriginValueOnClicked;
        protected Action<SerializedProperty, SerializedProperty> SetTargetValueOnClicked;

        protected virtual TweenComponentBase m_TweenComponentBase { get; set; }
        protected TweenEditorUIDraw UIDraw = new TweenEditorUIDraw();



        protected virtual void OnEnable()
        {
            m_TweenComponentBase = (TweenComponentBase)target;
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            var _serializedObject = this.serializedObject;
            UIDraw.DrawTitle(this.Title);
            EditorGUIUtil.HorizontalLine();
            EditorGUILayout.Space();

            UIDraw.DrawDuration(ref _serializedObject);
            UIDraw.DrawPlayOnAwake(ref _serializedObject);
            UIDraw.DrawDelayBefore(ref _serializedObject);
            UIDraw.DrawDescription(ref _serializedObject);
            UIDraw.DrawEvents_FinishAndStop(ref _serializedObject);

            _serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// 使用Unity自己的方式绘制InspectorGUI
        /// </summary>
        protected void DrawNativeInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }

    /// <summary>
    /// 泛型Tween基类
    /// </summary>
    [CustomEditor(typeof(TweenComponentBase<,>), true)]
    public class TweenComponentBaseCustomEditorGeneric : TweenComponentBaseCustomEditor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            var _serializedObject = this.serializedObject;
            UIDraw.DrawTitle(this.Title);
            EditorGUIUtil.HorizontalLine();
            EditorGUILayout.Space();

            UIDraw.DrawTarget(ref _serializedObject);
            UIDraw.DrawFromValue(ref _serializedObject);
            UIDraw.DrawToValue(ref _serializedObject);
            UIDraw.DrawAutoOriginValue(ref _serializedObject);
            UIDraw.DrawAutoTargetValue(ref _serializedObject);
            UIDraw.DrawSetAsOriginValueOrTargetValue(ref SetOriginValueOnClicked, ref SetTargetValueOnClicked);
            EditorGUILayout.Space();
            EditorGUIUtil.HorizontalLine();
            EditorGUILayout.Space();

            UIDraw.DrawDuration(ref _serializedObject);
            UIDraw.DrawPlayOnAwake(ref _serializedObject);
            UIDraw.DrawDelayBefore(ref _serializedObject);
            UIDraw.DrawDescription(ref _serializedObject);
            UIDraw.DrawEvents_FinishAndStop(ref _serializedObject);

            _serializedObject.ApplyModifiedProperties();
        }
    }

}

