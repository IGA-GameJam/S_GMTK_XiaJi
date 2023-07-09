using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int rowNum = 2;
    public int columnNum = 2;
    public int blockIndex = 4;

    public float timer = 0;
    public float actionTime = 0.5f;
    public float changeWindow = 0.2f;
    public bool actionStart;
    public bool jumping;
    public bool crounching;

    public List<GameObject> ganonPoseList = new List<GameObject>();
    public List<GameObject> ganonShadowList = new List<GameObject>();

    public GameObject attackmanager;


    void Update()
    {
        if (!attackmanager.GetComponent<AttackManager>().satisfied)
        {
            if ((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && !crounching && timer < changeWindow)
            {
                foreach (GameObject pose in ganonPoseList)
                {
                    if (rowNum == 2 && columnNum == 2)
                    {
                        blockIndex = 1;
                        if (ganonShadowList[4].activeSelf) ganonShadowList[4].SetActive(false);
                        ganonShadowList[4].SetActive(true);
                        if (pose.name == "Top")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                    else if (rowNum == 2 && columnNum == 1)
                    {
                        blockIndex = 0;
                        if (ganonShadowList[3].activeSelf) ganonShadowList[3].SetActive(false);
                        ganonShadowList[3].SetActive(true);
                        if (pose.name == "TopLeft")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                    else if (rowNum == 2 && columnNum == 3)
                    {
                        blockIndex = 2;
                        if (ganonShadowList[5].activeSelf) ganonShadowList[5].SetActive(false);
                        ganonShadowList[5].SetActive(true);
                        if (pose.name == "TopRight")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                }
                rowNum = 1;
                if (!actionStart) timer = 0;
                actionStart = true;
                jumping = true;
            }
            if ((Input.GetKeyDown("s") || Input.GetKeyDown("down")) && !jumping && timer < changeWindow)
            {
                foreach (GameObject pose in ganonPoseList)
                {
                    if (rowNum == 2 && columnNum == 2)
                    {
                        blockIndex = 7;
                        if (ganonShadowList[4].activeSelf) ganonShadowList[4].SetActive(false);
                        ganonShadowList[4].SetActive(true);
                        if (pose.name == "Bottom")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                    else if (rowNum == 2 && columnNum == 1)
                    {
                        blockIndex = 6;
                        if (ganonShadowList[3].activeSelf) ganonShadowList[3].SetActive(false);
                        ganonShadowList[3].SetActive(true);
                        if (pose.name == "BottomLeft")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                    else if (rowNum == 2 && columnNum == 3)
                    {
                        blockIndex = 8;
                        if (ganonShadowList[5].activeSelf) ganonShadowList[5].SetActive(false);
                        ganonShadowList[5].SetActive(true);
                        if (pose.name == "BottomRight")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                }
                rowNum = 3;
                if (!actionStart) timer = 0;
                actionStart = true;
                crounching = true;
            }
            if ((Input.GetKeyDown("a") || Input.GetKeyDown("left")) && columnNum == 2 && timer < changeWindow)
            {
                foreach (GameObject pose in ganonPoseList)
                {
                    if (rowNum == 2 && columnNum == 2)
                    {
                        blockIndex = 3;
                        if (ganonShadowList[4].activeSelf) ganonShadowList[4].SetActive(false);
                        ganonShadowList[4].SetActive(true);
                        if (pose.name == "Left")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                    else if (rowNum == 1 && columnNum == 2)
                    {
                        blockIndex = 0;
                        if (ganonShadowList[1].activeSelf) ganonShadowList[1].SetActive(false);
                        ganonShadowList[1].SetActive(true);
                        if (pose.name == "TopLeft")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                    else if (rowNum == 3 && columnNum == 2)
                    {
                        blockIndex = 6;
                        if (ganonShadowList[7].activeSelf) ganonShadowList[7].SetActive(false);
                        ganonShadowList[7].SetActive(true);
                        if (pose.name == "BottomLeft")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                }
                columnNum = 1;
                if (!actionStart) timer = 0;
                actionStart = true;
            }
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && columnNum == 2 && timer < changeWindow)
            {
                foreach (GameObject pose in ganonPoseList)
                {
                    if (rowNum == 2 && columnNum == 2)
                    {
                        blockIndex = 5;
                        if (ganonShadowList[4].activeSelf) ganonShadowList[4].SetActive(false);
                        ganonShadowList[4].SetActive(true);
                        if (pose.name == "Right")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                    else if (rowNum == 1 && columnNum == 2)
                    {
                        blockIndex = 2;
                        if (ganonShadowList[1].activeSelf) ganonShadowList[1].SetActive(false);
                        ganonShadowList[1].SetActive(true);
                        if (pose.name == "TopRight")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                    else if (rowNum == 3 && columnNum == 2)
                    {
                        blockIndex = 8;
                        if (ganonShadowList[7].activeSelf) ganonShadowList[7].SetActive(false);
                        ganonShadowList[7].SetActive(true);
                        if (pose.name == "BottomRight")
                            pose.SetActive(true);
                        else
                            pose.SetActive(false);
                    }
                }
                columnNum = 3;
                if (!actionStart) timer = 0;
                actionStart = true;
            }
        }      
    }

    void FixedUpdate()
    {
        if (actionStart && timer < actionTime)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= actionTime)
        {
            rowNum = 2;
            columnNum = 2;
            blockIndex = 4;
            foreach (GameObject pose in ganonPoseList)
            {
                if (pose.name == "Center")
                    pose.SetActive(true);
                else
                    pose.SetActive(false);
                /*
                else if (pose.activeSelf)
                {
                    foreach (GameObject shadow in ganonShadowList)
                    {
                        if (shadow.name == pose.name)
                            shadow.SetActive(true);
                    }
                    pose.SetActive(false);
                } 
                */
            }
            actionStart = false;
            jumping = false;
            crounching = false;
            timer = 0;            
        }
    }

}
