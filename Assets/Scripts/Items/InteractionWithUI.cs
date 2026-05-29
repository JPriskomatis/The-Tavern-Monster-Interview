using UnityEngine;
using UnityEngine.Events;

public class InteractionWithUI : InteractableItem
{
    public UnityEvent activateEvent;

    public GameEvent StopPlayerMovement;
    protected override void BeginInteraction()
    {
        Debug.Log("Reading newspaper...");

        StopPlayerMovement.Raise();
        activateEvent?.Invoke();
    }
}
