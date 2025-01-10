using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public enum GameStage
{
    STARTSTORY,
    GAMETIME
}
public class PlayerMovement : MonoBehaviour
{

    Animator animator;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameStage currentStage = GameStage.GAMETIME; // Default to STARTSTORY

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float speed;
    [SerializeField] private float input;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private float jumpForce;
    [SerializeField] LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;
    [SerializeField] float jumpTime = 0.35f;
    [SerializeField] float jumpTimeCounter;
    private bool isJumping;
    //start stage

    private void Start()
    {
            currentStage = GameStage.GAMETIME; // Default to STARTSTORY
        animator = GetComponent<Animator>();
    }
// Update is called once per frame
void Update()
    {
// Debug.Log(currentStage);


        if (currentStage == GameStage.STARTSTORY) {
        
        
        }
        else
        {

            input = Input.GetAxisRaw("Horizontal");
            if (input < 0)
            {
                playerSprite.flipX = true;
            }
            else if (input > 0)
            {
                playerSprite.flipX = false;
            }
            isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);



            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                jumpTimeCounter = jumpTime;
                playerRB.linearVelocity = Vector2.up * jumpForce;
                isJumping = true;
                animator.SetBool("isJumping",isJumping);
            }

            if (Input.GetButton("Jump") && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    playerRB.linearVelocity = Vector2.up * jumpForce;
                    jumpTimeCounter = jumpTimeCounter - Time.deltaTime;
                }
                else
                {

                    isJumping = false;
                    animator.SetBool("isJumping", isJumping);

                }

            }
            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
                animator.SetBool("isJumping", isJumping);

            }
            if (transform.position.y < -10)
            {
                ifPlayerDead();
            }

        }

    }
    private void FixedUpdate()
    {
        playerRB.linearVelocity = new Vector2(input * speed, playerRB.linearVelocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(playerRB.linearVelocity.x));
    }
    private void ifPlayerDead()
    {
        playerRB.position = new Vector2(-3, 2);
    }
}
