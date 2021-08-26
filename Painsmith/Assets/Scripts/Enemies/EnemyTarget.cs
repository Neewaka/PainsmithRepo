using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : Enemy
{

    bool playerInRange = false;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            playerInRange = true;
        }

        if (other.gameObject.CompareTag("Fireball") && playerInRange)
        {
            Debug.Log("Fireball hit");
            base.TakeDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
