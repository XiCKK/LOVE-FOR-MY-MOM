using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //How much time the player can hang in the air before jumping
    private float coyoteCounter; //How much time passed since the player ran off the edge


    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;


    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip walkSound;
    private bool walkCheck;
    AudioSource audioSource;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    private void Start()
    {
        walkCheck = true;
    }
    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }

        if (horizontalInput != 0 && isGrounded())
        {
            if (walkCheck == false)
            {
                SoundManager.instance.PlaySound(walkSound);
                walkCheck = true;
            }
        }
        else
        {
            SoundManager.instance.StopSound(walkSound);
            walkCheck = false;

        }  
        //Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());
        body.gravityScale = 4;
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        //Jump
        if (Input.GetKeyDown(KeyCode.W) && GetComponent<LadderMovement>().isClimbing == false)
        {
            anim.SetTrigger("Jump");
            Jump();
        }


        //Adjustable jump height
        if (Input.GetKeyUp(KeyCode.W) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.33f);
        }
        
        if (isGrounded())
        {
            coyoteCounter = coyoteTime; //Reset coyote counter when on the ground
        }
        else
            coyoteCounter -= Time.deltaTime; //Start decreasing coyote counter when not on the ground
    }

    public void Jump()
    {
        if (coyoteCounter <= 0)
            return;
        //If coyote counter is 0 or less and not on the wall 

        SoundManager.instance.PlaySound(jumpSound);

        if (isGrounded())
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            
        //Reset coyote counter to 0 to avoid double jumps
        coyoteCounter = 0;
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, 
            boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }


}