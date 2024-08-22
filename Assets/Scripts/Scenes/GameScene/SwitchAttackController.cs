using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class SwitchAttackController : MonoBehaviour
{
    [SerializeField] private Button _meleeAttack;
    [SerializeField] private Button _rangeAttack;

    private void Awake()
    {
        _meleeAttack.onClick.AddListener(MeleeAttack);
        _rangeAttack.onClick.AddListener(RangeAttack);
    }

    private void MeleeAttack()
    {
        GameController.s_Instance.CharacterController.TypeAttack = TypeWeapon.Melee;
        _meleeAttack.gameObject.SetActive(false);
        _rangeAttack.gameObject.SetActive(true);
    }

    private void RangeAttack()
    {
        GameController.s_Instance.CharacterController.TypeAttack = TypeWeapon.LongRange;
        _rangeAttack.gameObject.SetActive(false);
        _meleeAttack.gameObject.SetActive(true);
    }
}
