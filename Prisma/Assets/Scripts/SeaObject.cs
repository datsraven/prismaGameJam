using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaObject : Interactable
{
    public override void Activate() 
    {
        base.Activate();
        print("I am the sea");
    }
}
