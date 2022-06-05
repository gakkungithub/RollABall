using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupitemNumberView : MonoBehaviour
{
    public PickupitemSpawner PickupitemSpawner;

    public TextMeshProUGUI PickupNumberNode;

    //可変するのでListで保持する
    public List<TextMeshProUGUI> PickupNumberNodes = new List<TextMeshProUGUI>();
　　//ここで宣言しているのはListであり、Cでいう要素数を考えない配列である。(ただし、Cと違い、要素を ={1, 4, 5}のように記述はしなくても良い。あくまでも領域を作る作業である。)
    //配列の宣言はCと全く同じ(public int 〇〇[5] = )
    private void Start()
    {
        //Listの中を空にする
        PickupNumberNodes.Clear();

        //Nodeのtextを空にする
        PickupNumberNode.text = string.Empty;

        for(int i = 0; i < PickupitemSpawner.SpawnCount; i++)
        {
            PickupNumberNodes.Add(Instantiate(PickupNumberNode, this.transform)); //ここのAddは、０番地から順に()内の要素を入れることができる。
            PickupNumberNodes[i].text = $"{i + 1}";
        }
    }

    private void LateUpdate()
    {
        for(int i = 0; i < PickupitemSpawner.SpawnCount; i++)
        {
            if(!PickupitemSpawner.Pickupitems[i].gameObject.activeSelf) //ここのactiveSelfは自分が存在していることを示す。
            {
                if(!PickupNumberNodes[i].text.Equals(string.Empty))
                {
                   PickupNumberNodes[i].text = string.Empty;
                }
                //ここの条件に入ったら次のiの値の処理に飛ばす
                continue;
            }
            //カメラから見たPickupitemの位置をPickupNumberNodeの位置に代入する
            PickupNumberNodes[i].rectTransform.position
            = Camera.main.WorldToScreenPoint(PickupitemSpawner.Pickupitems[i].transform.position);
        }
    }

}
