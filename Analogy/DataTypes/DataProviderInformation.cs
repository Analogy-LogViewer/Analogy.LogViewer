﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.DataTypes
{
    public class DataProviderInformation
    {
        public Guid FactoryId { get; set; }
        public string Name { get; set; }
        public string AssemblyFileName { get; set; }
        public string RepositoryURL { get; set; }

        public Image Image { get; set; }
        public DataProviderInformation(string name, string assemblyFileName, string repositoryUrl,Image image)
        {
            FactoryId=Guid.Empty;
            Name = name;
            AssemblyFileName = assemblyFileName;
            RepositoryURL = repositoryUrl;
            Image = image;
        }

        public override string ToString() => $"{nameof(Name)}: {Name}, {nameof(AssemblyFileName)}: {AssemblyFileName}, {nameof(FactoryId)}: {FactoryId}, {nameof(RepositoryURL)}: {RepositoryURL}";
    }
}
