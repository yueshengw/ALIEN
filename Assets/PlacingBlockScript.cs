using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingBlockScript : MonoBehaviour
{
    public Vector3 upDirection;
    public Vector3 downDirection;
    public Vector3 leftDirection;
    public Vector3 rightDirection;

    public GameObject referenceBlock;
    public GameObject placedBlock;
    public int num;
    public int currentNumPlaced;
    public GameObject block;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            GetComponent<Transform>().position += upDirection;
        }
        if (Input.GetKey(KeyCode.K))
        {
            GetComponent<Transform>().position += downDirection;
        }
        if (Input.GetKey(KeyCode.J))
        {
            GetComponent<Transform>().position += leftDirection;
        }
        if (Input.GetKey(KeyCode.L))
        {
            GetComponent<Transform>().position += rightDirection;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            currentNumPlaced++;
            num++;
            block = Instantiate(referenceBlock,gameObject.transform.position, Quaternion.identity);
            block.name = "PlaceBlock"+currentNumPlaced;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            placedBlock = GameObject.Find("PlaceBlock"+num);
            Destroy(placedBlock);
        }
    }
}
