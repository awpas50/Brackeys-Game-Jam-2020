using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject[] whatToTrigger;
    public bool repeatable;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            if(repeatable)
            {
                for (int i = 0; i < whatToTrigger.Length; i++)
                {
                    whatToTrigger[i].SetActive(true);
                }
                AudioManager.instance.Play(SoundList.KeyUnlock);
                Destroy(other.gameObject);
            }
            else if(!repeatable)
            {
                for (int i = 0; i < whatToTrigger.Length; i++)
                {
                    whatToTrigger[i].SetActive(true);
                }
                Destroy(other.gameObject);
                AudioManager.instance.Play(SoundList.KeyUnlock);
                Destroy(gameObject, 0.2f);
            }
            
        }
    }
}
