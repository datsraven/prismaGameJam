using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnActivate;
    public Texture2D cursor;
    void OnMouseDown()
    {
        Debug.Log("Hello");
        Activate();
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);   
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public virtual void Activate()
    {
        OnActivate.Invoke();
        
    }

}
