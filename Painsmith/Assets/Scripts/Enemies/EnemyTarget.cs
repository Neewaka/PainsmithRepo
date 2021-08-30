using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : Enemy
// INHERITANCE
{
    Vector3 rotation;
    bool playerInRange = false;
    GameManager gameManager;

    protected override void OnTriggerEnter(Collider other)
    // POLYMORPHISM
    {
        if (other.gameObject.CompareTag("Player")){
            playerInRange = true;
        }

        if (other.gameObject.CompareTag("Fireball") && playerInRange)
        {
            base.TakeDamage(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (gameManager.isGameOn)
        {
            transform.Rotate(rotation * Time.deltaTime);
        }
    }

    private void Start()
    {
        rotation = new Vector3(0, 20, 0);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

}
