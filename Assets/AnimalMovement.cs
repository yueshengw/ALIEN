using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public Vector3 MovementForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(MovementForce);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().AddForce(MovementForce);
    }

}
