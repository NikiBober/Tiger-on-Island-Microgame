using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected int _id;
    [SerializeField] protected int _price;

    public void Buy()
    {
        Debug.Log("Click");
        if (SaveData.CoinsScore > _price)
        {
            SaveData.UpdateCoinsScore(-_price);
            UIManager.Instance.UpdateCoinsScoreText();
            Unlock();
        }
        else
        {
            UIManager.Instance.NotEnoughCoins();
        }
    }

    protected abstract void Unlock();
}
