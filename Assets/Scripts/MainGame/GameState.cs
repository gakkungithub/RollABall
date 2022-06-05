using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //ゲームの進行度
    public enum GameProgressStates
    {
        GameStart = 0,
        GameMain, 
        GameResult
    }
    
    //GameProgressStatesの変数
    private GameProgressStates gameProgressStates = GameProgressStates.GameStart;

    //Gameの進行度を変更するメソッド
    public void SetGameProgressState(GameProgressStates gameProgressState)
    {
        gameProgressStates = gameProgressState;
    }

    //外部からGameProgressStatesを取得するメソッド
    public GameProgressStates GetGameProgressState()
    {
        return gameProgressStates;
    }
}
