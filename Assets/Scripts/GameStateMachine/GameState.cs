
public enum GameStateEnum
{
    Authentication,
    EnemySearch,
    Battle,
    BattleResult,
}

public abstract class GameState
{
    protected PanelController _panelController;

    private GameStateEnum _gameStateName;

    public GameState(PanelController panelController)
    {
        _panelController = panelController;
    }

    public abstract void EnterState();
    public abstract void UpdateState(bool active);
    public abstract void ExitState();
}

public class AuthenticationState : GameState
{
    public AuthenticationState(PanelController panelController) : base(panelController) { }

    public override void EnterState()
    {
        _panelController.ShowAuthenticationPanel();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState(bool active)
    {

    }
}

public class EnemySearchState : GameState
{
    public EnemySearchState(PanelController panelController) : base(panelController) { }

    public override void EnterState()
    {
        _panelController.ShowEnemySearchPanel();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState(bool active)
    {
        _panelController.UpdateEnemySearchState(active);
    }
}

public class BattleState : GameState
{
    public BattleState(PanelController panelController) : base(panelController) { }

    public override void EnterState()
    {
        _panelController.ShowBattlePanel();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState(bool active)
    {

    }
}

public class BattleResultState : GameState
{
    public BattleResultState(PanelController panelController) : base(panelController) { }

    public override void EnterState()
    {
        _panelController.ShowBattleResultPanel();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState(bool active)
    {

    }
}
