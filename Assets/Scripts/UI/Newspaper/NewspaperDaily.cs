using TMPro;
using UnityEngine;

public class NewspaperDaily : MonoBehaviour
{
    [SerializeField] private NewDayManager dayManager;

    [Header("Event 1")]
    [SerializeField] private TextMeshProUGUI eventTitle;
    [SerializeField] private TextMeshProUGUI eventDescription;

    [Header("Event 2")]
    [SerializeField] private TextMeshProUGUI eventTitle1;
    [SerializeField] private TextMeshProUGUI eventDescription2;

    [SerializeField] private TextMeshProUGUI currentDayNum;

    [SerializeField] private WorldEventSO[] randomWorldEvent;
    private WorldEventSO currentRandomEvent;

    private void Start()
    {
        RefreshNewsPaper();
    }

    public void RefreshNewsPaper()
    {
        var currentEvent = dayManager.CurrentEvent;

        if (currentEvent == null) return;

        eventTitle.text = currentEvent.title;
        eventDescription.text = currentEvent.description;
        currentDayNum.text = "Day "+dayManager.CurrentDay.Value.ToString();

        GetRandomEvent();
        eventTitle1.text = currentRandomEvent.title;
        eventDescription2.text = currentRandomEvent.description;


    }

    private void GetRandomEvent()
    {
        int randomInx = Random.Range(0, randomWorldEvent.Length);
        currentRandomEvent = randomWorldEvent[randomInx];
    }
}