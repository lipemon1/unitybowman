using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowMan.Behaviors
{
    public class ShootBehavior : MonoBehaviour
    {
        [SerializeField] GameObject _projectilePrefab;
        [SerializeField] Transform _pointToLaunchProjectile;
        [SerializeField] string _shootInputName;
        
        BowBehavior _bowBehavior;

        void Awake()
        {
            _bowBehavior = GetComponent<BowBehavior>();
        }
        
        void Update()
        {
            if (Input.GetButtonDown(_shootInputName))
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
