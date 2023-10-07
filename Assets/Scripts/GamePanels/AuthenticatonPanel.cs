using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthenticatonPanel : GamePanel
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private TMP_Text _text;

    public event Action<string> OnContinue;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(() => OnContinue?.Invoke(_text.text));
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(() => OnContinue?.Invoke(_text.text));
    }

    private void Update()
    {
        if(_text.text.Length > 1)
        {
            _continueButton.interactable = true;
        }
        else
        {
            _continueButton.interactable = false;
        }
    }

    public override void Hide()
    {
        _panel.SetActive(false);
    }

    public override void Show()
    {
        _panel.SetActive(true);
    }
}
