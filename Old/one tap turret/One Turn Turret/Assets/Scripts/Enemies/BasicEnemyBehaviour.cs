using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BasicEnemyBehaviour : BaseEnemyBehaviour
    {
        [SerializeField]
        new private float speed = 0.2f;

        public override void StartEnemyBehaviour()
        {
            Vector3 directionToTarget = targetPosition - this.transform.position;
            StartCoroutine(MoveToTarget(directionToTarget.normalized));
        }

        IEnumerator MoveToTarget(Vector3 direction)
        {
            while (true)
            {
                Vector3 nextPosition = this.transform.position;
                nextPosition.x += direction.x * speed;
                nextPosition.y += direction.y * speed;
                _rb.MovePosition(nextPosition);
                yield return null;
            }
        }
    }
}
