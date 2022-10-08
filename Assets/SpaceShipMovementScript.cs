using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpaceShipMovementScript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject Player;
    public double timer;
    public Vector3 explosionForce;
    public TextMeshProUGUI informationTextCenter;
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        Player = GameObject.Find("Player");
        timer = 1.00;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.GetComponent<GMScript>().hasGameEnded == true)
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                explosionForce.y += 4f;
                GetComponent<Rigidbody2D>().AddForce(explosionForce);
                if (timer < -2f)
                {
                    informationTextCenter.text = "Game Over";
                    Player.SetActive(false);
                }
                
            }
        }
        //fire.SetActive(true);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
