using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseEnemyBehaviour : MonoBehaviour
    {
        protected SpawnManager spawnManager;
        protected Rigidbody2D _rb;
        protected Vector2 direction = Vector2.up;
        protected Vector3 targetPosition = new Vector3();

        [SerializeField]
        protected float speed = 0.1f;

        protected void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public virtual void InitializeEnemy(Vector3 _targetPos, SpawnManager _spawnMan)
        {
            targetPosition = _targetPos;
            spawnManager = _spawnMan;
        }

        public abstract void StartEnemyBehaviour();

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "PlayerProjectile")
            {
                DestoryThisEnemy();
                //Destroy(this.gameObject);
            }
        }

        public void DestoryThisEnemy()
        {
            spawnManager.RemoveEnemy(this.gameObject);
        }
    }
}