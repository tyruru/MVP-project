using Zenject;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class AbstractBehaviour : MonoBehaviour
{
    protected Rigidbody2D _body2d;
    [Inject] protected PlayerModel _model;

    protected virtual void Awake()
    {
        _body2d.GetComponentInParent<Rigidbody2D>();
        Assert.IsNull(_body2d, "[Body2d] is missed");
    }


}
