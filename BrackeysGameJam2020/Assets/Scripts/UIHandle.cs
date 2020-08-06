using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandle : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!player.debugMode)
        {
            if (other.gameObject.tag == "NormalJumpTrigger")
            {
                player.fJumpPressedRemember = player.fJumpPressedRememberTime;
                player.fTrigger = true;
                if (player.canJump)
                {
                    player.Jump();
                }
            }
            if (other.gameObject.tag == "SmallJumpTrigger")
            {
                player.fJumpPressedRemember = player.fJumpPressedRememberTime;
                player.fTrigger = true;
                if (player.canJump)
                {
                    player.SmallJump();
                }
            }
        }
    }
}
