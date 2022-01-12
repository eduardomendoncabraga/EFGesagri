using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EFGesAgro.Repositorios;
using EFGesAgro.Models;

namespace EFGesAgro.Repositorios
{
    public class RepositorioUsuarios
    {

        public static bool AutenticarUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
            try
            {
                using (EFGESAGROEntities db = new EFGESAGROEntities())
                {
                    var QueryAutenticaUsuarios =
                        db.Pessoa.Where(x => x.PesEmail == Login && x.PesUsr == Senha).SingleOrDefault();

                    if (QueryAutenticaUsuarios == null)
                    {

                        return false;

                    }
                    else
                    {

                        RepositorioCookies.RegistraCookieAutenticacao(QueryAutenticaUsuarios.PesCod);

                        return true;
                    }

                }
            }
            catch (Exception) { return false; }
        }
        public static Pessoa RecuperaUsuarioPorID(long CodUsr)
        {
            try
            {
                using (EFGESAGROEntities db = new EFGESAGROEntities())
                {
                    var us = db.Pessoa.Where(p => p.PesCod == CodUsr).SingleOrDefault();

                    //var usuario = db.Usuario.Where(u => u.UsrCod == CodUsr).SingleOrDefault();
                    
                    return us;
                }
                

            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Pessoa VerificaSeOUsuarioEstaLogado()
        {
            var usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            if (usuario == null) 
            {
                return null;
            }
            else
            {
                long CodUsr = Convert.ToInt64(RepositorioCriptografia.Descriptografar("UsrCod"));

                var usuarioRetornado = RecuperaUsuarioPorID(CodUsr);
                return usuarioRetornado;

            }
        }
    }
}