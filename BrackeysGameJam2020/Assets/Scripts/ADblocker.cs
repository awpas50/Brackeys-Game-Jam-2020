using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ADblocker : MonoBehaviour
{
    public GameObject ADBlocker;
    public bool triggered = false;
    public GameObject[] normalJumpTriggerList;
    public TextMeshProUGUI g1;
    public TextMeshProUGUI g2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !triggered)
        {
            ADBlocker.SetActive(true);
            triggered = true;
            g1.enabled = false;
        }
    }

    public void ADBlockerButtonEvent()
    {
        ADBlocker.SetActive(false);
        for(int i = 0; i < normalJumpTriggerList.Length; i++)
        {
            normalJumpTriggerList[i].SetActive(true);
            normalJumpTriggerList[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        g2.enabled = true;
    }
}
