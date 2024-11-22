using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject _boosPrefab;
    [SerializeField] ShowDialogInteractable _dialog;

    private void Start()
    {
        _dialog.OnDialogEnd += SpawnBoss;
    }

    private void SpawnBoss()
    {
        Instantiate(_boosPrefab);
    }
}
