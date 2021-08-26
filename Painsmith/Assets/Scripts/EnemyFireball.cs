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
    Vector3 startSpeed;

    void Start()
    {
        player = GameObject.Find("Player");
        target = GetTarget();
        startSpeed = target - transform.position;
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

        float normSpeed = startSpeed.magnitude / speed;

        transform.Translate(Vector3.forward * normSpeed * Time.deltaTime);
    }

    Vector3 GetTarget()
    {
        float offsetX = Random.Range(0, player.transform.position.x - spawnOffset);
        float offsetY = Random.Range(0, player.transform.position.y - spawnOffset);
        float offsetZ = Random.Range(0, player.transform.position.z - spawnOffset);

        Vector3 targetPos = GetRandomPos();

        while (CheckBound(targetPos))
        {
            targetPos = GetRandomPos();
        }

        Instantiate(targetPrefab, targetPos, targetPrefab.transform.rotation);

        return targetPos;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target") && other.transform.position == target)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        base.OnTriggerEnter(other);
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

        Vector3 newPos = new Vector3(randomX, spawnY, randomZ);

        return newPos;
    }

    bool CheckBound(Vector3 pos)
    {
        if (System.Math.Abs(pos.x) > 9 || System.Math.Abs(pos.z) > 9)
        {
            return true;
        }

        return false;
    }
}
