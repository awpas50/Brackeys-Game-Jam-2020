using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollide : MonoBehaviour
{
    public Animator animator;
    public Color jumpKeyColor;
    Player player;
    public GameObject[] normalJumpTriggers;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        normalJumpTriggers = GameObject.FindGameObjectsWithTag("NormalJumpTrigger");
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

            //Animation
            animator.SetBool("JumpState", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            player.fGroundedRemember = player.fGroundedRememberTime;
            player.fGroundedTrigger = true;
            player.canJump = false;

            //Animation
            animator.SetBool("JumpState", true);
        }
    }
}
