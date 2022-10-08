using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTopScript : MonoBehaviour
{
    public bool detectPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player detected");
        if (collision.gameObject.tag == "Player")
        {
            detectPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

    }
}
