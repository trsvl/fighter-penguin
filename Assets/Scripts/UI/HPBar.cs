using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Image hpBarImage;


    public void UpdateHP(int hp)
    {
        int maxHP = playerManager.MaxHP;
        float currentHP = (float)hp / maxHP;
        hpBarImage.fillAmount = currentHP;
    }
}
