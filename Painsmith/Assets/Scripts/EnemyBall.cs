using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : Enemy
{
    Rigidbody ballRb;
    [SerializeField] float speed = 0.5f;
    [SerializeField] bool isGrounded = false;
    GameManager gameManager;
    int side;
    bool isSpawned = false;
    Vector3 direction;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (transform.position.x == 8)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 9.5 || transform.position.x < -9.5f)
        {
            StartCoroutine(Demolish());
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded && transform.position.x < 9 && transform.position.x > -9)
        {
            ballRb.velocity = direction * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    IEnumerator Demolish()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        gameManager.canSpawnBalls = true;
    }
}
