using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    public Transform lookTarget;
    public bool inRange;
    public GameObject laserGuide;
    public GameObject laserPrefab;
    public float timer;
    public float timeG;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inRange == true)
        {
            Vector2 direction = new Vector2
            (
                lookTarget.position.x - transform.position.x,
                lookTarget.position.y - transform.position.y
            );
            transform.up = direction;
            timer += Time.fixedDeltaTime;
            timeG = Random.Range(1.6f,2.4f);
            if (timer >= timeG)
            {
                Instantiate(laserPrefab, laserGuide.transform.position, laserGuide.transform.rotation);

                timer = 0;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           inRange = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           inRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}