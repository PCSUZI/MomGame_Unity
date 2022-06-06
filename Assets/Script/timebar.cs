using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timebar : MonoBehaviour
{
    public RectTransform Timebar;

    float fallBackTime = 605; // 크기를 고려함.

    public GameObject win;
    public GameObject lose;

    public GameObject restart;
    public GameObject MainBG;
    public GameObject Player;

    //사운드
    private AudioSource winaudio;
    public AudioClip winSound;


    bool sound = false;




    float time = 0.0f;
    public GameObject FadeIn;
  

    // Start is called before the first frame update
    void Start()
    {
        win.active = false;
        lose.active = false;
        restart.active = false;
        Time.timeScale = 1;
        MainBG.active = true;
        Player.active = true;
        sound = false;

        //사운드
        this.winaudio = this.gameObject.AddComponent<AudioSource>();
        this.winaudio.clip = this.winSound;
        this.winaudio.loop = false;
        FadeIn.active = true;

        time = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {


        time += Time.deltaTime;

        if (time >= 3.0f)
        {
            FadeIn.active = false;
            time = 0.0f;
        }




        Timebar.sizeDelta = new Vector2(fallBackTime, 13);


            // Time.deltaTime*50만큼 줄어듬

            fallBackTime = fallBackTime - (Time.deltaTime * 30);

            // 사이즈 재조정           

            Timebar.sizeDelta = new Vector2(fallBackTime, 13);


        // 0보다 작거나 같다면 종료.
        if (PlayerClean.score >= 15)
        {
            MainBG.active = false;
            win.active = true;
            restart.active = true;
            Time.timeScale = 0;
            Player.active = false;

            if (sound == false)
            {
                this.winaudio.Play();
                    sound = true;
             }
        }

        if (fallBackTime <= 0)
        {
           Finish();
        } 

    }

    void Finish()
    {
        Time.timeScale = 0;
        MainBG.active = false;
        lose.active = true;
        restart.active = true;
        Player.active = false;


    }
}