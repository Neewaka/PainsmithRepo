using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float BallPlatformBound = 8;
    float spikeBound = 9;
    [SerializeField] GameObject SpikePrefab;
    Vector3 spikePos;
    float spikeY = 6.01f;
    [SerializeField] float spikeSpawnRate = 12;

    void Start()
    {
        InvokeRepeating("SpawnSpikes", 2, spikeSpawnRate);
    }

    void Update()
    {
  
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
}
