using UnityEngine;

public class Reservation : InteractableItem
{

    private string customerNames = "test";
    protected override void BeginInteraction()
    {
        Debug.Log("Reserved Table for: "+ customerNames);
    }

    public void ApplyReservation(string names)
    {
        customerNames = names;
    }
}
