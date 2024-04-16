using TMPro;
using UnityEngine;

public class EnemiesCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCount;
    private int count = 0;


    public void UpdateCount()
    {
        count++;
        textCount.text = count.ToString();
    }
}
