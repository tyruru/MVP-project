using UnityEngine;

public abstract class MonoPresenter : MonoBehaviour, IPresenter
{
    public virtual void Enable() { }

    public virtual void Disable() { }
}
