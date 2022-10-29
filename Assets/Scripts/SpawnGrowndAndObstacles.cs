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
    public GameObject tree;
    public int crowd;
 

    private Vector3 currentGroundPosition;
    public GameObject[] obstaclesPrefab;
    int countLines;
    Vector3 obstaclesPosition;
    int countObstaclesLine;
    float xpos;
    float lastXpos;
    float nowXpos;
    GameObject currentObstacle;
    float lastObstacleScaleX;
    // Start is called before the first frame update
    void Start()
    {
        currentGroundPosition = groundPrefab.transform.position;
        currentGroundPosition.z = currentGroundPosition.z + rangeSpawn;
        obstaclesPosition = player.transform.position;
        obstaclesPosition.y = -0.4f;
        obstaclesPosition.z = obstaclesPosition.z + groundPrefab.transform.localScale.z;
        countLines = (int) (groundPrefab.transform.localScale.z / crowd);
        
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if(player.transform.position.z > currentGroundPosition.z)
        {
            CreateRoad();
            CreeateEnviroment(20,(int)currentGroundPosition.z,80,(int)groundPrefab.transform.localScale.z,tree);
            CreeateEnviroment(-100,(int)currentGroundPosition.z,80,(int)groundPrefab.transform.localScale.z,tree);
 
            
    
            for (int j = 0; j < countLines; j++)
            {
                
                
                countObstaclesLine = Range(1,4);
                
                for (int i = 0; i < countObstaclesLine; i++)
                {
                        
                    
                    nowXpos = Range(-20,20);
                    currentObstacle = obstaclesPrefab[Range(0,obstaclesPrefab.Length)];
                    
                    if( Math.Abs(nowXpos-lastXpos) > (5 - currentObstacle.transform.localScale.x) * 2f + 1){
                        
                        obstaclesPosition.x = nowXpos; 
                        
                        Instantiate(currentObstacle, new Vector3(obstaclesPosition.x,obstaclesPosition.y,obstaclesPosition.z + Range(-6,6)), Quaternion.identity);
                        lastXpos = obstaclesPosition.x;
                       
                    }
                    else
                    {
                        i -= 1;
                    }
                    
                    
                    obstaclesPosition.z = obstaclesPosition.z + (crowd/2);
                    
                   
                }
                 
       
            }
        }
        
        
    }

    void CreateRoad()
    {
        currentGroundPosition.z = currentGroundPosition.z + groundPrefab.transform.localScale.z + Math.Abs(rangeSpawn);
        Instantiate(groundPrefab, currentGroundPosition, Quaternion.identity);      
        currentGroundPosition.z = currentGroundPosition.z - Math.Abs(rangeSpawn); 
    }

    void CreeateEnviroment(int x, int z, int a , int b, GameObject obj) 
    {
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
