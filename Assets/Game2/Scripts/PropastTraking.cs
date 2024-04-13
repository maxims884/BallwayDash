using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class PropastTraking : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float FallingThreshold = 0.6f;
    public TextMeshProUGUI playerText;
    private float countTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(other.gameObject.name == "BridgeLeft" || other.gameObject.name == "BridgeCenter" || other.gameObject.name == "BridgeRight"){
            if (countTimer > 20)
            {
                countTimer = 0;
                int playerValue = Int32.Parse(playerText.text);
                int res = playerValue - 1;
                playerText.text = res.ToString();
            }
            countTimer++;
        }
    }
}
