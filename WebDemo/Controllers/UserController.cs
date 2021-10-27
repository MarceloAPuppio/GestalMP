using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using MODELS;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebDemo.Herramientas;
using static BLL.ServerFileManager;
using static WebDemo.Herramientas.StringTools;

namespace WebDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string ServerPath;
        public UserController(IWebHostEnvironment hostEnvironment)
        {
            
            this._webHostEnvironment = hostEnvironment;
            this.ServerPath = this._webHostEnvironment.WebRootPath;

        }

        // GET: User
        [HttpGet]
        public JsonResult Get()
        {

            var BLLU = new BLLUsuarios();
            try
            {
                var Data = BLLU.Read();
                return Json(new { data = Data});

            }
            catch (Exception e)
            {

                return Json(new { error = e.Message});

            }
        }

        // GET: User/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            var BLLU = new BLLUsuarios();
            try
            {
                var Data = BLLU.ReadOne(id);
                return Json(new { data = Data });

            }
            catch (Exception e)
            {

                return Json(new { error = e.Message });

            }
        }

        // POST: User
        [HttpPost]
        public JsonResult Post([FromForm] Usuario usuario)

        {
            var BLLU = new BLLUsuarios();
            try
            {
                BLLU.Create(usuario);
                if (Request.Form.Files.Count > 0) /*Si hay archivos entra en el if*/
                {
                    IFormFile file = ObtenerPrimerArchivo(Request.Form.Files);
                    usuario.URL = URLGenerator("usuarios", usuario.ID, file);
                    var oPath = Path.Combine(this.ServerPath, usuario.URL);
                    Guardar(oPath, file);
                    BLLU.Update(usuario.ID, usuario);
                }
                //Hacemos un split de lo que recuperamos 
                List<string> Roles = SplitString(usuario.UsuarioRoles, ",");
                if (Roles.Count > 0)
                {
                    var BLLUR = new BLLUsuariosRoles();
                    Roles.ForEach(rol =>BLLUR.Create(new UsuarioRol() { IDUsuario = usuario.ID, Rol = rol }));
      
                }
                return Json(new { data = "Usuario Cargado con éxito" });
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });

            }

        }

        // PUT: api/HOme/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromForm] Usuario usuario)
        {
            var BLLU = new BLLUsuarios();
            try
            {
                
                if (Request.Form.Files.Count > 0) /*Si hay archivos entra en el if*/
                {
                    IFormFile file = ObtenerPrimerArchivo(Request.Form.Files);
                    usuario.URL = URLGenerator("usuarios", id, file);
                    var oPath = Path.Combine(this.ServerPath, usuario.URL);
                    Guardar(oPath, file);
                }
                BLLU.Update(id, usuario);
                //TODO Para hacer udpate de roles, debe hacerse desde perfil administrador, alguna seccion de roles... 
               //no le podemos dar al cliente esa responsabilidad
                return Json(new { data = "Usuario Modificado con éxito" });
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });

            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            BLLUsuarios BLLU = new BLLUsuarios();
            try
            {
                BLLU.Delete(id);
                return Json(new { message = "usuario eliminado con éxito" });

            }
            catch (Exception e )
            {

                return Json(new { error = "No se pudo eliminar usuario", description=e.Message });

            }

        }
    }
}
