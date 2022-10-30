using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.Random;

public class SpawnGrowndAndObstacles : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject groundModelPrefab;
    public GameObject player;
    public int rangeSpawn;
    public GameObject[] trees;
    public int crowd;
<<<<<<< Updated upstream
 

=======
    public GameObject[] obstaclesPrefab;
    public GameObject firstObjects;
    public int treeSpawn;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        currentGroundPosition = groundPrefab.transform.position;
        currentGroundPosition.z = currentGroundPosition.z + rangeSpawn;
        obstaclesPosition = player.transform.position;
        obstaclesPosition.y = -0.4f;
=======
        createdObjects.Add(firstObjects);
        countCretedObjects ++;
        currentGroundPosition = groundPrefab.transform.position;  
        obstaclesPosition = player.transform.position;
        obstaclesPosition.z = obstaclesPosition.z + 80f;
        //countLines = (int) (groundPrefab.transform.localScale.z / (crowd*1.7f));
        CreateObstacles(currentGroundPosition.z+120f);
        currentGroundPosition.z = currentGroundPosition.z + rangeSpawn;
        countCreateatedObjectsList.Add(countCretedObjects);
        countCretedObjects = 0;


        countLines = (int) (groundPrefab.transform.localScale.z / crowd);
        obstaclesPosition = player.transform.position;
>>>>>>> Stashed changes
        obstaclesPosition.z = obstaclesPosition.z + groundPrefab.transform.localScale.z;
        countLines = (int) (groundPrefab.transform.localScale.z / crowd);
        
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if(player.transform.position.z > currentGroundPosition.z)
        {
            CreateRoad();
<<<<<<< Updated upstream
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
                 
       
=======
            CreeateEnviroment(25,(int)currentGroundPosition.z,80,(int)groundPrefab.transform.localScale.z);
            CreeateEnviroment(-100,(int)currentGroundPosition.z,75,(int)groundPrefab.transform.localScale.z);
            CreateObstacles(currentGroundPosition.z + groundPrefab.transform.localScale.z);
            countCreateatedObjectsList.Add(countCretedObjects);
            if(delStep == 1){
                DestroyObjects();
                delStep = 0;
>>>>>>> Stashed changes
            }
        }
        
        
    }

    void CreateRoad()
    {
        currentGroundPosition.z = currentGroundPosition.z + groundPrefab.transform.localScale.z + Math.Abs(rangeSpawn);
<<<<<<< Updated upstream
        Instantiate(groundPrefab, currentGroundPosition, Quaternion.identity);      
=======
        createdObjects.Add(Instantiate(groundModelPrefab, currentGroundPosition, Quaternion.identity)); 
        countCretedObjects ++;     
>>>>>>> Stashed changes
        currentGroundPosition.z = currentGroundPosition.z - Math.Abs(rangeSpawn); 
    }

    void CreeateEnviroment(int x, int z, int a , int b) 
    {
        // x,z = кординати області в якій треба генерувати об`єкти (по нижньому лівому краю)
        //a,b - розмір області
        Vector3 pos;
        int count = Range(0,treeSpawn);
        for (int i = 0; i < count; i++)
        {
<<<<<<< Updated upstream
            pos = new Vector3(Range(x,x+a),obj.transform.position.y,Range(z,z+b));
            Instantiate(obj, pos, Quaternion.identity);
=======
            GameObject temp = trees[Range(0,trees.Length)];
            pos = new Vector3(Range(x,x+a),temp.transform.position.y,Range(z,z+b));
            createdObjects.Add(Instantiate(temp, pos, Quaternion.identity));
            countCretedObjects ++;
>>>>>>> Stashed changes
        }

        
    }

<<<<<<< Updated upstream
=======
    void CreateObstacles(float a)
    {
        while(obstaclesPosition.z + 6f + (crowd / 2.6f) < a)
        {             
            countObstaclesLine = Range(1,4);
                
            for (int i = 0; i < countObstaclesLine; i++)
            {
                        
                    
                nowXpos = Range(-20,20);
                currentObstacle = obstaclesPrefab[Range(0,obstaclesPrefab.Length)];
                    
                if( Math.Abs(nowXpos-lastXpos) > (5 - currentObstacle.GetComponent<BoxCollider>().size.x) * 2f + 1){
                        
                    obstaclesPosition.x = nowXpos; 
                        
                    createdObjects.Add(Instantiate(currentObstacle, new Vector3(obstaclesPosition.x,currentObstacle.transform.position.y,obstaclesPosition.z + Range(-6,6)), Quaternion.identity));
                    countCretedObjects += 1;
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
        //Debug.Log(countCreateatedObjectsList[j]);
        foreach (GameObject obj in createdObjects)
        {
            if(i == countCreateatedObjectsList[j]){break;}
            //Destroy(obj);
            obj.SetActive(false);
            //Debug.Log(i+" "+obj);
            i++;
        }
        createdObjects.RemoveRange(0,countCreateatedObjectsList[j]);
        j++;
        
    }

>>>>>>> Stashed changes
}
