using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private StateController _stateController;

    [SerializeField] private PanelController _panelController;

    private PlayerData _playerData;
    private EnemyData _enemyData;


    [Inject]
    private readonly PlayerDataSaver _playerDataSaver;

    private void OnEnable()
    {
        _panelController.OnAuthenticationComplete += SaveNewPlayer;
        _panelController.OnNewEnemySearch += GetEnemyData;
        _panelController.OnHeadToBattle += StartBattleState;
        _panelController.OnBattleFinished += StartBattleResultState;
        _panelController.OnResultExit += ProcessWin;
    }

    private void OnDisable()
    {
        _panelController.OnAuthenticationComplete -= SaveNewPlayer;
        _panelController.OnNewEnemySearch -= GetEnemyData;
        _panelController.OnHeadToBattle -= StartBattleState;
        _panelController.OnBattleFinished -= StartBattleResultState;
        _panelController.OnResultExit -= ProcessWin;
    }

    private void Start()
    {
        _stateController = new StateController(this);

        _playerData = _playerDataSaver.LoadPlayerData();

        if(_playerData.Name == "")
        {
            StartAuthenticationState();
        }
        else
        {
            StartEnemySearchState();
        }

    }

    private void SaveNewPlayer(string playerName)
    {
        _playerData = new PlayerData
        {
            Name = playerName,
            Score = 0
        };

        _playerDataSaver.SavePlayerData(_playerData);

        StartEnemySearchState();
    }

    private void StartAuthenticationState()
    {
        _stateController.ChangeState(new AuthenticationState(_panelController));
    }

    private void StartEnemySearchState()
    {
        _stateController.ChangeState(new EnemySearchState(_panelController));
        GetEnemyData();
        _panelController.SetPlayerInfo((PlayerData)_playerData);
    }

    private void StartBattleState()
    {
        _stateController.ChangeState(new BattleState(_panelController));
    }

    private void StartBattleResultState()
    {
        _stateController.ChangeState(new BattleResultState(_panelController));
    }

    private void ProcessWin(int score)
    {
        _playerData.Score += score;
        _playerDataSaver.UpdateScore(_playerData, _playerData.Score);
        StartEnemySearchState();
    }

    private void GetEnemyData()
    {
        EnemyDataFetcher dataFetcher = GetComponent<EnemyDataFetcher>();

        dataFetcher.OnEnemyDataFetched += (enemyData) =>
        {
            _enemyData = enemyData;
            _panelController.UpdateEnemyInfo(_enemyData);
        };

        dataFetcher.OnEnemyFetchingActive += _stateController.UpdateState;

        dataFetcher.GetNewEnemy();

    }    
}
