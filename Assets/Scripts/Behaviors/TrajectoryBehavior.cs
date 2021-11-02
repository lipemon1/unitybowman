using System;
using System.Collections.Generic;
using UnityEngine;

namespace BowMan.Behaviors
{
    [RequireComponent(typeof(BowBehavior))]
    [RequireComponent(typeof(ShootBehavior))]
    public class TrajectoryBehavior : MonoBehaviour
    {
        [SerializeField] int _numberOfPointsToShow;
        [SerializeField] float _spaceBetweenPoints;
        [SerializeField] GameObject _trajectoryPoint;
        GameObject[] _trajectoryPoints;

        BowBehavior _bowBehavior;
        ShootBehavior _shootBehavior;

        void Awake()
        {
            _bowBehavior = GetComponent<BowBehavior>();
            _shootBehavior = GetComponent<ShootBehavior>();
        }

        void Start()
        {
            _trajectoryPoints = new GameObject[_numberOfPointsToShow];

            for (int i = 0; i < _numberOfPointsToShow; i++)
            {
                _trajectoryPoints[i] = Instantiate(_trajectoryPoint, _shootBehavior.GetPositionToLaunchProjectile(), Quaternion.identity);
            }
        }
        
        void Update()
        {
            CalculateTrajectory(_trajectoryPoints, _spaceBetweenPoints, _shootBehavior.GetPositionToLaunchProjectile(), _bowBehavior.GetBowDirection(), _bowBehavior.GetProjectileForce());
        }

        static void CalculateTrajectory(IReadOnlyList<GameObject> trajectoryPoints, float spaceBetweenPoints, Vector3 emitPoint, Vector3 direction, float curForce)
        {
            for (int i = 0; i < trajectoryPoints.Count; i++)
            {
                trajectoryPoints[i].transform.position = CalculatePointPosition(i * spaceBetweenPoints, emitPoint, direction, curForce);
            }
        }

        static Vector2 CalculatePointPosition(float t, Vector3 startPoint, Vector2 direction, float currentLaunchForce)
        {
            Vector2 position = (Vector2) startPoint + (direction.normalized * currentLaunchForce * t) +
                               0.5f * Physics2D.gravity * (t * t);
            return position;
        }
    }   
}
