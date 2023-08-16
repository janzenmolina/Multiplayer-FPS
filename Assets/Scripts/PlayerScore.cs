using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

// TODO: finish score system later, this script is not used now.
public class PlayerScore : MonoBehaviourPunCallbacks
{

    // [SerializeField]
    // private Transform container;
    // [SerializeField]
    // private GameObject scoreboardItemPrefab;

    // void Start()
    // {
    //     foreach(Player player in PhotonNetwork.PlayerList)
    //     {
    //         AddScoreboardItem(player);
    //     }
    // }

    // void AddScoreboardItem()
    // {
    //     ScoreboardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreboardItem>();
    //     item.Initialize(player);
    // }





    // private int score = 0;
    // private int killed = 0;
    // // private string notification;

    // public void IncreaseKillCount() {
    //     killed++;
    //     switch (killed) {
    //     case 1:
    //         score += 10;
    //         // notification = null;
    //         break;
    //     case 2:
    //         score += 15;
    //         // notification = "Double Kill";
    //         break;
    //     case 3:
    //         score += 25;
    //         // notification = "Triple Kill";
    //         break;
    //     case 4:
    //         score += 40;
    //         // notification = "Killing Spring";
    //         break;
    //     default:
    //         score += 60;
    //         // notification = "God Like";
    //         break;
    //     }
    // }

    // public void AddScore(int newScore) {
    //     score += newScore;
    // }

}
