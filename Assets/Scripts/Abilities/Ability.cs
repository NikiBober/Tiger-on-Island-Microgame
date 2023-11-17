using System.Collections;
using UnityEngine;

/// <summary>
/// Parent class for all abilities
/// </summary>

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected float _ratio = 2.0f;
    [SerializeField] protected float _cooldown = 1.0f;
    [SerializeField] protected GameObject _readyImage;

    protected bool _isReady = true;

    public void Activate()
    {
        if (_isReady)
        {
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
        _readyImage.SetActive(true);
        _isReady = true;
    }

    // for concrete realisation in ability script
    protected abstract void ActivateMechanics();

}
