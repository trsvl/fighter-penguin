using UnityEngine;

public class Enemy : UnitStats
{
    public Transform TargetPosition { get; set; }
    public bool IsLeftSide { get; set; }
    private Rigidbody2D rb;
    private float direction;
    private Vector2 vectorSpeed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vectorSpeed = new Vector2(MoveSpeed, 0);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (direction * Time.deltaTime * vectorSpeed));
    }

    public void Direction(bool isLeft)
    {
        direction = isLeft ? -1f : 1f;
        transform.localScale = new Vector3(direction, 1f, 1f);
    }
    public void SwitchDirection()
    {
        direction *= -1;
    }
}
