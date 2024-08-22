using System;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    [SerializeField] protected HPController _hpController;
    [SerializeField] protected IndicatorController _indicatorController;
    public IndicatorController IndicatorController
    {
        get => _indicatorController;
        private set => _indicatorController = value;
    }

    public event Action DeadHero;

    public int MaxHP { get; set; }

    protected int _hp;
    public int HP
    {
        get => _hp;
        set
        {
            if (value < MaxHP)
            {
                _hp = value;
            }
            else
            {
                _hp = MaxHP;
            }

            _hpController.SetHP(_hp);

            if (_hp <= 0)
            {
                _hp = 0;
                Dead();
            }
        }
    }


    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    protected virtual void Dead()
    {
        DeadHero?.Invoke();
    }
}