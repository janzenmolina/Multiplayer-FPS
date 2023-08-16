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

    public static float acc;
    public static float bvp;
    public static float gsr;
    public static float ibi;
    public static float hr;
    public static float tmp;

    void Start()
    {
        vaEmoji = GameObject.Find("VAEmoji").GetComponent<Image>();
        vaSlider = GameObject.Find("VASlider").GetComponent<Slider>();
    }

    void Update()
    {  
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {   
            if (Input.GetKey(KeyCode.Mouse0))
            {
            ChangeSliderValue("excited");
            }
            else if (Input.GetKey(KeyCode.Space))
            {
            ChangeSliderValue("delighted");
            }
            else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                ChangeSliderValue("content");
            } 
            else
            {
                ChangeSliderValue("calm");
            }
            
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            ChangeSliderValue("delighted");
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            ChangeSliderValue("excited");
        }
        else if (!Input.anyKey)
        {
            ChangeSliderValue("sleepy");
        } 
        else
        {
            ChangeSliderValue("content");
        }
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

    void ChangeSliderValue(string state)
    {
        switch (state)
        {
            case "sleepy":
            // vaSlider.value = Random.Range(-1.0f, -0.6f);
            vaSlider.value = -0.8f;
            break;
            case "calm":
            // vaSlider.value = Random.Range(-0.6f, -0.2f);
            vaSlider.value = -0.4f;
            break;
            case "content":
            // vaSlider.value = Random.Range(-0.2f, 0.2f);
            vaSlider.value = 0f;
            break;
            case "delighted":
            // vaSlider.value = Random.Range(0.2f, 0.6f);
            vaSlider.value = 0.4f;
            break;
            case "excited":
            // vaSlider.value = Random.Range(0.6f, 1.0f);
            vaSlider.value = 0.8f;
            break;
            default:
            // vaSlider.value = Random.Range(-0.2f, 0.2f);
            vaSlider.value = 0f;
            break;
        }

        ChangeColor(vaSlider.value);
        ChangeEmoji();
    }

}
