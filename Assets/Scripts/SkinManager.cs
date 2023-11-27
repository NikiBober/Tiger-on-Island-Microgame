using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _skin;
    [SerializeField] private GameObject _lockedImage;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _purchaseButoon;

    private int _currentSkinIndex = 0;

    private void Start()
    {
        SaveData.UnlockSkin(_currentSkinIndex);
        _currentSkinIndex = SaveData.GetCurrentSkinIndex();
    }

    public void NextSkin()
    {
        _currentSkinIndex = (_currentSkinIndex + 1) % _skin.Length;
        SetSkin(_currentSkinIndex);
    }

    public void PreviousSkin()
    {
        _currentSkinIndex = (_currentSkinIndex - 1 + _skin.Length) % _skin.Length;
        SetSkin(_currentSkinIndex);
    }

    public void SaveSkin()
    {
        SaveData.SaveCurrentSkinIndex(_currentSkinIndex);
    }

    private void SetSkin(int skinIndex)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _skin[skinIndex];
        _lockedImage.SetActive(!SaveData.IsSkinOwned(skinIndex));
        _playButton.SetActive(SaveData.IsSkinOwned(skinIndex));
        _purchaseButoon.SetActive(!SaveData.IsSkinOwned(skinIndex));
    }
}
