using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float verticalInput;
    [SerializeField]
    private float speed = 4f;
    private bool isLadder;
    public bool isClimbing;
    private Animator anim;

    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        if (isLadder && Mathf.Abs(verticalInput) >= 0f)
        {
            isClimbing = true;
            anim.SetTrigger("Climbing");
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}