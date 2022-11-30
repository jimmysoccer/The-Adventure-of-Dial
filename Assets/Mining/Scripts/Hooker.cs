using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooker : MonoBehaviour
{
    public RopeManager ropeManager;
    private SpriteRenderer sr;
    public GameManager gameManager;
    public Sprite Openprite;
    [HideInInspector]
    public float HookObjectCost;
    bool canAddNum = false;

    public void Start(){
      ropeManager = GetComponentInParent<RopeManager>();
      sr = GetComponent<SpriteRenderer>();
    }

    public void Update(){
      if(ropeManager.ropeState == RopeState.Elongation){
        transform.GetComponent<CircleCollider2D>().enabled = true;
      }
      if(ropeManager.ropeLength <= 1){
        if(canAddNum){
          gameManager.Refresh(HookObjectCost);
          canAddNum = false;
        }
        // if(Input.GetKeyDown(KeyCode.Space)){
        //   gameManager.Refresh(HookObjectCost);
        //   canAddNum = false;
        // }
        if(transform.childCount > 0){
          Destroy(transform.GetChild(0).gameObject);
        }
      }
    }


    public void OnTriggerEnter2D(Collider2D col){
      ropeManager.ropeState = RopeState.Shorten;
      col.transform.parent = transform;
      col.transform.localPosition=Vector3.zero;
      transform.GetComponent<CircleCollider2D>().enabled = false;
      col.GetComponent<PolygonCollider2D>().enabled = false;
      if(col.transform.tag=="Mineral1"){
        ropeManager.RopeScaleSpeed = 0.5f;
        HookObjectCost = col.GetComponent<Values>().Cost;
        canAddNum = true;
      }
      if(col.transform.tag=="Mineral2"){
        ropeManager.RopeScaleSpeed = 0.5f;
        HookObjectCost = col.GetComponent<Values>().Cost;
        canAddNum = true;
      }
      if(col.transform.tag=="Gold"){
        ropeManager.RopeScaleSpeed = 1f;
        HookObjectCost = col.GetComponent<Values>().Cost;
        canAddNum = true;
      }
      if(col.transform.tag=="MediumGold"){
        ropeManager.RopeScaleSpeed = 1f;
        HookObjectCost = col.GetComponent<Values>().Cost;
        canAddNum = true;
      }
      if(col.transform.tag=="Diamond"){
        ropeManager.RopeScaleSpeed = 2f;
        HookObjectCost = col.GetComponent<Values>().Cost;
        canAddNum = true;
    }
}
}
