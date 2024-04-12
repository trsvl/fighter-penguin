using System.Collections;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int hp;
    public int HP { get { return hp; } }

    [SerializeField] private int damage;
    public int Damage { get { return damage; } }

    [SerializeField] private Color32 colorOnHit;
    private SpriteRenderer unitSprite;
    private Color32 initialPlayerColor;


    private void Start()
    {
        unitSprite = GetComponent<SpriteRenderer>();
        initialPlayerColor = unitSprite.color;
    }

    public void TakeDamage(int takenDamage)
    {
        hp -= takenDamage;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        unitSprite.color = colorOnHit;
        yield return new WaitForSeconds(0.25f);
        unitSprite.color = initialPlayerColor;
    }
}
