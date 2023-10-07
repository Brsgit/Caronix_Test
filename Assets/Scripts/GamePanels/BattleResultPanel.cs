using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleResultPanel : GamePanel
{

    [SerializeField] private TMP_Text _enemyNameText;
    [SerializeField] private TMP_Text _scoreGainedtext;

    [SerializeField] private Button _continueButton;

    private const string ENEMY_NAME_PREFIX = "Бой с ";

    private int _reward = 0;

    public event Action<int> OnContinueClick;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(() => OnContinueClick?.Invoke(_reward));
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(() => OnContinueClick?.Invoke(_reward));
    }

    private void UpdateRewardInfo()
    {
        _reward = Random.Range(100, 1001);
        _scoreGainedtext.text = _reward.ToString();
    }

    public override void Hide()
    {
        _panel.SetActive(false);
    }
    public override void Show()
    {
        _panel.SetActive(true);
    }

    public void SetBattleResultInfo(string name)
    {
        UpdateRewardInfo();
        _enemyNameText.text = ENEMY_NAME_PREFIX + name;
    }
}
