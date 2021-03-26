using TinaX.Tween.Components;
using TinaXEditor.Utils;
using UnityEditor;
using UnityEngine;

namespace TinaXEditor.Tween.CustomEditors
{
    /// <summary>
    /// 实现了PingPong功能的TweenRx组件基类
    /// </summary>
    [CustomEditor(typeof(PingPongTweenRxComponentBase),true)]
    public class PingPongTweenRxComponentBaseCustomEditor : TweenRxComponentBaseCustomEditor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            var _serializedObject = this.serializedObject;
            UIDraw.DrawTitle(this.Title);
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();

            UIDraw.DrawDuration(ref _serializedObject);
            UIDraw.DrawTweenRxEaseValue(ref _serializedObject);
            UIDraw.DrawPlayOnAwake(ref _serializedObject);
            UIDraw.DrawDelayBefore(ref _serializedObject);

            EditorGUILayout.Space();
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();
            UIDraw.DrawPingPong(ref _serializedObject);

            UIDraw.DrawDescription(ref _serializedObject);
            EditorGUILayout.Space();
            UIDraw.DrawEvents_FinishAndStop(ref _serializedObject);

            _serializedObject.ApplyModifiedProperties();
        }
    }

    /// <summary>
    /// 实现了PingPong功能的【泛型】TweenRx组件基类
    /// </summary>
    [CustomEditor(typeof(PingPongTweenRxComponentBase<,>), true)]
    public class PingPongTweenRxComponentBaseCustomEditorGeneric : TweenRxComponentBaseCustomEditorGeneric
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            var _serializedObject = this.serializedObject;
            UIDraw.DrawTitle(this.Title);
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();

            UIDraw.DrawTarget(ref _serializedObject);
            UIDraw.DrawFromValue(ref _serializedObject);
            UIDraw.DrawToValue(ref _serializedObject);
            UIDraw.DrawAutoOriginValue(ref _serializedObject);
            UIDraw.DrawAutoTargetValue(ref _serializedObject);
            UIDraw.DrawSetAsOriginValueOrTargetValue(ref SetOriginValueOnClicked, ref SetTargetValueOnClicked);
            EditorGUILayout.Space();
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();

            UIDraw.DrawDuration(ref _serializedObject);
            UIDraw.DrawTweenRxEaseValue(ref _serializedObject);
            UIDraw.DrawPlayOnAwake(ref _serializedObject);
            UIDraw.DrawDelayBefore(ref _serializedObject);

            EditorGUILayout.Space();
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();

            UIDraw.DrawPingPong(ref _serializedObject);

            EditorGUILayout.Space();
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();

            UIDraw.DrawDescription(ref _serializedObject);
            EditorGUILayout.Space();
            UIDraw.DrawEvents_FinishAndStop(ref _serializedObject);

            _serializedObject.ApplyModifiedProperties();
        }
    }

}
