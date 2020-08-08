using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollide : MonoBehaviour
{
    public Color jumpKeyColor;
    Player player;
    public GameObject[] normalJumpTriggers;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        
        normalJumpTriggers = GameObject.FindGameObjectsWithTag("NormalJumpTrigger");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.gameObject.tag == "Floor")
    //    {
    //        player.canJump = true;
    //    }
    //}
    private void Update()
    {
        //ColorUtility.TryParseHtmlString("FFAC00", out jumpKeyColor);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            for (int i = 0; i < normalJumpTriggers.Length; i++)
            {
                normalJumpTriggers[i].GetComponent<Image>().color = jumpKeyColor;
            }
            player.canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            player.fGroundedRemember = player.fGroundedRememberTime;
            player.fGroundedTrigger = true;
            
            player.canJump = false;
        }
    }
}
