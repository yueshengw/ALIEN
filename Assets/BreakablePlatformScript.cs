using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatformScript : MonoBehaviour
{
    public GameObject DetectTop;
    public bool isBreakable;
    public double timer;
    public GameObject player;
    public Vector3 explosionForce;
    public bool destroyed;
    public GameObject effectPrefab;
    public bool blockLight;
    public GameObject b;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosionForce.y = 1000;
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (isBreakable == true)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 1.5)
            {
                isBreakable = false;
                DetectTop.GetComponent<DetectTopScript>().detectPlayer = false;
            }
        }
        else if (isBreakable == false && DetectTop.GetComponent<DetectTopScript>().detectPlayer == true)
        {
            timer = 0.0;
            isBreakable = true;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && DetectTop.GetComponent<DetectTopScript>().detectPlayer == true)
        {
            player.GetComponent<Rigidbody2D>().AddForce(explosionForce);
            player.GetComponent<PlayerMovementScript>().destroyed = true;
            if (blockLight == true)
            {
                b.SetActive(false);
            }
            Instantiate(effectPrefab,gameObject.transform.position, Quaternion.identity);
            Explosion.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
