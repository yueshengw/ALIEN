using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderInfoScript : MonoBehaviour
{
    public float playerRotateAngle;
    public bool canItBeClimbed;
    public GameObject ceiling;
    public GameObject Player;
    public bool canCeiling;
    public bool collis;
    public float timer;
    public float timerF;
    public bool ceiliDisabled;
    //public GameObject Up;
    //public GameObject Down;
    public bool detect;

    void Start()
    {
        ceiling.SetActive(false);
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        /**
        if (Player.GetComponent<PlayerMovementScript>().spaceKey == false && collis == true)
        {
            ceiling.SetActive(true);
        }
        */
        //if (Player.GetComponent<PlayerMovementScript>().spaceKey == true)
        //{
        //    ceiling.SetActive(false);
        //    ceiliDisabled = true;
        //}
        //if (Up.GetComponent<DetectForSliderScript>().detectPlayer == true)
        //{
        //    ceiling.SetActive(false);
        //    ceiliDisabled = true;
        //    Up.GetComponent<DetectForSliderScript>().detectPlayer = false;
        //}
        //if (Down.GetComponent<DetectForSliderScript>().detectPlayer == true)
        //{
        //    ceiling.SetActive(false);
        //    ceiliDisabled = true;
        //    Down.GetComponent<DetectForSliderScript>().detectPlayer = false;
        //}
    }
    void FixedUpdate()
    {
        if (ceiliDisabled == false && timer <1f)
        {
            timer += Time.fixedDeltaTime;
        }
        if (Player.GetComponent<PlayerMovementScript>().spaceKey == true || detect == true)
        {
            timer = 0f;
            ceiling.SetActive(false);
            ceiliDisabled = true;
            detect = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ceiliDisabled = false;
            ceiling.SetActive(true);

            if (timer >= 0.5f)
            {
                ceiling.SetActive(true);
            }
        } 
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        //ceiling.SetActive(false);
    }
}
