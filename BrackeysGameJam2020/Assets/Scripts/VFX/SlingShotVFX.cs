using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotVFX : MonoBehaviour
{
    public GameObject spriteGO;
    public Sprite sprite_white;
    public Sprite sprite_blue;
    
    private float timer = 0f;
    Vector3 originalPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            int seed = Random.Range(0, 2);
            if(seed == 0)
            {
                AudioManager.instance.Play(SoundList.Impact1);
            }
            else if(seed == 1)
            {
                AudioManager.instance.Play(SoundList.Impact2);
            }
            timer = 0.3f;
        }
    }

    private void Start()
    {
        //DEBUG
        originalPos = transform.position;
        timer = 0f;
        spriteGO.GetComponent<SpriteRenderer>().sprite = sprite_white;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0f)
        {
            Vector3 newPos = Random.insideUnitCircle * (Time.deltaTime * 5);
            transform.position = originalPos + newPos;
            spriteGO.GetComponent<SpriteRenderer>().sprite = sprite_blue;
        }
        else
        {
            transform.position = originalPos;
            spriteGO.GetComponent<SpriteRenderer>().sprite = sprite_white;
        }
    }
}
