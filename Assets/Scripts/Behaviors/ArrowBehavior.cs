using UnityEngine;

namespace BowMan.Behaviors
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ArrowBehavior : MonoBehaviour
    {
        Rigidbody2D _rb;
        bool _hasHit;
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        void Update()
        {
            float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            _hasHit = true;
            _rb.velocity = Vector2.zero;
            _rb.isKinematic = true;
        }
    }   
}
