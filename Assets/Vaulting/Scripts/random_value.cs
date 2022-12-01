using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_value : MonoBehaviour
{
    // Start is called before the first frame update
    public static int[] r;
    void Start()
    {
        r = new int[4];
        r[0] = Random.Range(0,13);
        while(r[0] == 0) r[0] = Random.Range(0,13);
        r[1] = Random.Range(0,13);
        while(r[1] == r[0]) r[1] = Random.Range(0,13);
        r[2] = Random.Range(0,13);
        while(r[2] == r[0] || r[1] == r[2]) r[2] = Random.Range(0,13);
        r[3] = 1;
        Debug.Log(r[0]);
        Debug.Log(r[1]);
        Debug.Log(r[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
