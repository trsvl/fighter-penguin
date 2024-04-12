using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private ParticleSystem groundSlam;
    [SerializeField] private float jumpForce;
    private Animator animator;
    private Rigidbody2D rb;
    private bool triggerJump;
    private bool triggerForcedFalling;
    private bool isJumped;
    private bool isFalling;
    internal bool isForcedFalling;


    private void Start()
    {
        animator = playerManager.animator;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isJumped && !isFalling && rb.velocity.y < 0)
        {
            ManageFalling(true);
        }

        ForcedLandingController();
        JumpController();
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
            ManageJump(true);
            triggerJump = true;
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
        rb.gravityScale = 10;
    }

    private void ManageFalling(bool value)
    {
        isFalling = value;
        animator.SetBool("IsFalling", value);
    }
    private void ManageJump(bool value)
    {
        isJumped = value;
        animator.SetBool("IsJumped", value);
    }

    private void FallingAttackAnimation()
    {
        if (!isForcedFalling) return;

        isForcedFalling = false;
        animator.SetTrigger("FallingAttack");
        groundSlam.Play();
        rb.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumped && collision.gameObject.CompareTag("Ground"))
        {
            ManageJump(false);
            ManageFalling(false);
            FallingAttackAnimation();
        }
    }
}
