using UnityEngine;

public class EnemyManager : UnitManager
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal bool isAttackingUnit;
    [SerializeField] internal bool isImmune;
    [SerializeField] internal EnemyMovement enemyMovement;
    [SerializeField] internal EnemyAttack enemyAttack;
    [SerializeField] internal EnemyJump enemyJump;
    private EnemiesCount enemiesCount;


    private void Start()
    {
        enemiesCount = GameObject.FindWithTag("EnemiesCount").GetComponent<EnemiesCount>();
    }

    public override void TakeDamage(int takenDamage)
    {
        base.TakeDamage(takenDamage);

        if (hp <= 0)
        {
            Destroy(gameObject);
            enemiesCount.UpdateCount();
        }
    }
}
