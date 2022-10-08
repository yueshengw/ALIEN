using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    public double timer;
    public bool hasGameEnded;
    public TextMeshProUGUI informationText;
    public TextMeshProUGUI informationText1;
    public TextMeshProUGUI informationTextCenter;


    public GameObject Player;
    // Level generation
    public int whichLevel;
    public bool enterNewLevel;
    public bool collideVoid;
    public Vector3 respawnLoc;
    public ArrayList breakableBlockPosArList = new ArrayList();
    public ArrayList respawnLocArList = new ArrayList();
    public List<Vector3> list = new List<Vector3>();

    public GameObject breakableBlockPrefab;

    public GameObject playerVirtualCam;
    public GameObject spaceShipVirtualCam;
    public GameObject spaceVirtualCam;
    public GameObject sunVirtualCam;
    public int levNum;
    public bool gameStart;
    void Awake()
    {
        //Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        hasGameEnded = false;
        timer = 60.00;
        whichLevel = 0;
        InitialSetUp();
        Player = GameObject.Find("Player");
        respawnLoc = (Vector3)respawnLocArList[whichLevel];
        Player.transform.position = respawnLoc;
        spaceShipVirtualCam.SetActive(false);
        spaceVirtualCam.SetActive(false);
        sunVirtualCam.SetActive(false);
        //playerVirtualCam.SetActive(true);
        Camera.main.GetComponent<Camera>().backgroundColor = new Color32(166,63,63,255);
        gameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        respawnLoc = (Vector3)respawnLocArList[whichLevel];

        if (collideVoid == true)
        {

        }

        //TestShortCuts
        if (Input.GetKeyDown(KeyCode.V))
        {
            InstantiateBreakableBlocks();
             Camera.main.GetComponent<Camera>().backgroundColor = new Color(166f,63f,63f,255f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            DestroyInstantiateBreakableBlocks();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            whichLevel++;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            LevelGeneration();
            Player.transform.position = respawnLoc;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            levNum++;
            if (levNum < respawnLocArList.Count-1)
            {
                whichLevel = levNum;
            }
            else
            {
                levNum = 0;
                whichLevel = levNum;
            }
            Debug.Log("levNum:" + levNum);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            levNum = 0;
            whichLevel = levNum;
            Debug.Log("levNum:" + levNum);

        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            LevelGeneration();
        }

    }
    void FixedUpdate()
    {
        if (hasGameEnded == false)
        {
            playerVirtualCam.SetActive(true);
            spaceShipVirtualCam.SetActive(false);
            if (playerVirtualCam.transform.position.y <= 1f)
            {
                gameStart = true;
            }
            if (gameStart == true)
            {
                timer = Round((timer - Time.fixedDeltaTime), 100);
            }
            if (timer < 0)
            {
                hasGameEnded = true;
                //ExecuteAfterTime(1.5f, 1);
                Invoke("GameOverText",1.5f);
                //Destroy(Player);
                informationTextCenter.text = "";

            }
            else if (timer <= 2)
            {
                informationText.text = "";

                informationText1.text = "";
                
                //informationTextCenter.text = "Game Over";
                informationTextCenter.text = "      "+timer;
            }
            else if (timer > 0)
            {
                informationText.text = ""+timer;
                //informationText1.text = "Seconds";
                informationTextCenter.text = "";
            }
        }
        else
        {
            playerVirtualCam.SetActive(false);
            spaceShipVirtualCam.SetActive(true);
            //ExecuteAfterTime(4f, 2);
            Invoke("CameraShift1",4f);
        }
        if (hasGameEnded == false && Player.GetComponent<PlayerMovementScript>().reachSpaceShip == true)
        {
            hasGameEnded = true;
            //Destroy(Player);
            informationText.text = "";
            informationText1.text = "";
            informationTextCenter.text = "You Win!!!";
            Player.SetActive(false);
        }
        if (hasGameEnded == true && Player.GetComponent<PlayerMovementScript>().reachSpaceShip == false && timer <= 0)
        {
            //hasGameEnded = true;
            //Destroy(Player);
            informationText.text = "";
            informationText1.text = "";
            //ExecuteAfterTime(1.5f, 1);
            Invoke("GameOverText",1.5f);
            //informationTextCenter.text = "Game Over";
        }
    }
    static double Round(double x, int decimalPlace)
    {
        double y = 0.0;
        y = Math.Floor(x * decimalPlace + 0.5) / decimalPlace;
        return y;
    }

    public void InitialSetUp()
    {
        respawnLocArList.Add(new Vector3(-200.1f,-25.23f,0)); //respawn for lev 1

        respawnLocArList.Add(new Vector3(-22.03f,-69.79f,0)); //respawn for lev 2

        //respawnLocArList.Add(new Vector3(-9.034259f,1.25f,0)); //respawn for lev 1
        //respawnLocArList.Add(new Vector3(-23.28f,-21.12f,0)); //respawn for lev 2
        //respawnLocArList.Add(new Vector3(-23.5f,-45.4f,0)); //respawn for lev 3
        //respawnLocArList.Add(new Vector3(-175.3f,27.2f,0)); //respawn for lev 3

        //breakableBlockPosArList.Add(new Vector3(-11.85f,-20.83f-25f,0));
        //breakableBlockPosArList.Add(new Vector3(-8.34f,-18.68f-25f,0));
        //breakableBlockPosArList.Add(new Vector3(-4.56f, -20.62f-25f,0));

    }
    public void LevelGeneration()
    {
        respawnLoc = (Vector3)respawnLocArList[whichLevel];
        DestroyInstantiateBreakableBlocks();
        InstantiateBreakableBlocks();
    }

    public void InstantiateBreakableBlocks()
    {
        foreach (Vector3 bbPos in breakableBlockPosArList)
        {
            Instantiate(breakableBlockPrefab, bbPos, Quaternion.identity);
        }
    }
    public void DestroyInstantiateBreakableBlocks()
    {
        //var breakableBlock = GameObject.FindGameObjectsWithTag("BreakableBlock");
        //foreach(var item in breakableBlock)
        //{
        //    Destroy(item);
        //}
    }
    IEnumerator ExecuteAfterTime(float time, int num)
    {
    yield return new WaitForSeconds(time);
    if (num == 1)
    {
        //informationTextCenter.text = "Game Over";
    }
    }
    void CameraShift1()
    {
        spaceShipVirtualCam.SetActive(false);
        spaceVirtualCam.SetActive(true);
    }
    void GameOverText()
    {
        informationTextCenter.text = "Game Over";
    }
 }
