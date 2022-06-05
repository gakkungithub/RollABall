using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultParam
{
    //勝利したかのフラグ
    private static bool isWin;

    public static void Init()
    {
        isWin = false;
    }

    public static bool GetResultIsWin()
    {
        return isWin;
    }

    public static void IsWinResult()
    {
        isWin = true;
    }

    public static void IsLoseResult()
    {
        isWin = false;
    }
}
