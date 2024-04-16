using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private float spawnPointProximityThreshold;
    [SerializeField] private float tossBackPower;
    private Rigidbody2D rb;
    private float direction;
    private float prevDirection;
    private float moveSpeed;
    private float isTossedTriggerTimer;
    private bool isAttackingUnit;
    private bool stopTrigger;
    private bool stopEnemyOnAttack;
    private bool isTossed;
    private bool isTossedTrigger;
    private bool isBoss;
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
        DisableStopTriggerOnAttack();
    }

    private void FixedUpdate()
    {
        TossBackEnemy();

        if (isTossed) return;

        StopEnemyOnAttack();

        if (stopEnemyOnAttack) return;

        StopEnemyNearPlayer();
        Movement();
    }

    private void TossBackEnemy()
    {
        if (!isTossedTrigger) return;

        isTossedTrigger = false;
        isTossed = true;

        TossBack();
    }

    private void StopEnemyOnAttack()
    {
        if (!stopEnemyOnAttack) return;

        rb.velocity = new Vector2(0f, 0f);
    }

    private void StopEnemyNearPlayer()
    {
        if (!stopTrigger && direction == 0)
        {
            stopTrigger = true;
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
        else if (stopTrigger && direction != 0)
        {
            stopTrigger = false;
        }
    }

    private void Movement()
    {
        if (direction != 0)
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
    }

    private void CheckSpawnPointProximity()
    {
        if (targetPoint == null) return;

        float distanceToPoint = Vector2.Distance(transform.position, targetPoint.position);
        if (distanceToPoint < spawnPointProximityThreshold)
        {
            if (isAttackingUnit && direction != 0)
            {
                prevDirection = direction;
                direction = 0;
                enemyManager.animator.SetBool("IsWalking", false);
                enemyManager.enemyAttack.TriggetAttack();
            }
            else if (!isAttackingUnit)
            {
                SwitchDirection();
            }
        }
        else if ((distanceToPoint > spawnPointProximityThreshold) && direction == 0 && !isBoss)
        {
            direction = prevDirection;
            enemyManager.animator.SetBool("IsWalking", true);
            enemyManager.enemyAttack.StopTriggetAttack();
        }
    }

    public void SetData(bool isLeftSpawnSide, Transform leftSpawnPoint, Transform rightSpawnPoint, Transform playerPoint, bool isBoss = false)
    {
        Start();

        direction = isLeftSpawnSide ? 1f : -1f;
        transform.localScale = new Vector2(direction * transform.localScale.x, transform.localScale.y);
        this.leftSpawnPoint = leftSpawnPoint;
        this.rightSpawnPoint = rightSpawnPoint;
        this.isBoss = isBoss;

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
        transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
    }

    private void TossBack()
    {
        float tossDirection = (transform.position.x < targetPoint.position.x) ? -1f : 1f;
        rb.AddForce(new Vector2(tossDirection * tossBackPower, 0f), ForceMode2D.Impulse);
    }

    public void TriggerTossBackEnemy()
    {
        isTossedTrigger = true;
        StartCoroutine(DisableToss());
    }
    public void TriggerStopEnemy()
    {
        stopEnemyOnAttack = true;
        isTossedTriggerTimer = 0f;
    }

    private void DisableStopTriggerOnAttack()
    {
        if (!stopEnemyOnAttack) return;

        isTossedTriggerTimer += Time.deltaTime;
        if (isTossedTriggerTimer >= 0.5f)
        {
            isTossedTriggerTimer = 0f;
            stopEnemyOnAttack = false;
        }
    }

    private IEnumerator DisableToss()
    {
        yield return new WaitForSeconds(1f);
        isTossed = false;
    }
}
