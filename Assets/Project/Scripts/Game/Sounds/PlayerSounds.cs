using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource walk;

    private void OnEnable()
    {
        PlayerJump.OnJump += JumpSound;
        PlayerWalk.OnWalk += WalkSound;
    }

    private void OnDisable()
    {
        PlayerJump.OnJump -= JumpSound;
        PlayerWalk.OnWalk -= WalkSound;
    }

    public void JumpSound()
    {
        jump.Play();
    }

    public void WalkSound()
    {
        walk.Play();
    }
}
