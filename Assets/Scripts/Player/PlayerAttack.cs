using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private Animator animator;


    private void Start()
    {
        animator = playerManager.animator;
    }

    private void Update()
    {
        if (playerManager.playerJump.IsForcedFalling) return;

        LeftAttack();
        RightAttack();
    }

    private void LeftAttack()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DefaultAttack(true);
        }
    }
    private void RightAttack()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            DefaultAttack(false);
        }
    }

    private void DefaultAttack(bool isLeft)
    {
        animator.SetTrigger("Attack");
        transform.localScale = new Vector3(isLeft ? -1f : 1f, 1f, 1f);
    }

}
