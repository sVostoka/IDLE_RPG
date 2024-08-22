using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private TextMeshProUGUI _lvlValue;
    [SerializeField] private TextMeshProUGUI _expValue;

    private void Awake()
    {
        ResourceManager.s_Instance.Level.ChangeLvlValue += ChangeLvl;
        ResourceManager.s_Instance.Level.ChangeExperienceValue += ChangeExp;
    }

    private void Start()
    {
        ChangeLvl();
        ChangeExp();
    }

    private void OnDisable()
    {
        ResourceManager.s_Instance.Level.ChangeLvlValue -= ChangeLvl;
        ResourceManager.s_Instance.Level.ChangeExperienceValue -= ChangeExp;
    }

    private void ChangeLvl()
    {
        _lvlValue.text = "Lv." + ResourceManager.s_Instance.Level.Value;
    }

    private void ChangeExp()
    {
        _expValue.text = _expValue.text = ResourceManager.s_Instance.Level.Experience + " / " + ResourceManager.s_Instance.Level.LimitExp;
        _bar.fillAmount = (float)ResourceManager.s_Instance.Level.Experience / ResourceManager.s_Instance.Level.LimitExp;
    }
}
