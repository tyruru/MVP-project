using UnityEngine;

public abstract class MonoCommand : MonoBehaviour, ICommand
{
    public abstract void Execute();
}
