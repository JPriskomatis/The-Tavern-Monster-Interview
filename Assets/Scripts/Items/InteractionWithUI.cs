using UnityEngine;
using UnityEngine.Events;

public class InteractionWithUI : InteractableItem
{
    public UnityEvent activateEvent;

    public GameEvent StopPlayerMovement;

    public static bool hasRead = false;
    public IntGameEvent FinishedTask;
    protected override void BeginInteraction()
    {
        if (!hasRead)
        {
            FinishedTask.Raise(1);
            hasRead = true;
        }
        Debug.Log("Reading newspaper...");

        StopPlayerMovement.Raise();
        activateEvent?.Invoke();
    }
}
