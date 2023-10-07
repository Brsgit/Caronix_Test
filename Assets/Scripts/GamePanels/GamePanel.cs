using UnityEngine;

public abstract class GamePanel : MonoBehaviour
{
    [SerializeField] protected GameObject _panel;

    public abstract void Show();
    public abstract void Hide();
}
