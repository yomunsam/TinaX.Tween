using System;
using System.Collections.Generic;
using TinaX.Tween.Const;
using UniRx;
using UnityEngine;

namespace TinaX.Tween.Components
{
    [AddComponentMenu(TweenConst.ComponentMenuRootPath + "Tween Sequence")]
    public class TweenSequence : TweenComponentBase
    {
        #region 嵌套结构体的定义
        [Serializable]
        public struct SeqItem
        {
            public TweenItem[] Tweens;
            public float DelayAfter;
        }

        [Serializable]
        public struct TweenItem
        {
            public TweenComponentBase TweenComponent;
            public bool ReadyOnSequenceStart;
        }
        #endregion


        public List<SeqItem> _Sequences;

        private int m_Index = 0;
        private bool m_PlayFlag = false;

        private bool ready_flag = false; //如果执行过Ready，这里为true
        private bool valid_tween = true; //该组件的各项配置是否有效

        public override float Duration
        {
            get
            {
                if (_Sequences == null || _Sequences.Count == 0) 
                    return 0;
                if (_CheckLoopRecursive(this)) return 0;
                float total = 0;
                foreach (var item in this._Sequences)
                {
                    total += _GetMaxDurationTime(item);
                    total += item.DelayAfter;
                }
                return total;
            }
        }

        public override void Ready()
        {
            if (ready_flag)
                return;
            ready_flag = true;

            if (_Sequences == null || _Sequences.Count < 1)
                return;

            //检查死循环
            if (_CheckLoopRecursive(this))
                return;

            //Ready
            foreach (var item in this._Sequences)
            {
                if (item.Tweens != null && item.Tweens.Length > 0)
                {
                    foreach (var i2 in item.Tweens)
                    {
                        if (i2.ReadyOnSequenceStart && i2.TweenComponent != null)
                            i2.TweenComponent.Ready();
                    }
                }
            }

            valid_tween = true;
        }

        public override void BeginPlay()
        {
            if (Playing)
                return;

            if (!ready_flag)
                this.Ready();

            if (!valid_tween)
                return;

            m_PlayFlag = true;
            m_Index = 0;
            //Debug.Log("总时长：" + this.Duration.ToString(), this);

            doPlay();
        }


        /// <summary>
        /// 递归 死循环检查
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="calls"></param>
        /// <returns>发现死循环则返回true</returns>
        private bool _CheckLoopRecursive(TweenSequence sequence, List<TweenSequence> calls = null)
        {
            if (calls == null)
                calls = new List<TweenSequence>();
            calls.Add(sequence);

            if (sequence._Sequences == null || sequence._Sequences.Count == 0) return false;

            foreach (var item in sequence._Sequences)
            {
                if (item.Tweens == null || item.Tweens.Length == 0)
                    continue;
                foreach (var item2 in item.Tweens)
                {
                    if (item2.TweenComponent == null)
                        continue;
                    if (!(item2.TweenComponent is TweenSequence))
                        continue;
                    var __seq = item2.TweenComponent as TweenSequence;
                    if (calls.Contains(__seq))
                    {
                        //死循环了
                        Debug.LogError($"[TinaX.Tween][TweenSequence] The sequence cannot be played because the current sequence or one of the sequence contains the current sequence, causing an infinite loop.The sequence causing the conflict is {__seq.name}", __seq);
                        return true;
                    }
                    //递归检查
                    bool b = _CheckLoopRecursive(__seq, calls);
                    if (b)
                        return true;
                }
            }

            return false;
        }


        //递归
        private void doPlay()
        {
            if (!m_PlayFlag) return;
            if (m_Index >= this._Sequences.Count)
                return;

            if (_Sequences[m_Index].Tweens == null || _Sequences[m_Index].Tweens.Length == 0)
                finish();
            else
            {
                int _play_counter = 0;
                int counter = 0;
                void __finish()
                {
                    counter++;
                    //Debug.Log("收到finish" + counter);
                    if (counter == _play_counter)
                    {
                        //Debug.Log("队列中的当前index都finish了：" + m_Index);
                        foreach (var item in _Sequences[m_Index].Tweens)
                        {
                            if (item.TweenComponent == null) 
                                continue;
                            item.TweenComponent._OnTweenFinish.RemoveListener(__finish);
                        }
                        this.finish();
                    }
                }
                foreach (var item in _Sequences[m_Index].Tweens)
                {
                    if (item.TweenComponent == null) 
                        continue;
                    if(item.TweenComponent is IPingPong)
                    {
                        ((IPingPong)item.TweenComponent).PingPong = false;
                    }
                    item.TweenComponent._OnTweenFinish.AddListener(__finish);
                    item.TweenComponent.BeginPlay();
                    _play_counter++;
                }
                if (_play_counter == 0)
                    this.finish();
            }


        }

        private void finish()
        {
            if (m_Index >= this._Sequences.Count)
                return;

            //Debug.Log("finish尝试等待并继续执行下一队列，index:" + m_Index);

            //等待并继续开始
            Observable
                .NextFrame()
                .Delay(TimeSpan.FromSeconds(_Sequences[m_Index].DelayAfter))
                .Subscribe(_ =>
                {
                    if (!m_PlayFlag) 
                        return;
                    m_Index++;
                    if(m_Index >= _Sequences.Count)
                    {
                        //Debug.Log("到此，队列结束", this);

                        //整个序列全结束了
                        m_PlayFlag = false;
                        this.Finish();
                        m_Index = 0;
                        return;
                    }

                    doPlay();
                });
        }


        private float _GetMaxDurationTime(SeqItem item)
        {
            if (item.Tweens == null || item.Tweens.Length == 0)
                return 0;
            float max = 0;
            foreach (var i in item.Tweens)
            {
                if (i.TweenComponent == null)
                    continue;
                var _d = i.TweenComponent.Duration;
                if (_d > max)
                    max = _d;
            }
            return max;
        }
    }

}
