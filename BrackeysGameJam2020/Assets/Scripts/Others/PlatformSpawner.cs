using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public Vector3 position;

    public float spawnTimer = 1f;
    public float duration = 10f;
    public float nextSpawn = 0f;

    GameManager gameManager;

    void Start()
    {
        //StartCoroutine(SpawnPlatform());
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameManager.redImage.fillAmount <= 0 || gameManager.redImage.fillAmount >= 1)
        {
            nextSpawn += 0;
        } else
        {
            nextSpawn += Time.deltaTime;
        }
        
        if(nextSpawn > spawnTimer)
        {
            GameObject platformObj = Instantiate(platform, position, Quaternion.identity);
            Destroy(platformObj, duration);
            nextSpawn = 0f;
        }
    }
}
