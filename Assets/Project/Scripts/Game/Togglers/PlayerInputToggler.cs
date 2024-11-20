using UnityEngine.InputSystem;

public class PlayerInputToggler : AbstractToggler<PlayerInput>
{
    PlayerInput playerInput;
    private bool flag = false;

    private void Update()
    {
        if (playerInput == null)
        {
            playerInput = FindObjectOfType<PlayerInput>();
            flag = false;
            return;
        }

        if (playerInput != null && !flag)
        {
            _objects.Add(playerInput);
            flag = true;
        }
    }

    public override void DisableObjects()
    {
        playerInput.enabled = false;
    }

    public override void EnableObjects()
    {
        playerInput.enabled = true;
    }
}
