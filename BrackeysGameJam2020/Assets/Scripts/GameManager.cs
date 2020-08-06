using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance = null;
    public bool isRewinding = false;
    public Image redImage;
    public float videoSpeed;
    Player player;

    public float freezeTime;

    //public float freezeTime = 2f;
    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //    DontDestroyOnLoad(gameObject);
    //}

    private void Start()
    {
        player = FindObjectOfType<Player>();
        redImage = GameObject.FindGameObjectWithTag("RedImage").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        freezeTime -= Time.deltaTime;
        if (!player.debugMode)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RewindButtonEvent();
            }
            if (!isRewinding)
            {
                redImage.fillAmount -= videoSpeed * Time.deltaTime;
            }
            if (isRewinding)
            {
                redImage.fillAmount += videoSpeed * Time.deltaTime;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RewindButtonEvent()
    {
        isRewinding = !isRewinding;
    }
}
