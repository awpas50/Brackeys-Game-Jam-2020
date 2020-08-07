using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.gameObject.tag == "Floor")
    //    {
    //        player.canJump = true;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "KeyBG")
        {
            player.canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "KeyBG")
        {
            player.fGroundedRemember = player.fGroundedRememberTime;
            player.fGroundedTrigger = true;
            
            player.canJump = false;
        }
    }
}
