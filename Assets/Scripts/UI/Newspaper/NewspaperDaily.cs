using TMPro;
using UnityEngine;

public class NewspaperDaily : MonoBehaviour
{
    [SerializeField] private NewDayManager dayManager;

    [SerializeField] private TextMeshProUGUI eventTitle, eventDescription;

    private void Start() => RefreshNewsPaper();

    public void RefreshNewsPaper()
    {
        eventTitle.text = dayManager.CurrentNewspaper.eventTitle;
        eventDescription.text = dayManager.CurrentNewspaper.eventDescription;
    }
}
