using UnityEngine;
using TMPro;

public class AbilityCountTextUpdater : MonoBehaviour
{
    [SerializeField] private int _id;
    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        EventManager.OnUpdateAbility += TextUpdateHandler;
    }

    private void OnDisable()
    {
        EventManager.OnUpdateAbility -= TextUpdateHandler;
    }
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        TextUpdateHandler();
    }

    private void TextUpdateHandler()
    {
        _text.text = SaveData.GetAbilityCount(_id).ToString();
    }
}
