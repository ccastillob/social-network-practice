using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticaRedSocial.Utilities.Log
{
    // Le añadimos un generic para que el tipo de dato que se le pase a la interface sea el mismo que el metodo SaveLog
    public interface ILog<T>
    {
        void SaveLog(T action);

    }
}
