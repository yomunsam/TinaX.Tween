using System;

namespace TinaX.Tween
{
    /// <summary>
    /// 使动画可以PingPong的接口
    /// </summary>
    public interface IPingPong
    {
        bool PingPong { get; }

        /// <summary>
        /// 每次PingPong之间的延迟
        /// </summary>
        float PingPongDelay { get; }

        /// <summary>
        /// Ping之后Pong之前的延迟
        /// </summary>
        float PongDelay { get; }

        Action OnPing { get; set; }
        Action OnPong { get; set; }
        Action OnPingPong { get; set; }
    }
}
