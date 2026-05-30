using System;
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

    public GameEventDefinitionSO CurrentEvent { get; private set; }

    private void Start()
    {
        GenerateDay();
    }

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

        //The next couple of parts generate the things we need for the new day, a new newspaper and a new monster;
        GameEventDefinitionSO forcedEvent = CurrentMonster.eventReference;

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

    private GameEventDefinitionSO Convert(GameEventDefinitionSO eventData)
    {
        GameEventDefinitionSO data = new GameEventDefinitionSO();

        data.title = eventData.title;
        data.description= eventData.description;

        return data;
    }
}
