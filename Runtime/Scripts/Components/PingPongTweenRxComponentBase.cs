using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinaX.Tween.Components
{
    public abstract class PingPongTweenRxComponentBase : TweenRxComponentBase, IPingPong
    {
        #region Editor Variables
        //暴露给编辑器的可配置变量

        public bool _PingPong = false;

        public float _PingPongDelay = 0f;

        public float _PongDelay = 0f;
        #endregion

        public bool PingPong => _PingPong;
        public float PingPongDelay => _PingPongDelay;
        public float PongDelay => _PongDelay;

        public Action OnPing { get; set; }
        public Action OnPong { get; set; }
        public Action OnPingPong { get; set; }

    }

    public abstract class PingPongTweenRxComponentBase<TTarget, TValue> : TweenRxComponentBase<TTarget, TValue>, IPingPong where TTarget: UnityEngine.Object
    {
        #region Editor Variables
        //暴露给编辑器的可配置变量

        public bool _PingPong = false;

        public float _PingPongDelay = 0f;

        public float _PongDelay = 0f;
        #endregion

        public bool PingPong => _PingPong;
        public float PingPongDelay => _PingPongDelay;
        public float PongDelay => _PongDelay;

        public Action OnPing { get; set; }
        public Action OnPong { get; set; }
        public Action OnPingPong { get; set; }

        //两个时间统一弄个变量出来存起来
        protected TimeSpan TimeSpan_PingPongDelay;
        protected TimeSpan TimeSpan_PongDelay;

    }
}
