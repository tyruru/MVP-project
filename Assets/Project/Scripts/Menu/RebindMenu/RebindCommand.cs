using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using static UnityEngine.InputSystem.InputActionRebindingExtensions;

[System.Serializable]
public class BindingReference
{
    public InputActionReference actionReference;
    [HideInInspector] public int bindingIndex;
}

public class RebindCommand : ButtonCommand
{
    public BindingReference currentBinding; // Привязка, которую нужно переназначить

    private RebindingOperation _rebindingOperation; // Хранит текущую операцию переназначения
    private TextMeshProUGUI _buttonLabel;

    private void Start()
    {
        _buttonLabel = _button.GetComponentInChildren<TextMeshProUGUI>();

        UpdateButtonLabel();
    }

    public override void Execute()
    {
        WaitingTextLabel();
        var action = currentBinding.actionReference.action; // Получаем действие из ссылки
        action.Disable();

        // Отключаем предыдущую операцию переназначения, если она существует
        _rebindingOperation?.Dispose();

        _rebindingOperation = action.PerformInteractiveRebinding(currentBinding.bindingIndex)
            .OnComplete(operation =>
            {
                action.Enable();
                UpdateButtonLabel();
                BindingController.SaveBind(currentBinding.actionReference);
                _rebindingOperation.Dispose();        // Освобождение ресурсов

            })
            .OnCancel(operation =>
            {
                action.Enable();
                Debug.Log("Rebinding cancelled.");
                _rebindingOperation.Dispose();        // Освобождение ресурсов

            })
            .Start();
    }

    protected override void OnDestroy()
    {
        // Освобождаем ресурсы, если еще не освобождены
        _rebindingOperation?.Dispose();
    }

    private void UpdateButtonLabel()
    {
        var action = currentBinding.actionReference.action; // Получаем действие из ссылки
        var binding = action.bindings[currentBinding.bindingIndex];
        _buttonLabel.text = InputControlPath.ToHumanReadableString(binding.effectivePath);
    }

    private void WaitingTextLabel()
    {
        _buttonLabel.text = "Waiting for input...";
    }
}
