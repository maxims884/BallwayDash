using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    // [SerializeField] KeyCode keyOne;
    // [SerializeField] KeyCode keyTwo;
    // [SerializeField] KeyCode keyThree;
    // [SerializeField] KeyCode keyFour;
    
    // [SerializeField] Vector3 moveDirectioX;
    // [SerializeField] Vector3 moveDirectionY;

    // private float width;
    // private float height;
    // private Vector3 position;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 6.0f;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private PlayerControl playerInput; 

    private void Awake() {
        playerInput = new PlayerControl();
    }

    private void OnEnable() {
        playerInput.Enable(); 
    }

    private void OnDisable(){
        playerInput.Disable();
    }

    // void FixedUpdate()
    // {
        // if(Input.GetKey(keyOne))
        // {
        //     GetComponent<Rigidbody>().velocity += moveDirectioX;
        // }

        // if(Input.GetKey(keyTwo))
        // {
        //     GetComponent<Rigidbody>().velocity -= moveDirectioX;
        // }

        // if(Input.GetKey(keyThree))
        // {
        //     GetComponent<Rigidbody>().velocity += moveDirectionY;
        // }

        // if(Input.GetKey(keyFour))
        // {
        //     GetComponent<Rigidbody>().velocity -= moveDirectionY;
        // }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(this.CompareTag("Player") && other.CompareTag("Finish")){
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = playerInput.FindAction("Move").ReadValue<Vector2>();
        
        Vector3 move = new Vector3(-input.x,0,-input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }


        // Changes the height position of the player..
        if (playerInput.FindAction("Jump").triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // if(Input.touchCount > 0) {
        // Touch touch = Input.GetTouch(0);
        // Vector2 pos = touch.position;
        // pos.x = (pos.x - width) / width;
        // pos.y = (pos.y - height) / height;
        // position = new Vector3(-pos.x, pos.y, 0.0f);
        // // if (touch.phase == TouchPhase.Moved)
        // // {
        //     GetComponent<Rigidbody>().position = position;
        // // }

        // }

	if (Application.platform == RuntimePlatform.Android)
  	{
    		if (Input.GetKeyDown(KeyCode.Escape)) 
    		{
      			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    		}
  	}
    }
}
