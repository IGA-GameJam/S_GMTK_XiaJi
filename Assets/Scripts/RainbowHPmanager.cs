using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class RainbowHPmanager : MonoBehaviour
{
    public int hpIndex = 0;
    public bool calculated;
    public float hpDropRate = 1f;
    public List<GameObject> hpBarList = new List<GameObject>();

    void FixedUpdate()
    {
        if (hpBarList[0].GetComponent<HPbarHandler>().currentHealth < 0)
            SceneManager.LoadScene("Lose");
        if (hpBarList[4].GetComponent<HPbarHandler>().currentHealth > 10)
            SceneManager.LoadScene("Win");

        if (hpIndex < 4 && hpBarList[hpIndex].GetComponent<HPbarHandler>().currentHealth > hpBarList[hpIndex].GetComponent<HPbarHandler>().maxHP)
        {
            float difference = hpBarList[hpIndex].GetComponent<HPbarHandler>().currentHealth - hpBarList[hpIndex].GetComponent<HPbarHandler>().maxHP;
            hpIndex++;
            hpBarList[hpIndex].SetActive(true);
            hpBarList[hpIndex - 1].GetComponent<HPbarHandler>().currentHealth = hpBarList[hpIndex-1].GetComponent<HPbarHandler>().maxHP;
            hpBarList[hpIndex - 1].GetComponent<HPbarHandler>().hpDropRate = 0;
            hpBarList[hpIndex].GetComponent<HPbarHandler>().currentHealth += difference;
        }

        if (hpIndex > 0 && hpBarList[hpIndex].GetComponent<HPbarHandler>().currentHealth < 0)
        {
            float difference = Mathf.Abs(hpBarList[hpIndex].GetComponent<HPbarHandler>().currentHealth);
            hpBarList[hpIndex].SetActive(false);
            hpIndex--;
            hpBarList[hpIndex].SetActive(true);
            hpBarList[hpIndex + 1].GetComponent<HPbarHandler>().currentHealth = 0;
            hpBarList[hpIndex].GetComponent<HPbarHandler>().currentHealth -= difference;
            hpBarList[hpIndex].GetComponent<HPbarHandler>().hpDropRate = hpDropRate;
        }

    }
}
