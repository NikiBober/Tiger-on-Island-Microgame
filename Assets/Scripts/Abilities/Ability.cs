using System.Collections;
using UnityEngine;

/// <summary>
/// Parent class for all abilities
/// </summary>

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected int _id;
    [SerializeField] protected float _ratio;
    [SerializeField] protected float _cooldown;
    [SerializeField] protected GameObject _readyImage;

    protected bool _isReady;

    protected virtual void Start()
    {
        StartCoroutine(CooldownRoutine());
    }

    public void Activate()
    {
        if (_isReady)
        {
            SaveData.ChangeAbilityCount(_id, -1);
            UIManager.Instance.UpdateAbilityCount(_id);
            ActivateMechanics();
            StartCoroutine(CooldownRoutine());
        }
    }

    // block using during cooldown and hide ready image
    protected IEnumerator CooldownRoutine()
    {
        _isReady = false;
        _readyImage.SetActive(false);
        yield return new WaitForSeconds(_cooldown);
        if (SaveData.GetAbilityCount(_id) > 0)
        {
            _readyImage.SetActive(true);
            _isReady = true;
        }
    }

    // for concrete realisation in ability script
    protected abstract void ActivateMechanics();

}
