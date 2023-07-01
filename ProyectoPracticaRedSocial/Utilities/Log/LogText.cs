using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticaRedSocial.Utilities.Log
{
    public class LogText: ILog<string>, ILogText
    {
        public string GetLogText()
        {
            string logPath = Directory.GetCurrentDirectory() + @"\log.txt";
            string currentContent = string.Empty;

            // Validamos que el archivo exista y procedemos a leerlo
            if (File.Exists(logPath))
            {
                // Leemos el archivo
                var streamReader = new StreamReader(logPath);

                // Leemos todo el archivo y lo guardamos el contenido actual del archivo
                currentContent = streamReader.ReadToEnd();

                streamReader.Close();
            }

            return currentContent;
        }

        public void SaveLog(string action)
        {
            string logPath = Directory.GetCurrentDirectory() + @"\log.txt";
            string currentContent = string.Empty;

            // Validamos que el archivo exista y procedemos a leerlo
            if(File.Exists(logPath))
            {
                // Leemos el archivo
                var streamReader = new StreamReader(logPath);

                // Leemos todo el archivo y lo guardamos el contenido actual del archivo
                currentContent = streamReader.ReadToEnd();

                streamReader.Close();
            }

            // Sirve para crear el archivo y escribir sobre él, recibe la colección de datos binarios que se va a guardar o la ubicación donde se encuentra el archivo
            StreamWriter streamWriter = new StreamWriter(logPath);

            // Escribe una linea de cualquier tipo que se le pasa por parametro
            streamWriter.WriteLine($"{DateTime.Now} - {action}");

            streamWriter.WriteLine( currentContent );

            // Sirve para cerrar el proceso anterior y no ocurra un error
            streamWriter.Close();

        }
    }
}
