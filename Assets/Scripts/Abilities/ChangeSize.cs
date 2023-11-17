/// <summary>
/// Change scale of game object
/// </summary>

public class ChangeSize : Ability
{
    protected override void ActivateMechanics()
    {
        transform.localScale *= _ratio;
    }
}
