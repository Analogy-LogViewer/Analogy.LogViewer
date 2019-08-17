using Philips.Analogy.Interfaces.Interfaces;
using System;

namespace Analogy.Implementation.Example
{
    public class AnalogyExampleFactory : IAnalogyFactories
    {
        public Guid FactoryID => new Guid("4B1EBC0F-64DD-44A1-BC27-79DBFC6384CC");

        public string Title => "Analogy Examples";

        public IAnalogyDataSourceFactory DataSources { get; } = new AnalogyDataSourceFactory();

        public IAnalogyCustomActionFactory Actions => null;

        public IAnalogyUserControlFactory UserControls => null;
    }
}
