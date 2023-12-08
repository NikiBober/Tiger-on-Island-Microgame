public class AbilityItem : Item
{
    protected override void Unlock()
    {
        SaveData.AddAbility(_id);
    }
}
