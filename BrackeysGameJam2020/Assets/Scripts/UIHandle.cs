using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandle : MonoBehaviour
{
    Player player;
    DarkLightMode DarkLightMode;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        DarkLightMode = FindObjectOfType<DarkLightMode>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!player.debugMode)
        {
            if (other.gameObject.tag == "NormalJumpTrigger")
            {
                if(DarkLightMode != null)
                {
                    DarkLightMode.darkLightMode = !DarkLightMode.darkLightMode;

                    DarkLightMode.loopValue++;
                    if (DarkLightMode.loopValue > DarkLightMode.endPointList.Length - 1)
                    {
                        DarkLightMode.loopValue = 0;
                    }
                }
                
                player.fJumpPressedRemember = player.fJumpPressedRememberTime;
                player.fTrigger = true;
                if (player.fJumpPressedRemember > 0 && player.fGroundedRemember > 0 && player.canJump)
                {
                    player.fJumpPressedRemember = 0;
                    player.fGroundedRemember = 0;
                    player.Jump();
                }

                //color
                other.gameObject.GetComponent<Image>().color = Color.grey;
            }
            //if (other.gameObject.tag == "SmallJumpTrigger")
            //{
            //    if (DarkLightMode != null)
            //    {
            //        DarkLightMode.darkLightMode = !DarkLightMode.darkLightMode;

            //        DarkLightMode.loopValue++;
            //        if (DarkLightMode.loopValue > DarkLightMode.endPointList.Length - 1)
            //        {
            //            DarkLightMode.loopValue = 0;
            //        }
            //    }

            //    player.fJumpPressedRemember = player.fJumpPressedRememberTime;
            //    player.fTrigger = true;
            //    if (player.fJumpPressedRemember > 0 && player.fGroundedRemember > 0 && player.canJump)
            //    {
            //        player.fJumpPressedRemember = 0;
            //        player.fGroundedRemember = 0;
            //        player.SmallJump();
            //    }
            //}
        }
    }
}
