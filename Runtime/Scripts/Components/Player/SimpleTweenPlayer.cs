using TinaX.Tween.Const;
using UnityEngine;

namespace TinaX.Tween.Components
{
    [AddComponentMenu(TweenConst.ComponentMenuRootPath + "Player/Simple Tween Player")]
    public class SimpleTweenPlayer : MonoBehaviour
    {
        public TweenComponentBase Tween;

        public void BeginPlay()
        {
            if (!Tween.Playing)
            {
                Tween.BeginPlay();
            }
        }

        public void Stop()
        {
            if (Tween.Playing)
            {
                Tween.Stop();
            }
        }
    }
}
