using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractToggler<T> : MonoBehaviour where T : Behaviour
{
    [SerializeField] protected List<T> _objects;

    public virtual void DisableObjects()
    {
        foreach(var obj in _objects)
            obj.enabled = false;
    }

    public virtual void EnableObjects()
    {
        foreach(var obj in _objects)
            obj.enabled = true;
    }
}
