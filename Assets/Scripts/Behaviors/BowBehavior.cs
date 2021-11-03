using System;
using UnityEngine;

namespace BowMan.Behaviors
{
    [RequireComponent(typeof(DirectionInputBehavior))]
    public class BowBehavior : MonoBehaviour
    {
        [SerializeField] Transform _bowPivotTransform;
        [SerializeField] float _projectileForce;

        public float GetProjectileForce()
        {
            return _projectileForce;
        }

        public Vector2 GetNewProjectileVelocity()
        {
            return _bowPivotTransform.right * _projectileForce;
        }
    }
}
