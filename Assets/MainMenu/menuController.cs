using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void navigateToGame(int index){
        SceneManager.LoadScene(index);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")){
            navigateToGame(1);
        }
        if(Input.GetKeyDown("2")){
            navigateToGame(2);
        }
        if(Input.GetKeyDown("3")){
            navigateToGame(3);
        }
        if(Input.GetKeyDown("4")){
            navigateToGame(4);
        }
        if(Input.GetKeyDown("5")){
            navigateToGame(5);
        }
    }
}
