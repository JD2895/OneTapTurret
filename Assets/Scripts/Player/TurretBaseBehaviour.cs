using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TurretBaseBehaviour : MonoBehaviour
    {
        private bool _turnDirection = false;    // 0 = turn left, 1 = turn right
        private Rigidbody2D _rb;
        [SerializeField]
        private float _turnRate = 3f;

        public bool TurnDirection { get { return _turnDirection; } }

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (_turnDirection)
            {
                _rb.rotation += _turnRate;
            }
            else
            {
                _rb.rotation -= _turnRate;
            }
        }

        public bool ChangeTurnDirection()
        {
            _turnDirection = !_turnDirection;
            return _turnDirection;
        }

        public float GetCurrentDirection()
        {
            return this.transform.eulerAngles.z;
        }
    }
}
