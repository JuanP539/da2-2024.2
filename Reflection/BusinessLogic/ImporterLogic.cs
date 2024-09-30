using IBusinessLogic;
using IImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ImporterLogic : IImporterLogic
    {
        public List<ImporterInterface> GetAllImporters()
        {
            var importersPath = "./Importers"; // Se puede usar appsettings.json
            string[] filePaths = Directory.GetFiles(importersPath);
            // ej: filePaths = ["./Importers/JsonImporter.dll", "./Importers/CSVImporter.dll"]
            List<ImporterInterface> availableImporters = new List<ImporterInterface>();

            foreach (string file in filePaths)
            {
                if (FileIsDll(file))
                {
                    // Proporciona métodos y propiedades para trabajar con archivos
                    FileInfo dllFile = new FileInfo(file);
                    // Proporciona información sobre los assemblies y permite cargar ensamblados en tiempo de ejecución
                    Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);

                    // ej de GetTypes -> [JSONImporter, CSVImporter]
                    foreach (Type type in myAssembly.GetTypes())
                    {
                        if (ImplementsRequiredInterface(type))
                        {
                            ImporterInterface instance = (ImporterInterface)Activator.CreateInstance(type);
                            availableImporters.Add(instance);
                        }
                    }
                }
            }
            return availableImporters;
        }
        private bool FileIsDll(string file)
        {
            return file.EndsWith("dll");
        }
        public bool ImplementsRequiredInterface(Type type)
        {
            return typeof(ImporterInterface).IsAssignableFrom(type) && !type.IsInterface;
        }

    }
}
