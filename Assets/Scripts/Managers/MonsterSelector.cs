using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MonsterSelector : MonoBehaviour
{
    /*
     * 1. Get all monsters
     *  2. Filter by rules (day, later reputation, events)
     *  3. Build weighted pool
     *  4. Pick random based on weight
     *  5. Return MonsterSO
     */

    [SerializeField] private Transform spawnLocation;
    [SerializeField] private MonsterSO[] monsters;

    public MonsterSO GetMonster(int day)
    {
        Debug.Log("Monsters array size: " + monsters.Length);
        List<MonsterSO> validMonsters = new List<MonsterSO>();

        //We add all the valid monsters into our list;

        foreach(var monster in monsters)
        {
            if (day < monster.minDay) continue;
            if (day > monster.maxDay) continue;

            validMonsters.Add(monster);
        }

        if(validMonsters.Count == 0)
        {
            Debug.LogWarning("No valid monsters for this day");
            return null;
        }

        float totalWeight = 0f;
        foreach (var monster in validMonsters)
        {
            totalWeight += monster.spawnWeight;
        }
        
        float roll = Random.Range(0f, totalWeight);

        float current = 0f;

        foreach (var monster in validMonsters)
        {
            current += monster.spawnWeight;
            
            if(roll <= current)
            {
                return monster;
            }

        }


        return monsters[0];
    }

    public GameObject SpawnMonster(MonsterSO monster)
    {
        return Instantiate(monster.monsterObject, spawnLocation);
    }
}