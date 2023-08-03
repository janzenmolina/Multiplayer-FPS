using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleSystemManager : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private ParticleSystem myParticleSystem;
    [SerializeField]
    private Sprite[] emojis;

    private Slider vaSlider;
    private Image vaEmoji;
    

    void Start()
    {
        vaEmoji = GameObject.Find("VAHandle").GetComponent<Image>();
        vaSlider = GameObject.Find("VASlider").GetComponent<Slider>();
        InvokeRepeating("ChangeSliderValue", 5.0f, 5.0f);
    }

    void Update()
    {  

    }

    void ChangeColor(float newValue) 
    {
        var colorOverLifetime = myParticleSystem.colorOverLifetime;
        colorOverLifetime.enabled = true;
        Gradient gradient = new Gradient();

            if (newValue >= 0.0f) 
            {
                gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(new Color(1.0f, 1.0f - newValue, 1.0f - newValue), 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
                );
            }
            else 
            {
                gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(new Color(1.0f + newValue, 1.0f + newValue, 1.0f), 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
                );
            }

             colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
    }

    void ChangeEmoji() 
    {
        if (vaSlider.value >= -1.0f && vaSlider.value < -0.6f)
        {
            vaEmoji.sprite = emojis[0];
        }
        else if (vaSlider.value > -0.6f && vaSlider.value <= -0.2f)
        {
            vaEmoji.sprite = emojis[1];
        }
        else if (vaSlider.value > -0.2f && vaSlider.value <= 0.2f)
        {
            vaEmoji.sprite = emojis[2];
        }
        else if (vaSlider.value > 0.2f && vaSlider.value <= 0.6f)
        {
            vaEmoji.sprite = emojis[3];
        }
        else if (vaSlider.value > 0.6f && vaSlider.value <= 1.0f)
        {
            vaEmoji.sprite = emojis[4];
        }   
        else 
        {
            vaEmoji.sprite = emojis[2];
        }
    }

    void ChangeSliderValue()
    {
        vaSlider.value = Random.Range(-1.0f, 1.0f);
        ChangeColor(vaSlider.value);
        ChangeEmoji();
    }

    void ChangeSliderValue(float newValue)
    {
        vaSlider.value = newValue;
        ChangeColor(vaSlider.value);
        ChangeEmoji();
    }

}
