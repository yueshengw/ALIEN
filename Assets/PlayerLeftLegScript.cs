using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftLegScript : MonoBehaviour
{
    public bool touchSlope;
    public GameObject Right;
    // Start is called before the first frame update
    void Start()
    {
        //Right = GameObject.Find("Right");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slope")
        {
            Right.GetComponent<PlayerRightLegScript>().leftLegTouchSlope = true;
        }
        else
        {
            Right.GetComponent<PlayerRightLegScript>().leftLegTouchSlope = false;
        }
    }
}
