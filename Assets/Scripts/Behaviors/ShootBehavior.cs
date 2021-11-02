using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowMan.Behaviors
{
    [RequireComponent(typeof(BowBehavior))]
    public class ShootBehavior : MonoBehaviour
    {
        [SerializeField] GameObject _projectilePrefab;
        [SerializeField] Transform _pointToLaunchProjectile;

        BowBehavior _bowBehavior;

        void Awake()
        {
            _bowBehavior = GetComponent<BowBehavior>();
        }
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Shoot();
        }
        
        void Shoot()
        {
            GameObject newArrow = Instantiate(_projectilePrefab, _pointToLaunchProjectile.position, _pointToLaunchProjectile.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = _bowBehavior.GetNewProjectileVelocity(); 
        }

        public Vector3 GetPositionToLaunchProjectile()
        {
            return _pointToLaunchProjectile.position;
        }
    }   
}
