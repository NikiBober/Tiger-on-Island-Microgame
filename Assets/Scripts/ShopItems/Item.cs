using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected int _price;
    [SerializeField] protected int _id;

    public void Buy()
    {
        Debug.Log("Click");
        if (SaveData.CoinsScore > _price)
        {
            Unlock();
        }
        else
        {

        }
    }

    protected abstract void Unlock();
}
