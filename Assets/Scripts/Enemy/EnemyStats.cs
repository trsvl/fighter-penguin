using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float speed;
    internal float Speed => speed;

    [SerializeField] private bool isAttack;
    internal bool IsAttack => isAttack;
}
