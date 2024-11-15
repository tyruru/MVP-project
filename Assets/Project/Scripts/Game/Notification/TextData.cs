using UnityEngine;
using System;

[Serializable]
public class TextData
{
    [SerializeField] private string[] _sentences;
    public string[] Sentences => _sentences;
}
