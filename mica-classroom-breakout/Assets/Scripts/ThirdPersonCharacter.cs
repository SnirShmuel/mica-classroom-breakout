using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(Animator))]
	public class ThirdPersonCharacter : MonoBehaviour
	{
	private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 2.0f;
	private bool m_Jump = false;
	private bool m_Crouch = false;
	private Animator m_Animator;
	private Transform m_Cam;
	private float m_ForwardAmount;
	private float m_TurnAmount ;
   // gravity
    private float gravity = 9.87f;
    private float verticalSpeed = 0;

	public Text finishedText;

	private void Awake()
    {
    }
	
	void OnControllerColliderHit(ControllerColliderHit hit)
    {
		if (hit.gameObject.name == "WinningCup") {
        	if (DragAndDropScript.isFinish && Player.isFinish) {
				SceneManager.LoadScene("WinMenuScene");
			} else {
				finishedText.text = "Return when everything was finished!";
			}
		}

		if (hit.gameObject.name == "Goblin_rouge_b") {
			transform.position = new Vector3(0,0.5f,-11);
		}
    }


    private void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = gameObject.GetComponent<CharacterController>();
		m_Animator = GetComponent<Animator>();
		if (Camera.main != null) {
			m_Cam = Camera.main.transform;
		}
		
    }
	
	private void Update()
	{
		bool isRunning = m_Animator.GetBool("isRunning");
		bool isWalking = m_Animator.GetBool("isWalking");
		bool isBackward = m_Animator.GetBool("isBackward");
		bool forwardPressed = Input.GetKey(KeyCode.W);
		bool backwardPressed = Input.GetKey(KeyCode.S);
		bool runPressed = Input.GetKey(KeyCode.LeftShift);
		m_Jump = Input.GetKeyDown(KeyCode.Space);
		m_Crouch = Input.GetKeyDown(KeyCode.C);


		// Check if start walking
		if (!isWalking && forwardPressed)
		{
			m_Animator.SetBool("isWalking", true);
		} 

		// Check if stop walking
		if (isWalking && !forwardPressed)
		{
			m_Animator.SetBool("isWalking", false);
		}

		// Check if start backward walking
		if (!isBackward && backwardPressed)
		{
			m_Animator.SetBool("isBackward", true);
		}

		// Check if stop backward walking
		if (isBackward && !backwardPressed)
		{
			m_Animator.SetBool("isBackward", false);
		}

		if(!isRunning && (forwardPressed && runPressed))
		{
			m_Animator.SetBool("isRunning", true);
		}

		if (isRunning && (!forwardPressed || !runPressed))
		{
			m_Animator.SetBool("isRunning", false);
		}
		
	    float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (controller.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        
        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
		
		float speed = playerSpeed;
		if (isRunning) {
			speed *= 2;
		}
		
        controller.Move(speed * Time.deltaTime * move);
		
		 if (m_Jump && controller.isGrounded)
        {
			Debug.Log("!!");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * 3.0f * gravity);
        }


		playerVelocity.y += -1 * gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
		
		if (m_Crouch) {
			m_Animator.Play("Female Roll");
		}
		
		Rotate();		
		UpdateAnimator();
	}
	
	public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        
        transform.Rotate(0, horizontalRotation * 2f, 0);
    }
	
	void UpdateAnimator()
	{
		// update the animator parameters
		m_Animator.SetBool("Crouch", m_Crouch);
		m_Animator.SetBool("OnGround", controller.isGrounded);
		if (!controller.isGrounded)
		{
			m_Animator.SetFloat("Jump", controller.velocity.y);
		}

		// calculate which leg is behind, so as to leave that leg trailing in the jump animation
		// (This code is reliant on the specific run cycle offset in our animations,
		// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
		float runCycle =
			Mathf.Repeat(
				m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + 0.2f, 1);
		float jumpLeg = (runCycle < 0.5f ? 1 : -1) * m_ForwardAmount;
		if (controller.isGrounded)
		{
			m_Animator.SetFloat("JumpLeg", jumpLeg);
		}
	}	
}
}	
