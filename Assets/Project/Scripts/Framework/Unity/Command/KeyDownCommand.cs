using UnityEngine;
using UnityEngine.Assertions;

public abstract class KeyDownCommand : MonoCommand
{
    [SerializeField] private KeyCode _key;

    protected virtual void Awake()
    {
        Assert.AreNotEqual(KeyCode.None, _key, "[KeyDownCommand] is null");   
    }

    private void Update()
    {
        if(Input.GetKeyDown(_key))
        {
            Execute();
        }
    }
}
