using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject[] endPointList;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            for (int i = 0; i < endPointList.Length; i++)
            {
                endPointList[i].SetActive(true);
            }
            Destroy(other.gameObject);
        }
    }
}
