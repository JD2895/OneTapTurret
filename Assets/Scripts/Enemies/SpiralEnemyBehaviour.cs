using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpiralEnemyBehaviour : BaseEnemyBehaviour
    {
        private float largestDistanceToTarget;

        [SerializeField]
        new private float speed = 0.1f;

        [SerializeField]
        private float startingAot = 80f;    //angle of attack

        public override void StartEnemyBehaviour()
        {
            largestDistanceToTarget = Vector3.Magnitude(this.transform.position - targetPosition);
            StartCoroutine(MoveToTarget());
        }

        IEnumerator MoveToTarget()
        {
            while (true)
            {
                float currentDistanceToTarget = Vector3.Magnitude(this.transform.position - targetPosition);

                // Get direction to move in
                direction = targetPosition - this.transform.position;
                float aot = Mathf.Exp(0.2f * (currentDistanceToTarget / largestDistanceToTarget) - 0.201f) * startingAot;
                direction = Quaternion.AngleAxis(aot, Vector3.forward) * direction;
                direction = Vector3.Normalize(direction);

                // Move to new positon based on direciton
                Vector3 nextPosition = this.transform.position;
                nextPosition.x += direction.x * speed;
                nextPosition.y += direction.y * speed;
                _rb.MovePosition(nextPosition);
                yield return null;
            }
        }
    }
}
