using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPickupitemManager : MonoBehaviour //クラス名は必ずproject欄のC#スクリプトと同じである必要がある。基本同じになるが、たまに名前の変更などで異なってしまうことがあるので要チェックしよう。
{
    //Pickupitemが生まれる数を取得するためにPickupitemSpawnerを参照する
    public PickupitemSpawner PickupitemSpawner;

    //プレイヤーが取得したアイテム数
    public int PickupitemCount = 0;

    //生まれた数
    public int PickupitemSpawnCount = 0; //C#での変数宣言の都合上、ここで初期値０で宣言する必要がある。

    //全て取得できたかのフラグ
    public bool GetAllPickupitems = false; //bool = boolean。booleanはyesかno(true or false)の値をもつ変数である。

    //GameStateを参照する
    public GameState GameState;

    private void Start()
    {
        //PickupitemSpawnCountにPickupitemが生まれる数を代入する
        PickupitemSpawnCount = PickupitemSpawner.SpawnCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(GameState.GetGameProgressState() == GameState.GameProgressStates.GameResult)
        {
            return;
        }

        //当たった相手がPickupitemだったら
        if(collision.gameObject.tag.Equals("Pickupitem")) //後にtag付けする必要あり。
        {
            //PickupitemCountの値を１つ増やす
            PickupitemCount++;

            //一時変数として当たったPickupitemのクラスを取得
            var pickupitem = collision.gameObject.GetComponent<Pickupitem>();
            
            //当たったPickupitemのピックアップ番号が一緒じゃなかったら返る
            if(pickupitem.GetPickupNumber() != PickupitemCount)
            {
                PickupitemCount--;
                return;
            }
            
            //ここに来たということはPickupitemCountとピックアップ番号が一緒
            pickupitem.SetIsDestructible(true);
            
            //生まれた数とPickupitemCountが同値になったらGetAllPickupitemsのフラグを立てる
            if(PickupitemCount == PickupitemSpawnCount)
            {
                GetAllPickupitems = true;
                GameState.SetGameProgressState(GameState.GameProgressStates.GameResult);
           　　 
           　　 //GameResultParamのisWinをtrueにする
                GameResultParam.IsWinResult();
                
                SceneManager.LoadScene("Result"); //staticでなくても関数を読み込める。（データ量が削減できて便利。)
            }
        }
    }

}
