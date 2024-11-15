using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGameModel : MonoBehaviour
{
    private Dictionary<int, Dictionary<Transform, float>> _levelsData;
    private int _currentLevel;

    [SerializeField] private List<Transform> _winFieldPositions;
    [SerializeField] private List<float> _winFieldSizes;

    private void Awake()
    {
        _levelsData = new();

        _currentLevel = 0;

        for (int i = 0; i < _winFieldPositions.Count; i++)
        {
            Dictionary<Transform, float> dictionary = new Dictionary<Transform, float>();

            dictionary.Add(_winFieldPositions[i], _winFieldSizes[i]);

            _levelsData.Add(i+1, dictionary);
        }
    }

    public Dictionary<Transform, float> NextLevel()
    {
        _currentLevel++;

        if (_currentLevel <= _levelsData.Count)
        {
            return _levelsData[_currentLevel];
        }

        return null;
    }
}
