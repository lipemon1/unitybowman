using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowMan.Behaviors
{
    public class DirectionInputBehavior : MonoBehaviour
    {
        [SerializeField] Transform _bowPivotTransform;
        [SerializeField] bool _isMovingJoystick;
        [SerializeField] bool _isMovingMouse;

        //cached values
        Vector2 _bowPosition;
        Vector2 _mousePosition;
        Vector2 _inputPosition;
        Camera _camera;

        float _horizontalInput;
        float _verticalInput;

        Vector3 _lastMousePosition;
    
        void Awake()
        {
            _camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");   
            
            Vector3 newMousePosition = Input.mousePosition;

            _isMovingJoystick = IsMovingJoystick();
            _isMovingMouse = IsMouseMoving(newMousePosition);

            if (IsMovingJoystick())
                CalculateJoystickDirection();
            
            if(IsMouseMoving(newMousePosition))
                CalculateMouseDirection();

            _lastMousePosition = newMousePosition;
        }

        bool IsMovingJoystick()
        {
            return _horizontalInput != 0f || _verticalInput != 0 && Input.GetKey(KeyCode.W);
        }

        bool IsMouseMoving(Vector3 newMousePosition)
        {
            return newMousePosition != _lastMousePosition;
        }

        void CalculateJoystickDirection()
        {
            _bowPosition = _bowPivotTransform.localPosition;
            _inputPosition = new Vector2(_horizontalInput, _verticalInput);
            
            _bowPivotTransform.right = _inputPosition - _bowPosition;;
        }
        
        void CalculateMouseDirection()
        {
            _bowPosition = _bowPivotTransform.position;
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            _bowPivotTransform.right = _mousePosition - _bowPosition;;
        }
        
        public Vector2 GetDirection()
        {
            return _bowPivotTransform.right;
        }
    }   
}
