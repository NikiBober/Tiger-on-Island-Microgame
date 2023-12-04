using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int[] _price;

    [SerializeField] private GameObject _notEnoughCoinsText;
    [SerializeField] private float _popUpDelay = 1.0f;

    public void Buy (int index)
    {

    }

    public void BuySkin (int skinIndex, int priceIndex)
    {
        if (SaveData.CoinsScore > _price[priceIndex])
        {
            SaveData.UnlockSkin(skinIndex);
            SaveData.UpdateCoinsScore(-_price[priceIndex]);
        }
        else
        {
            StartCoroutine(NotEnoughCoinsRoutine());
        }
    }

    private IEnumerator NotEnoughCoinsRoutine()
    {
        _notEnoughCoinsText.SetActive(true);
        yield return new WaitForSeconds(_popUpDelay);
        _notEnoughCoinsText.SetActive(false);
    }
}
