using System;
using UniRx;
using UnityEngine;

namespace TinaX.Tween.Components
{
    public class TransformScaleTween : PingPongTweenRxComponentBase<Transform, Vector3>
    {
        private Vector3? origin_value;
        private Vector3? target_value;

        private bool ready_flag = false; //如果执行过Ready，这里为true
        private bool valid_tween = true; //该组件的各项配置是否有效

        private bool pingpong_switch;



        public override bool Playing => this.TweenRxDisposable != null;

        public override Transform GetDefaultTarget()
        {
            return this.transform;
        }

        public override void Ready()
        {
            if (ready_flag)
                return;
            ready_flag = true;

            if (Target == null)
            {
                Debug.LogError($"[TinaX.Tween]{nameof(TransformScaleTween)} cannot get valid target.");
                valid_tween = false;
            }

            if (!this.AutoOriginValue)
            {
                this.Target.localScale = this.FromValue;
            }
            else
            {
                this._PingPong = false; //如果自动识别初始值，则不应该可以PingPong（规则是只有明确指定了初始值和目标值才可以PingPong）
                this.AutoTargetValue = false;
            }
            origin_value = this.AutoOriginValue ? this.Target.localScale : this.FromValue;
            target_value = this.AutoTargetValue ? this.Target.localScale : this.ToValue;

            TimeSpan_PingPongDelay = TimeSpan.FromSeconds(this.PingPongDelay);
            TimeSpan_PongDelay = TimeSpan.FromSeconds(this.PongDelay);

            valid_tween = true;

        }

        public override void BeginPlay()
        {
            if (Playing)
                return;

            if(!ready_flag)
                this.Ready();

            if (!valid_tween)
                return;

            if (origin_value.Value.Equals(target_value.Value))
            {
                this.Finish();
                return;
            }

            this.TweenRxDisposable = Tween.Play(
                origin_value.Value,
                target_value.Value,
                this.Duration,
                this.EaseType,
                this.DelayBefore)
                .Subscribe(value => { this.Target.localScale = value; }, tweenFinish);
        }

        

        

        public override void Stop()
        {
            this.TweenRxDisposable?.Dispose();
            this.TweenRxDisposable = null;
            pingpong_switch = false;
        }

        private void tweenFinish()
        {
            if (this.PingPong)
            {
                this.pingpong_switch = !this.pingpong_switch;
                this.TweenRxDisposable?.Dispose();
                var obsv3 = Tween.Play(!pingpong_switch ? this.FromValue : this.ToValue,
                    !pingpong_switch ? this.ToValue : this.FromValue,
                    this.Duration,
                    this.EaseType);
                //延迟处理
                if (!pingpong_switch)
                {
                    if (this.PingPongDelay > 0)
                        obsv3 = obsv3.Delay(TimeSpan_PingPongDelay);
                }
                else
                {
                    if (this.PongDelay > 0)
                        obsv3 = obsv3.Delay(TimeSpan_PongDelay);
                }

                this.TweenRxDisposable = obsv3.Subscribe(value => { this.Target.localScale = value; }, tweenFinish);
            }
            else
            {
                this.Finish();
            }
        }

    }
}
