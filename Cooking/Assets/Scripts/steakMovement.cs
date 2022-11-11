using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=System.Random;

public class steakMovement : MonoBehaviour
{
    //set image variables
    public Sprite blueRawMeat;
    public Sprite rawMeat;
    public Sprite mediumMeat;
    public Sprite wellDoneMeat;
    public Sprite overcookedMeat;

    //set fire speed rate
    private const float bigFireSpeed = 10.0f;
    private const float middleFireSpeed = 6.6f;
    private const float smallFireSpeed = 4.5f;

    //set degree of meat
    private const int blueRawDegree = 0;
    private const int rawDegree = 1;
    private const int mediumDegree = 2;
    private const int wellDoneDegree = 3;
    private const int overcookedDegree = 4;

    //set meat completeness
    private float[] bigFireCompleteness;
    private float[] middleFireCompleteness;
    private float[] smallFireCompleteness;
    private float[] meatCompleteness;
    //盘上的肉第一次点击出肉，第二次点击提交菜单
    private bool[] panHasMeat;

    //record time
    private float[] levelTimer;
    private float[] leftTime; //record the time before change fire
    private float[,] timeInterval; // 4 * 3 array, 4 pans vs 3 type of fire, small -> middle -> big fire
    private bool updateTimer;

    private bool passTime;
    private int[] previousFire;

    private bool controlTimeIntervalIncrement;

    void hideMeat(int index){
        GameObject.Find("meat"+(index+1).ToString()).transform.position = new Vector2(-85f,44f);
        panHasMeat[index] = false;
    }

