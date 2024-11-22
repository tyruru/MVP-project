using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInteract : AbstractBehaviour
{
    private PlayerFindInteractableTargets _findInteractable;
    private InputAction _interactInput;

    private void Start()
    {
        _findInteractable = GetComponent<PlayerFindInteractableTargets>();
        _interactInput = _playerInput.actions.FindAction("Vertical");
    }

    private void Update()
    {
        if(_findInteractable.CurrentTarget != null)
        {
            if (Time.timeScale == 0f)
                return;

            if(_interactInput.ReadValue<float>() == 1)
            {
                _findInteractable.CurrentTarget.GetComponent<IInteractable>().Execute();
            }
        }
    }
}
