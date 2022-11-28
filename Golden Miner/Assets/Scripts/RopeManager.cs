using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState{
  IDLE,
  Elongation,
  Shorten
}

public class RopeManager : MonoBehaviour
{
  private Vector3 Dir = Vector3.forward;
  public float ropeLength = 1;
  private float Speed = 30f;
  [HideInInspector]
  public RopeState ropeState;
  public GameObject hook;
  [HideInInspector]
  public float RopeScaleSpeed = 1;
  //float time = GameData.Gaming.Time;

  public void Update(){
    //time -= Time.time;
    if(ropeState == RopeState.IDLE){
      AlwaysRotate();
      // if(Input.GetMouseButtonDown(0)){
      //   ropeState = RopeState.Elongation;
      //   RopeScaleSpeed=1;
      // }
      if(Input.GetKeyDown(KeyCode.Space)){
        ropeState = RopeState.Elongation;
        RopeScaleSpeed=1;
      }
    }
    else if(ropeState == RopeState.Elongation){
      Elongation();
    }
    else if(ropeState == RopeState.Shorten){
      Shorten();
    }
  }
  public void AlwaysRotate(){
    // if(transform.localRotation.z<-0.6f){
    //   Dir = Vector3.forward;
    // }else if(transform.localRotation.z > 0.6f){
    //   Dir = Vector3.back;
    // }
    if(Input.GetKeyDown(KeyCode.D) || transform.localRotation.z<-0.6f){
      Dir = Vector3.forward;
      transform.Rotate(Dir * Speed * Time.deltaTime * 10);
    }else if(Input.GetKeyDown(KeyCode.A) || transform.localRotation.z>0.6f){
      Dir = Vector3.back;
      transform.Rotate(Dir * Speed * Time.deltaTime * 10);
    }
    // else if(transform.localRotation.z<-0.6f){
    //   Dir = Vector3.back;
    //   transform.Rotate(Dir * Speed * Time.deltaTime * 10);
    // }
    // else if(transform.localRotation.z > 0.6f){
    //   Dir = Vector3.forward;
    //   transform.Rotate(Dir * Speed * Time.deltaTime * 10);
    // }
    // transform.Rotate(Dir * Speed * Time.deltaTime);
  }
  public void Elongation(){
    if(ropeLength >= 3.5f){
      ropeState = RopeState.Shorten;
      return;
    }
    ropeLength += Time.deltaTime*RopeScaleSpeed;
    transform.localScale = new Vector3(transform.localScale.x,ropeLength,transform.localScale.z);
    hook.transform.localScale = new Vector3(hook.transform.localScale.x,1/ropeLength,hook.transform.localScale.z);
  }

  public void Shorten(){
    if(ropeLength <= 1f){
      ropeState = RopeState.IDLE;
      return;
    }
    ropeLength -= Time.deltaTime*RopeScaleSpeed;
    transform.localScale = new Vector3(transform.localScale.x,ropeLength,transform.localScale.z);
    hook.transform.localScale = new Vector3(hook.transform.localScale.x,1/ropeLength,hook.transform.localScale.z);
  }
}
