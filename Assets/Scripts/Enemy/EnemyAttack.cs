using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private bool isFallingAttack;


    public void TriggetAttack()
    {
        StartCoroutine(Attack());
    }
    public void StopTriggetAttack()
    {
        StopAllCoroutines();
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            if (isFallingAttack)
            {
                enemyManager.enemyJump.TriggerJump = true;
            }
            else
            {
                enemyManager.animator.SetTrigger("Attack");
            }

            yield return new WaitForSeconds(attackCoolDown);
        }
    }
}
