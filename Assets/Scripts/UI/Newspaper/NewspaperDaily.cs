using TMPro;
using UnityEngine;

public class NewspaperDaily : MonoBehaviour
{
    [SerializeField] private NewDayManager dayManager;

    [SerializeField] private TextMeshProUGUI eventTitle;
    [SerializeField] private TextMeshProUGUI eventDescription;

    [SerializeField] private TextMeshProUGUI currentDayNum;

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
        currentDayNum.text = "Day "+dayManager.currentDay.ToString();
    }
}