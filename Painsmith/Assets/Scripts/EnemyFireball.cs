using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : Enemy
{

    [SerializeField] float speed = 5;
    GameObject player;
    Vector3 target;
    [SerializeField] GameObject targetPrefab;
    float spawnOffset = 6;
    float spawnY = 6.552089f;

    void Start()
    {
        player = GameObject.Find("Player");
        target = GetTarget();

    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget(target);
    }

    void MoveToTarget(Vector3 target)
    {
        Vector3 relPos = target - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relPos, Vector3.down);

        transform.rotation = rotation;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    Vector3 GetTarget()
    {
        float offsetX = Random.Range(0, player.transform.position.x - spawnOffset);
        float offsetY = Random.Range(0, player.transform.position.y - spawnOffset);
        float offsetZ = Random.Range(0, player.transform.position.z - spawnOffset);

        Vector3 targetPos = GetRandomPos();

        Instantiate(targetPrefab, targetPos, targetPrefab.transform.rotation);

        return targetPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target") && other.transform.position == target)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    Vector3 GetRandomPos()
    {
        Vector3 pos = player.transform.position;

        float leftBoundX = pos.x - spawnOffset;
        float rightBoundX = pos.x + spawnOffset;

        float leftBoundZ = pos.z - spawnOffset;
        float rightBoundZ = pos.z + spawnOffset;

        float randomX = Random.Range(leftBoundX, rightBoundX);
        float randomZ = Random.Range(leftBoundZ, rightBoundZ);

        return new Vector3(randomX, spawnY, randomZ);
    }
}
