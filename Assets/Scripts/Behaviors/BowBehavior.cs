using System;
using UnityEngine;

namespace BowMan.Behaviors
{
    [RequireComponent(typeof(DirectionInputBehavior))]
    public class BowBehavior : MonoBehaviour
    {
        [SerializeField] Transform _bowPivotTransform;

        public Vector2 GetNewProjectileVelocity()
        {
            return _bowPivotTransform.right * LaunchForceBehavior.CurForce;
        }
    }
}
