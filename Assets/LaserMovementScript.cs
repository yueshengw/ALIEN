using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LaserMovementScript : MonoBehaviour
{
    public float speed; //0.000004f
    public GameObject lookTarget;
    //public Vector2 direction;
    public Vector3 movementForce;
    public float timer;
    private Rigidbody2D rb;
    public double x;
    public double y;
    public float c;

    public GameObject laserSound;
    public GameObject TeleportSound;

    // Start is called before the first frame update
    void Start()
    {
        lookTarget = GameObject.Find("Player");
        movementForce = new Vector2
        (
            lookTarget.transform.position.x - transform.position.x,
            lookTarget.transform.position.y - transform.position.y
        );
        x =  Math.Pow(lookTarget.transform.position.x - transform.position.x,2);
        y =  Math.Pow(lookTarget.transform.position.y - transform.position.y,2);
        //c = (100/(x+y)*-1);
        c = (float) (100/(Math.Sqrt(x+y)));
        Debug.Log(lookTarget.transform.position.x - transform.position.x);
        Debug.Log(lookTarget.transform.position.y - transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        // -- laserSound.GetComponent<AudioSource>().Play();

        //movementForce = new Vector3();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= 3f)
        {
            Destroy(gameObject);
        }
        if (c < 0)
        {
            c = c * -1;
        }
        GetComponent<Rigidbody2D>().AddForce(movementForce * speed * c);
        rb.velocity = movementForce * speed;
        //gameObject.transform.position += transform.forward * Time.deltaTime * speed;

    }

	void OnTriggerEnter2D (Collider2D collision)
	{
		// Put a particle effect here
        if (collision.gameObject.tag == "Player")
        {
		    //collision.gameObject.SetActive(false);
		    //Destroy(gameObject);
            //collision.gameObject.GetComponent<PlayerMovementScript>().Respawn();
            TeleportSound.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
		    //Destroy(gameObject);
        }
    }
}
/**
[RequireComponent(typeof(Rigidbody2D))]
public class LaserMovementScript : MonoBehaviour
{
	public GameObject target;
    [Range(1f,20f)]
	public float speed;
	public float rotateSpeed = 200f;

	private Rigidbody2D rb;
    public bool one;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        one = true;
	}
	
	void FixedUpdate () {
		Vector2 direction = (Vector2)target.transform.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D (Collider2D collision)
	{
		// Put a particle effect here
        if (collision.gameObject.tag == "Player")
        {
		    Destroy(collision.gameObject);
		    Destroy(gameObject);
        }
	}
}
*/
