using UnityEngine;

public class PlayerJump : UnitJump
{
    protected override void JumpController()
    {
        if (isJumped) return;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            base.JumpController();
        }
    }
    protected override void ForcedLandingController()
    {
        if (!isJumped) return;

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            base.ForcedLandingController();
        }
    }
}
