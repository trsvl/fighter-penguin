using System.Collections;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected int hp;
    [SerializeField] private int damage;
    [SerializeField] private Color32 colorOnHit;
    private Color32 initialPlayerColor;
    private SpriteRenderer unitSprite;
    internal Rigidbody2D rb;
    internal Animator animator;
    internal bool isPlayer;
    public int Damage { get { return damage; } }


    protected virtual void Awake()
    {
        unitSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPlayerColor = unitSprite.color;
        isPlayer = gameObject.CompareTag("Player");
    }

    public virtual void TakeDamage(int takenDamage)
    {
        hp -= takenDamage;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        unitSprite.color = colorOnHit;
        yield return new WaitForSeconds(0.1f);
        unitSprite.color = initialPlayerColor;
    }
}
