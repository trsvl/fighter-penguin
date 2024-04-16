using UnityEngine;

public class UnitJump : MonoBehaviour
{
    [SerializeField] private UnitManager unitManager;
    [SerializeField] private float jumpForce;
    [SerializeField] private ParticleSystem groundSlam;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected bool triggerJump;
    protected bool isFalling;
    protected bool isJumped;
    protected bool triggerForcedFalling;
    protected bool isForcedFalling;
    public bool IsJumped { get { return isJumped; } }
    public bool IsFalling { get { return isFalling; } }
    public bool IsForcedFalling { get { return isForcedFalling; } }


    private void Start()
    {
        animator = unitManager.animator;
        rb = unitManager.rb;
    }

    protected virtual void Update()
    {
        if (isJumped && !isFalling && rb.velocity.y < 0)
        {
            ManageFalling(true);
        }

        ForcedLandingController();
        JumpController();
    }

    protected virtual void FixedUpdate()
    {
        Jump();
        ForcedLanding();
    }

    protected virtual void JumpController()
    {
        ManageJump(true);
        triggerJump = true;
    }

    protected virtual void ForcedLandingController()
    {
        isForcedFalling = true;
        triggerForcedFalling = true;
        ManageFalling(true);
    }

    protected void Jump()
    {
        if (!triggerJump) return;

        triggerJump = false;
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
    }

    protected void ForcedLanding()
    {
        if (!triggerForcedFalling) return;

        triggerForcedFalling = false;
        rb.gravityScale = 10;
    }

    protected void FallingAttackAnimation()
    {
        if (!isForcedFalling) return;

        isForcedFalling = false;
        animator.SetTrigger("FallingAttack");
        groundSlam.Play();
        rb.gravityScale = 1;
    }

    protected void ManageFalling(bool value)
    {
        isFalling = value;
        animator.SetBool("IsFalling", value);
    }
    protected void ManageJump(bool value)
    {
        isJumped = value;
        animator.SetBool("IsJumped", value);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumped && collision.gameObject.CompareTag("Ground"))
        {
            ManageJump(false);
            ManageFalling(false);
            FallingAttackAnimation();
        }
    }
}
