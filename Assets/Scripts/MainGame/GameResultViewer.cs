using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameResultViewer : MonoBehaviour
{
    //PlayerPickupitemManagerからフラグを受け取るためにPlayerPickupitemManagerを参照する
    public PlayerPickupitemManager PlayerPickupitemManager;

    //結果を表示するTextMeshProを参照する
    public TextMeshProUGUI ResultText;

    private void Start()
    {
        //結果を表示するTextMeshProの文字を空にする
        ResultText.text = string.Empty;
    }

    void Update()
    {
        //PlayerPickupitemManagerのフラグが立てばGame Clearを表示する
        if(PlayerPickupitemManager.GetAllPickupitems){
            ResultText.text = "Game Clear";
        }
    }
}
