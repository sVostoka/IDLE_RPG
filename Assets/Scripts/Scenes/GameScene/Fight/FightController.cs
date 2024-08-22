using System.Collections;
using UnityEngine;
using static Enums;

public class FightController : MonoBehaviour
{
    [SerializeField] private float _changeWeaponDelay;

    private m_CharacterController _characterController;
    private EnemyController _enemyController;

    private Coroutine _characterFight;
    private Coroutine _enemyFight;
    private Coroutine test;

    private bool _isChangeWeapon = false;

    private void Start()
    {
        _characterController = GameController.s_Instance.CharacterController;
        _enemyController = GameController.s_Instance.EnemyController;

        GameController.s_Instance.UpdateIsFighting += SwitchFight;
        _characterController.ChangeTypeAttack += ChangeTypeAttack;
    }

    private void OnDestroy()
    {
        GameController.s_Instance.UpdateIsFighting -= SwitchFight;
        _characterController.ChangeTypeAttack -= ChangeTypeAttack;
    }

    private void SwitchFight(bool isFighting)
    {
        if (isFighting)
        {
            _enemyController.Spawn();

            _characterController.IndicatorController.gameObject.SetActive(isFighting);
            _enemyController.IndicatorController.gameObject.SetActive(isFighting);

            _characterFight = CoroutineManager.s_Instance.StartCoroutine(CharacterFight());
            _enemyFight = CoroutineManager.s_Instance.StartCoroutine(EnemyFight());
        }
        else
        {
            _enemyController.Delete();

            _characterController.IndicatorController.gameObject.SetActive(isFighting);
            _enemyController.IndicatorController.gameObject.SetActive(isFighting);

            CoroutineManager.s_Instance.StopCoroutine(_characterFight);
            CoroutineManager.s_Instance.StopCoroutine(_enemyFight);
        }
    }

    private void ChangeTypeAttack()
    {
        _isChangeWeapon = true;
    }

    private IEnumerator CharacterFight()
    {
        while (true)
        {
            _characterController.IndicatorController.IsPreparation = true;
            yield return StartCoroutine(FillImage(_characterController.Characteristics.Preparation.Value, _characterController.IndicatorController, true));

            _characterController.IndicatorController.IsAttacking = true;
            yield return StartCoroutine(FillImage(_characterController.AttackSpeed, _characterController.IndicatorController));

            int characterDamage = _characterController.Damage - _enemyController.Enemy.armor;

            _enemyController.TakeDamage(characterDamage <= 0 ? 0 : characterDamage);

            if (_isChangeWeapon)
            {
                yield return new WaitForSeconds(_changeWeaponDelay);
                _isChangeWeapon = false;
            }
        }
    }

    private IEnumerator EnemyFight()
    {
        while (true)
        {
            _enemyController.IndicatorController.IsPreparation = true;
            //Подготовка
            yield return StartCoroutine(FillImage(_enemyController.Enemy.preparation, _enemyController.IndicatorController));

            _enemyController.IndicatorController.IsAttacking = true;
            //Атака
            yield return StartCoroutine(FillImage(_enemyController.Enemy.attackSpeed, _enemyController.IndicatorController));

            int enemyDamage = _enemyController.Enemy.damage - _characterController.Armor;

            _characterController.TakeDamage(enemyDamage <= 0 ? 0 : enemyDamage);
        }
    }

    private IEnumerator FillImage(float fillDuration, IndicatorController indicator, bool isCharacter = false)
    {
        indicator.Bar.fillAmount = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            indicator.Bar.fillAmount = Mathf.Clamp01(elapsedTime / fillDuration);

            if (_isChangeWeapon && isCharacter)
            {
                yield return new WaitForSeconds(_changeWeaponDelay);
                _isChangeWeapon = false;
            }

            yield return null;
        }

        indicator.Bar.fillAmount = 0f;
    }
}
