public class BuffItem : UseItem
{
    public Define.BuffType buffType;
    public float duration;
    public int value;

    public BuffItem(ItemSO itemSO) : base(itemSO)
    {
        if (itemSO is BuffItemSO)
        {
            BuffItemSO buffItemSO = (BuffItemSO)itemSO;

            buffType = buffItemSO.buffType;
            duration = buffItemSO.duration;
            value = buffItemSO.value;
        }
    }

    public override void Use()
    {
        GameManager.Instance.condition.Buff(buffType, duration, value);

        base.Use();
    }
}