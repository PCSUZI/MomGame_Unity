using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerClean : MonoBehaviour
{
    public Text scoreLabel;
    static public int score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dummy")
        {
            collision.gameObject.SendMessage("Hit");
        }
    }

}
