using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private UnitManager unitManager;
    [SerializeField] private UnitJump jumpScript;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float timeScale;
    private Vector3 initialScale;
    private float initialYPosition;


    private void Start()
    {
        initialScale = transform.localScale;
        initialYPosition = transform.position.y;
    }

    private void Update()
    {
        if (!jumpScript.IsJumped) return;

        if (!unitManager.isPlayer)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = initialYPosition;
            transform.position = newPosition;
        }

        if (jumpScript.IsFalling)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initialScale, timeScale * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, timeScale * Time.deltaTime);
        }
    }
}
