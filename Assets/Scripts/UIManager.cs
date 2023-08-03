using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject aiCamera;
    [SerializeField]
    private Text usernameText;
    [SerializeField]
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    void ToggleAIView() {
        if (aiCamera.activeSelf)
        {
            aiCamera.SetActive(false);
        } 
        else 
        {
            aiCamera.SetActive(true);
        }
    }

}
