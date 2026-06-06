using EJETAGame;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TutorialFlow : InteractableItem
{
    public UnityEvent TalkToKnight;

    protected override void BeginInteraction()
    {
        TalkToKnight?.Invoke();
    }
}
