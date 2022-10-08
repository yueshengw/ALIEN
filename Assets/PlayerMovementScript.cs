using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float jumpSpeed;
    public float moveInput;

    public bool isOnGround;
    public bool isOnSlope;

    public int jumpNum;

    public bool destroyed;
    public double disablePlayerJumpTimer;
    public float temp;

    public GameObject GameManager;

    public double timer;
    public float spaceTimer;
    public bool notPortalCheck;

    public bool reachSpaceShip;
    
    public bool spaceKey;

    public GameObject colli;

    public float fallMultiplier = 5f;
    public float lowJumpMultiplier = 5f;

    public GameObject TeleportSound;
    //public GameObject breakableBlock;
    void Awake()
    {
        //Application.targetFrameRate = 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        disablePlayerJumpTimer = 0.4;
        temp = jumpSpeed;
        GameManager = GameObject.Find("GameManager");
    }

    void OnEnable() {
        //GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("DetectTop");

        //foreach (GameObject obj in otherObjects) {
        //    Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        //}

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (destroyed == true)
        {
            disablePlayerJumpTimer -= Time.fixedDeltaTime;
            //temp = GetComponent<PlayerMovementScript>().jumpSpeed;    
            //jumpSpeed = 0;    
            jumpNum = 0;
            if (disablePlayerJumpTimer <= 0)
            {
                destroyed = false;
                jumpSpeed = temp;    
            }
        }
        if (spaceKey == true)
        {
            spaceTimer += Time.fixedDeltaTime;
            if (spaceTimer > 0.1f)
            {
                spaceKey = false;
            }
        }
        else
        {
            spaceTimer = 0;
        }
        //if (Input.GetKey(KeyCode.R))
        //{
            //gameObject.transform.position = new Vector3(-8.58f,0.25f,0);
        //}
    }

    void Update()
    {
        if (isOnGround == true && (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) && jumpNum > 0 && destroyed == false)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumpNum -= 1;
            isOnGround = false;
        }
        if (isOnSlope == true && (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) && jumpNum > 0 && destroyed == false)
        {
            spaceKey = true;
            //transform.Translate (0f, 2f, 0f);
            //gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            rb.velocity = Vector2.up * jumpSpeed * 1.2f;
            jumpNum -= 1;
            //colli.SetActive(false);
        }
        
        /**
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (isOnGround == true && !(Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) && jumpNum > 0 && destroyed == false)
        {
            //rb.velocity = Vector2.up * jumpSpeed;
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

            jumpNum -= 1;
            isOnGround = false;
        }
        else if (isOnSlope == true && !(Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) && jumpNum > 0 && destroyed == false)
        {
            spaceKey = true;
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            //transform.Translate (0f, 2f, 0f);
            //gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            //rb.velocity = Vector2.up * jumpSpeed * 1.2f;
            jumpNum -= 1;
            //colli.SetActive(false);
        }
        */
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
        jumpNum = 0;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touch ground");
        spaceKey = false;
        if (collision.gameObject.tag == "Ground"||collision.gameObject.tag == "BreakableBlock")
        {
            isOnGround = true;
            jumpNum = 3;
            notPortalCheck = true;
        }
        if (collision.gameObject.tag == "Slope")
        {
            jumpNum = 3;
            isOnSlope = true;
            //colli = collision.gameObject.GetComponent<SliderInfoScript>().ceiling;
        }
        if (collision.gameObject.tag == "Boss")
        {
            Respawn();
        }
        //else if (collision.gameObject.tag != "GroundDown")
        //{
        //    jumpNum = 0;
        //    isOnGround = false;
        //}

        //if (collision.gameObject.tag == "Portal1" && portalActivated == true)
        //{
            //Debug.Log("Teleport");
            //timer += 2.00;
            //GameManager.GetComponent<GMScript>().whichLevel++;
            //GameManager.GetComponent<GMScript>().LevelGeneration();

            //gameObject.transform.position = GameManager.GetComponent<GMScript>().respawnLoc;

        //}
        if (collision.gameObject.tag == "Void1")
        {
            gameObject.transform.position = GameManager.GetComponent<GMScript>().respawnLoc;
            TeleportSound.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Trap")
        {
            gameObject.transform.position = GameManager.GetComponent<GMScript>().respawnLoc;
            TeleportSound.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "SpaceShip")
        {
            reachSpaceShip = true;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"||collision.gameObject.tag == "BreakableBlock")
        {
            isOnGround = true;
            jumpNum = 3;
        }
        if (collision.gameObject.tag == "Slope")
        {
            jumpNum = 3;
            isOnSlope = true;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        Debug.Log("Jump");

        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.up * jumpSpeed * 1.2f;
        jumpNum -= 1;
    }
    public void Respawn()
    {
        gameObject.transform.position = GameManager.GetComponent<GMScript>().respawnLoc;
    }
}
