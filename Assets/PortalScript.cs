using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject Player;
    public GameObject TeleportSound;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Player.GetComponent<PlayerMovementScript>().notPortalCheck == true)
        {
            Debug.Log("Teleport1");
            GameManager.GetComponent<GMScript>().whichLevel++;
            GameManager.GetComponent<GMScript>().LevelGeneration();
            Player.GetComponent<PlayerMovementScript>().notPortalCheck = false;
            TeleportSound.GetComponent<AudioSource>().Play();
            Player.transform.position = GameManager.GetComponent<GMScript>().respawnLoc;
        }
    }

}
