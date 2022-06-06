using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float animTime = 2f;

    public Image fadeImage;

    private float start = 0f;
    private float end = 1f;
    private float time = 0f;

    bool go=false;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        go = true;


    }

    // Update is called once per frame
    void Update()
    {
        if(go == true)
        PlayFadeIn();
    }

    void PlayFadeIn()
    {
        time += Time.deltaTime / animTime;

        Color color = fadeImage.color;

        color.a = Mathf.Lerp(start, end, time);

        fadeImage.color = color;
    }
}
