using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy.DataTypes
{
    public struct FactoryCheckItem
    {
        public string Name { get; }
        public Guid ID { get; }
        public string Description { get; }
        public Image? Image { get; }

        public FactoryCheckItem(string name, Guid id, string description, Image? image)
        {
            Name = name;
            ID = id;
            Description = description;
            Image = image;
        }

        public override string ToString() => $"{Name} ({ID})";
    }
}
