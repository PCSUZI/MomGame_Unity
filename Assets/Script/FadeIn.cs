using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float animTime = 2f;

    public Image fadeImage;

    private float start = 1f;
    private float end = 0f;
    private float time = 0f;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
