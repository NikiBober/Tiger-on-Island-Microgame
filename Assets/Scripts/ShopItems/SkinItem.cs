public class SkinItem : Item
{
    protected override void Unlock()
    {
        SaveData.UnlockSkin(_id);
    }
}