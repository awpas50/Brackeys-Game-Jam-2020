using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public bool up;
    public float force;
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Box")
        {
            if (up)
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.up * force;
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.down * force;
            }
            
        }
    }
}
