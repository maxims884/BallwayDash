using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 6.0f;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private int CollisionCount = 0;
    private PlayerControl playerInput; 

    private Text textScore;
    private void Awake() {
        playerInput = new PlayerControl();
    }

    private void OnEnable() {
        playerInput.Enable(); 
    }

    private void OnDisable(){
        playerInput.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
	if (collision.collider.CompareTag("sph"))
        {
	    int current = LevelSettings.GetInstance().GetCurrentScore();
	    current = current + (LevelSettings.GetInstance().GetUpdatedCollisedBalls() - LevelSettings.GetInstance().GetOldUpdatedCollisedBalls()) * 100 ; 
	    CollisionCount++;
	    if(CollisionCount == 5){
		CollisionCount = 0;
		current = current - 10;	
	    }
            LevelSettings.GetInstance().SetCurrentScore(current);
	    textScore.text = current.ToString();
        }
    }

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

	GameObject textObject = GameObject.Find("Score");
        if (textObject != null)
        {
            // Get the Text component from the text object
            textScore = textObject.GetComponent<Text>();
        }
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

	if (Application.platform == RuntimePlatform.Android)
  	{
    		if (Input.GetKeyDown(KeyCode.Escape)) 
    		{
      			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    		}
  	}
    }
}
