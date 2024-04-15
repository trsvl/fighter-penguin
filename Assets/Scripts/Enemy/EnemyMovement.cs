using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private float spawnPointProximityThreshold;
    private Rigidbody2D rb;
    private float direction;
    private bool isAttackingUnit;
    private float moveSpeed;
    private Transform leftSpawnPoint;
    private Transform rightSpawnPoint;
    private Transform targetPoint;


    private void Start()
    {
        rb = enemyManager.rb;
        isAttackingUnit = enemyManager.isAttackingUnit;
        moveSpeed = enemyManager.moveSpeed;
    }

    private void Update()
    {
        CheckSpawnPointProximity();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void CheckSpawnPointProximity()
    {
        if (targetPoint == null) return;

        float distanceToSpawnPoint = Vector2.Distance(transform.position, targetPoint.position);
        if (distanceToSpawnPoint < spawnPointProximityThreshold)
        {
            if (isAttackingUnit)
            {
                direction = 0;
                Debug.Log("ATTACK");
            }
            else
            {
                SwitchDirection();
                Debug.Log("Enemy is close to the spawn point.");
            }
        }
    }

    public void SetData(bool isLeftSpawnSide, Transform leftSpawnPoint, Transform rightSpawnPoint, Transform playerPoint)
    {
        direction = isLeftSpawnSide ? 1f : -1f;
        transform.localScale = new Vector3(direction, 1f, 1f);
        this.leftSpawnPoint = leftSpawnPoint;
        this.rightSpawnPoint = rightSpawnPoint;

        if (isAttackingUnit)
        {
            targetPoint = playerPoint;
        }
        else
        {
            targetPoint = isLeftSpawnSide ? rightSpawnPoint : leftSpawnPoint;
        }
    }

    private void SwitchDirection()
    {
        bool condition = targetPoint == rightSpawnPoint;
        targetPoint = condition ? leftSpawnPoint : rightSpawnPoint;
        direction = condition ? -1f : 1f;
        transform.localScale = new Vector3(direction, 1f, 1f);
    }
}
