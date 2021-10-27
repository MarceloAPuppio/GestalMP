using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL
{
    public static class ServerFileManager
    {
        public static void Guardar(string path, IFormFile archivo)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                //TODO:analizar la opcion ASyncCopyto ... para eso tengo que hacer el método async, pero sin el await para que no me trabe todo... o no se, para eso tengo que hacer un task
                archivo.CopyTo(fileStream);
            }

        }
        public static IFormFile ObtenerPrimerArchivo(IFormFileCollection obj) => obj[0];

        public static string URLGenerator(string subfolder, int id, IFormFile file) => $"images/{subfolder}/{id}{Path.GetExtension(file.FileName)}";

    }
}
