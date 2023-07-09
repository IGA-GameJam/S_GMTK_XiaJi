using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public GameObject ganon;
    public GameObject HealthBarGroup;
    public bool bgmSwitch;
    public bool satisfied;
    public bool negativeProjectile;

    [Header("Whip")]
    [SerializeField] private float whipDamage = 4;

    [Header("Bat")]
    [SerializeField] private float batDamage1 = 2;
    [SerializeField] private float batDamage2 = 3;
    [SerializeField] private float batDamage3 = 5;

    [Header("Hammer")]
    [SerializeField] private float hammerDamage1 = 2;
    [SerializeField] private float hammerDamage2 = 3;
    [SerializeField] private float hammerDamage3 = 5;
    [SerializeField] private float moanDelay = 0.3f;

    [Header("Nunchucks")]
    [SerializeField] private float nunchucksDamage1 = 2;
    [SerializeField] private float nunchucksDamage2 = 3;
    [SerializeField] private float nunchucksDamage3 = 5;
    [SerializeField] private float moanDelay2 = 0.3f;

    [Header("Potion")]
    [SerializeField] private float potionDamage = 4;

    [Header("Pillow")]
    [SerializeField] private float pillowDamage = 2;


    [Header("Randomizer && Timer")]
    public int randomPosNum = -1;
    public int randomWeaponNum = 1;

    public float coolDownTimer = 0;
    public float coolDownTime = 10f;
    public float startUpTimer = 0;
    public float startUpTime = 6f;
    public float ActiveTimer = 0;
    public float ActiveTime = 4f;

    public List<string> weaponList = new List<string>();
    [SerializeField] private List<GameObject> AttackDirectionList = new List<GameObject>();
    [SerializeField] private List<GameObject> GanonGotHitList = new List<GameObject>();
    [SerializeField] private List<Sprite> GanonNormalList = new List<Sprite>();
    [SerializeField] private List<Sprite> GanonSadList = new List<Sprite>();

    [SerializeField] private List<GameObject> blockList = new List<GameObject>();
    [SerializeField] private List<GameObject> WhipAttackList = new List<GameObject>();
    public List<GameObject> BatAttackList = new List<GameObject>();
    public List<GameObject> HammerAttackList = new List<GameObject>();
    public List<GameObject> NunchucksAttackList = new List<GameObject>();
    public List<GameObject> PotionAttackList = new List<GameObject>();
    public List<GameObject> PillowAttackList = new List<GameObject>();


    private void Start()
    {
        randomWeaponNum = Random.Range(1, weaponList.Count);
        string[] backgroundAudio = new string[1] { "EpicBossFight" };
        M_Audio.PlayLoopAudio(backgroundAudio);
    }

    void FixedUpdate()
    {
        if (coolDownTimer < coolDownTime && startUpTimer == 0 && ActiveTimer == 0)
        {
            coolDownTimer += Time.fixedDeltaTime;
        }
        else if (coolDownTimer >= coolDownTime)
        {
            if (randomPosNum == -1 && (weaponList[randomWeaponNum] == "Whip" || weaponList[randomWeaponNum] == "Potion" || weaponList[randomWeaponNum] == "Pillow"))
            {
                randomPosNum = Random.Range(0, 9);
                blockList[randomPosNum].SetActive(true);

                if (weaponList[randomWeaponNum] == "Whip")
                {
                    blockList[randomPosNum].GetComponent<AttackIndicator>().skull.SetActive(true);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().heart.SetActive(false);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().circle1.SetActive(true);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().circle2.SetActive(true);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().circle3.SetActive(false);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().circle4.SetActive(false);
                }
                else if (weaponList[randomWeaponNum] == "Potion" || weaponList[randomWeaponNum] == "Pillow")
                {
                    blockList[randomPosNum].GetComponent<AttackIndicator>().skull.SetActive(false);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().heart.SetActive(true);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().circle1.SetActive(false);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().circle2.SetActive(false);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().circle3.SetActive(true);
                    blockList[randomPosNum].GetComponent<AttackIndicator>().circle4.SetActive(true);
                }
            }
            else if (randomPosNum == -1 && weaponList[randomWeaponNum] == "Bat")
            {
                randomPosNum = Random.Range(0, 6);
                AttackDirectionList[randomPosNum].SetActive(true);
            }
            else if (randomPosNum == -1 && weaponList[randomWeaponNum] == "Hammer")
            {
                randomPosNum = Random.Range(0, 3);
                AttackDirectionList[randomPosNum + 6].SetActive(true);
            }
            else if (randomPosNum == -1 && weaponList[randomWeaponNum] == "Nunchucks")
            {
                randomPosNum = Random.Range(0, 3);
                AttackDirectionList[randomPosNum + 9].SetActive(true);
            }

            if (startUpTimer < startUpTime && ActiveTimer == 0)
                startUpTimer += Time.fixedDeltaTime;

            else if (startUpTimer >= startUpTime)
            {
                foreach (GameObject block in blockList)
                {
                    block.SetActive(false);
                }
                foreach (GameObject direction in AttackDirectionList)
                {
                    direction.SetActive(false);
                }

                if (weaponList[randomWeaponNum] == "Whip")
                {
                    WhipAttackList[randomPosNum].SetActive(true);
                    if (!GameObject.Find("Sound WhipStart"))
                        M_Audio.PlayOneShotAudio("WhipStart");
                }
                else if (weaponList[randomWeaponNum] == "Potion")
                {
                    PotionAttackList[randomPosNum].SetActive(true);
                    if (!GameObject.Find("Sound ProjectileStart"))
                        M_Audio.PlayOneShotAudio("ProjectileStart");
                }
                else if (weaponList[randomWeaponNum] == "Pillow")
                {
                    PillowAttackList[randomPosNum].SetActive(true);
                    if (!GameObject.Find("Sound ProjectileStart"))
                        M_Audio.PlayOneShotAudio("ProjectileStart");
                }
                else if (weaponList[randomWeaponNum] == "Bat")
                {
                    BatAttackList[randomPosNum].SetActive(true);
                    if (!GameObject.Find("Sound MeleeStart"))
                        M_Audio.PlayOneShotAudio("MeleeStart");
                }
                else if (weaponList[randomWeaponNum] == "Hammer")
                {
                    HammerAttackList[randomPosNum].SetActive(true);
                    if (!GameObject.Find("Sound MeleeStart"))
                        M_Audio.PlayOneShotAudio("MeleeStart");
                }
                else if (weaponList[randomWeaponNum] == "Nunchucks")
                {
                    NunchucksAttackList[randomPosNum].SetActive(true);
                    if (!GameObject.Find("Sound MeleeStart"))
                        M_Audio.PlayOneShotAudio("MeleeStart");
                }

                if (ActiveTimer < ActiveTime)
                {
                    ActiveTimer += Time.fixedDeltaTime;

                    if (weaponList[randomWeaponNum] == "Whip")
                    {
                        if (ganon.GetComponent<PlayerController>().blockIndex == randomPosNum && !satisfied)
                        {
                            GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                            GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                            HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += whipDamage;                            
                            satisfied = true;
                            if (!GameObject.Find("Sound WhipHit"))
                                M_Audio.PlayOneShotAudio("WhipHit");
                            if (!GameObject.Find("Sound Moan1"))
                                M_Audio.PlayOneShotAudio("Moan1");
                        }
                    }
                    else if (weaponList[randomWeaponNum] == "Potion")
                    {
                        if (ganon.GetComponent<PlayerController>().blockIndex == randomPosNum && !negativeProjectile)
                        {
                            HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth -= potionDamage;
                            if (!GameObject.Find("Sound PotionHit"))
                                M_Audio.PlayOneShotAudio("PotionHit");
                            if (!GameObject.Find("Sound Huh"))
                                M_Audio.PlayOneShotAudio("Huh");
                            for (int i = 0; i < 9; i++)
                            {
                                ganon.GetComponent<PlayerController>().ganonPoseList[i].GetComponent<Image>().sprite = GanonSadList[i];
                            }
                        }
                        negativeProjectile = true;
                    }
                    else if (weaponList[randomWeaponNum] == "Pillow")
                    {
                        if (ganon.GetComponent<PlayerController>().blockIndex == randomPosNum && !negativeProjectile)
                        {
                            HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth -= pillowDamage;
                            if (!GameObject.Find("Sound PillowHit"))
                                M_Audio.PlayOneShotAudio("PillowHit");
                            if (!GameObject.Find("Sound Huh"))
                                M_Audio.PlayOneShotAudio("Huh");
                            for (int i = 0; i < 9; i++)
                            {
                                ganon.GetComponent<PlayerController>().ganonPoseList[i].GetComponent<Image>().sprite = GanonSadList[i];
                            }
                        }
                        negativeProjectile = true;
                    }
                    else if (weaponList[randomWeaponNum] == "Bat")
                    {
                        //Top right to left
                        if (randomPosNum == 0)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 2 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 1 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 0 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound ClubHit"))
                                    M_Audio.PlayOneShotAudio("ClubHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio("Moan2");
                            }
                        }
                        //Mid right to left
                        else if (randomPosNum == 1)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 5 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 4 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 3 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound ClubHit"))
                                    M_Audio.PlayOneShotAudio("ClubHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio("Moan2");

                            }
                        }
                        //Bottom right to left
                        else if (randomPosNum == 2)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 8 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 7 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 6 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound ClubHit"))
                                    M_Audio.PlayOneShotAudio("ClubHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio("Moan2");
                            }
                        }
                        //Top left to right
                        else if (randomPosNum == 3)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 0 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 1 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 2 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound ClubHit"))
                                    M_Audio.PlayOneShotAudio("ClubHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio("Moan2");
                            }
                        }
                        //Mid left to right
                        else if (randomPosNum == 4)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 3 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 4 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 5 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound ClubHit"))
                                    M_Audio.PlayOneShotAudio("ClubHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio("Moan2");
                            }
                        }
                        //Bottom left to right
                        else if (randomPosNum == 5)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 6 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 7 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 8 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += batDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound ClubHit"))
                                    M_Audio.PlayOneShotAudio("ClubHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio("Moan2");
                            }
                        }                      
                    }
                    else if (weaponList[randomWeaponNum] == "Hammer")
                    {
                        //Left top to bottom
                        if (randomPosNum == 0)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 0 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 3 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 6 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound HammerHit"))
                                    M_Audio.PlayOneShotAudio("HammerHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio_Delay("Moan2", moanDelay);
                            }                          
                        }
                        //Mid top to bottom
                        if (randomPosNum == 1)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 1 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 4 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 7 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound HammerHit"))
                                    M_Audio.PlayOneShotAudio("HammerHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio_Delay("Moan2", moanDelay);
                            }
                        }
                        //Right top to bottom
                        if (randomPosNum == 2)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 2 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 5 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 8 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += hammerDamage3;
                                satisfied = true;                             
                                if (!GameObject.Find("Sound HammerHit"))
                                    M_Audio.PlayOneShotAudio("HammerHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio_Delay("Moan2", moanDelay);
                            }
                        }                       
                    }
                    else if (weaponList[randomWeaponNum] == "Nunchucks")
                    {
                        //Left bottom to top
                        if (randomPosNum == 0)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 6 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 3 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 0 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound NunchucksHit"))
                                    M_Audio.PlayOneShotAudio("NunchucksHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio_Delay("Moan2", moanDelay2);
                            }
                        }
                        //Mid bottom to top
                        if (randomPosNum == 1)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 7 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 4 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 1 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound NunchucksHit"))
                                    M_Audio.PlayOneShotAudio("NunchucksHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio_Delay("Moan2", moanDelay2);
                            }
                        }
                        //Right bottom to top
                        if (randomPosNum == 2)
                        {
                            if (ganon.GetComponent<PlayerController>().blockIndex == 8 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage1;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 5 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage2;
                                satisfied = true;
                                if (!GameObject.Find("Sound BodyHit"))
                                    M_Audio.PlayOneShotAudio("BodyHit");
                                if (!GameObject.Find("Sound Moan1"))
                                    M_Audio.PlayOneShotAudio("Moan1");
                            }
                            else if (ganon.GetComponent<PlayerController>().blockIndex == 2 && !satisfied)
                            {
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].SetActive(true);
                                GanonGotHitList[ganon.GetComponent<PlayerController>().blockIndex].transform.GetChild(0).gameObject.SetActive(true);
                                HealthBarGroup.GetComponent<RainbowHPmanager>().hpBarList[HealthBarGroup.GetComponent<RainbowHPmanager>().hpIndex].GetComponent<HPbarHandler>().currentHealth += nunchucksDamage3;
                                satisfied = true;
                                if (!GameObject.Find("Sound NunchucksHit"))
                                    M_Audio.PlayOneShotAudio("NunchucksHit");
                                if (!GameObject.Find("Sound Moan2"))
                                    M_Audio.PlayOneShotAudio_Delay("Moan2", moanDelay2);
                            }
                        }
                    }
                    if (satisfied)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            ganon.GetComponent<PlayerController>().ganonPoseList[i].GetComponent<Image>().sprite = GanonNormalList[i];
                        }
                        if (!bgmSwitch)
                        {
                            string[] backgroundAudio = new string[1] { "BossFight" };
                            M_Audio.PlayLoopAudio(backgroundAudio);
                            bgmSwitch = true;
                        }
                    }                              
                }
                else if (ActiveTimer >= ActiveTime)
                {
                    if (!satisfied && !negativeProjectile)
                    {
                        if (!GameObject.Find("Sound Huh"))
                            M_Audio.PlayOneShotAudio("Huh");
                        for (int i = 0; i < 9; i++)
                        {
                            ganon.GetComponent<PlayerController>().ganonPoseList[i].GetComponent<Image>().sprite = GanonSadList[i];
                        }
                    }
                      
                    randomPosNum = -1;
                    coolDownTimer = 0;
                    coolDownTime = Random.Range(0.5f, 2);
                    startUpTimer = 0;
                    ActiveTimer = 0;
                    randomWeaponNum = Random.Range(1, weaponList.Count);
                    satisfied = false;
                    negativeProjectile = false;
                }
            }
        }
    }

}
