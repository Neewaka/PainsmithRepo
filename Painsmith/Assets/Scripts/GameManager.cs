using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float BallBound = 8;
    float spikeBound = 9;
    [SerializeField] GameObject SpikePrefab;
    [SerializeField] GameObject SpikedBallPrefab;
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject restartButton;
    Vector3 spikePos;
    Vector3 fireballSpawn = new Vector3(0, 18, 14);
    float ballY = 15f;
    float spikeY = 6.01f;
    int side = 1;
    [SerializeField] float spikeSpawnRate = 8;
    

    void Start()
    {
        Time.timeScale = 1;
        InvokeRepeating("SpawnSpikes", 2, spikeSpawnRate);
        InvokeRepeating("SpawnFireballs", 2, 4);
        SpawnBalls();
    }

    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
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
        yield return new WaitForSeconds(1);
        CreateLineOfSpikes(spikeZ, freeSpace);
    }

    public void SpawnBalls()
    {
        for (int i = 8; i > -9; i -= 4)
        {
            Vector3 BallPos = new Vector3(BallBound * side, ballY, i);
            Instantiate(SpikedBallPrefab, BallPos, SpikedBallPrefab.transform.rotation);
        }

        side *= -1;
    }

    void SpawnFireballs()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(fireballPrefab, fireballSpawn, fireballPrefab.transform.rotation);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
    }
}
