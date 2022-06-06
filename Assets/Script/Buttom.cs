using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttom : MonoBehaviour
{
    public GameObject Why;
    static bool why_check=false;

    private AudioSource audio;
    public AudioClip ExitSound;

    private AudioSource audio2;
    public AudioClip whySound;

    private AudioSource audio3;
    public AudioClip startSound;

    private AudioSource audio4;
    public AudioClip restartSound;

    public GameObject FadeOut;

    bool start = false;
    bool end = false;

    float time;

    // Use this for initialization
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.ExitSound;
        this.audio.loop = false;

        this.audio2 = this.gameObject.AddComponent<AudioSource>();
        this.audio2.clip = this.whySound;
        this.audio2.loop = false;

        this.audio3 = this.gameObject.AddComponent<AudioSource>();
        this.audio3.clip = this.startSound;
        this.audio3.loop = false;

        this.audio4 = this.gameObject.AddComponent<AudioSource>();
        this.audio4.clip = this.restartSound;
        this.audio4.loop = false;

        FadeOut.active = false;

        start = false;
        end = false;

    }

    // Update is called once per frame
    void Update()
    {
     if(start==true||end==true)
        {
            FadeOut.active = true;

            time+= Time.deltaTime;

            if (time >= 3.0f)
            {
                if (start == true)
                {
                    SceneManager.LoadScene("Game");
                }
                else if (end == true)
                {
                    Application.Quit();
                }

                time = 0.0f;
            }

        }

    }

    public void OnclickExit()
    {
        this.audio.Play();

        if (why_check == false)
            end = true;
        if (why_check==true)
        {
            Why.SetActive(false);
            why_check = false;
        }
       
        
    }
    public void Onclickstart()
    {
        this.audio3.Play();
        start = true;
       // 
    }
    public void OnclickWhy()
    {
        this.audio2.Play();

        if (why_check == false)
        {
            Why.SetActive(true);
            why_check = true;
        }

    }

    public void OnclickRestart()
    {
        this.audio4.Play();
        SceneManager.LoadScene("SampleScene");
    }
}
