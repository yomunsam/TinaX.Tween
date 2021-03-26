namespace TinaX.Tween.Components
{
    public abstract class TweenRxComponentBase : TweenComponentBase
    {
        #region Editor Variables
        //暴露给编辑器的可配置变量
        public Tween.EaseType _EaseType;
        #endregion

        protected System.IDisposable TweenRxDisposable { get; set; }

    }

    public abstract class TweenRxComponentBase<TTarget, TValue>: TweenComponentBase<TTarget, TValue> where TTarget: UnityEngine.Object
    {
        #region Editor Variables
        //暴露给编辑器的可配置变量
        public Tween.EaseType _EaseType;
        #endregion

        protected System.IDisposable TweenRxDisposable { get; set; }

    }

}
