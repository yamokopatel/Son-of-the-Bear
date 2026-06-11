using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StaticLines", menuName = "Scriptable Objects/StaticLines")]
public class StaticLines : ScriptableObject
{
    [SerializeField] private List<string> localLines = new List<string>();

    public Dictionary<string, string> lineMap = new Dictionary<string, string>();
}
