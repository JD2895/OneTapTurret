using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JD.Utils;

namespace JD.OTT
{
    public class TurretBarrelBehaviour : MonoBehaviour
    {
        public void FireProjectile(GameObject projectilePrefab)
        {
            Vector3 initialPosition = this.transform.position;
            Vector3 directionToFire = this.transform.up;

            // Move the initial position to a barrel's length away
            initialPosition += directionToFire * this.transform.localScale.y;

            // Instantiate the projectile
            GameObject newProjectile = Instantiate(projectilePrefab, initialPosition, Quaternion.identity);

            // Fire the projectile
            newProjectile.GetComponent<BasicProjectileBehaviour>().StartFire(directionToFire);
        }
    }
}
