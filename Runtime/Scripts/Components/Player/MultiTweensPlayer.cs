using System.Linq;
using TinaX.Tween.Const;
using UnityEngine;

namespace TinaX.Tween.Components
{
    [AddComponentMenu(TweenConst.ComponentMenuRootPath + "Player/Multi Tweens Player")]
    public class MultiTweensPlayer : MonoBehaviour
    {
        [System.Serializable]
        public struct TweenInfo
        {
            public string Name;
            public TweenComponentBase Tween;
        }

        [Tooltip("Only one tween plays at a time \n 同一时间内只播放一个Tween")]
        public bool SingleTween = true;

        public bool StopAllOnDestory = true;

        public TweenInfo[] Tweens;


        public void BeginPlay(string name)
        {
            
            if (SingleTween && Tweens != null)
            {
                foreach(var item in this.Tweens)
                {
                    if (item.Tween.Playing)
                        item.Tween.Stop();
                }
            }

            if(this.TryGetTweenInfoByName(name,out var tweenInfo))
            {
                if (!tweenInfo.Value.Tween.Playing)
                {
                    tweenInfo.Value.Tween.BeginPlay();
                }
            }
        }


        public void StopIf(string name)
        {
            if(this.TryGetTweenInfoByName(name, out var tweenInfo))
            {
                if (tweenInfo.Value.Tween.Playing)
                {
                    tweenInfo.Value.Tween.Stop();
                }
            }
        }

        public void StopAll()
        {
            if (Tweens == null || Tweens.Length == 0)
                return;
            foreach(var item in Tweens)
            {
                if (item.Tween.Playing)
                    item.Tween.Stop();
            }
        }

        private void OnDestroy()
        {
            if (StopAllOnDestory)
                this.StopAll();
        }


        private bool TryGetTweenInfoByName(string name, out TweenInfo? result)
        {
            if (Tweens == null || Tweens.Length == 0)
            {
                Debug.LogError($"[Multi Tweens Player]{this.name} Not found tween by name: {name}");
                result = null;
                return false;
            }    
            var enumerable_tweens = Tweens.Where(info => info.Name.Equals(name));
            var tween_count = enumerable_tweens.Count();
            if (tween_count != 1)
            {
                if (tween_count < 1)
                {
                    Debug.LogError($"[Multi Tweens Player]{this.name} Not found tween by name: {name}");
                    result = null;
                    return false;
                }
                else
                {
                    Debug.LogError($"[Multi Tweens Player]There are multiple tweens with the same name: {name}");
                }
            }

            result = enumerable_tweens.First();
            return true;
        }

        private void RemovePlayListIf(string name)
        {
            
        }
    }
}
