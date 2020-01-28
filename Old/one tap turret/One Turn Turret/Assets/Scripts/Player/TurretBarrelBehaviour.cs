using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JD.Utils;

namespace JD.OTT
{
    public class TurretBarrelBehaviour : MonoBehaviour
    {
        public void FireProjectile(GameObject projectilePrefab, float direction)
        {
            Vector3 initialPosition = Vector3.zero;
            Vector2 directionToFire = SpecMath.GetXYComponents(direction % 360);

            // Move the initial position to a barrel's length away
            initialPosition.x = directionToFire.x * this.transform.localScale.y;
            initialPosition.y = directionToFire.y * this.transform.localScale.y;
            
            // Always instantiate slightly behind the barrel
            initialPosition.z = this.transform.position.z + 0.1f;
            
            GameObject newProjectile = Instantiate(projectilePrefab, initialPosition, Quaternion.identity);
            newProjectile.GetComponent<BasicProjectileBehaviour>().StartFire(directionToFire);
        }
    }
}
