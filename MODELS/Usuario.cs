using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS
{
    public class Usuario
    {
        public Usuario()
        {
            this.URL = "images/usuarios/default.png";
        }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechadeNacimiento { get; set; }
        //public string Password { get; set; }

        private string _Password;

        public string Password
        {
            get => _Password;
            set
            {
                _Password = Encrypt.GetSHA256(value);
            }
        }
        public string Estudios { get; set; }
        public string MateriasAdeudadas { get; set; }
        private string _URL;
        //esta property la voy a usar cuando decida evitar usar la cache desde el cliente
        public string URL
        {
            get => _URL;
            set
            {
                if (_URL == null)
                {
                    //esto se ejecutará solo la primera vez con el constructor
                    _URL = value;
                    return;
                }
                _URL = value;
            }
        }
        //esta property la voy a usar cuando decida evitar usar la cache desde el servidor
        //public string URL
        //{
        //    get => _URL;
        //    set
        //    {
        //        if (_URL == null)
        //        {
        //            //esto se ejecutará solo la primera vez con el constructor
        //            _URL = value;
        //            return;
        //        }
        //        if (_URL != "images/usuarios/default.png")
        //        {
        //            int version = int.Parse(_URL.Substring(_URL.IndexOf("=") + 1, 1)) + 1;
        //            _URL = $"images/usuarios/{this.ID}_V={version}";
        //            return;
        //        }
        //        _URL = $"images/usuarios/{this.ID}_V=1";
        //    }
        //}
        public List<Rol> Roles { get; set; }
        //Usuario roles va a recibir un conjunto de roles. Luego haremos un array a través de un split. Y con un foreach daremos de alta los roles para el usuario...
        public string UsuarioRoles { get; set; }


    }

}
