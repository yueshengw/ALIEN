using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectForSliderScript : MonoBehaviour
{
    public bool detectPlayer;
    public GameObject Slider;
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
            Slider.GetComponent<SliderInfoScript>().detect = true;
        }
    }
}
