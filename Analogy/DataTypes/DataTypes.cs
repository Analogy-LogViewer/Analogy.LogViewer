
using System.Drawing;

namespace Analogy.DataTypes
{
    public struct FactoryCheckItem
    {
        public string Name { get; }
        public Guid ID { get; }
        public string Description { get; }
        private string Assembly { get; }
        public Image? Image { get; }

        public FactoryCheckItem(string name, Guid id, string description,string assembly, Image? image)
        {
            Name = name;
            ID = id;
            Description = description;
            Assembly = assembly;
            Image = image;
        }

        public override string ToString() => $"{Name} (from {Assembly}. With id: {ID}):";
    }
}