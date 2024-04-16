using UnityEngine;

public class EnemyManager : UnitManager
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal bool isAttackingUnit;
    [SerializeField] internal bool isImmune;
    [SerializeField] internal EnemyMovement enemyMovement;
    [SerializeField] internal EnemyAttack enemyAttack;
    [SerializeField] internal EnemyJump enemyJump;
}
