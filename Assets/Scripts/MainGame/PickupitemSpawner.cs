using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupitemSpawner : MonoBehaviour
{
    //生成するPickupitem
    public GameObject Pickupitem;
    //生成する個数
    public int SpawnCount = 8;
    //生成する円の半径
    public float SpawnCircleRadius = 3f;

    //生まれたPickupitemの情報をListとして保持しておく
    public List<Pickupitem> Pickupitems = new List<Pickupitem>();

    // Start is called before the first frame update
    private void Start()
    {
        //円周をSpwanCountで割った角度
        float radian = Mathf.PI * 2 / SpawnCount;
        for( int i = 0; i < SpawnCount; i++)
        {
            GameObject Pick = Instantiate(Pickupitem);
            //新しくVector3を作成し、生成したPickupitemのPositionを代入
            Vector3 pos = Pick.transform. position;
            //Posのzの値に円周のyの値をSpawnCircleRadiusで掛けた値を代入
            pos.z = Mathf.Sin(radian * (i + 1)) * SpawnCircleRadius;
            //Posのzの値に円周のyの値をSpawnCircleRadiusで掛けた値を代入
            pos.x = Mathf.Cos(radian * (i + 1)) * SpawnCircleRadius;
            //求められたVector3を生成されたPickのpositionに代入
            Pick.transform.position = pos;

            //ピックアップ番号を設定する
            Pick.GetComponent<Pickupitem>().SetPickupNumber(i+1);

            Pickupitems.Add(Pick.GetComponent<Pickupitem>());
            
        }
    }
}
