using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySearchPanel : GamePanel
{
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private GameObject _enemyFoundPanel;

    [Header("Buttons")]
    [SerializeField] private Button _newEnemyButton;
    [SerializeField] private Button _continueButton;

    [Header("Player")]
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerScore;

    [Header("Enemy")]
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private Image _enemyImage;

    public event Action OnContinueClick;
    public event Action OnNewEnemyClick;

    private void OnEnable()
    {
        _newEnemyButton.onClick.AddListener(() => OnNewEnemyClick?.Invoke());
        _continueButton.onClick.AddListener(() => OnContinueClick?.Invoke());        
    }

    private void OnDisable()
    {
        _newEnemyButton.onClick.RemoveListener(() => OnNewEnemyClick?.Invoke());
        _continueButton.onClick.RemoveListener(() => OnContinueClick?.Invoke());
    }

    public override void Hide()
    {
        _panel.SetActive(false);
    }

    public override void Show()
    {
        _panel.SetActive(true);
        _loadingPanel.SetActive(true);
    }

    public void ShowLoadingPanel(bool show)
    {
        _loadingPanel.SetActive(show);
        _enemyFoundPanel.SetActive(!show);
    }

    public void SetPlayerInfo(string name, string score)
    {
        _playerName.text = name;
        _playerScore.text = score;
    }

    public void SetEnemyInfo(string name, Sprite sprite)
    {
        _enemyName.text = name;
        _enemyImage.sprite = sprite;
    }  
}
