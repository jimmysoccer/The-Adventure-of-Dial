using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingUICtrl : MonoBehaviour
{
  public GameObject StartCanvas;
  public GameObject RopeObj;
  public GameObject StartBtn;
  public GameManager gameManager;

  public void Start(){
    RopeObj.SetActive(false);
  }

  public void BackButton(){
    StartCanvas.SetActive(true);
  }

  public void ShowRope(){
    RopeObj.SetActive(true);
    StartBtn.SetActive(false);
    gameManager.CanTimer = true;
  }
}
