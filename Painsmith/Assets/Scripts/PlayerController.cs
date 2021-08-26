using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public float speed = 20;
    GameManager gameManager;
    
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    
    void Update()
    { 
        float horizontaInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        gameObject.transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        gameObject.transform.Translate(Vector3.right * horizontaInput * speed * Time.deltaTime);

        if (HealthBarHandler.GetHealthBarValue() < 0.1f)
        {
            gameManager.GameOver();
        }
    }

    
}
