using UnityEngine;

public class PlayerManager : UnitStats
{
    [Header("References")]
    [SerializeField] internal PlayerJump playerJump;
    [SerializeField] internal PlayerAttack playerAttack;
    internal Animator animator;
    internal Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
