using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputActionRebindingExtensions;

[System.Serializable]
public class BindingReference
{
    public InputActionReference actionReference; // Измените на InputActionReference
    public int bindingIndex;
}

public class RebindManager : MonoBehaviour
{
    public BindingReference bindingToRebind; // Привязка, которую нужно переназначить
    public Button rebindButton;               // Кнопка для старта переназначения
    public TextMeshProUGUI buttonLabel;                  // Текст кнопки, отображающий текущую клавишу

    private RebindingOperation rebindingOperation; // Хранит текущую операцию переназначения

    private void Start()
    {
        if (bindingToRebind.actionReference != null && bindingToRebind.actionReference.action != null)
        {
            // Назначаем действие на кнопку
            rebindButton.onClick.AddListener(StartRebind);
            UpdateButtonLabel();
        }
    }

    private void StartRebind()
    {
        var action = bindingToRebind.actionReference.action; // Получаем действие из ссылки
        action.Disable();

        // Отключаем предыдущую операцию переназначения, если она существует
        rebindingOperation?.Dispose();

        rebindingOperation = action.PerformInteractiveRebinding(bindingToRebind.bindingIndex)
            .OnComplete(operation =>
            {
                action.Enable();
                UpdateButtonLabel();
                rebindingOperation.Dispose(); // Освобождаем ресурсы после завершения
            })
            .OnCancel(operation =>
            {
                action.Enable();
                Debug.Log("Rebinding cancelled.");
                rebindingOperation.Dispose(); // Освобождаем ресурсы после отмены
            })
            .Start();
    }

    private void OnDestroy()
    {
        // Освобождаем ресурсы, если еще не освобождены
        rebindingOperation?.Dispose();
    }

    private void UpdateButtonLabel()
    {
        var action = bindingToRebind.actionReference.action; // Получаем действие из ссылки
        var binding = action.bindings[bindingToRebind.bindingIndex];
        buttonLabel.text = InputControlPath.ToHumanReadableString(binding.effectivePath);
    }
}
