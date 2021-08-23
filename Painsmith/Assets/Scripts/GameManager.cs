using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float BallBound = 8;
    float spikeBound = 9;
    [SerializeField] GameObject SpikePrefab;
    [SerializeField] GameObject SpikedBallPrefab;
    public bool canSpawnBalls = true;
    Vector3 spikePos;
    float ballY = 15f;
    float spikeY = 6.01f;
    int side = 1;
    [SerializeField] float spikeSpawnRate = 12;

    void Start()
    {
        InvokeRepeating("SpawnSpikes", 2, spikeSpawnRate);
        SpawnBalls();
    }

    void Update()
    {
        if (canSpawnBalls)
        {
            SpawnBalls();
        }
    }

    public void SpawnSpikes()
    {
        int freeSpace = Random.Range(0, 10);
        float spikeZ = spikeBound;
        StartCoroutine(SpikeEnum(spikeZ, freeSpace));
    }

    void CreateLineOfSpikes(float SpikeZ, float freeSpace)
    {
        if (SpikeZ > -10)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != freeSpace)
                {
                    spikePos = new Vector3(spikeBound - i * 2, spikeY, SpikeZ);
                    Instantiate(SpikePrefab, spikePos, SpikePrefab.transform.rotation);
                }
            }
            StartCoroutine(SpikeEnum(SpikeZ - 2, freeSpace));
        }    
    }

    IEnumerator SpikeEnum(float spikeZ, float freeSpace)
    {
        yield return new WaitForSeconds(2);
        CreateLineOfSpikes(spikeZ, freeSpace);
    }

    public void SpawnBalls()
    {
        for (int i = 8; i > -9; i -= 4)
        {
            Vector3 BallPos = new Vector3(BallBound * side, ballY, i);
            Instantiate(SpikedBallPrefab, BallPos, SpikedBallPrefab.transform.rotation);
        }
        canSpawnBalls = false;
        side *= -1;
    }

    public void BallCanBeSpawned()
    {
        if (canSpawnBalls)
        {
            SpawnBalls();
        }
    }
}
