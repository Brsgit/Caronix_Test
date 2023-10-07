using System;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private AuthenticatonPanel _authenticationPanel;
    [SerializeField] private EnemySearchPanel _enemySearchPanel;
    [SerializeField] private BattlePanel _battlePanel;
    [SerializeField] private BattleResultPanel _battleResultPanel;

    public event Action<string> OnAuthenticationComplete;
    public event Action OnNewEnemySearch;
    public event Action OnHeadToBattle;
    public event Action OnBattleFinished;
    public event Action<int> OnResultExit;

    private void OnEnable()
    {
        _authenticationPanel.OnContinue += (name) => OnAuthenticationComplete?.Invoke(name);
        _enemySearchPanel.OnContinueClick += () => OnHeadToBattle?.Invoke();
        _enemySearchPanel.OnNewEnemyClick += () => OnNewEnemySearch?.Invoke();
        _battlePanel.OnBattleFinished += () => OnBattleFinished?.Invoke();
        _battleResultPanel.OnContinueClick += (score) => OnResultExit?.Invoke(score);
    }


    private void OnDisable()
    {
        _authenticationPanel.OnContinue -= (name) => OnAuthenticationComplete?.Invoke(name);
        _enemySearchPanel.OnContinueClick -= () => OnHeadToBattle?.Invoke();
        _enemySearchPanel.OnNewEnemyClick -= () => OnNewEnemySearch?.Invoke();
        _battlePanel.OnBattleFinished -= () => OnBattleFinished?.Invoke();
        _battleResultPanel.OnContinueClick -= (score) => OnResultExit?.Invoke(score);
    }

    private void ClearScene()
    {
        _authenticationPanel.Hide();
        _enemySearchPanel.Hide();
        _battlePanel.Hide();
        _battleResultPanel.Hide();
    }

    public void ShowAuthenticationPanel()
    {
        ClearScene();
        _authenticationPanel.Show();
    }

    public void ShowEnemySearchPanel()
    {
        ClearScene();
        _enemySearchPanel.Show();
    }

    public void ShowBattlePanel()
    {
        ClearScene();
        _battlePanel.Show();
    }

    public void ShowBattleResultPanel()
    {
        ClearScene();
        _battleResultPanel.Show();
    }

    public void SetPlayerInfo(PlayerData playerData)
    {
        _enemySearchPanel.SetPlayerInfo(playerData.Name, playerData.Score.ToString());
    }

    public void UpdateEnemySearchState(bool show)
    {
        _enemySearchPanel.ShowLoadingPanel(show);
    }

    public void UpdateEnemyInfo(EnemyData enemyData)
    {
        _enemySearchPanel.SetEnemyInfo(enemyData.Name, enemyData.Picture);
        _battlePanel.SetEnemyInfo(enemyData.Name, enemyData.Picture);
        _battleResultPanel.SetBattleResultInfo(enemyData.Name);
    }

}
