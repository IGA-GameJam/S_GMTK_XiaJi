using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public GameObject ganon;
    public GameObject HealthBarObject;
    public bool satisfied;

    public int randomPosNum = -1;
    public int randomWeaponNum = 1;

    public float coolDownTimer = 0;
    public float coolDownTime = 10f;
    public float startUpTimer = 0;
    public float startUpTime = 6f;
    public float ActiveTimer = 0;
    public float ActiveTime = 4f;

    public List<string> weaponList = new List<string>();

    [SerializeField] private List<GameObject> blockList = new List<GameObject>();
    [SerializeField] private List<GameObject> WhipAttackList = new List<GameObject>();
    public List<GameObject> BatAttackList = new List<GameObject>();
    public List<GameObject> HammerAttackList = new List<GameObject>();


    private void Start()
    {
        randomWeaponNum = Random.Range(1, weaponList.Count);
    }

    void Update()
    {
        if (coolDownTimer < coolDownTime && startUpTimer == 0 && ActiveTimer == 0)
        {
            coolDownTimer += Time.fixedDeltaTime;
        }
        else if (coolDownTimer >= coolDownTime)
        {
            if (randomPosNum == -1 && weaponList[randomWeaponNum] == "Whip")
            {
                randomPosNum = Random.Range(0, 9);
                blockList[randomPosNum].SetActive(true);
            }
            else if (randomPosNum == -1 && weaponList[randomWeaponNum] == "Bat")
            {
                randomPosNum = Random.Range(0, 6);
                if (randomPosNum == 0 || randomPosNum == 3)
                {
                    blockList[0].SetActive(true);
                    blockList[1].SetActive(true);
                    blockList[2].SetActive(true);
                }
                else if (randomPosNum == 1 || randomPosNum == 4)
                {
                    blockList[3].SetActive(true);
                    blockList[4].SetActive(true);
                    blockList[5].SetActive(true);
                }
                else if (randomPosNum == 2 || randomPosNum == 5)
                {
                    blockList[6].SetActive(true);
                    blockList[7].SetActive(true);
                    blockList[8].SetActive(true);
                }
            }
            else if (randomPosNum == -1 && weaponList[randomWeaponNum] == "Hammer")
            {
                randomPosNum = Random.Range(0, 3);
                if (randomPosNum == 0)
                {
                    blockList[0].SetActive(true);
                    blockList[3].SetActive(true);
                    blockList[6].SetActive(true);
                }
                else if (randomPosNum == 1)
                {
                    blockList[1].SetActive(true);
                    blockList[4].SetActive(true);
                    blockList[7].SetActive(true);
                }
                else if (randomPosNum == 2)
                {
                    blockList[2].SetActive(true);
                    blockList[5].SetActive(true);
                    blockList[8].SetActive(true);
                }
            }
            
            if (startUpTimer < startUpTime && ActiveTimer == 0)
                startUpTimer += Time.fixedDeltaTime;
            else if (startUpTimer >= startUpTime)
            {
                foreach (GameObject block in blockList)
                {
                    if(block.activeSelf)
                        block.GetComponent<Image>().color = new Color(255, 255, 255);
                }

                if (weaponList[randomWeaponNum] == "Whip")
                    WhipAttackList[randomPosNum].SetActive(true);
                if (weaponList[randomWeaponNum] == "Bat")
                    BatAttackList[randomPosNum].SetActive(true);
                if (weaponList[randomWeaponNum] == "Hammer")
                    HammerAttackList[randomPosNum].SetActive(true);

                if (ActiveTimer < ActiveTime)
                {
                    ActiveTimer += Time.fixedDeltaTime;

                    if (weaponList[randomWeaponNum] == "Whip")
                    {
                        if (ganon.GetComponent<PlayerController>().blockIndex == randomPosNum && !satisfied)
                        {
                            HealthBarObject.GetComponent<HPbarHandler>().currentHealth += 4;
                            satisfied = true;
                        }                    
                    }
                      
                }
                else if (ActiveTimer >= ActiveTime )
                {
                    foreach (GameObject block in blockList)
                    {
                        block.GetComponent<Image>().color = new Color(0, 0, 0);
                        block.SetActive(false);
                    }
                    randomPosNum = -1;
                    coolDownTimer = 0;
                    coolDownTime = Random.Range(3, 10);
                    startUpTimer = 0;
                    ActiveTimer = 0;
                    randomWeaponNum = Random.Range(1, weaponList.Count);
                    satisfied = false;
                }
            }
        }
    }

}
