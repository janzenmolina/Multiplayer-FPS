using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class ScoreboardItem : MonoBehaviour
{   
    [SerializeField]
    private Text usernameText;
    [SerializeField]
    private Text scoreText;

    public void Initialize(Player player)
    {
        usernameText.text = player.NickName;
    }
}
