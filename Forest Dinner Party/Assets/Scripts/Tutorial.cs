using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public RawImage display;
    public GameObject game;
    public List<Texture> slides;
    int currentSlide;

    public void PlayTutorial()
    {
        gameObject.SetActive(true);
        game.SetActive(false);
        currentSlide = 0;
        display.texture = slides[currentSlide];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentSlide++;
            if (currentSlide == slides.Count)
            {
                EndTutorial();
            }
            else
            {
                display.texture = slides[currentSlide];
            }
        }
    }

    void EndTutorial()
    {
        gameObject.SetActive(false);
        game.SetActive(true);
    }
}
