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
            UIManager.Instance.NotEnoughCoins();
        }
    }

    protected abstract void Unlock();
}
