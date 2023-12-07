using System;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace hazethedev.GameManagement
{
    [CreateAssetMenu(fileName = "Game Preferences", menuName = "Common/Game Preferences")]
    public class GamePreferenceApplier : ScriptableObject
    {
        [ValueDropdown(nameof(CultureInfoList))]
        public string CultureInfo;
        public bool UseMultiTouch;
        public bool UseTargetFrameRate;
        [ShowIf(nameof(UseTargetFrameRate))]
        [Range(30, 500)]
        public int TargetFrameRate;

        [Space(5)]
        [Header("DOTween Settings")]
        public DOTweenPreferences TweenPreferences;

        private static IEnumerable CultureInfoList = new ValueDropdownList<string>()
        {
            {"En", "en-US"},
        };

        internal void ApplyOnEnter(GameManager manager)
        {
            if (UseTargetFrameRate) Application.targetFrameRate = TargetFrameRate;
            
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(CultureInfo);
            
            DOTween.useSafeMode = TweenPreferences.UseSafeMode;
            DOTween.SetTweensCapacity(TweenPreferences.TweenerCapacity, TweenPreferences.SequenceCapacity);
            
            Input.multiTouchEnabled = UseMultiTouch;
        }

        internal void ApplyOnExit(GameManager manager)
        {
            DOTween.KillAll();
        }
    }

    [Serializable]
    public struct DOTweenPreferences
    {
        public int TweenerCapacity;
        public int SequenceCapacity;
        public bool UseSafeMode;
    }
}