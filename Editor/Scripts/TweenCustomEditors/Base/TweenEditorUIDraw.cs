using TinaX.Tween;
using TinaX.Tween.Components;
using UnityEditor;
using UnityEngine;
using TinaXEditor.Utils;
using System;

namespace TinaXEditor.Tween.CustomEditors
{
    public class TweenEditorUIDraw
    {
        private SerializedProperty _duration;
        private SerializedProperty _playOnAwake;
        private SerializedProperty _delayBefore;
        private SerializedProperty _description;
        private SerializedProperty _onTweenFinish;
        private SerializedProperty _onTweenStop;
        private SerializedProperty _target;
        private SerializedProperty _fromValue;
        private SerializedProperty _toValue;
        private SerializedProperty _autoOriginValue;
        private SerializedProperty _autoTargetValue;

        private bool _foldout_events;

        private GUIContent GC_Duration;
        private GUIContent GC_PlayOnAwake;
        private GUIContent GC_DelayBefore;
        private GUIContent GC_Description;
        private GUIContent GC_Target;
        private GUIContent GC_Events
        {
            get
            {
                if (_GC_Events == null)
                {
                    switch (Application.systemLanguage)
                    {
                        default:
                            _GC_Events = new GUIContent("Tween Events");
                            break;
                        case SystemLanguage.Chinese:
                        case SystemLanguage.ChineseSimplified:
                            _GC_Events = new GUIContent("动画事件");
                            break;
                        case SystemLanguage.Japanese:
                            _GC_Events = new GUIContent("Tweenイベント");
                            break;
                    }
                }
                return _GC_Events;
            }
        }

        private GUIContent _GC_Events;

        private TweenEditorUIStyles Styles = new TweenEditorUIStyles();

        public void DrawTitle(string title)
        {
            EditorGUILayout.LabelField(title, Styles.Title);
        }

