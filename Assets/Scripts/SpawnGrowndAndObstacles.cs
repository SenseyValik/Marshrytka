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
    public GameObject[] obstaclesPrefab;
    public GameObject firstObjects;

    private Vector3 currentGroundPosition;
    int countLines;
    Vector3 obstaclesPosition;
    int countObstaclesLine;
    float xpos;
    float lastXpos;
    float nowXpos;
    GameObject currentObstacle;
    float lastObstacleScaleX;
    private List<GameObject> createdObjects;
    int countCretedObjects = 0;
    List<int> countCreateatedObjectsList;
    int delStep = 0;
    
    void Start()
    {
        createdObjects.Add(firstObjects);
        countCretedObjects ++;
        currentGroundPosition = groundPrefab.transform.position;
        currentGroundPosition.z = currentGroundPosition.z + rangeSpawn;
        obstaclesPosition = player.transform.position;
        obstaclesPosition.z = obstaclesPosition.z + 80f;
        countLines = (int) (groundPrefab.transform.localScale.z / (crowd*1.7f));
        CreateObstacles();
        countCreateatedObjectsList.Add(countCretedObjects);
        countCretedObjects = 0;


        countLines = (int) (groundPrefab.transform.localScale.z / crowd);
        obstaclesPosition = player.transform.position;
        obstaclesPosition.z = obstaclesPosition.z + groundPrefab.transform.localScale.z;
        
        
    }

    
    void Update()
    {
   
        if(player.transform.position.z > currentGroundPosition.z)
        {
            CreateRoad();
            CreeateEnviroment(25,(int)currentGroundPosition.z,80,(int)groundPrefab.transform.localScale.z,tree);
            CreeateEnviroment(-100,(int)currentGroundPosition.z,75,(int)groundPrefab.transform.localScale.z,tree);
            CreateObstacles();
            countCreateatedObjectsList.Add(countCretedObjects);
            if(delStep == 2){
               // DestroyObjects();
                delStep = 0;
            }
            countCretedObjects = 0;
            delStep +=1;
           
        }
        
        
        
    }

    void CreateRoad()
    {
        currentGroundPosition.z = currentGroundPosition.z + groundPrefab.transform.localScale.z + Math.Abs(rangeSpawn);
        createdObjects.Add(Instantiate(groundPrefab, currentGroundPosition, Quaternion.identity)); 
        countCretedObjects ++;     
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
            createdObjects.Add(Instantiate(obj, pos, Quaternion.identity));
            countCretedObjects ++;
        }

        
    }

    void CreateObstacles()
    {
        for (int j = 0; j < countLines; j++)
        {             
            countObstaclesLine = Range(1,4);
                
            for (int i = 0; i < countObstaclesLine; i++)
            {
                        
                    
                nowXpos = Range(-20,20);
                currentObstacle = obstaclesPrefab[Range(0,obstaclesPrefab.Length)];
                    
                if( Math.Abs(nowXpos-lastXpos) > (5 - currentObstacle.GetComponent<BoxCollider>().size.x) * 2f + 1){
                        
                    obstaclesPosition.x = nowXpos; 
                        
                    createdObjects.Add(Instantiate(currentObstacle, new Vector3(obstaclesPosition.x,currentObstacle.transform.position.y,obstaclesPosition.z + Range(-6,6)), Quaternion.identity));
                    countCretedObjects ++;
                    lastXpos = obstaclesPosition.x;
                       
                }
                else
                {
                    i -= 1;
                }
                    
                obstaclesPosition.z = obstaclesPosition.z + (crowd / 2.6f);        
                   
            }               
       
        }
    }
    int j = 0;
    void DestroyObjects()
    {
        int i = 0;
        Debug.Log(countCreateatedObjectsList[j]);
        foreach (GameObject obj in createdObjects)
        {
            if(i == countCreateatedObjectsList[j]){break;}
            //Destroy(obj);
            Debug.Log(i+" "+obj);
            i++;
        }
        createdObjects.RemoveRange(0,countCreateatedObjectsList[j]);
        j++;
        
    }

}
