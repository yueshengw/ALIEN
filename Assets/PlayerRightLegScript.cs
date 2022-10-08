using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRightLegScript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject Player;
    public bool leftLegTouchSlope;
    public float z1;
    public float z2;
    public float goalRotation;

    public float v1;
    public float v2;
    public float v3;

    public float timer;
    public float timerS;

    public bool contactSlope;
    public bool contactGroundZone;
    public bool canGoBach;
    public bool canRotateToSlope;

    public GameObject ceili;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Player.transform.rotation = Quaternion.Euler(0,0,0);
        }
        if (contactSlope == true && contactGroundZone == true)
        {
            canGoBach = false;
        }
        else if (contactSlope == true)
        {
            canGoBach = false;
        }
        if (Player.GetComponent<PlayerMovementScript>().spaceKey == true)
        {
            canGoBach = true;
            Invoke("RotateBackToZero",v1);
        }
        else if (contactSlope == false)
        {
            timerS += Time.fixedDeltaTime;
            if (timerS >= 5f)
            {
                canGoBach = true;
            }
            //canGoBach = false;
        }
        else
        {
            timerS = 0;
        }
        if ((canGoBach == true || contactGroundZone == true)&& contactSlope == false)
        {
            Invoke("RotateBackToZero",v1);
            
        }
        else if (canGoBach == true && timer == 2f)
        {
            //RotateBackToZero();
        }
        if (contactSlope == true)
        {
            goalRotation = z1;
            RotateToSlope();
        }
        Player.transform.rotation = Quaternion.Euler(0,0,z2);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        /**
        if (collision.gameObject.tag == "Slope")
        {
            Player.GetComponent<PlayerMovementScript>().isOnSlope = true;
            if (contactGroundZone == false)
            {
                if (z1 != collision.gameObject.GetComponent<SliderInfoScript>().playerRotateAngle)
                {
                    z1 = collision.gameObject.GetComponent<SliderInfoScript>().playerRotateAngle;
                    //z2 = z1;
                }
                //z2 = z1;
                //Player.transform.rotation = Quaternion.Euler(0,0,z1);
            }
        }
        */
        if (collision.gameObject.tag == "Slope")
        {
            Player.GetComponent<PlayerMovementScript>().isOnSlope = true;
            contactSlope = true;
            contactGroundZone = false;
            canGoBach = false;

            if (Player.GetComponent<PlayerMovementScript>().moveInput == 0)
            {
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            }
            if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 2)
            {
                if (z1 != 44.888f)
                {
                    z1 = 44.888f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 1)
            {
                if (z1 != -45.166f)
                {
                    z1 = -45.166f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 3)
            {
                if (z1 != 55.046f)
                {
                    z1 = 55.046f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 4)
            {
                if (z1 != 27.839f)
                {
                    z1 = 27.839f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 5)
            {
                if (z1 != 22.803f)
                {
                    z1 = 22.803f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 6)
            {
                if (z1 != -15.882f)
                {
                    z1 = -15.882f;
                    //z2 = z1;
                }
            }
            //-15.882f
            //22.803f
            //z2 = z1;
            //Player.transform.rotation = Quaternion.Euler(0,0,z1);
        }
        //if (collision.gameObject.tag == "Slope")
        //{
        //    Player.GetComponent<PlayerMovementScript>().isOnSlope = true;
        //    z1 = 44.888f;
        //}
        else
        {
            Player.GetComponent<PlayerMovementScript>().isOnSlope = false;
        }
        if (collision.gameObject.tag == "Ground")
        {
            Player.GetComponent<PlayerMovementScript>().isOnGround = true;
        }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Player.GetComponent<PlayerMovementScript>().isOnGround = true;
        }
        /**
        if (collision.gameObject.tag == "Slope")
        {
            canGoBach = false;
            contactSlope = true;
            //ceili = collision.gameObject.GetComponent<SliderInfoScript>().ceiling;
            //if (collision.gameObject.GetComponent<SliderInfoScript>().canItBeClimbed == true)
            //{
                if (Player.GetComponent<PlayerMovementScript>().moveInput == 0)
                {
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                }
            //}
            if (z1 == collision.gameObject.GetComponent<SliderInfoScript>().playerRotateAngle && Player.GetComponent<PlayerMovementScript>().spaceKey == false)
            {
                //ceili.SetActive(true);
            }
            else
            {
                //ceili.SetActive(false);
            }
            //Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            //z1 = 55.046f;


            //Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        */
        if (collision.gameObject.tag == "Slope")
        {
            Player.GetComponent<PlayerMovementScript>().isOnSlope = true;
            contactSlope = true;
            contactGroundZone = false;
            canGoBach = false;
        
            if (Player.GetComponent<PlayerMovementScript>().moveInput == 0)
            {
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            }
            if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 2)
            {
                if (z1 != 44.888f)
                {
                    z1 = 44.888f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 1)
            {
                if (z1 != -45.166f)
                {
                    z1 = -45.166f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 3)
            {
                if (z1 != 55.046f)
                {
                    z1 = 55.046f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 4)
            {
                if (z1 != 27.839f)
                {
                    z1 = 27.839f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 5)
            {
                if (z1 != 22.803f)
                {
                    z1 = 22.803f;
                    //z2 = z1;
                }
            }
            else if (collision.gameObject.GetComponent<PaletteSliderScript>().slideType == 6)
            {
                if (z1 != -15.882f)
                {
                    z1 = -15.882f;
                    //z2 = z1;
                }
            }
            //27.839f
            //55.046f
            //z2 = z1;
            //Player.transform.rotation = Quaternion.Euler(0,0,z1);
        }
        /**
        if (collision.gameObject.tag == "Ground"||collision.gameObject.tag == "BreakableBlock")
        {
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            Player.transform.rotation = Quaternion.Euler(0,0,0);
            //Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        */
    }
    void OnCollisionExit2D(Collision2D collision)
    {
       Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
       Player.GetComponent<PlayerMovementScript>().isOnSlope = false;
       //canGoBach = true;
       contactSlope = false;
        /**
        if (contactSlope != true)
        {
            canGoBach = true;
        }
        else
        canGoBach = false;
        */
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slope")
        {
            contactSlope = true;
        }
        /**
            canGoBach = false;
            //canRotateToSlope = true;
            if (collision.gameObject.GetComponent<SliderInfoScript>().canItBeClimbed == true)
            {
                if (Player.GetComponent<PlayerMovementScript>().moveInput == 0)
                {
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                }
            }
            if (z1 != collision.gameObject.GetComponent<SliderInfoScript>().playerRotateAngle)
            {
                z1 = collision.gameObject.GetComponent<SliderInfoScript>().playerRotateAngle;
            }
        }
        else
        {
            //canGoBach = true;
            //contactSlope = false;
            //canRotateToSlope = false;
        }
        */
        //if (collision.gameObject.tag == "Slope")
        //{
        //    Player.GetComponent<PlayerMovementScript>().isOnSlope = true;
        //    z1 = 44.888f;
        //}
        if (collision.gameObject.tag == "Slope")
        {
            contactSlope = true;
            canGoBach = false;
            //canRotateToSlope = true;
            if (collision.gameObject.GetComponent<SliderInfoScript>().canItBeClimbed == true)
            {
                if (Player.GetComponent<PlayerMovementScript>().moveInput == 0)
                {
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
        else
        {
            //canGoBach = true;
            //contactSlope = false;
            //canRotateToSlope = false;
        }
        if (collision.gameObject.tag == "Ground")
        {
            contactSlope = false;
            canGoBach = true;
            contactGroundZone = true;
            
            //Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("TrigLeave");
        contactGroundZone = false;
        contactSlope = false;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        goalRotation = 0;
        canGoBach = true;
    }
    void ReturnToNormal()
    {
        if (contactGroundZone == true)
        {
            Player.transform.rotation = Quaternion.Euler(0,0,0);
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void RotateBackToZero()
    {
        if (z2 >= 0)
        {
            if (z2 - v2 > goalRotation)
            {
                z2 -= v2;
            }
            else if (z2 - v2 <= goalRotation)
            {
                z2 = 0;
            }

        }
        else if (z2 < goalRotation)
        {
            if (z2 + v2 >= goalRotation)
            {
                z2 = goalRotation;
            }
            else if (z2 + v2 < goalRotation)
            {
                z2 += v2;
            }
        }
    }
    void RotateToSlope()
    {
        if (z2 >= goalRotation)
        {
            if (z2 - v3 >= goalRotation)
            {
                z2 -= v3;
            }
            else if (z2 - v3 < goalRotation)
            {
                z2 = goalRotation;
            }

        }
        else if (z2 < goalRotation)
        {
            if (z2 + v3 >= goalRotation)
            {
                z2 = goalRotation;
            }
            else if (z2 + v3 < goalRotation)
            {
                z2 += v3;
            }
        }
    }
}
