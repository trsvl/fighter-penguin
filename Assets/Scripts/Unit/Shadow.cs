using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private UnitManager unitManager;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float timeScale;
    private UnitJump jumpScript;
    private Vector3 initialScale;
    private float initialYPosition;


    private void Start()
    {
        jumpScript = unitManager.gameObject.GetComponent<UnitJump>();
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (!jumpScript.IsJumped) return;

        GetCurrentYPositionOnLanded();

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

    private void GetCurrentYPositionOnLanded()
    {
        if (initialYPosition == 0f)
        {
            initialYPosition = transform.position.y;
        }
    }
}
