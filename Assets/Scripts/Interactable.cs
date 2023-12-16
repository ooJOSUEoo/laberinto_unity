using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Message displayed to player when looking at an interactable.
    public bool useEvents;
    [SerializeField]

    public string prompMessage;

    public virtual string OnLook()
    {
        return prompMessage;
    }

    //This function will be called from our player.
    public void BaseInteract()
    {
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        //We wont have any code written in this function
        //This is a template function to be overridden by our subclasses
    }
}