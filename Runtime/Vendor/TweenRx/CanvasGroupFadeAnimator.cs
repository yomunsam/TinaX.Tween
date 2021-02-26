﻿/*
 * 此处代码改写自TweenRx （https://github.com/fumobox/TweenRx）
 * The code here is rewritten from TweenRx
 */

using UnityEngine;
using System;
using UniRx;

namespace TinaX.Tween
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupFadeAnimator : MonoBehaviour
    {
        CanvasGroup _canvasGroup;

        Action _onComplete;

        [SerializeField]
        float _fadeInFromAlpha = 0;

        [SerializeField]
        float _fadeInToAlpha = 1;

        [SerializeField]
        float _fadeInTime = 1;

        [SerializeField]
        Tween.EaseType _fadeInEaseType = Tween.EaseType.EaseInCubic;

        [SerializeField]
        float _fadeOutFromAlpha = 1;

        [SerializeField]
        float _fadeOutToAlpha = 0;

        [SerializeField]
        float _fadeOutTime = 1;

        [SerializeField]
        Tween.EaseType _fadeOutEaseType = Tween.EaseType.EaseOutCubic;

        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public IObservable<float> FadeInAsObservable()
        {
            return Tween.Play(
                _fadeInFromAlpha,
                _fadeInToAlpha,
                _fadeInTime,
                _fadeInEaseType
            ).Do(a =>
                {
                    _canvasGroup.alpha = a;
                }
            );
        }

        public IObservable<float> FadeOutAsObservable()
        {
            return Tween.Play(
                _fadeOutFromAlpha,
                _fadeOutToAlpha,
                _fadeOutTime,
                _fadeOutEaseType
            ).Do(a =>
                {
                    _canvasGroup.alpha = a;
                }
            );
        }
    }
}
