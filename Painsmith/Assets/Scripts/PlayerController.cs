using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public float speed = 20;
    
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    
    void Update()
    {


        float horizontaInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        gameObject.transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        gameObject.transform.Translate(Vector3.right * horizontaInput * speed * Time.deltaTime);
        //playerRb.AddForce(Vector3.forward * verticalInput * speed);
        //playerRb.AddForce(Vector3.right * horizontaInput * speed);


    }
}
