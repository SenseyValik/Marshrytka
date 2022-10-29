using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.Random;

public class SpawnGrowndAndObstacles : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject player;
    public int rangeSpawn;
    public GameObject[] enviromentObjects;
    Vector3 currentGroundPosition;

  
    // Start is called before the first frame update
    void Start()
    {
        
        currentGroundPosition = groundPrefab.transform.position;
        currentGroundPosition.z = currentGroundPosition.z + rangeSpawn;
        Debug.Log(currentGroundPosition);
        
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if(player.transform.position.z > currentGroundPosition.z)
        {
            CreateRoad();
            CreeateEnviroment(20,(int)currentGroundPosition.z,80,(int)groundPrefab.transform.localScale.z,enviromentObjects[0]);
            CreeateEnviroment(-100,(int)currentGroundPosition.z,80,(int)groundPrefab.transform.localScale.z,enviromentObjects[0]);
        }
        
        
    }

    void CreateRoad()
    {
        currentGroundPosition.z = currentGroundPosition.z + groundPrefab.transform.localScale.z + Math.Abs(rangeSpawn);
        Instantiate(groundPrefab, currentGroundPosition, Quaternion.identity);      
        currentGroundPosition.z = currentGroundPosition.z - Math.Abs(rangeSpawn); 
    }

    void CreeateEnviroment(int x, int z, int a , int b, GameObject obj) {
        // x,z = кординати області в якій треба генерувати об`єкти (по нижньому лівому краю)
        //a,b - розмір області
        Vector3 pos;
        int count = Range(30,50);
        for (int i = 0; i < count; i++)
        {
            pos = new Vector3(Range(x,x+a),obj.transform.position.y,Range(z,z+b));
            Instantiate(obj, pos, Quaternion.identity);
        }

        
    }
}
