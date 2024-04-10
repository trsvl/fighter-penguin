using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private float jumpForce;
    private Animator animator;
    private Rigidbody2D rb;
    private bool triggerJump;
    private bool triggerForcedFalling;
    private bool isJumped;
    private bool isFalling;
    private bool isForcedFalling;

    private void Start()
    {
        animator = playerManager.animator;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        JumpController();
        ForcedLandingController();

        if (isJumped && !isFalling && rb.velocity.y <= 0)
        {
            ManageFalling(true);
        }
    }
    private void FixedUpdate()
    {
        Jump();
        ForcedLanding();
    }

    private void JumpController()
    {
        if (isJumped) return;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            isJumped = true;
            triggerJump = true;
            animator.SetTrigger("Jump");
        }
    }
    private void ForcedLandingController()
    {
        if (!isJumped) return;

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            isForcedFalling = true;
            triggerForcedFalling = true;
            ManageFalling(true);
        }
    }

    private void Jump()
    {
        if (!triggerJump) return;

        triggerJump = false;
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
    }
    private void ForcedLanding()
    {
        if (!triggerForcedFalling) return;

        triggerForcedFalling = false;
        rb.gravityScale = 5;
    }

    private void ManageFalling(bool value)
    {
        isFalling = value;
        animator.SetBool("Falling", value);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumped = false;
            ManageFalling(false);

            if (isForcedFalling)
            {
                isForcedFalling = false;
                animator.SetTrigger("FlytingAttack");
                rb.gravityScale = 1;
                //ATTACK REFERENCE
            }
        }
    }
}
