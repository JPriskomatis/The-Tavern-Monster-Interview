using TMPro;
using UnityEngine;

public class Reservation : InteractableItem
{

    private string customerNames = "test";

    private string customerType = "test";
    public GameEvent ReservationUI;

    [SerializeField] TextMeshProUGUI npcName, npcType;

    protected override void BeginInteraction()
    {
        Debug.Log("Reserved Table for: "+ customerNames);

        npcName.text = customerNames;
        npcType.text = customerType;
        ReservationUI.Raise();
    }

    public void ApplyReservation(string names, string types)
    {
        customerNames = names;
        customerType = types;


    }
}
