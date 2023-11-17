using System.Collections;
using UnityEngine;

/// <summary>
/// Parent class for abilities with temporary effect
/// </summary>

public abstract class TimedAbility : Ability
{
    [SerializeField] protected float _duration = 1.0f;

    protected override void ActivateMechanics()
    {
        StartCoroutine(DurationRoutine());
    }

    // for deactivate effect after duration complete
    protected IEnumerator DurationRoutine()
    {
        yield return new WaitForSeconds(_duration);
        DeactivateMechanics();
    }

    protected abstract void DeactivateMechanics();

}
