using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElementSorter : MonoBehaviour
{
    private int playerOrder = 0;
    private SpriteRenderer sprite;
    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update() 
    {
        if(sprite != null)
        {
            if (player.transform.position.y > transform.position.y)
                sprite.sortingOrder = 1;
            else
                sprite.sortingOrder = -1;
        }
    }
}
