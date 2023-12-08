using UnityEngine;

public class IsSkinOwned : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private GameObject _ownedImage;

    private void OnEnable()
    {
        if (SaveData.IsSkinOwned(_id))
        {
            _ownedImage.SetActive(true);
        }
    }
}
