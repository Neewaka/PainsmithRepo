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
            other.gameObject.transform.position.Set(other.gameObject.transform.position.x, 10, other.gameObject.transform.position.z);
            //gameObject.transform.Translate(Vector3.up * 2);
        }
        
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HitCol with" + gameObject.name);
        }
    }
}
