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
    }
}