    void updateOrderByIndex(int index){
        if(index>=orderController.meatDegree.Count){
            print("not enough order");
            return;
        }
        Random rnd = new Random();
        int num = rnd.Next(rawDegree,wellDoneDegree+1);
        orderController.moveOrderIndex = index;
        if(index==0){
            GameObject.Find("menu1").transform.position = new Vector2(-85f,44f);
            GameObject.Find("menu1").name = "temp";
            GameObject.Find("menu2").name = "menu1";
            GameObject.Find("menu3").name = "menu2";
            GameObject.Find("menu4").name = "menu3";
            GameObject.Find("temp").name = "menu4";

            GameObject.Find("menu-meat1").name = "temp";
            GameObject.Find("menu-meat2").name = "menu-meat1";
            GameObject.Find("menu-meat3").name = "menu-meat2";
            GameObject.Find("menu-meat4").name = "menu-meat3";
            GameObject.Find("temp").name = "menu-meat4";
        }
        if(index == 1){
            GameObject.Find("menu2").transform.position = new Vector2(-85f,44f);
            GameObject.Find("menu2").name = "temp";
            GameObject.Find("menu3").name = "menu2";
            GameObject.Find("menu4").name = "menu3";
            GameObject.Find("temp").name = "menu4";

            GameObject.Find("menu-meat2").name = "temp";
            GameObject.Find("menu-meat3").name = "menu-meat2";
            GameObject.Find("menu-meat4").name = "menu-meat3";
            GameObject.Find("temp").name = "menu-meat4";
        }
        if(index == 2){
            GameObject.Find("menu3").transform.position = new Vector2(-85f,44f);
            GameObject.Find("menu3").name = "temp";
            GameObject.Find("menu4").name = "menu3";
            GameObject.Find("temp").name = "menu4";
            
            GameObject.Find("menu-meat3").name = "temp";
            GameObject.Find("menu-meat4").name = "menu-meat3";
            GameObject.Find("temp").name = "menu-meat4";
        }
        if(index == 3){
            GameObject.Find("menu4").transform.position = new Vector2(-85f,44f);
        }
        orderController.meatDegree[index] = num;
        for(int i = 0;i<orderController.meatDegree.Count;i++){
            if(i == 3){
                orderController.meatDegree[i] = num;
                GameObject.Find("menu-meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = 
                    num==rawDegree?rawMeat:num==mediumDegree?mediumMeat:num==wellDoneDegree?wellDoneMeat:rawMeat;
            }else if(i>=index){
                orderController.meatDegree[i] = orderController.meatDegree[i+1];
                GameObject.Find("menu-meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = 
                    orderController.meatDegree[i+1]==rawDegree?
                    rawMeat:orderController.meatDegree[i+1]==mediumDegree?
                    mediumMeat:orderController.meatDegree[i+1]==wellDoneDegree?
                    wellDoneMeat:rawMeat;
            }
        }
        print("order menu: "+orderController.meatDegree[0]+" "+orderController.meatDegree[1]+" "+orderController.meatDegree[2]+" "+orderController.meatDegree[3]+" \n");
    }

    void addPoint(int point){
        //TODO if have time, add a satisfaction bar, based on satisfaction level, add points, 1 -> 3
        pointController.points += point;
    }

    void minusPoint(int point){
        if(pointController.points!=0){
            pointController.points -= point;
        }
    }

    void submitOrder(int index){
        print("submit order index: "+index);
        int meatStatus = 1;
        if(meatCompleteness[index]<30){
            meatStatus = blueRawDegree;
        }else if(meatCompleteness[index]>30&&meatCompleteness[index]<50){
            meatStatus = rawDegree;
        }else if(meatCompleteness[index]>50&&meatCompleteness[index]<80){
            meatStatus = mediumDegree;
        }else if(meatCompleteness[index]>80&&meatCompleteness[index]<110){
            meatStatus = wellDoneDegree;
        }else if(meatCompleteness[index]>110){
            meatStatus = overcookedDegree;
        }
        for(int i=0;i<orderController.meatDegree.Count;i++){
            if(orderController.meatDegree[i]==meatStatus){
                updateOrderByIndex(i);
                addPoint(1);
                return;
            }
        }
        minusPoint(1);
        print("submit order doesn't find correct order");
    }

    // Start is called before the first frame update
    void Start()
    {
        bigFireCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        middleFireCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        smallFireCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        meatCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        panHasMeat = new bool[]{false,false,false,false};
        levelTimer = new float[]{0.0f,0.0f,0.0f,0.0f};
        leftTime = new float[]{0.0f,0.0f,0.0f,0.0f};
        timeInterval = new float[,]{{0.0f,0.0f,0.0f},{0.0f,0.0f,0.0f},{0.0f,0.0f,0.0f},{0.0f,0.0f,0.0f}};
        previousFire = new int[]{3,3,3,3};
        updateTimer = true;
        for(int i=0;i<4;i++){
            hideMeat(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //record time
        if(updateTimer){
            for(int i=0;i<levelTimer.Length;i++){
                levelTimer[i] += Time.deltaTime;
            }
        }
        //check current pan and current fire
        int currentPan = PanController.currentPan;
        int[] currentFire = fireController.currentFire;

        if(Input.GetKeyDown(KeyCode.Return)){
            if(panHasMeat[currentPan-1]==false){
                GameObject.Find("meat"+(currentPan).ToString()).transform.position = new Vector2(
                    currentPan==1?-6.88f:currentPan==2?-2.65f:currentPan==3?2.3f:6.34f,-0.86f);
                panHasMeat[currentPan-1] = true;
                levelTimer[currentPan-1] = 0.0f;
            }else{
                //FIXME fix 按enter 无论false还是true都运行了，因为getkeydown太快
                // submit order
                // hideMeat(currentPan-1);
                // submitOrder(currentPan-1);
            }
        }

        if(Input.GetKeyDown("k")&&panHasMeat[currentPan-1]){
            //temporary submit order
            hideMeat(currentPan-1);
            submitOrder(currentPan-1);
        }

        for(int i=0;i<leftTime.Length;i++){

            //calculate completeness
            if(panHasMeat[i]){
                float currentTimeInterval = levelTimer[i] - leftTime[i] + timeInterval[i,currentFire[i]-1];
                switch(currentFire[i]){
                    case 3:
                        bigFireCompleteness[i] = currentTimeInterval * bigFireSpeed;
                        break;
                    case 2:
                        middleFireCompleteness[i] = currentTimeInterval * middleFireSpeed;
                        break;
                    case 1:
                        smallFireCompleteness[i] = currentTimeInterval * smallFireSpeed;
                        break;
                    default:
                        break;
                }
                meatCompleteness[i] = bigFireCompleteness[i]+middleFireCompleteness[i]+smallFireCompleteness[i];
                // print("meat completeness:"+meatCompleteness[i].ToString());
            }

            //detect if fire is changed
            if(previousFire[i]!=currentFire[i]){
                //calculate accumulated each fire's interval
                timeInterval[i,previousFire[i]-1] += levelTimer[i] - leftTime[i];
                // print("detected previous fire: "+previousFire[i].ToString()+"timeInterval: "+timeInterval[i,previousFire[i]-1]);
            
                leftTime[i] = levelTimer[i];
                //!!!!!!!!!NOTICE this must set [0] to [0] otherwise, the previous will be current, the same thing
                previousFire[i] = currentFire[i];
                }

            //check if meat is done, and its current status
            if(meatCompleteness[i]<30){
                GameObject.Find("meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = blueRawMeat;
            }else if(meatCompleteness[i]>30&&meatCompleteness[i]<50){
                GameObject.Find("meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = rawMeat;
            }else if(meatCompleteness[i]>50&&meatCompleteness[i]<80){
                GameObject.Find("meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = mediumMeat;
            }else if(meatCompleteness[i]>80&&meatCompleteness[i]<110){
                GameObject.Find("meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = wellDoneMeat;
            }else if(meatCompleteness[i]>110){
                GameObject.Find("meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = overcookedMeat;
            }
        }
    }
}
