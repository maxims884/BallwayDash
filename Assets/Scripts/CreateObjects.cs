using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    public GameObject obj;
    public Material greenMat;
    public Material redMat;
    public Material blueMat;
    public Material yellowMat;
    public int totalCountBalls; 
    
    void Start()
    {
        int k = 0;
        for(int i = 1; i <= totalCountBalls; i++){
            Instantiate(obj,new Vector3 (RandomNumber(-9,8),5,RandomNumber(-12,12)), Quaternion.Euler(0,0,0));
            if(k == 4) k = 0;
            if(k == 0) {obj.GetComponent<Renderer>().material = greenMat; } 
            else if(k == 1) obj.GetComponent<Renderer>().material = redMat;
            else if(k == 2) obj.GetComponent<Renderer>().material = blueMat;
            else obj.GetComponent<Renderer>().material = yellowMat;

            k++;
        }
    }

    private int RandomNumber(int from, int to){
        return Random.Range(from,to);
    }

    void Update()
    {
        int totalCount = totalCountBalls/4;
        int blueCount = 0;
        int redCount = 0;
        int yellowCount = 0;
        int greenCount = 0;

        string meshName = "Sphere";
        MeshFilter[] allMeshFilters = FindObjectsOfType(typeof(MeshFilter)) as MeshFilter[];

        foreach(MeshFilter thisMeshFilter in allMeshFilters)
        {       
                if (meshName == thisMeshFilter.sharedMesh.name)
                {    
                    float x = thisMeshFilter.gameObject.transform.position.x;
                    float z = thisMeshFilter.gameObject.transform.position.z;

                    Color color = thisMeshFilter.gameObject.GetComponent<Renderer>().material.color;
                    if(color.r > 0.1 && color.r < 0.11 && color.g > 0.49 && color.g < 0.5 && color.b > 0.99 && color.b < 1.1) {
                        if(x > -10 && x < 0 && z > -13.5 && z < 0){ 
                            blueCount ++ ;
                        }
                    }

                    if(color.r > 0.05 && color.r < 0.07 && color.g > 0.99 && color.g < 1.1 && color.b > -0.1 && color.b < 0.1) {
                        if(x > 0 && x < 10 && z > 0 && z < 13.5){
                            greenCount++;
                        }
                    }

                    if(color.r > 0.99 && color.r < 1.1 && color.g > -0.1 && color.g < 0.1 && color.b > -0.1 && color.b < 0.1) {
                        if(x > 0 && x < 10 && z > -13.5 && z < 0){
                            redCount ++ ;
                        } 
                    }

                    if(color.r > 0.88 && color.r < 0.9 && color.g > 0.61 && color.g < 0.63 && color.b > 0.11 && color.b < 0.13) {
                        if(x > -10 && x < 0 && z > 0 && z < 13.5){
                            yellowCount++;
                        }
                    }                    
                }                  
        }

        if(blueCount == totalCount && yellowCount == totalCount && redCount == totalCount && greenCount == totalCount){
            Debug.Log("YOU WIN"); 
        }
    }
}
