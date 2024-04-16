using UnityEngine;

public class PlayerManager : UnitManager
{
    [Header("References")]
    [SerializeField] internal PlayerJump playerJump;
    [SerializeField] internal PlayerAttack playerAttack;
    [SerializeField] private HPBar hpBar;
    [SerializeField] private PopUpManager popUpManager;
    public int MaxHP { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        MaxHP = hp;
    }

    public override void TakeDamage(int takenDamage)
    {
        base.TakeDamage(takenDamage);

        hpBar.UpdateHP(hp);

        if (hp <= 0)
        {
            popUpManager.ShowPopUpRestart();
        }
    }
}
