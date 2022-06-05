using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public enum StageTypes
    {
        NormalType,
        IceType
    }

    public StageTypes StageType = StageTypes.NormalType;

    private void OnCollisionEnter(Collision collision)
    {
        //当たった相手がPlayerだったら
        if(collision.gameObject.tag.Equals("Player"))
        {
            switch(StageType)
            {
                case StageTypes.NormalType:
                    collision.gameObject.GetComponent<Rigidbody>().angularDrag = 1f;
                    break;
                case StageTypes.IceType:
                    collision.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;
                    break;
            }
        }
    }
}
