using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePlatform : MonoBehaviour
{
    public GameManager gameManager;
    public float speed;
    public float maxHeight;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (gameManager.redImage.fillAmount <= 0 || gameManager.redImage.fillAmount >= 1)
        {
            transform.position += Vector3.up * 0 * Time.deltaTime;
        }
        else
        {
            if (transform.position.y <= maxHeight)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }
    }
}
