using UnityEngine;

public class Reservation : InteractableItem
{

    private string customerNames = "test";

    private string customerType = "test";
    public StringGameEvent ReservationUI;
    protected override void BeginInteraction()
    {
        Debug.Log("Reserved Table for: "+ customerNames);
        ReservationUI.Raise(customerNames + " " + customerType);
    }

    public void ApplyReservation(string names, string types)
    {
        customerNames = names;
        customerType = types;


    }
}
