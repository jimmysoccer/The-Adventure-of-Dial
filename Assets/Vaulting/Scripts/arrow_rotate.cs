using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_rotate : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1;
    public Transform center;
    public float radius = 18;
    public float zAngle;
    Vector3 vec;
    float progress = 0f;
    public static int curr_value = 3;

    void Start()
    {
        zAngle = 0;
        curr_value = 3;
    }


    // Update is called once per frame
    void Update()
    {
            if(controller.curr_r % 2 == 0) {
            if(Input.GetKeyDown (KeyCode.LeftArrow)) {
                progress -= (float)0.5225;
                zAngle = -25f;
                transform.Rotate(0,0,zAngle,0);
                curr_value += 1;
                if(curr_value == 13) {
                    curr_value = 1;
                }
            }
        } else {
            if(Input.GetKeyDown (KeyCode.RightArrow)) {
                progress += (float)0.5225;
                zAngle = 25f; 
                transform.Rotate(0,0,zAngle,0);
                curr_value -= 1;
                if(curr_value == 0) {
                    curr_value = 12;
                }
                //transform.Rotate(0,0,zAngle,Space.Self);
                //vec = new Vector3(23.1f,1.2f, zAngle);
                //transform.RotateAround(vec, Vector3.forward, zAngle);
            }
        }
        if(progress >= 360) {
            progress -= 360;
        }
        float x1 = center.position.x + radius * Mathf.Cos(progress);
        float y1 = center.position.y + radius * Mathf.Sin(progress);
        this.transform.position = new Vector3(x1, y1);
        }
    
}
