using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Hello");
        OnActivated();
    }

    public virtual void OnActivated()
    {
        // To be implemented
    }

}
