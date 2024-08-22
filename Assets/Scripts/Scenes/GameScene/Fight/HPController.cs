using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private Image _bar;

    private int _limit;

    public void SetHP(int value, int limit)
    {
        _limit = limit;
        _value.text = value + " / " + _limit;
        _bar.fillAmount = (float)value / _limit;
    }

    public void SetHP(int value)
    {
        _value.text = value + " / " + _limit;
        _bar.fillAmount = (float)value / _limit;
    }
}
