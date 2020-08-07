using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float smalljumpForce;

    private float orignialSpeed;
    public float orignialJumpForce;
    public float orignialSmallJumpForce;

    private float moveInput;
    private Rigidbody2D rb;
    LevelLoader levelLoader;

    private bool facingRight = false;
    public bool canJump;

    public float fJumpPressedRemember;
    public float fJumpPressedRememberTime = 0.2f;

    public float fGroundedRemember;
    public float fGroundedRememberTime = 0.2f;

    public bool fTrigger = false;
    public bool fGroundedTrigger = false;
    public bool debugMode = false;

    GameManager gameManager;
    DarkLightMode DarkLightMode;

    public Vector3 originalPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        levelLoader = FindObjectOfType<LevelLoader>();
        Physics2D.queriesStartInColliders = false;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        orignialSpeed = speed;
        orignialJumpForce = jumpForce;
        orignialSmallJumpForce = smalljumpForce;
        DarkLightMode = FindObjectOfType<DarkLightMode>();

        originalPos = transform.position;
    }

    private void FixedUpdate()
    {
        if(gameManager.freezeTime < 0)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                debugMode = !debugMode;
            }
            if (debugMode)
            {
                NormalMovement();
            }
            else
            {
                RewindMovement();
            }
        }
        
    }

    private void Update()
    {
        if(gameManager.freezeTime < 0)
        {
            //RaycastHit2D hit;
            //hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
            //Debug.DrawLine(transform.position, transform.position + new Vector3(0, -1f, 0), Color.green);
            //if (hit)
            //{
            //    canJump = true;
            //}
            //else
            //{
            //    canJump = false;
            //}

            if (!debugMode)
            {
                if (fTrigger)
                {
                    fJumpPressedRemember -= Time.deltaTime;
                }
                if(fGroundedTrigger)
                {
                    fGroundedRemember -= Time.deltaTime;
                }
                if (canJump)
                {
                    fGroundedRemember = fGroundedRememberTime;
                }
            }

            if (debugMode)
            {
                if (canJump && Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
                if (canJump && Input.GetKeyDown(KeyCode.C))
                {
                    SmallJump();
                }
                moveInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            }
        }
        
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Jump()
    {
        fJumpPressedRemember = 0;
        fGroundedRemember = 0;
        rb.velocity = Vector2.up * jumpForce;
        //if (DarkLightMode == null)
        //{
        //    return;
        //}
        //else
        //{
        //    DarkLightMode.loopValue++;
        //    if (DarkLightMode.loopValue > DarkLightMode.endPointList.Length - 1)
        //    {
        //        DarkLightMode.loopValue = 0;
        //    }

        //    DarkLightMode.darkLightMode = !DarkLightMode.darkLightMode;
        //}
        canJump = false;
    }
    public void SmallJump()
    {
        fJumpPressedRemember = 0;
        fGroundedRemember = 0;
        rb.velocity = Vector2.up * smalljumpForce;
        //if (DarkLightMode == null)
        //{
        //    return;
        //}
        //else
        //{
        //    DarkLightMode.loopValue++;
        //    if (DarkLightMode.loopValue > DarkLightMode.endPointList.Length - 1)
        //    {
        //        DarkLightMode.loopValue = 0;
        //    }

        //    DarkLightMode.darkLightMode = !DarkLightMode.darkLightMode;
        //}
        canJump = false;
    }

    public void RewindMovement()
    {
        if (gameManager.redImage.fillAmount <= 0 || gameManager.redImage.fillAmount >= 1)
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
            if (gameManager.isRewinding)
            {
                //transform.position += Vector3.right * Time.deltaTime * speed;
                //rb.velocity = Vector2.right * speed;
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (!gameManager.isRewinding)
            {
                //transform.position += Vector3.left * Time.deltaTime * speed;
                //rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }

    //DEBUG
    public void NormalMovement()
    {
        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EndPoint")
        {
            levelLoader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.tag == "WaterBG")
        {
            speed = orignialSpeed * 0.5f;
            jumpForce = orignialJumpForce * 0.5f;
            smalljumpForce = orignialSmallJumpForce * 0.5f;
        }
        else if (other.gameObject.tag == "WindBG")
        {
            speed = orignialSpeed * 2;
            jumpForce = orignialJumpForce * 2;
            smalljumpForce = orignialSmallJumpForce * 2;
        }
        if(other.gameObject.tag == "Boundary")
        {
            transform.position = originalPos;
        }
    }
}
