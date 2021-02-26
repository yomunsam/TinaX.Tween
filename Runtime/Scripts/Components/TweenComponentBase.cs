using System;
using TinaX.Tween.UnityEvents;
using UnityEngine;

namespace TinaX.Tween.Components
{
    public abstract class TweenComponentBase : MonoBehaviour, IPlayableTween
    {

        #region Editor Variables
        //暴露给编辑器的可配置变量

        public float _Duration = 1f;

        public float _DelayBefore = 0f;

        [TextArea]
        public string _Description = "tween1"; //一个描述，通常只用于备注用途

        public bool _PlayOnAwake = false;

        public OnTweenFinishEvent _OnTweenFinish = new OnTweenFinishEvent();
        #endregion
        
        public float Duration => _Duration;
        public float DelayBefore => _DelayBefore;

        /// <summary>
        /// 是否正在播放
        /// </summary>
        public virtual bool Playing { get; private set; } = false;

        public Action OnFinish { get; set; }


        public abstract void Ready();
        public abstract void BeginPlay();

        public abstract void Stop();

        protected virtual void Finish()
        {
            OnFinish?.Invoke();
            _OnTweenFinish?.Invoke();
        }

        public virtual void Dispose()
        {
            if (this.Playing)
                this.Stop();
        }

        protected virtual void Awake()
        {
            if (_PlayOnAwake)
            {
                this.BeginPlay();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TValue">要改变的值</typeparam>
    /// <typeparam name="TTarget">操作值的目标</typeparam>
    public abstract class TweenComponentBase<TTarget, TValue> : TweenComponentBase where TTarget: UnityEngine.Object
    {
        #region Editor Variables
        //暴露给编辑器的可配置变量

        /// <summary>
        /// 操作目标
        /// </summary>
        public TTarget _Target;

        /// <summary>
        /// 初始值
        /// </summary>
        public TValue FromValue;
        public TValue ToValue;

        public bool AutoOriginValue = false;
        public bool AutoTargetValue = false;
        #endregion

        public TTarget Target
        {
            get
            {
                if(_Target == null)
                {
                    _Target = this.GetDefaultTarget();
                }
                return _Target;
            }
        }


        /// <summary>
        /// 如果编辑器中没有对TTarget赋值的话，基类会调用这里
        /// </summary>
        /// <returns></returns>
        public abstract TTarget GetDefaultTarget();


    }
}
