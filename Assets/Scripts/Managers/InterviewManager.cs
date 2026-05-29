using UnityEngine;

public class InterviewManager : MonoBehaviour
{
    public MonsterContext currentMonster;

    public void StartInterview(MonsterSO monster)
    {
        currentMonster.monster = monster;
    }

    public void AcceptMonster()
    {
        Debug.Log("Accepted: "+ currentMonster.monster.monsterName);
    }

    public void RejectMonster()
    {
        Debug.Log("Reject: " + currentMonster.monster.monsterName);
    }
}
