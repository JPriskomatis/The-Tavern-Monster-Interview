using UnityEngine;

public class NewsBoard : InteractableItem
{
    protected override void BeginInteraction()
    {
        Debug.Log("Reading newspaper...");
    }
}
