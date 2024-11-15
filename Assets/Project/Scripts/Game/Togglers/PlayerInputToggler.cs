using UnityEngine.InputSystem;

public class PlayerInputToggler : AbstractToggler<PlayerInput>
{
    private void Start()
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        _objects.Add(playerInput);
    }
}
