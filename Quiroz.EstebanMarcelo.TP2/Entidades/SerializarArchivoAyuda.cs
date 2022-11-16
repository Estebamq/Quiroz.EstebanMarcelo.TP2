using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SerializarArchivoAyuda : IArchivosArchivoAyuda<string>
    {
        
            /// <summary>
            /// Escribe datos recibiendo el path y el dato a escribir
            /// </summary>
            /// <param name="dato">string</param>
            /// <param name="path">string</param>
            public void Escribir(string dato, string path)
            {
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(path))
                    {
                        streamWriter.WriteLine(dato);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            
            public string Leer(string path)
            {
                string returnAux = string.Empty;
                try
                {
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            returnAux += $"{streamReader.ReadLine()}\n";
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return returnAux;
            }
        

    }
}
