using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowMan.Behaviors
{
    public class LaunchForceBehavior : MonoBehaviour
    {
        public static float CurForce = 0f;
        public static float MinForce;
        public static float MaxForce;
        
        [SerializeField] float _curForce; 

        [SerializeField] float _forceMult;
        
        [Header("Constraints")]
        [SerializeField] float _minForce;
        [SerializeField] float _maxForce;

        [Header("Inputs")] 
        [SerializeField] string _inscreasingInputName;
        [SerializeField] string _decreasingInputName;
        
        //cached values
        bool _increasingForce;
        bool _decreasingForce;

        void Awake()
        {
            MinForce = _minForce;
            MaxForce = _maxForce;
        }

        // Update is called once per frame
        void Update()
        {
            _increasingForce = Input.GetButton(_inscreasingInputName);
            _decreasingForce = Input.GetButton(_decreasingInputName);
            
            if(_increasingForce || _decreasingForce)
                UpdateForce();
        }

        void UpdateForce()
        {
            float forceDirection = _increasingForce ? 1f : -1f;

            _curForce = CurForce + forceDirection * _forceMult * Time.deltaTime;

            if (_curForce < _minForce)
                _curForce = _minForce;
            else if (_curForce > _maxForce)
                _curForce = _maxForce;

            CurForce = _curForce;
        }
    }   
}
