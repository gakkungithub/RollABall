using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameResult : MonoBehaviour
{
    public Button ResultButton;

    //UnityからTextMeshProUGUIを参照できるようにする = TextMeshProUGUI型の変数をpublicで作るようにする
    public TextMeshProUGUI ResultText;

    private void Start()
    {
        //結果によって上述で作ったTextにGameResultParamのisWinを反映させる
        if(GameResultParam.GetResultIsWin())
        {
            ResultText.text = "GameClear";
        }
        else
        {
            ResultText.text = "GameOver";
        }
        ResultButton.onClick.RemoveAllListeners();

        ResultButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Start");
        });
    }
}
