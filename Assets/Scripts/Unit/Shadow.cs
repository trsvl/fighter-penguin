using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private GameObject jumpScriptGameObject;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float timeScale;
    private IJump jumpScript;
    private Vector3 initialScale;


    private void Start()
    {
        jumpScript = jumpScriptGameObject.GetComponent<IJump>();
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (jumpScript == null) return;

        if (!jumpScript.IsJumped) return;

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
