using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinaX.Tween
{
    /// <summary>
    /// 可播放的补间动画
    /// </summary>
    public interface IPlayableTween : IDisposable
    {
        /// <summary>
        /// 持续时间
        /// </summary>
        float Duration { get; }

        /// <summary>
        /// 在整个动画开始前的延迟（BeginPlay开始的延迟）
        /// </summary>
        float DelayBefore { get; }

        /// <summary>
        /// 是否正在运行动画
        /// </summary>
        bool Playing { get; }

        /// <summary>
        /// 动画播放结束后的触发事件
        /// </summary>
        Action OnFinish { get; set; }

        /// <summary>
        /// 动画开始前的准备操作
        /// </summary>
        void Ready();

        /// <summary>
        /// 正式开始播动画
        /// </summary>
        void BeginPlay();
        /// <summary>
        /// 停止播放动画
        /// </summary>
        void Stop();
        
    }
}

