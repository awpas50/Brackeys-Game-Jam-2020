using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject[] whatToTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            for (int i = 0; i < whatToTrigger.Length; i++)
            {
                whatToTrigger[i].SetActive(true);
            }
            Destroy(other.gameObject);
            Destroy(gameObject, 0.2f);
        }
    }
}
