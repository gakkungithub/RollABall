using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{

    public TextMeshProUGUI TimeText;

    public GameResultViewer GameResultViewer;

    public float TimeLimit = 20f;

    public GameState GameState;

    private void Update()
    {
        if(GameState.GetGameProgressState() == GameState.GameProgressStates.GameResult)
        {
            return;
        }

        //制限時間が0より上で、かつ、まだ全てのPickupitemが取得しきれていなかったら
        if(TimeLimit > 0 && !GameResultViewer.PlayerPickupitemManager.GetAllPickupitems)
        {
            //TimeLimitを毎フレーム、フレームとフレームの差分で引いていく
            TimeLimit -= Time.deltaTime;
            TimeText.text = $"{(int)TimeLimit + 1}";
        }
        //全てのPickupitemが取得しきれたら、カウントをやめる
        else if(GameResultViewer.PlayerPickupitemManager.GetAllPickupitems)
        {
            TimeText.text = $"{(int)TimeLimit+1}";
        }
        //制限時間が0より↓になったらゲームオーバー
        else
        {
            GameState.SetGameProgressState(GameState.GameProgressStates.GameResult);

            //GameResultParamのisWinをfalseにする
            GameResultParam.IsLoseResult();

            SceneManager.LoadScene("Result");

            TimeText.text = $"{0}";
        }
    }
}
