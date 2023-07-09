using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class M_Global : MonoBehaviour
{
    public static M_Global Instance;
    public SO_AudioRepo repo_Audio;

    //public Image cha;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
      
    }

    void Start()
    {
        //string[] backgroundAudio = new string[1] { "BossFight" };
        //M_Audio.PlayLoopAudio(backgroundAudio);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.L))
        {
            Sequence s = DOTween.Sequence();
            s.Append(cha.transform.DOMoveX(1000, 1));
            s.AppendInterval(1);
            s.AppendCallback(() => DOTween.To(() => cha.color, x => cha.color = x, new Color(0, 0, 0, 0), 2));
            s.Append(cha.transform.DOScale(0, 2));  
        }
        */

        //SpriteRenderer spr;
        //spr.DOFade

        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            string[] backgroundAudio = new string[1] { "Dark World" }; 
            M_Audio.PlayLoopAudio(backgroundAudio);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            M_Audio.PlayOneShotAudio("Bubble");
        }
        */
    }
}
