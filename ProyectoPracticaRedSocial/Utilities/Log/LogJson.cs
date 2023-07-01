using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticaRedSocial.Utilities.Log
{
    // Hacemos una implementación multiple de interfaces para que pueda recibir 2 tipos de datos LogObject y string
    public class LogJson : ILog<LogObject>, ILog<string>
    {
        public void SaveLog(LogObject action)
        {
            string logPath = Directory.GetCurrentDirectory() + @"\log.json";
            string currentContent = string.Empty;

            var logObjects = new List<LogObject>();

            // Validamos que el archivo exista y procedemos a leerlo
            if (File.Exists(logPath))
            {
                // Leemos el archivo
                var streamReader = new StreamReader(logPath);

                // Leemos todo el archivo y lo guardamos el contenido actual del archivo
                currentContent = streamReader.ReadToEnd();

                logObjects = JsonConvert.DeserializeObject<List<LogObject>>(currentContent);

                streamReader.Close();
            }

            StreamWriter streamWriter = new StreamWriter(logPath);

            // var logObject = new LogObject() { LogDate = DateTime.Now, Action = action };
            logObjects.Add(action);

            var jsonResult = JsonConvert.SerializeObject(logObjects);

            streamWriter.WriteLine(jsonResult);

            // Sirve para cerrar el proceso anterior y no ocurra un error
            streamWriter.Close();
        }

        public void SaveLog(string action)
        {
            string logPath = Directory.GetCurrentDirectory() + @"\log.json";
            string currentContent = string.Empty;

            var logObjects = new List<LogObject>();

            // Validamos que el archivo exista y procedemos a leerlo
            if (File.Exists(logPath))
            {
                // Leemos el archivo
                var streamReader = new StreamReader(logPath);

                // Leemos todo el archivo y lo guardamos el contenido actual del archivo
                currentContent = streamReader.ReadToEnd();

                logObjects = JsonConvert.DeserializeObject<List<LogObject>>(currentContent);

                streamReader.Close();
            }

            StreamWriter streamWriter = new StreamWriter(logPath);

            var logObject = new LogObject() { LogDate = DateTime.Now, Action = action };
            logObjects.Add(logObject);

            var jsonResult = JsonConvert.SerializeObject(logObjects);

            streamWriter.WriteLine(jsonResult);

            // Sirve para cerrar el proceso anterior y no ocurra un error
            streamWriter.Close();
        }
    }
}