        public void DrawDuration(ref SerializedObject serializedObject)
        {
            if (_duration == null && serializedObject != null)
                _duration = serializedObject.FindProperty("_Duration");

            if (GC_Duration == null)
            {
                switch (Application.systemLanguage)
                {
                    default:
                        GC_Duration = new GUIContent("Duration");
                        break;
                    case SystemLanguage.Chinese:
                    case SystemLanguage.ChineseSimplified:
                        GC_Duration = new GUIContent("间隔时间");
                        break;
                    case SystemLanguage.Japanese:
                        GC_Duration = new GUIContent("期間");
                        break;
                }
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(_duration, GC_Duration, true);
            EditorGUILayout.EndHorizontal();
        }

        public void DrawPlayOnAwake(ref SerializedObject serializedObject)
        {
            if (_playOnAwake == null && serializedObject != null)
                _playOnAwake = serializedObject.FindProperty("_PlayOnAwake");

            if (GC_PlayOnAwake == null)
            {
                switch (Application.systemLanguage)
                {
                    default:
                        GC_PlayOnAwake = new GUIContent("Play On Awake");
                        break;
                    case SystemLanguage.Chinese:
                    case SystemLanguage.ChineseSimplified:
                        GC_PlayOnAwake = new GUIContent("自动播放");
                        break;
                    case SystemLanguage.Japanese:
                        GC_PlayOnAwake = new GUIContent("自動再生");
                        break;
                }
            }

            EditorGUILayout.PropertyField(_playOnAwake, GC_PlayOnAwake, true);
        }
        
        public void DrawDelayBefore(ref SerializedObject serializedObject)
        {
            if (_delayBefore == null && serializedObject != null)
                _delayBefore = serializedObject.FindProperty("_DelayBefore");

            if (GC_DelayBefore == null)
            {
                switch (Application.systemLanguage)
                {
                    default:
                        GC_DelayBefore = new GUIContent("Delay Before", "The unit is seconds");
                        break;
                    case SystemLanguage.Chinese:
                    case SystemLanguage.ChineseSimplified:
                        GC_DelayBefore = new GUIContent("播放前延迟", "单位为秒");
                        break;
                    case SystemLanguage.Japanese:
                        GC_DelayBefore = new GUIContent("プレイの遅延", "単位は秒です");
                        break;
                }
            }

            EditorGUILayout.PropertyField(_delayBefore, GC_DelayBefore, true);
        }

        public void DrawDescription(ref SerializedObject serializedObject)
        {
            if (_description == null && serializedObject != null)
                _description = serializedObject.FindProperty("_Description");

            if (GC_Description == null)
            {
                switch (Application.systemLanguage)
                {
                    default:
                        GC_Description = new GUIContent("Description", "The unit is seconds");
                        break;
                    case SystemLanguage.Chinese:
                    case SystemLanguage.ChineseSimplified:
                        GC_Description = new GUIContent("描述");
                        break;
                    case SystemLanguage.Japanese:
                        GC_Description = new GUIContent("説明");
                        break;
                }
            }

            EditorGUILayout.PropertyField(_description, GC_Description, true);
        }

        public void DrawTarget(ref SerializedObject serializedObject)
        {
            if (_target == null && serializedObject != null)
                _target = serializedObject.FindProperty("_Target");

            if (GC_Target == null)
            {
                switch (Application.systemLanguage)
                {
                    default:
                        GC_Target = new GUIContent("Tween Target", "The target that the interposition animation acts on");
                        break;
                    case SystemLanguage.Chinese:
                    case SystemLanguage.ChineseSimplified:
                        GC_Target = new GUIContent("动画目标", "补间动画作用于的目标");
                        break;
                    case SystemLanguage.Japanese:
                        GC_Target = new GUIContent("Tween Target", "アニメの役割を補完する目的");
                        break;
                }
            }

            EditorGUILayout.PropertyField(_target, GC_Target, true);
        }
        
        public void DrawFromValue(ref SerializedObject serializedObject)
        {
            if (_fromValue == null && serializedObject != null)
                _fromValue = serializedObject.FindProperty("_FromValue");

            if (_autoOriginValue != null)
            {
                if (_autoOriginValue.boolValue)
                    return;
            }
            EditorGUILayout.PropertyField(_fromValue, true);
        }
        
        public void DrawToValue(ref SerializedObject serializedObject)
        {
            if (_toValue == null && serializedObject != null)
                _toValue = serializedObject.FindProperty("_ToValue");

            if (_autoTargetValue != null)
            {
                if (_autoTargetValue.boolValue)
                    return;
            }
            EditorGUILayout.PropertyField(_toValue, true);
        }


        public void DrawAutoOriginValue(ref SerializedObject serializedObject)
        {
            if (_autoOriginValue == null && serializedObject != null)
                _autoOriginValue = serializedObject.FindProperty("_AutoOriginValue");

            EditorGUILayout.PropertyField(_autoOriginValue, true);
        }
        
        public void DrawAutoTargetValue(ref SerializedObject serializedObject)
        {
            if (_autoTargetValue == null && serializedObject != null)
                _autoTargetValue = serializedObject.FindProperty("_AutoTargetValue");

            EditorGUILayout.PropertyField(_autoTargetValue, true);
        }

        public void DrawSetAsOriginValueOrTargetValue(ref Action<SerializedProperty, SerializedProperty> SetOriginOnClicked,ref Action<SerializedProperty, SerializedProperty> SetTargetOnClicked)
        {
            //显示“设置当前值为初始值或目标值”的按钮，其中Action的两个参数，第一个固定为"Target"，第二个为FromValue或ToValue.
            if (SetOriginOnClicked == null && SetTargetOnClicked == null)
                return;
            if (_target == null)
                return;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(EditorGUIUtil.IsCmnHans ? "设置当前值为:" : "Set current value as:", GUILayout.MaxWidth(140));
            if(SetOriginOnClicked != null && _fromValue != null && _autoOriginValue != null && !_autoOriginValue.boolValue)
            {
                if(GUILayout.Button(EditorGUIUtil.IsCmnHans ?"初始值":"Origin", GUILayout.MaxWidth(50)))
                {
                    SetOriginOnClicked?.Invoke(_target, _fromValue);
                }
            }

            if (SetTargetOnClicked != null && _toValue != null && _autoTargetValue != null && !_autoTargetValue.boolValue)
            {
                if (GUILayout.Button(EditorGUIUtil.IsCmnHans ? "目标值" : "Target", GUILayout.MaxWidth(50)))
                {
                    SetOriginOnClicked?.Invoke(_target, _fromValue);
                }
            }
        }




        public void DrawEvents_FinishAndStop(ref SerializedObject serializedObject)
        {
            if (_onTweenFinish == null && serializedObject != null)
                _onTweenFinish = serializedObject.FindProperty("_OnTweenFinish");
            if (_onTweenStop == null && serializedObject != null)
                _onTweenStop = serializedObject.FindProperty("_OnTweenStop");

            _foldout_events = EditorGUILayout.Foldout(_foldout_events, GC_Events);
            if (_foldout_events)
            {
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(_onTweenFinish);
                EditorGUILayout.PropertyField(_onTweenStop);
            }
        }
    }
}
