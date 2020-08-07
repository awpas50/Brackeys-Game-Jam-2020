using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    GameManager gameManager;

    public bool reverseable = true;
    public bool upward = true;
    public bool right = false;
    public float speed;
    public float originalSpeed;

    public bool vertical;
    public bool horizontal;

    Rigidbody2D rb;

    private void Start()
    {
        originalSpeed = speed;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (gameManager.redImage.fillAmount <= 0 || gameManager.redImage.fillAmount >= 1)
        {
            speed = 0;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else if(gameManager.redImage.fillAmount > 0 && gameManager.redImage.fillAmount < 1)
        {
            if(vertical)
            {
                if (upward)
                {
                    speed = originalSpeed;
                    GetComponent<Rigidbody2D>().velocity = Vector3.up * speed;
                }
                else if (!upward)
                {
                    speed = originalSpeed;
                    GetComponent<Rigidbody2D>().velocity = Vector3.down * speed;
                }
            }
            if(horizontal)
            {
                if (right)
                {
                    speed = originalSpeed;
                    GetComponent<Rigidbody2D>().velocity = Vector3.right * speed;
                }
                if (!right)
                {
                    speed = originalSpeed;
                    GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;
                }
            }
            
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Floor" && reverseable)
        {
            if(vertical)
            {
                upward = !upward;
                speed *= -1;
            }
            if(horizontal)
            {
                right = !right;
                speed *= -1;
            }
            
        }
    }
}
