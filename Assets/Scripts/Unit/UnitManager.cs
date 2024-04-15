using System.Collections;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int hp;
    public int HP { get { return hp; } }

    [SerializeField] private int damage;
    public int Damage { get { return damage; } }

    [SerializeField] private Color32 colorOnHit;
    private Color32 initialPlayerColor;
    private SpriteRenderer unitSprite;
    internal Rigidbody2D rb;
    internal Animator animator;
    internal bool isPlayer;


    private void Awake()
    {
        unitSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPlayerColor = unitSprite.color;
        isPlayer = gameObject.CompareTag("Player");
    }

    public void TakeDamage(int takenDamage)
    {
        hp -= takenDamage;
        StartCoroutine(ChangeColor());
        if (hp <= 0 && !isPlayer)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangeColor()
    {
        unitSprite.color = colorOnHit;
        yield return new WaitForSeconds(0.1f);
        unitSprite.color = initialPlayerColor;
    }
}
