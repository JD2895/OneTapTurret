using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    public class PlayerController : MonoBehaviour
    {
        public TurretBaseBehaviour turretBase;
        public TurretBarrelBehaviour turrretBarrel;
        public GameObject basicProjectilePrefab;

        private bool readyToFire = false;

        // Shot charging
        [SerializeField]
        private float fireChargeReq = 0.5f;
        private float currentFireChargeLevel = 0f;
        [SerializeField]
        private float chargeSpeed = 0.01f;
        [SerializeField]
        private ChargeIndicatorSlider chargeUISlider;

        void Update()
        {
            // Update shot charge slider
            chargeUISlider.SetSliderValue((currentFireChargeLevel / fireChargeReq) * 100);

            // On click/tap
            if (Input.GetMouseButtonDown(0))
            {
                ChangeTurretTurnDirection(); 
                currentFireChargeLevel = 0f;
            }

            // While held
            if (Input.GetMouseButton(0))
            {
                if (currentFireChargeLevel < fireChargeReq)
                {
                    readyToFire = false;
                    currentFireChargeLevel += chargeSpeed;
                }
                else if (currentFireChargeLevel >= fireChargeReq)
                {
                    readyToFire = true;
                }
            }

            // When released
            if (Input.GetMouseButtonUp(0))
            {
                FireProectileFromBarrel();
                currentFireChargeLevel = 0f;
            }

            // Debugging
            if (Input.GetKeyDown(KeyCode.D))
            {
            }

        }

        public void ChangeTurretTurnDirection()
        {
            turretBase.ChangeTurnDirection();
        }

        public void FireProectileFromBarrel()
        {
            if (readyToFire)
            {
                turrretBarrel.FireProjectile(basicProjectilePrefab);
            }
        }

        //**** This should go into the update manager
        public void ReduceFireCooldown(float reduceBy)
        {
            fireChargeReq -= reduceBy;

            // Limit firing cooldown, also ensure that it never goes below 0
            if(fireChargeReq < 0.2f)
            {
                fireChargeReq = 0.2f;
            }
        }
    }
}
