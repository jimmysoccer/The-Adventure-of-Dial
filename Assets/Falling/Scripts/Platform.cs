using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //move all the obiject from bottom to up
    Vector3 movement;
    GameObject topLine;

    public float speed;
    
    void Start()
    {
        movement.y = speed;
        topLine = GameObject.Find("Topline");
    }

    
    void Update()
    {
        MovePlatform();
    }
    void MovePlatform()
    {
        transform.position += movement * Time.deltaTime;
        //touch or beyond the topline, then destory
        if(transform.position.y >= topLine.transform.position.y){

            Destroy(gameObject);

        }

    }
}
