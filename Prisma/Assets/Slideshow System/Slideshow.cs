using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slideshow : MonoBehaviour
{
    public static Slideshow scriptSlides;
    public Image frame;
    private List<Sprite> slideSequence = new List<Sprite>();

    public static bool bPlaying; 

    private int currentIndex;

    private void Awake()
    {
        scriptSlides = this;
    }

    public void StartSequence(List<Sprite> slides)
    {
        if (slides.Count != 0)
        {
            bPlaying = true;
            slideSequence = slides;
            currentIndex = 0;
            frame.enabled = true;
            PlaySlide();
        }
        else
            Debug.LogError("No slides to be played!");

    }

    public void PlaySlide()
    {
        frame.sprite = slideSequence[currentIndex];

    }

    public void EndSequence()
    {
        frame.enabled = false;
        bPlaying = false;
        slideSequence.Clear();

    }

    public void NexSlide()
    {

        if (currentIndex >= slideSequence.Count -1)
            EndSequence();
        else
        {
            currentIndex++;
         //   Debug.Log(currentIndex);
            PlaySlide();
        }

    }


}
