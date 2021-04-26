using TinaX.Tween.Components;
using UnityEditor;
using UnityEngine;

namespace TinaXEditor.Tween.CustomEditors
{
    [CustomEditor(typeof(TransformScaleTween))]
    public class TransformScaleTweenCustomEditor : PingPongTweenRxComponentBaseCustomEditorGeneric
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            //定义标题
            switch (Application.systemLanguage)
            {
                default:
                    Title = "Transform Scale";
                    break;
                case SystemLanguage.Chinese:
                case SystemLanguage.ChineseSimplified:
                    Title = "Transform 缩放";
                    break;
            }


            //定义两个按钮

            if (SetOriginValueOnClicked == null)
                SetOriginValueOnClicked = (targetSP, fromSP) =>
                {
                    var trans = targetSP.objectReferenceValue as Transform;
                    if (trans == null)
                        return;
                    fromSP.vector3Value = trans.localScale;
                };

            if (SetTargetValueOnClicked == null)
                SetTargetValueOnClicked = (targetSP, toSP) =>
                {
                    var trans = targetSP.objectReferenceValue as Transform;
                    if (trans == null)
                        return;
                    toSP.vector3Value = trans.localScale;
                };
        }
    }
}
