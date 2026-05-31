using System;
using UnityEngine;

[System.Serializable]
public class MonsterTraitValue
{
    public MonsterTraitSO Trait;

    [Range(1, 10)]
    public int Value = 1;
}