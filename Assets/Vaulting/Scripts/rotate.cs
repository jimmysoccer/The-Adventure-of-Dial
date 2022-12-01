using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    float x;
    public AudioClip audio;  //指定需要播放的音效
    private AudioSource source;   //必须定义AudioSource才能调用AudioClip

    void Start()
    {
        x = 0;
        source = GetComponent<AudioSource>();  //将this Object 上面的Component赋值给定义的AudioSource
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetKeyDown (KeyCode.LeftArrow) && controller.rotate_right_allowed) {
                x += 10; 
                source.Play();
            } else if(Input.GetKeyDown (KeyCode.RightArrow) && controller.rotate_left_allowed) {
                x -= 10;
                source.Play();
            }
            transform.rotation = Quaternion.Euler(0,0,x); 
    }
}
