using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LaSalleWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace LaSalleWeb
{
    /// <summary>
    /// Summary description for LaSalleWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LaSalleWS : System.Web.Services.WebService
    {

        //Modelo de seguridad
        ApplicationDbContext context = new ApplicationDbContext();
        //Modelo de datos
        LaSalleModelContainer db = new LaSalleModelContainer();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }



        //WebMethod de logeo
        [WebMethod]
        public string Logueo(string UserName, string password)
        {
            return Validar(UserName, password);
        }

        //Este metodo es privado

        string Validar(string UserName, string password)
        {
            var result = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>().PasswordSignIn(UserName, password, false, false);

            //Verificamos si fue exitoso
            if (result == SignInStatus.Success)
            {
                //Obtener el rol del usuario
                var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                return ManejadorUsuario.GetRoles(ManejadorUsuario.FindByEmail(UserName).Id.ToString()).First();
            }
            else
            {
                return "false";
            }
        }

        //GetAlumnosByTutor

        [WebMethod]

        public List<AlumnoSW> GetAlumnosByTutor(string UserName, string password)
        {

            if (Validar(UserName, password) == "Tutor")
            {

                return db.Alumnos.Where(x => x.Tutor.Email == UserName).Select(
                    x => new AlumnoSW()
                    {
                        Id = x.Id
                        , Carnet = x.Carnet
                        , Nombre = x.Nombre
                        , Email = x.Email
                        , Celular = x.Celular
                        , FechaNac = x.FechaNac
                    }).ToList();
            }
            else
            {
                return new List<AlumnoSW>();


            }
        }

        //GetNotasByCarnet

        [WebMethod]
        public List<NotaSW> GetNotasByCarnet(string UserName, string password, string carnet)
        {
            if (Validar(UserName, password) == "Tutor")
            {
                return db.Notas.Where(x => x.Alumno.Carnet == carnet).Select(
                    x => new NotaSW() {
                        Id = x.Id
                        , Acumulado = x.Acumulado
                        , Examen = x.Examen
                        , NombreAsignatura = x.Asignatura.Nombre
                    }
                    ).ToList();
            }
            else {
                return new List<NotaSW>();
            }
        }

        //GetAsignaturaByDocente

        [WebMethod]
        public List<AsignaturaSW> GetAsignaturaByDocente(string UserName, string password)
        {
            if (Validar(UserName, password) == "Docente")
            {
                return db.Asignaturas.Where(x => x.Docente.Email == UserName).Select(
                    x=>new AsignaturaSW()
                    {
                        Id=x.Id
                        ,Nombre=x.Nombre
                        ,Creditos=x.Creditos
                        ,Codigo=x.Codigo
                    }
                    ).ToList();
            }
            else
            {
                return new List<AsignaturaSW>();
            }

        }

        //AddDocente

        [WebMethod]
        public bool AddDocente(string Nombre, string email, string pass, string inns, decimal salario)
        {
            Docente doc = new Docente();
            doc.NombreCompleto = Nombre;
            doc.Email = email;
            doc.INSS = inns;
            doc.SalarioBase = salario;

            db.Docentes.Add(doc);

            if (db.SaveChanges() > 0)
            {
                //Si se guardo la informacion del docente
                //Agregamos un usuario para ese docente
                var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser();
                //Asignamos los vslores
                user.UserName = email;
                user.Email = email;
                string pwd = "123456";
                //procedemos a agregar el usuario
                var verificar = ManejadorUsuario.Create(user, pwd);

                //Asignamos el usuario con su respectivo rol

                if (verificar.Succeeded)
                {
                    var result = ManejadorUsuario.AddToRole(user.Id, "Docente");
                    return true;
                }

                return true;
            }
            else
            { return false; }
        }



        //Definicion de clases

        public class AsignaturaSW {

            public int Id { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public short Creditos { get; set; }
          
        }
        public class AlumnoSW
        {
            public int Id { get; set; }
            public string Carnet { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
            public string Celular { get; set; }
            public string FechaNac { get; set; }
        }

        public class NotaSW
        {
            public int Id { get; set; }
            public decimal Acumulado { get; set; }
            public decimal Examen { get; set; }
            public int AlumnoId { get; set; }
            public string NombreAsignatura { get; set; }
        }

    }
}
