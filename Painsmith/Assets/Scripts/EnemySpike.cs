using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : Enemy
{
    Vector3 nextPosition;
    bool move = false;
    [SerializeField] float speed = 0.1f;
    bool active = false;
    bool canBeDestroyed = false;
    float spikeDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement("up"));
    }

    // Update is called once per frame
    void Update()
    {
        Move(nextPosition);

        if (active)
        {
            StartCoroutine(Movement("down"));
            active = false;
            canBeDestroyed = true;
        }
    }

    IEnumerator Movement(string direction)
    {
        yield return new WaitForSeconds(spikeDelay);
        nextPosition = DirectionMove(direction);
        move = true;
    }

    void Move(Vector3 direction)
    {
        if (Vector3.Distance(transform.position, nextPosition) < 0.02 && move)
        {
            move = false;
            active = true;
            if (canBeDestroyed)
            {
                Destroy(gameObject);
            }
        }
        else if (move)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, speed);
        }
    }

    Vector3 DirectionMove(string direction)
    {
        if (direction == "up")
        {
            return nextPosition = transform.position + Vector3.up;
            
        }
        else
        {
            return nextPosition = transform.position + Vector3.down;
        }
    }
}
