using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //UnityのScene上から参照するボタン
    public Button StartButton;

    private void Start()
    {
        //ボタンをクリックした時の処理を全て消去
        StartButton.onClick.RemoveAllListeners();

        //ボタンをクリックしたときの処理を追加
        StartButton.onClick.AddListener(() => /*矢印は引数の代入を示す。*/
        {
            SceneManager.LoadScene("MainGame");
        });
        //ここの(()=>)はラムダ式、無名関数などと呼ばれる書き方で、イベント型の処理を行うときに使う。
    }
}
