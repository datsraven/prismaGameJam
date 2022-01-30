using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideshowTriggers : MonoBehaviour
{
    public enum Activation { startUp, triggerEntry }

    [Tooltip("Startup: Starts slideshow on scene entry. \n\n"  +
        "Trigger Entry: Starts slideshow when player collides with trigger component.")]

    public Activation trigger;

    public List<Sprite> slidesToPlay = new List<Sprite>();

    private void Start()
    {
        if (trigger == Activation.startUp)
            StartSlideshow();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (trigger == Activation.triggerEntry)
                StartSlideshow();
        }
        
    }

    public void StartSlideshow()
    {
        Slideshow.scriptSlides.StartSequence(slidesToPlay);
        gameObject.SetActive(false);

    }

}
