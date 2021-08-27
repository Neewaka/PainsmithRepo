using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public float speed = 20;
    float planeSpeed;
    GameManager gameManager;
    float mouseX;
    float mouseY;
    float rotationX = 0.0f;
    float rotationY = 0.0f;
    float clampAngle = 80.0f;
    [SerializeField] float sensitivity = 15.0f;

    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    { 
        float horizontaInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float sideSpeed = speed / 2;

        if (verticalInput < 0)
        {
            planeSpeed = speed / 2;
        }
        else
        {
            planeSpeed = speed;
        }

        gameObject.transform.Translate(Vector3.forward * verticalInput * planeSpeed * Time.deltaTime);
        gameObject.transform.Translate(Vector3.right * horizontaInput * sideSpeed * Time.deltaTime);

        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationY += mouseX * sensitivity * Time.deltaTime;
        rotationX += mouseY * sensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(-rotationX, rotationY, 0.0f);
        transform.rotation = localRotation;


        if (HealthBarHandler.GetHealthBarValue() < 0.1f)
        {
            gameManager.GameOver();
        }
    }

    
}
