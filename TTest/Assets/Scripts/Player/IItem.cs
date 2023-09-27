public interface IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ITEM_TYPE Type { get; set; }
    public int Damage { get; set; }
    public int Health { get; set; }

}