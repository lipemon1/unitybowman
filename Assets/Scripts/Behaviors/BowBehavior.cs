using UnityEngine;

namespace BowMan.Behaviors
{
    public class BowBehavior : MonoBehaviour
    {
        [SerializeField] Transform _bowPivotTransform;
        [SerializeField] float _projectileForce;

        Vector2 _direction;

        //cached values
        Vector2 _bowPosition;
        Vector2 _mousePosition;
        Camera _camera;

        void Awake()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            UpdateBowDirection();
        }

        void UpdateBowDirection()
        {
            _bowPosition = _bowPivotTransform.position;
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _direction = _mousePosition - _bowPosition;

            _bowPivotTransform.right = _direction;
        }

        public float GetProjectileForce()
        {
            return _projectileForce;
        }

        public Vector2 GetBowDirection()
        {
            return _direction;
        }

        public Vector2 GetNewProjectileVelocity()
        {
            return _bowPivotTransform.right * _projectileForce;
        }
    }
}
