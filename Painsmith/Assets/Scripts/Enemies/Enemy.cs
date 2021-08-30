using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TakeDamage(3);
        }
        
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(3);
        }
    }

    protected void TakeDamage(int damage)
    {
        float currentHP = HealthBarHandler.GetHealthBarValue();
        HealthBarHandler.SetHealthBarValue(currentHP - 0.333f * damage);
    }
}
