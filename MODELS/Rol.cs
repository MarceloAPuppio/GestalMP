using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace MODELS
{
    public class Rol
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(20,ErrorMessage = "Max 20 caracteres")]
        public string Nombre { get; set; }
    }

}
