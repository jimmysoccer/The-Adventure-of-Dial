using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingGameManager : MonoBehaviour
{
    static FallingGameManager instance;
    public Text timeScore;
    public GameObject gameOverUI;
    private static GameObject bgm;
    
    void Start(){
        bgm = GameObject.Find("BGM");
    }

    private void Awake() {
        if (instance != null){
            Destroy(gameObject);
                
        }
        instance = this;
    }

    void Update()
    {
        timeScore.text = Time.timeSinceLevelLoad.ToString("00");
    }

    public void RestartGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
    
    public void quitGame(){
        Application.Quit();
    }

    public void Resume(){

        
        instance.gameOverUI.SetActive(false);
        Time.timeScale = 1;
        // bgm.SetActive(true);
       // GameObject.Find("BGM").SetActive(true);


    }

    public void backToMain(){
        Time.timeScale = 1f;


        SceneManager.LoadScene(0);
        
    }
    


    public static void GameOver(bool dead){

        instance.gameOverUI.SetActive(true);
        Time.timeScale = 0f;


        if(dead){

            GameObject.Find("resume").SetActive(false);
            bgm.SetActive(false);


            //GameObject.FindGameObjectWithTag("resume").SetActive(false);
        }
        
       
    }


}
