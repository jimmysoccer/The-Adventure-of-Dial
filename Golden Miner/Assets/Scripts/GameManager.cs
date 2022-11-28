using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text GoldCostText;
    public Text TargetText;

    public Hooker hook;
    public RopeManager ropeManager;

    float BoxHasGolds = 0;

    public GameObject WinUI;
    public GameObject DefeatUI;

    public Text timer;
    public float Temptimer = 60;
    [HideInInspector]
    public bool CanTimer = false;
    bool isWin = false;

    public void Update(){
      if(CanTimer){
        Temptimer -= Time.deltaTime;
        timer.text = Temptimer.ToString("0.00");
      }

      if(Temptimer <= 0 && !isWin){
        Temptimer = 0;
        DefeatUI.SetActive(true);
      }
    }

    public void Refresh(float value){
      BoxHasGolds += value;
      TargetText.text = BoxHasGolds.ToString();
      // int status = TargetText.text.CompareTo(GoldCostText.text);
      // if(status == -1){
      //   WinUI.SetActive(true);
      // }
      if(TargetText.text.Equals(GoldCostText.text)){
        isWin = true;
        WinUI.SetActive(true);
      }
      if(GoldCostText.text.Length <= TargetText.text.Length){
        isWin = true;
        WinUI.SetActive(true);
      }
    }
}
