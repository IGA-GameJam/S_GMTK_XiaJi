using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject attackManager;

    public void Hide()
    {
        if (attackManager.GetComponent<AttackManager>().weaponList[attackManager.GetComponent<AttackManager>().randomWeaponNum] == "Whip")
            this.gameObject.SetActive(false);
 
        else if (attackManager.GetComponent<AttackManager>().weaponList[attackManager.GetComponent<AttackManager>().randomWeaponNum] == "Bat")
        {
            foreach (GameObject BatAttack in attackManager.GetComponent<AttackManager>().BatAttackList)
            {
                if(BatAttack.name == this.name)
                {
                    BatAttack.SetActive(false);
                }
            }
        }
        else if (attackManager.GetComponent<AttackManager>().weaponList[attackManager.GetComponent<AttackManager>().randomWeaponNum] == "Hammer")
        {
            foreach (GameObject HammerAttack in attackManager.GetComponent<AttackManager>().HammerAttackList)
            {
                if (HammerAttack.name == this.name)
                {
                    HammerAttack.SetActive(false);
                }
            }
        }
        else if (attackManager.GetComponent<AttackManager>().weaponList[attackManager.GetComponent<AttackManager>().randomWeaponNum] == "Nunchucks")
        {
            foreach (GameObject NunchucksAttack in attackManager.GetComponent<AttackManager>().NunchucksAttackList)
            {
                if (NunchucksAttack.name == this.name)
                {
                    NunchucksAttack.SetActive(false);
                }
            }
        }
        else if (attackManager.GetComponent<AttackManager>().weaponList[attackManager.GetComponent<AttackManager>().randomWeaponNum] == "Potion")
        {
            foreach (GameObject PotionAttack in attackManager.GetComponent<AttackManager>().PotionAttackList)
            {
                if (PotionAttack.name == this.name)
                {
                    PotionAttack.SetActive(false);
                }
            }
        }
        else if (attackManager.GetComponent<AttackManager>().weaponList[attackManager.GetComponent<AttackManager>().randomWeaponNum] == "Pillow")
        {
            foreach (GameObject PillowAttack in attackManager.GetComponent<AttackManager>().PillowAttackList)
            {
                if (PillowAttack.name == this.name)
                {
                    PillowAttack.SetActive(false);
                }
            }
        }
        attackManager.GetComponent<AttackManager>().randomWeaponNum = 0;
    }

}
