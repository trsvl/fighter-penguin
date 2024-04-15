using UnityEngine;

public class ColliderAttack : MonoBehaviour
{
    [SerializeField] private UnitManager unit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(unit.CompareTag("Player") ? "Enemy" : "Player"))
        {
            collision.GetComponent<UnitManager>().TakeDamage(unit.Damage);
        }
    }
}
