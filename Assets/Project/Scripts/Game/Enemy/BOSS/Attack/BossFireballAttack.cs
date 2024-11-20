using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireballAttack : MonoBehaviour, IBossExecute
{
    [SerializeField] Transform _fireProjectile;
    [SerializeField] GameObject _fireball;

    public void Execute()
    {
        Instantiate(_fireball, _fireProjectile.position, Quaternion.identity);
    }
}
