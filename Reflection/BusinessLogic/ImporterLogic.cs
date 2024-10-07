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
            string[] filePaths = Directory.GetFiles(importersPath); // Obtiene los archivos en la ruta especificada. En este caso, las DLL de los importadores.
            // ej: filePaths = ["./Importers/JsonImporter.dll", "./Importers/CSVImporter.dll"]
            List<ImporterInterface> availableImporters = new List<ImporterInterface>();// Lista que almacenará las instancias de los importadores disponibles.

            foreach (string file in filePaths) // Itera sobre todos los archivos encontrados en la ruta de importadores.
            {
                if (FileIsDll(file))
                {
                    // Proporciona métodos y propiedades para trabajar con archivos
                    FileInfo dllFile = new FileInfo(file);
                    // Proporciona información sobre los assemblies y permite cargar ensamblados en tiempo de ejecución
                    Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);

                    // ej de GetTypes -> [JSONImporter, CSVImporter]
                    foreach (Type type in myAssembly.GetTypes()) // Obtiene todos los tipos (clases) definidos en el ensamblado.
                    {
                        if (ImplementsRequiredInterface(type)) // Verifica si el tipo implementa la interfaz requerida (ImporterInterface).
                        {
                            // Crea una instancia del tipo que implementa la interfaz ImporterInterface.
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
