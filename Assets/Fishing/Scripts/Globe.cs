using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : MonoBehaviour {

    public float Speed;
    public float A;
    public float Col;
    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("Manage").GetComponent<Manage>().Sound == 0)
        {
            GameObject.Find("Globe").GetComponent<AudioSource>().Play();
        }
        Speed = Random.Range(1f, 1.5f);
        Col = 1;
        StartCoroutine(Des());

    }

    // Update is called once per frame
    void Update()
    {
        Col -= A * Time.deltaTime;
        Color color = GetComponent<SpriteRenderer>().material.color;
        color.a = Col;
        color.r = 1f;
        color.g = 1f;
        color.b = 1f;
        GetComponent<SpriteRenderer>().material.SetColor("_Color", color);



        transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
    }
    IEnumerator Des()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }




}
