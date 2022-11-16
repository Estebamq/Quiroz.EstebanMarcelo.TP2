using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivosArchivoAyuda<T> where T : class
    {
        
        T Leer(string path);
        void Escribir(T dato, string path);
        

    }
}
