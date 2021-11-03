using System;
using System.Collections;
using System.Collections.Generic;
using BowMan.Behaviors;
using UnityEngine;
using UnityEngine.UI;

namespace BowMan.Views
{
    public class LaunchForceView : MonoBehaviour
    {
        [SerializeField] Slider _forceSlider;

        void Start()
        {
            _forceSlider.minValue = LaunchForceBehavior.MinForce;
            _forceSlider.maxValue = LaunchForceBehavior.MaxForce;
            _forceSlider.value = LaunchForceBehavior.CurForce;
        }

        void LateUpdate()
        {
            _forceSlider.value = LaunchForceBehavior.CurForce;
        }
    }   
}
