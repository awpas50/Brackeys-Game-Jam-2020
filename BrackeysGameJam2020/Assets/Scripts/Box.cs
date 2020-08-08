using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Vector3 originalPos;
    GameManager gameManager;
    Rigidbody2D rb;
    void Start()
    {
        originalPos = transform.position;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Boundary")
        {
            transform.position = originalPos;
        }
    }

    private void Update()
    {
        if (gameManager.redImage.fillAmount <= 0 || gameManager.redImage.fillAmount >= 1)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (gameManager.redImage.fillAmount > 0 && gameManager.redImage.fillAmount < 1)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
