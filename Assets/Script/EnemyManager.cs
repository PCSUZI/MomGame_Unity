using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject DummyPrefab;
    float span = 2.0f;
    float span2 = 1.0f;

    float delta = 0;
    float delta2 = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        this.delta2 += Time.deltaTime;

        if (this.delta>this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(EnemyPrefab) as GameObject;
            int px = Random.Range(-8, 8);
            go.transform.position = new Vector3(px, 7, 0);
        }

        if (this.delta2 > this.span2)
        {
            this.delta2 = 0;
            GameObject go = Instantiate(DummyPrefab) as GameObject;
            int px = Random.Range(-8, 8);
            go.transform.position = new Vector3(px, -1.8451f, 0);
        }
    }
}
