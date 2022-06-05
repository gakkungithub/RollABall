using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupitem : MonoBehaviour
{
    //破壊可能か
    private bool isDestructible = false;

    //ピックアップ番号
    private int pickupNumber = 0;

    public void SetPickupNumber(int pickupNumber)
    {
        this.pickupNumber = pickupNumber;
    }

    public int GetPickupNumber()
    {
        return pickupNumber;
    }

    public void SetIsDestructible(bool isDestructible)
    {
        this.isDestructible = isDestructible;
    }

    // 衝突判定を取得します
    private void OnCollisionEnter(Collision collision) //このCollision collisionは引数(cでいうintと同じ)　引数名は必ず小initialにする
    {
        //破壊可能じゃなかったら返る
        if(!isDestructible)
        {
            return;
        }
        
        // もし衝突してきたのがPlayerだったら
        if (collision.gameObject.tag.Equals("Player")) //cと同じ! オブジェクトが衝突してくる→tag確認、もしPlayerなら消える
        {
            // 自分を消します
            // Destroy(this.gameObject); //これは参照先自体を消してしまう
            this.gameObject.SetActive(false); //しかし、これはアクティブを消すだけなので、参照先は存在し続け、アクセスできる。
        }
    }

    private void Update()
    {
        transform.Rotate(1.0f, 1.0f, 0);
        //sinは-1～1の値を入力(x)によって返してくれるので反復をするのに便利
        float sin = Mathf.Sin(Time.time);
        transform.localPosition += new Vector3(sin / 100, 0, 0);
    }
}
