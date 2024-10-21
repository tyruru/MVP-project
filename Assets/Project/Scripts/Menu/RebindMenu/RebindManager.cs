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
    public BindingReference currentBinding; // Привязка, которую нужно переназначить
    public Button rebindButton;               // Кнопка для старта переназначения
    public TextMeshProUGUI buttonLabel;                  // Текст кнопки, отображающий текущую клавишу

    private RebindingOperation rebindingOperation; // Хранит текущую операцию переназначения

    private const string RebindsKey = "rebinds";

    private void Start()
    {
        LoadRebinds();

        if (currentBinding.actionReference != null && currentBinding.actionReference.action != null)
        {
            rebindButton.onClick.AddListener(StartRebind);
            UpdateButtonLabel();
        }
    }

    private void StartRebind()
    {
        EnterTextLabel();
        var action = currentBinding.actionReference.action; // Получаем действие из ссылки
        action.Disable();

        // Отключаем предыдущую операцию переназначения, если она существует
        rebindingOperation?.Dispose();

        rebindingOperation = action.PerformInteractiveRebinding(currentBinding.bindingIndex)
            .OnComplete(operation =>
            {
                action.Enable();
                UpdateButtonLabel();
                SaveRebinds();
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
        var action = currentBinding.actionReference.action; // Получаем действие из ссылки
        var binding = action.bindings[currentBinding.bindingIndex];
        buttonLabel.text = InputControlPath.ToHumanReadableString(binding.effectivePath);
    }

    private void EnterTextLabel()
    {
        buttonLabel.text = "Waiting for input...";
    }

    // Сохранение биндов
    private void SaveRebinds()
    {
        var action = currentBinding.actionReference.action;
        string rebindsJson = action.SaveBindingOverridesAsJson();  // Сохраняем привязку как JSON
        PlayerPrefs.SetString(RebindsKey + action.name, rebindsJson);  // Сохраняем отдельно для каждого действия
        
        PlayerPrefs.Save();
    }

    // Загрузка всех биндов при запуске программы
    private void LoadRebinds()
    {
        var action = currentBinding.actionReference.action;
        string key = RebindsKey + action.name;

        if (PlayerPrefs.HasKey(key))
        {
            string rebindsJson = PlayerPrefs.GetString(key);
            action.LoadBindingOverridesFromJson(rebindsJson);  // Загружаем бинды
        }
        
    }

    // Сброс всех биндов
    public void ResetRebinds()
    { 
        var action = currentBinding.actionReference.action;
        action.RemoveAllBindingOverrides();
        PlayerPrefs.DeleteKey(RebindsKey + action.name);  // Удаляем сохранённые бинды
        
        UpdateButtonLabel();
    }
}
