using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    [RequireComponent(typeof(Rigidbody))]
    public class BasicProjectileBehaviour : MonoBehaviour
    {
        private Rigidbody rb;
        private Vector3 direction = Vector3.zero;

        [SerializeField]
        private float lifeTime = 0.5f;
        [SerializeField]
        private float speed = 0.4f;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();

            // Destroy this object after set amount of time
            Destroy(this.gameObject, lifeTime);
        }

        public void StartFire(Vector3 directionToFire)
        {
            // Rotate object to face the direction it will be fired in
            this.transform.rotation = Quaternion.LookRotation(directionToFire);

            // Fire the object
            StartCoroutine(Firing());
            
        }

        IEnumerator Firing()
        {
            while(true)
            {
                // Constantly move this object forward
                Vector3 nextPosition = this.transform.position;
                nextPosition += this.transform.forward * speed;
                rb.MovePosition(nextPosition);
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
