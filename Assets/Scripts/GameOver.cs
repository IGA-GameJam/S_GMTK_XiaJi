using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool win;
    public bool lose;

    void Start()
    {
        if(win)
            M_Audio.PlayOneShotAudio("Win");
        else if (lose)
            M_Audio.PlayOneShotAudio("Lose");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
