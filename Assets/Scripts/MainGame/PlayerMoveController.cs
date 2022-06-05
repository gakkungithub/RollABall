using System.Collections;
using System.Collections.Generic;
using UnityEngine; //cでいうinclude、javaでいうimportにあたる

public class PlayerMoveController : MonoBehaviour //このclassが集結してc#が出来上がる :MonobehaviourはMonobehaviorを継承させること(後に習う) この継承は違うものしか再度できない
{
    //プレイヤーのRigidbody
    private Rigidbody playerRigidbody; //変数は基本最初に宣言する 名前は分かりやすく publicとprivateはcやjavaでいう変数、定数(const)にあたる

    public float Speed = 2f;

    // Start is called before the first frame update
    void Start() //updateの前に最初に1回呼ばれる処理
    {
        //プレイヤーのRigidBodyをアタッチしたGameObjectから取得します
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() //今回は、毎フレームごとにキーの入力の値が足されるようになる
    {
        //vector3型の変数moveに(左右キー,0,上下キー)の値を代入します
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //playerRigidbodyにmove向きの力を加えます
        playerRigidbody.AddForce(move*Speed);

        if(Input.GetKeyDown(KeyCode.Space)){
            playerRigidbody.AddForce(new Vector3(0, 300, 0)); //newを使うことで、未定義の変数も使えるようになる
        }

    }
}
