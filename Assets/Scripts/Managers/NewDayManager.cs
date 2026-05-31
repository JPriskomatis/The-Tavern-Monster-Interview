using System;
using System.Collections;
using UnityEngine;

public class NewDayManager : MonoBehaviour
{
    /*
     * We need to fire an Event that goes to the next day, meaning the follow things should Happen
     * 
     * Event -> New Monster in the tavern, newspaper updated
     */

    //Event about next day
    public GameEvent NewDay;


    [Header("Days Settings")]
    public int currentDay = 1;

    [SerializeField] private MonsterSelector monsterSelector;

    public MonsterSO CurrentMonster { get; private set; }

    private GameObject currentMonsterObject;

    public WorldEventSO CurrentEvent { get; private set; }

    [SerializeField] private Transform destinationTransform;

    public void AdvanceDay()
    {
        currentDay++;

        GenerateDay();
    }

    private void GenerateDay()
    {
        //We destroy the previous day's monster;
        if(currentMonsterObject != null)
        {
            Destroy(currentMonsterObject);
        }

        CurrentMonster =
            monsterSelector.GetMonster(currentDay);

        currentMonsterObject = monsterSelector.SpawnMonster(CurrentMonster);

        StartCoroutine(MoveTowards(currentMonsterObject, destinationTransform, 3f));

        //The next couple of parts generate the things we need for the new day, a new newspaper and a new monster;
        WorldEventSO forcedEvent = CurrentMonster.eventReference;

        if (forcedEvent != null)
        {
            CurrentEvent = Convert(forcedEvent);
        }
        else
        {
            Debug.LogWarning("Something wrong with the event");
        }

        
        

        Debug.Log($"DAY {currentDay}");
        Debug.Log($"Monster: {CurrentMonster.monsterName}");
        Debug.Log($"Headline: {CurrentEvent.title}");
    }

    public IEnumerator MoveTowards(GameObject monster, Transform target, float speed)
    {
        while (Vector3.Distance(monster.transform.position, target.position) > 0.01f)
        {
            Vector3 direction = (target.position - monster.transform.position).normalized;

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                monster.transform.rotation = Quaternion.Slerp(
                    monster.transform.rotation,
                    lookRotation,
                    10f * Time.deltaTime
                );
            }

            monster.transform.position = Vector3.MoveTowards(
                monster.transform.position,
                target.position,
                speed * Time.deltaTime
            );

            yield return null;
        }

        monster.transform.position = target.position;
    }

    private WorldEventSO Convert(WorldEventSO eventData)
    {
        WorldEventSO data = new WorldEventSO();

        data.title = eventData.title;
        data.description= eventData.description;

        return data;
    }
}
