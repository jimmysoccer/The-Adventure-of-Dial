using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    public float spawnTime;
    private float countTime;
    private Vector3 spawnPosition;
  
    
    void Update()
    {
        SpawnPlatform();
    }

    // public void SpawnPlatform(){
    //     countTime += Time.deltaTime;
    //     spawnPosition = transform.position;
    //     spawnPosition.x = Random.Range(-3.5f, 3.5f);

    //     if(countTime >= spawnTime)
    //     {
    //         Create();
    //         countTime = 0;

    //     }
    public void SpawnPlatform(){
        countTime +=  Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-4f, 4f);

        if(countTime >= spawnTime){
            CreatePlatform();
            countTime = 0;
        }
    }
    // }

    // public void Create()
    // {
    //     int index = Random.Range(0, platforms.Count);
    //     // int spikeNum = 0;

    //     // if (index == 4){
    //     //     spikeNum ++;
    //     // }

    //     // if (spikeNum > 1){
    //     //     spikeNum = 0;
    //     //     countTime = spawnTime;
    //     //     return;
    //     // }

    //     GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
    //     newPlatform.transform.SetParent(this.gameObject.transform);
    // }
    public void CreatePlatform(){
        int index = Random.Range(0, platforms.Count);
        int spikeNum = 0;
        if(index == 4){
            spikeNum++;
        }
        if(spikeNum > 1){
            spikeNum = 0;
            countTime = spawnTime;
            return;
        }
        
        GameObject newPlatform;
        if(index == 4){
            spawnPosition.x = Random.Range(-1.8f, 5.5f);
            newPlatform = Instantiate(platforms[4], spawnPosition, Quaternion.identity);
        }
        else{
            newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
        }
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
}
