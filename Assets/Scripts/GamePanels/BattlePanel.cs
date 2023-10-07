using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanel : GamePanel
{

    [Header("Enemy")]
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private Image _enemyImage;
    [SerializeField] private EnemyHealthBar _enemyHealthBar;

    [SerializeField] private ClickHandler _clickHandler;

    public event Action OnBattleFinished;

    private void OnEnable()
    {
        _enemyHealthBar.OnNoMorehealth += () => OnBattleFinished?.Invoke();
        _clickHandler.OnImageClick += () => _enemyHealthBar.DealDamage();
    }

    private void OnDisable()
    {
        _enemyHealthBar.OnNoMorehealth -= () => OnBattleFinished?.Invoke();
        _clickHandler.OnImageClick -= () => _enemyHealthBar.DealDamage();
    }

    public override void Hide()
    {
        _panel.SetActive(false);
    }

    public override void Show()
    {
        _panel.SetActive(true);
    }

    public void SetEnemyInfo(string name, Sprite sprite)
    {
        _enemyName.text = name;
        _enemyImage.sprite = sprite;
    }
}
