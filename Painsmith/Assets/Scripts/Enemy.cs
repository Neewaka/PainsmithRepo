using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            other.gameObject.transform.position.Set(other.gameObject.transform.position.x, 10, other.gameObject.transform.position.z);
            //gameObject.transform.Translate(Vector3.up * 2);
        }
        
    }
}
