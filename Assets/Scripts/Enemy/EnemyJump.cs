using UnityEngine;

public class EnemyJump : UnitJump
{
    [SerializeField] private bool isHasFallingAttack;


    protected override void Update()
    {
        if (isJumped && !isFalling && rb.velocity.y < 0)
        {
            if (isHasFallingAttack)
            {
                ForcedLandingController();
            }
            else
            {
                ManageFalling(true);
            }
        }

        JumpController();
    }

    protected override void JumpController()
    {
        if (isJumped) return;

        base.JumpController();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumped && collision.gameObject.CompareTag("Ground"))
        {
            ManageJump(false);
            ManageFalling(false);

            if (isHasFallingAttack)
            {
                FallingAttackAnimation();
            }
        }
    }
}
