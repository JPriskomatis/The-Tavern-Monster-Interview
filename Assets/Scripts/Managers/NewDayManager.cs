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
    [SerializeField] private int currentDay;

    [Header("Systems")]
    [SerializeField] private NewspaperGenerator newspaperGenerator;
    
    [SerializeField] private MonsterSelector monsterSelector;

    public NewspaperData CurrentNewspaper { get; private set; }
    public MonsterSO CurrentMonster { get; private set; }

    private GameObject currentMonsterObject;

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
        Destroy(currentMonsterObject);

        CurrentNewspaper =
            newspaperGenerator.Generate(currentDay);

        CurrentMonster =
            monsterSelector.GetMonster(currentDay);

        currentMonsterObject = monsterSelector.SpawnMonster(CurrentMonster);
        

        Debug.Log($"DAY {currentDay}");
        Debug.Log($"Monster: {CurrentMonster.monsterName}");
        Debug.Log($"Headline: {CurrentNewspaper.eventTitle}");
    }
}
