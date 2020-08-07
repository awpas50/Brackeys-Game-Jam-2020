using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10BoxSpawn : MonoBehaviour
{
    public GameObject platformSpawner;
    public Vector3 position;
    public GameObject box;
    public Vector3 boxPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            Instantiate(platformSpawner, position, Quaternion.identity);
            Instantiate(box, boxPosition, Quaternion.identity);
        }
    }
}
