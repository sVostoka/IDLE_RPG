using UnityEngine;
using UnityEngine.UI;

public class IndicatorController : MonoBehaviour
{
    [SerializeField] private Image _bar;
    public Image Bar { get => _bar; set => _bar = value; }

    [SerializeField] private GameObject _preparation;
    [SerializeField] private GameObject _attack;

    private bool _isPrepareting = true;
    public bool IsPreparation 
    { 
        get => _isPrepareting;
        set 
        {
            _isPrepareting = value;
            IsAttacking = !_isPrepareting;
            SetVisibility();
        }
    }

    private bool _isAttacking = false;
    public bool IsAttacking 
    { 
        get => _isAttacking;
        set 
        {
            _isAttacking = value;
            _isPrepareting = !_isAttacking;
            SetVisibility();
        } 
    }

    private void SetVisibility()
    {
        _preparation.SetActive(IsPreparation);
        _attack.SetActive(IsAttacking);
    }
}
