using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitZLeft = -181;
    private float spawnLimitZRight = -30;
    private float spawnPosX = 156;

    private float startDelay = 1.0f;
    private float spawnInterval = 2.0f;

    private int ballIndex;
    private int randomTime;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(3, 5);
        InvokeRepeating("SpawnRandomBall", startDelay, randomTime);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        ballIndex = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(spawnPosX,-13,Random.Range(spawnLimitZLeft, spawnLimitZRight));

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

    }

}