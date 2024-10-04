using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public abstract class ButtonCommand : MonoCommand
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        Assert.IsNotNull(_button, "[ButtonCommand] is null");

        _button.onClick.AddListener(Execute);
    }

    protected virtual void OnDestroy()
    {
        _button.onClick.RemoveListener(Execute);
    }
}
