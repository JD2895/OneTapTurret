using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.OTT
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerController playerController;

        [SerializeField]
        private float amountToReduceCooldown = 0.15f;

        private bool fireOnPress = false;

        public void PlayerUpdate()
        {
            if (fireOnPress && Input.GetMouseButtonDown(0))
            {
                playerController.FireProectileFromBarrel();
            }
        }

        public void ReduceCooldown()
        {
            playerController.ReduceFireCooldown(amountToReduceCooldown);
        }
    }
}
