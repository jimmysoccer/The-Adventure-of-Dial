using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1;
    public Transform center;
    float radius = 10;
    public static int curr_r;
    int curr = 0;
    float position;
    public static int curr_point = 3;
    bool run = true;
    public static bool rotate_left_allowed = false;
    public static bool rotate_right_allowed = true;
    public GameObject instru_R;
    public GameObject instru_L;
    public GameObject opened;

    //test
    public float cr;
    public int point;
    public int arrow;
    public bool ll = false;
    public bool rr = true;

    void Start()
    {
        curr_r = 0; 
        rotate_left_allowed = false;
        rotate_right_allowed = true;  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
        
        float r = random_value.r[curr_r];
        cr = r;
        //progress = r * 15;
        //progress += Time.deltaTime * speed;
        // if(curr == curr_r) {
        //     for(int i = 0; i < r; ++i) {
        //         if(i % 2 == 0) {
        //             position += (float)0.5;
        //         }else {
        //             position += (float)0.55;
        //         }
        //         if(progress >= 360) {
        //             progress -= 360;
        //         }
        //     }
        //     curr += 1;
        // }
        float progress = 0;
        if(run) curr_point = 3;
        for(int i = 0; i < r; ++i) {
            if(i % 2 == 0) {
                progress += (float)0.5;
            }else {
                progress += (float)0.55;
            }
            if (run) {
                curr_point -= 1;
                if(curr_point == 0) {
                    curr_point = 12;
                }
            }
        }
        curr_point = Mathf.Abs(curr_point);
        point = curr_point;
        arrow = arrow_rotate.curr_value;
        run = false;
        //if(progress != position) progress += (float)0.01;
        float x1 = center.position.x + radius * Mathf.Cos(progress);
        float y1 = center.position.y + radius * Mathf.Sin(progress);
        this.transform.position = new Vector3(x1, y1);

        if(arrow_rotate.curr_value == curr_point) {
            curr_r += 1;
            run = true;
            if(rotate_left_allowed) {
                rotate_left_allowed = false;
                rotate_right_allowed = true;
                ll = false;
            } else {
                rotate_left_allowed = true;
                rotate_right_allowed = false;
                ll = true;
            }
            // if(rotate_right_allowed) {
            //     rotate_right_allowed = false;
            //     rotate_left_allowed = true;
            //     rr = false;
            // } else {
            //     rotate_right_allowed = true;
            //     rotate_left_allowed = false;
            //     rr = true;
            // }
            if(rotate_left_allowed) {
                instru_L.SetActive(true);
                instru_R.SetActive(false);
            }else {
                instru_L.SetActive(false);
                instru_R.SetActive(true);
            }
            if(curr_r >= 3) {
                opened.SetActive(true);
            }
        }
    }
}
