using Microsoft.Owin;
using Owin;
using LaSalleWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(LaSalleWeb.Startup))]
namespace LaSalleWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRolesConUsuarios();
        }
        //Creamos un metodo para generar los roles y usarios por defecto

        private void CrearRolesConUsuarios()
        {
            //Acceder al modelo de seguridad
            ApplicationDbContext context = new ApplicationDbContext();

            //Manejadores de roles y usuarios
            var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Verificamos la existencia del Rol
            //Es rol Admin

            if(!ManejadorRol.RoleExists("Admin"))
            {
                //creamos el nuevo rol por primera vez
                var rol = new IdentityRole();
                //Establcemos algunos valores
                rol.Name = "Admin";
                ManejadorRol.Create(rol);
                //Asignamos a su primer usuriario

                var user = new ApplicationUser();
                //Asignamos los vslores
                user.UserName = "rsolis@unan.edu.ni";
                user.Email= "rsolis@unan.edu.ni";
                string pwd = "123456";
                //procedemos a agregar el usuario
                var verificar = ManejadorUsuario.Create(user, pwd);

                //Asignamos el usuario con su respectivo rol

            if(verificar.Succeeded)
                {
                    var result = ManejadorUsuario.AddToRole(user.Id, "Admin");
                }

           }

            //Es rol Direccion

            if (!ManejadorRol.RoleExists("Direccion"))
            {
                //creamos el nuevo rol por primera vez
                var rol = new IdentityRole();
                //Establcemos algunos valores
                rol.Name = "Direccion";
                ManejadorRol.Create(rol);
                //Asignamos a su primer usuriario

                var user = new ApplicationUser();
                //Asignamos los vslores
                user.UserName = "Direccion@unan.edu.ni";
                user.Email = "Direccion@unan.edu.ni";
                string pwd = "123456";
                //procedemos a agregar el usuario
                var verificar = ManejadorUsuario.Create(user, pwd);

                //Asignamos el usuario con su respectivo rol

                if (verificar.Succeeded)
                {
                    var result = ManejadorUsuario.AddToRole(user.Id, "Direccion");
                }

            }

            //Es rol Docente

            if (!ManejadorRol.RoleExists("Docente"))
            {
                //creamos el nuevo rol por primera vez
                var rol = new IdentityRole();
                //Establcemos algunos valores
                rol.Name = "Docente";
                ManejadorRol.Create(rol);
                //Asignamos a su primer usuriario

                var user = new ApplicationUser();
                //Asignamos los vslores
                user.UserName = "Docente@unan.edu.ni";
                user.Email = "Docente@unan.edu.ni";
                string pwd = "123456";
                //procedemos a agregar el usuario
                var verificar = ManejadorUsuario.Create(user, pwd);

                //Asignamos el usuario con su respectivo rol

                if (verificar.Succeeded)
                {
                    var result = ManejadorUsuario.AddToRole(user.Id, "Docente");
                }

            }

            //Es rol Tutor

            if (!ManejadorRol.RoleExists("Tutor"))
            {
                //creamos el nuevo rol por primera vez
                var rol = new IdentityRole();
                //Establcemos algunos valores
                rol.Name = "Tutor";
                ManejadorRol.Create(rol);
                //Asignamos a su primer usuriario

                var user = new ApplicationUser();
                //Asignamos los vslores
                user.UserName = "Tutor@unan.edu.ni";
                user.Email = "Tutor@unan.edu.ni";
                string pwd = "123456";
                //procedemos a agregar el usuario
                var verificar = ManejadorUsuario.Create(user, pwd);

                //Asignamos el usuario con su respectivo rol

                if (verificar.Succeeded)
                {
                    var result = ManejadorUsuario.AddToRole(user.Id, "Tutor");
                }

            }

        }
    }
}
