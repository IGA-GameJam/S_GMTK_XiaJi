using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        string[] backgroundAudio = new string[1] { "EpicBossFight" };
        M_Audio.PlayLoopAudio(backgroundAudio);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
