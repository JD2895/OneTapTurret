using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BasicProjectileBehaviour : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Vector2 direction = Vector2.up;

        [SerializeField]
        private float lifeTime = 0.1f;
        [SerializeField]
        private float speed = 0.2f;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            Destroy(this.gameObject, lifeTime);
        }

        public void StartFire(Vector2 directionToFire)
        {
            direction = directionToFire;
            StartCoroutine(Firing());
            
        }

        IEnumerator Firing()
        {
            while(true)
            {
                Vector3 nextPosition = this.transform.position;
                nextPosition.x += direction.x * speed;
                nextPosition.y += direction.y * speed;
                _rb.MovePosition(nextPosition);
                yield return null;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Enemy")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
