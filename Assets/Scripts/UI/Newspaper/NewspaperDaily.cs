using TMPro;
using UnityEngine;

public class NewspaperDaily : MonoBehaviour
{
    public NewspaperData NewspaperData;

    [SerializeField] private TextMeshProUGUI eventTitle, eventDescription;

    //Event to fire a new event on the newspaper;
    public NewspaperData[] newspaperDatas;
    public GameEvent NewEventNewspaper;

    private void Start () =>SetUpNewspaper(NewspaperData);

    public void NewEvent()
    {
        NewspaperData randomEvent = newspaperDatas[Random.Range(0, newspaperDatas.Length)];
        Debug.Log(randomEvent.eventTitle);
        SetUpNewspaper(randomEvent);
    }
    public void SetUpNewspaper(NewspaperData data)
    {
        eventTitle.text = data.eventTitle;
        eventDescription.text = data.eventDescription;
    }
}
