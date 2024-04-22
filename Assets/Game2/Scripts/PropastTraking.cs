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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {

    	
    }

    void OnTriggerStay(Collider other)
    {
       

        if (other.CompareTag("lava")){
            if (countTimer > 11)
            {
                countTimer = 0;
                int playerValue = Int32.Parse(playerText.text);

                int res = playerValue - 1;

                //if (playerValue == 1)
                //{
                //    if ((player.transform.position -
                //    (other.gameObject.transform.parent.gameObject.transform.position + Vector3.forward * (other.gameObject.transform.parent.gameObject.transform.localScale.z / 2))).sqrMagnitude <= minDistance * minDistance)
                //    {
                //        res = 1;
                //    }
                //}

                
                playerText.text = res.ToString();
                
                if(res <= 0)
                {
                    tileGenerator.GetComponent<TileGenerator>().SetPauseGenerate();
                    other.gameObject.GetComponent<Collider>().enabled = false;
                    Destrictible script = other.GetComponent<Destrictible>();
                    script.DestroyObj();
                }
            }
            countTimer++;
        }
    }
}
