using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Slider))]
public class EnemyHealthBar : MonoBehaviour
{
    private Slider _healthBar;
    private TMP_Text _healthText;

    private int _healthValue;

    public event Action OnNoMorehealth;

    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
        _healthText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _healthValue = Random.Range(50, 101);
        _healthBar.maxValue = _healthValue;
        UpdateHealthBar();
    }

    public void DealDamage()
    {
        var damage = Random.Range(5, 11);
        _healthValue -= damage;

        if(_healthValue < 0)
        {
            _healthValue = 0;
            OnNoMorehealth?.Invoke();
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = _healthValue;
        _healthText.text = _healthValue.ToString();
    }
}
