using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TavernMonsters", menuName = "World/TavernMonsters")]
public class TavernMonsters : ScriptableObject
{
    public List<MonsterSO> acceptedMonsters = new List<MonsterSO>();
    public List<MonsterSO> rejectedMonsters = new List<MonsterSO>();

    private void OnEnable()
    {
        ResetData();
    }

    public void ResetData()
    {
        acceptedMonsters.Clear();
        rejectedMonsters.Clear();
    }

}
