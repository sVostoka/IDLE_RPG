using TMPro;
using UnityEngine;

public class CharacteristicsController : MonoBehaviour
{
    [SerializeField] private CharacteristicController _armorValue;
    [SerializeField] private CharacteristicController _healthValue;
    [SerializeField] private CharacteristicController _damageValue;
    [SerializeField] private CharacteristicController _preparationValue;
    [SerializeField] private CharacteristicController _attackSpeedValue;

    private void OnEnable()
    {
        _armorValue.SetData(
            GameController.s_Instance.CharacterController.Characteristics.Armor.Name, 
            GameController.s_Instance.CharacterController.Armor.ToString());

        _healthValue.SetData(
            GameController.s_Instance.CharacterController.Characteristics.Health.Name,
            GameController.s_Instance.CharacterController.Characteristics.Health.Value.ToString());

        _damageValue.SetData(
            GameController.s_Instance.CharacterController.Characteristics.Damage.Name,
            GameController.s_Instance.CharacterController.Damage.ToString());

        _preparationValue.SetData(
            GameController.s_Instance.CharacterController.Characteristics.Preparation.Name,
            GameController.s_Instance.CharacterController.Characteristics.Preparation.Value.ToString());

        _attackSpeedValue.SetData(
            GameController.s_Instance.CharacterController.Characteristics.AttackSpeed.Name,
            GameController.s_Instance.CharacterController.AttackSpeed.ToString());

    }
}
