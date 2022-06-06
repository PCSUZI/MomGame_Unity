using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = -0.07f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);

        if (transform.position.y < -4.5f)
        {
            Destroy(gameObject);
        }
    }
}
