using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerJump playerJump;
    [SerializeField] private PlayerAttack playerAttack;
    internal Animator animator;
    internal Rigidbody2D rb;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
}
