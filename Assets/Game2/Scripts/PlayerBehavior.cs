using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float cameraSpeed = 0.6f;
    private Vector3 targetCameraPosition = new Vector3(0, 3.7f, -3.3f);
    private bool isNeedMoveCamera = false;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    //private float countTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        isNeedMoveCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNeedMoveCamera)
        {
            Vector3 nextPositionCamera = Vector3.Lerp(camera.transform.position, targetCameraPosition, Time.deltaTime * cameraSpeed);
            camera.transform.position = nextPositionCamera;
            Debug.Log("Move Camera");
            if (camera.transform.position.y > 3.6 && camera.transform.position.y < 3.8) isNeedMoveCamera = false;
        }
    }

    void FixedUpdate()
    {
        //counttimer++;
        //if (counttimer > 500)
        //{
            //player.getcomponent<rigidbody>().usegravity = true;
        //}
    }
}
