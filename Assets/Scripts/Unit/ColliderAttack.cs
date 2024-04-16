using UnityEngine;

public class ColliderAttack : MonoBehaviour
{
    [SerializeField] private UnitManager unitManager;
    [SerializeField] private bool isFallingAttack;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(unitManager.isPlayer ? "Enemy" : "Player"))
        {
            bool isPlayerFallingAttack = unitManager.isPlayer && isFallingAttack;
            collision.GetComponent<UnitManager>().TakeDamage(isPlayerFallingAttack ? unitManager.Damage * 2 : unitManager.Damage);

            PlayerEffect(collision);
        }
    }

    private void PlayerEffect(Collider2D collision)
    {
        if (!unitManager.isPlayer) return;

        if (collision.GetComponent<EnemyManager>().isImmune) return;

        if (isFallingAttack)
        {
            collision.GetComponent<EnemyManager>().enemyMovement.TriggerTossBackEnemy();
        }
        else
        {
            collision.GetComponent<EnemyManager>().enemyMovement.TriggerStopEnemy();
        }
    }
}