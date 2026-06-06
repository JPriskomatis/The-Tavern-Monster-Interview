using UnityEngine;

public class SimpleInteraction : InteractableItem
{
    public GameEvent SkipDay;
    protected override void BeginInteraction()
    {
        SkipDay.Raise();
    }
}
