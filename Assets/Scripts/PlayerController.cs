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
    private Text textBestScore;

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
	    CollisionCount++;
	    if(CollisionCount == 3){
		CollisionCount = 0;
		LevelSettings.GetInstance().AddCurrentScore(-2);	
	    }
        }
    }

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

	GameObject textObject = GameObject.Find("Score");
        if (textObject != null)
        {
            textScore = textObject.GetComponent<Text>();
        }

	GameObject textObjectBest = GameObject.Find("BestScore");
        if (textObjectBest != null)
        {
            textBestScore = textObjectBest.GetComponent<Text>();
        }
    }

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
	if(LevelSettings.GetInstance().GetChangedScore()){
		LevelSettings.GetInstance().AddCurrentScore((LevelSettings.GetInstance().GetUpdatedCollisedBalls() - LevelSettings.GetInstance().GetOldUpdatedCollisedBalls())*10);
		LevelSettings.GetInstance().CheckBestScore();
		LevelSettings.GetInstance().SetChangedScore(false);
	}
	textScore.text = LevelSettings.GetInstance().GetCurrentScore().ToString();
	textBestScore.text = LevelSettings.GetInstance().GetBestScore().ToString();
    }
}
