public class AbilityItem : Item
{
    protected override void Unlock()
    {
        SaveData.ChangeAbilityCount(_id, 1);
        EventManager.UpdateAbility();
    }
}
