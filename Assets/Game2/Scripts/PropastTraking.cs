using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using static System.Net.Mime.MediaTypeNames;

public class PropastTraking : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject tileGenerator;
    private float FallingThreshold = 0.6f;
    public TextMeshProUGUI playerText;
    private float countTimer = 0;
    private const float minDistance = 0.2f;
    MeshDestroy destroy = null;
    // Start is called before the first frame update
    void Start()
    {
        destroy = new MeshDestroy();
    }

    // Update is called once per frame
    void Update()
    {
        	//if(player.transform.position.y < FallingThreshold){
		//Debug.Log("player.transform.position.y " + player.transform.position.y);
		//player.transform.position = new Vector3(player.transform.position.x, FallingThreshold, player.transform.position.z);
	//}
    }

    void FixedUpdate()
    {

    	
    }

    //     private void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.name == "BridgeLeft" || other.gameObject.name == "BridgeCenter" || other.gameObject.name == "BridgeRight"){

    //     }
    // }

    void OnTriggerStay(Collider other)
    {
       

        if (other.gameObject.name == "BridgeLeft" || other.gameObject.name == "BridgeCenter" || other.gameObject.name == "BridgeRight"){
            //Debug.Log("other.gameObject.transform.localSacale.z; " + other.gameObject.transform.parent.gameObject.transform.localScale.z);
            // + Vector3.forward * (other.gameObject.transform.parent.gameObject.transform.localScale.z / 2)
            //Debug.Log("(transform.position - target.transform.position).sqrMagnitude " + (player.transform.position - 
              //  (other.gameObject.transform.parent.gameObject.transform.position + Vector3.forward * (other.gameObject.transform.parent.gameObject.transform.localScale.z / 2))).sqrMagnitude);
            if (countTimer > 9)
            {
                countTimer = 0;
                int playerValue = Int32.Parse(playerText.text);

                int res = playerValue - 1;

                if (playerValue == 1)
                {
                    if ((player.transform.position -
                    (other.gameObject.transform.parent.gameObject.transform.position + Vector3.forward * (other.gameObject.transform.parent.gameObject.transform.localScale.z / 2))).sqrMagnitude <= minDistance * minDistance)
                    {
                        res = 1;
                    }
                }

                
                playerText.text = res.ToString();
                
                if(res <= 0)
                {
                    tileGenerator.GetComponent<TileGenerator>().SetPauseGenerate();
                    other.gameObject.GetComponent<Collider>().isTrigger = false;
                    destroy.DestroyMesh(other.gameObject);
                }
            }
            countTimer++;
        }
    }
}
