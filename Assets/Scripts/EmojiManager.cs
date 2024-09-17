using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiManager : MonoBehaviour
{   
 
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Sprites/calm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
