using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    public class PlayerController : MonoBehaviour
    {
        public TurretBaseBehaviour turretBase;
        //public TurretBarrelBehaviour turrretBarrel;
        //public UpgradeManager upgradeManager;
        //public GameObject basicProjectilePrefab;

        private bool readyToFire = true;

        [SerializeField]
        private float fireCooldown = 0.5f;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeTurretTurnDirection();
            }

            if (Input.GetMouseButtonUp(0))
            {
                FireProectileFromBarrel();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
            }

            //upgradeManager.PlayerUpdate();
        }

        public void ChangeTurretTurnDirection()
        {
            turretBase.ChangeTurnDirection();
        }

        public void FireProectileFromBarrel()
        {
            if (readyToFire)
            {
                //turrretBarrel.FireProjectile(basicProjectilePrefab, turretBase.GetCurrentDirection());
                StartCoroutine(FireCooldown());
            }
        }

        IEnumerator FireCooldown()
        {
            readyToFire = false;
            yield return new WaitForSeconds(fireCooldown);
            readyToFire = true;
        }

        public void ReduceFireCooldown(float reduceBy)
        {
            fireCooldown -= reduceBy;

            // Limit firing cooldown, also ensure that it never goes below 0
            if(fireCooldown < 0.2f)
            {
                fireCooldown = 0.2f;
            }
        }
    }
}
