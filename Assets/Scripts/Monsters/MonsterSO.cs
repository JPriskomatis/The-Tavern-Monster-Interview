using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "MonsterData/NewMonster")]
public class MonsterSO : ScriptableObject
{
    [Header("Identity")]
    public string monsterName;
    public GameObject monsterObject;

    [Header("Type")]
    public MonsterType monsterType;

    [Header("Traits")]
    public MonsterTraitValue[] monsterTraits;

    [Header("Progression")]
    public int minDay = 1;
    public int maxDay = 999;

    [Range(0f, 1f)]
    public float spawnWeight = 1f;

    [Header("Story Hook")]
    public WorldEventSO eventReference;

    [Header("Dialogue")]
    public TextAsset inkJSON;
}
