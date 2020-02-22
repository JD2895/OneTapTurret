using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    [RequireComponent(typeof(Rigidbody))]
    public class TurretBaseBehaviour : MonoBehaviour
    {
        private bool turnDirection = false;    // 0 = turn left, 1 = turn right
        private Rigidbody rb;
        [SerializeField]
        private float turnRate = 1.5f;

        public bool TurnDirection { get { return turnDirection; } }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (turnDirection)
            {
                rb.rotation *= Quaternion.Euler(Vector3.up * turnRate);
            }
            else
            {
                rb.rotation *= Quaternion.Euler(Vector3.up * -turnRate);
            }
        }

        public bool ChangeTurnDirection()
        {
            turnDirection = !turnDirection;
            return turnDirection;
        }

        public float GetCurrentDirection()
        {
            return this.transform.eulerAngles.y;
        }
    }
}
