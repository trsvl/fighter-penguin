using UnityEngine;

public class EnemyManager : UnitManager
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal bool isAttackingUnit;
    [SerializeField] internal EnemyMovement enemyMovement;
}
