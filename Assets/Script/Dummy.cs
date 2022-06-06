using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public int DummyHp = 300;

    float Detla;



    // Start is called before the first frame update
    void Start()
    {
        Detla = 0;
    }

    void Hit()
    {

        DummyHp -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (DummyHp <= 0)
        {
            Destroy(gameObject);
            PlayerClean.score += 1;
        }
        else
        {
            Detla += Time.deltaTime;

            if(Detla>5.0f)
            {
                Destroy(gameObject);
                Detla = 0.0f;
            }
        }
    }
}
