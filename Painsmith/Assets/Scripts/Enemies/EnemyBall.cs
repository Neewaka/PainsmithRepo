using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : Enemy
// INHERITANCE
{
    Rigidbody ballRb;
    [SerializeField] float speed = 0.5f;
    [SerializeField] bool isGrounded = false;
    GameManager gameManager;
    int side;
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
        if (transform.position.x > 10 || transform.position.x < -10)
        {
            StartCoroutine(Demolish());
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded && transform.position.x < 9 && transform.position.x > -9)
        {
            ballRb.velocity = speed * (ballRb.velocity.normalized);
            ballRb.AddForce(direction * speed * Time.deltaTime);
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    // POLYMORPHISM
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }

        base.OnCollisionEnter(collision);
    }

    protected override void OnTriggerEnter(Collider other)
    // POLYMORPHISM
    {
        if (other.gameObject.CompareTag("Target") &&
            gameObject.transform.position.x == other.transform.position.x &&
            gameObject.transform.position.z == other.transform.position.z)
        {
            Destroy(other.gameObject);
        }

        base.OnTriggerEnter(other);
    }

    IEnumerator Demolish()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
