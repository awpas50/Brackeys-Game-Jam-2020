using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10BoxSpawn : MonoBehaviour
{
    //public GameObject platformSpawner;
    //public Vector3 position;
    public GameObject box;
    public Vector3 boxPosition;
    public bool part2Triggered = false;

    public GameObject[] platformList;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            //Instantiate(platformSpawner, position, Quaternion.identity);
            Instantiate(box, boxPosition, Quaternion.identity);
            part2Triggered = true;
        }
    }

    private void Update()
    {
        for(int i = 0; i < platformList.Length; i++)
        {
            if (part2Triggered && platformList[i].transform.position.x >= 7.3f)
            {
                platformList[i].GetComponent<Platform>().reverseable = false;
                platformList[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
}
