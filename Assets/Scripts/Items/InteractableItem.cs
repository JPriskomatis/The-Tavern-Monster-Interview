using EJETAGame;
using TMPro;
using UnityEngine;

public abstract class InteractableItem : MonoBehaviour, IInteractable
{
    [Header("Interaction Settings")]
    [SerializeField] protected bool canInteractWith;
    [SerializeField] protected bool canInteractAgain = false;
    [SerializeField] protected string interactionText;
    private static bool firstInteract = true;

    protected bool interactingWith = false;

    private void Start()
    {
        canInteractWith = true;
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteractWith)
        {
            if (!canInteractAgain)
            {
                canInteractWith = false;
            }
            else
            {
                canInteractWith = true;
            }
            InteractionText.instance.SetText("");
            BeginInteraction();
        }
    }

    public virtual void OnInteractEnter()
    {
        if (firstInteract)
        {
            InteractionText.instance.SetText("Press " + KeyCode.E + " to interact");
            firstInteract = false;
        }
        if (canInteractWith && !interactingWith)
        {
            InteractionText.instance.SetText("[" + KeyCode.E + "] " + interactionText);
        }
        else
        {
            InteractionText.instance.SetText("");
        }
    }

    public void OnInteractExit()
    {
        InteractionText.instance.SetText("");
    }

    //This is the actual interaction that each item script should create the action that we want
    //when the player interacts with the object (eg. run open door script);
    protected abstract void BeginInteraction();
}
