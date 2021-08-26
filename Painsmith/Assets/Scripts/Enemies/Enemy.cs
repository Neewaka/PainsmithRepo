using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit with " + gameObject.name);
            TakeDamage();
        }
        
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HitCol with" + gameObject.name);
            TakeDamage();
        }
    }

    protected void TakeDamage()
    {
        float currentHP = HealthBarHandler.GetHealthBarValue();
        HealthBarHandler.SetHealthBarValue(currentHP - 0.333f);
    }
}
