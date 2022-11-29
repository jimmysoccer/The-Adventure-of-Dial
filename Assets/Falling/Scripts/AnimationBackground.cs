using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBackground : MonoBehaviour
{
    Material material;
    Vector2 movement;

    public Vector2 speed;

    // Start is called before the first frame update
    void Start()
    {
        //since the texture is under renderer
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //change the offset based on the speed
        movement += speed * Time.deltaTime;
        material.mainTextureOffset = movement;
    }
}
