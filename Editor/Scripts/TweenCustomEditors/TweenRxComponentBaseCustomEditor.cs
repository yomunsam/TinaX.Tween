using TinaX.Tween.Components;
using TinaXEditor.Utils;
using UnityEditor;
using UnityEngine;

namespace TinaXEditor.Tween.CustomEditors
{
    /// <summary>
    /// TweenRx组件基类
    /// </summary>
    [CustomEditor(typeof(TweenRxComponentBase), true)]
    public class TweenRxComponentBaseCustomEditor : TweenComponentBaseCustomEditor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            var _serializedObject = this.serializedObject;
            UIDraw.DrawTitle(this.Title);
            EditorGUIUtil.HorizontalLine(1, Color.gray);
            EditorGUILayout.Space();

            UIDraw.DrawDuration(ref _serializedObject);
            UIDraw.DrawTweenRxEaseValue(ref _serializedObject); //这个组件多出来的Ease加在这儿了
            UIDraw.DrawPlayOnAwake(ref _serializedObject);
            UIDraw.DrawDelayBefore(ref _serializedObject);
            UIDraw.DrawDescription(ref _serializedObject);

            EditorGUILayout.Space();
            UIDraw.DrawEvents_FinishAndStop(ref _serializedObject);

            _serializedObject.ApplyModifiedProperties();
        }

    }

    /// <summary>
    /// 泛型TweenRx组件基类
    /// </summary>
    [CustomEditor(typeof(TweenRxComponentBase<,>), true)]
    public class TweenRxComponentBaseCustomEditorGeneric : TweenComponentBaseCustomEditorGeneric
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
            UIDraw.DrawTweenRxEaseValue(ref _serializedObject); //这个组件多出来的Ease加在这儿了
            UIDraw.DrawPlayOnAwake(ref _serializedObject);
            UIDraw.DrawDelayBefore(ref _serializedObject);
            UIDraw.DrawDescription(ref _serializedObject);

            EditorGUILayout.Space();
            UIDraw.DrawEvents_FinishAndStop(ref _serializedObject);

            _serializedObject.ApplyModifiedProperties();
        }
    }


}
