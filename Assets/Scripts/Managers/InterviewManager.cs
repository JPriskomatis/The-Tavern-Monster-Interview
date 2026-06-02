using System.Collections.Generic;
using UnityEngine;

public class InterviewManager : MonoBehaviour
{
    public MonsterContext currentMonster;

    public TavernMonsters tavernMonsters;

    public GameEvent FinishedWithMonster;


    public void StartInterview(MonsterSO monster)
    {
        currentMonster.monster = monster;
    }

    public void AcceptMonster()
    {

        Debug.Log("Accepted: " + currentMonster.monster.monsterName);
        tavernMonsters.acceptedMonsters.Add(currentMonster.monster);



        FinishedWithMonster.Raise();
    }

    public void RejectMonster()
    {
        Debug.Log("Reject: " + currentMonster.monster.monsterName);

        tavernMonsters.rejectedMonsters.Add(currentMonster.monster);

        FinishedWithMonster.Raise();
    }
}
