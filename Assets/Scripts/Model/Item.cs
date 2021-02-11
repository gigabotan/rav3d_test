namespace rav3d.Model
{
    
    public enum ItemType
    {
        Cube,
        Circle,
        Prism
    }
    
    [System.Serializable]
    public struct Item
    {
        public ItemType ItemType;
        public int Id;
        public string Name;
        public int Weight;
    }
}