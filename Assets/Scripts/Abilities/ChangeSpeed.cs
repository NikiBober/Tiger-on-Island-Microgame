/// <summary>
/// Change speed in IslandController
/// </summary>

public class ChangeSpeed : TimedAbility
{
    private IslandController _islandController;

    protected override void Start()
    {
        base.Start();
        _islandController = GetComponent<IslandController>();
    }

    protected override void ActivateMechanics()
    {
        base.ActivateMechanics();
        _islandController.Speed *= _ratio;
    }

    protected override void DeactivateMechanics()
    {
        _islandController.Speed /= _ratio;
    }
}
