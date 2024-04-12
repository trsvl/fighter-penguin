using UnityEngine;

public class ColliderAttack : MonoBehaviour
{
    [SerializeField] private UnitStats unit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(unit.CompareTag("Player") ? "Enemy" : "Player"))
        {
            collision.GetComponent<UnitStats>().TakeDamage(unit.Damage);
        }
    }
}
