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

    [Header("Bottom Screen UI")]
    public GameObject Playbutton;
    public Sprite pause;
    public Sprite play;

    [Header("Top Screen UI")]
    public GameObject InfoBar;
    public float InfoBarfreezeTime;

    [Header("Middle Screen UI")]
    public GameObject Icon_Middle;
    public Sprite pause_middle;
    public Sprite play_middle;
    public Animator midIconAnim;

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
        InfoBar = GameObject.FindGameObjectWithTag("InfoBar");
        Playbutton = GameObject.FindGameObjectWithTag("PlayButton");
        Icon_Middle = GameObject.FindGameObjectWithTag("MidIcon");
        midIconAnim = GameObject.FindGameObjectWithTag("MidIcon").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        GamePlay();
        PlayButtonUI();
        TopScreenUI();
        RestartLevel();
    }

    public void RewindButtonEvent()
    {
        isRewinding = !isRewinding;
    }

    public void GamePlay()
    {
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
    }
    public void PlayButtonUI()
    {
        if (redImage.fillAmount <= 0 || redImage.fillAmount >= 1)
        {
            Playbutton.GetComponent<Image>().sprite = pause;
            Icon_Middle.GetComponent<Image>().sprite = play_middle;
            midIconAnim.SetBool("MidIconPauseState", true);
        }
        else
        {
            Playbutton.GetComponent<Image>().sprite = play;
            Icon_Middle.GetComponent<Image>().sprite = pause_middle;
            midIconAnim.SetBool("MidIconPauseState", false);
        }
    }
    public void TopScreenUI()
    {
        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
        {
            //Code for action on mouse moving left
            //Code for action on mouse moving right
            InfoBarfreezeTime = 3f;
        }
        else
        {
            InfoBarfreezeTime -= Time.deltaTime;
        }

        if(InfoBarfreezeTime <= 0f)
        {
            InfoBar.SetActive(false);
        }
        else
        {
            InfoBar.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
