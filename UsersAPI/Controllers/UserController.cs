using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using UsersAPI.Models;

namespace UsersAPI.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage Get()
        {
           

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersApiDB"].ConnectionString))
            using (var comand = new SqlCommand("[dbo].[SP_User_View2]", con))
            using (var data = new SqlDataAdapter(comand))
            {
                comand.CommandType = CommandType.StoredProcedure;
                data.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(User user)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersApiDB"].ConnectionString))
                using (var comand = new SqlCommand("[dbo].[SP_User_Insert]", con))
                using (var data = new SqlDataAdapter(comand))
                {
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.Add(new SqlParameter("@Nome", user.Nome));
                    comand.Parameters.Add(new SqlParameter("@DataNascimento", user.DataNascimento));
                    comand.Parameters.Add(new SqlParameter("@Email", user.Email));
                    comand.Parameters.Add(new SqlParameter("@Senha", user.Senha));
                    comand.Parameters.Add(new SqlParameter("@Ativo", 1));
                    comand.Parameters.Add(new SqlParameter("@SexoID", user.SexoId));
                    data.Fill(table);
                }

                return "Adicionado com Sucesso";
            }
            catch (Exception)
            {
                return "Erro ao Adicionar";
            }
        }

        public string Put(User user)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersApiDB"].ConnectionString))
                using (var comand = new SqlCommand("[dbo].[SP_User_Update]", con))
                using (var data = new SqlDataAdapter(comand))
                {
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.Add(new SqlParameter("@UsuarioId", user.UsuarioId));
                    comand.Parameters.Add(new SqlParameter("@Nome", user.Nome));
                    comand.Parameters.Add(new SqlParameter("@DataNascimento", user.DataNascimento));
                    comand.Parameters.Add(new SqlParameter("@Email", user.Email));
                    comand.Parameters.Add(new SqlParameter("@Senha", user.Senha));
                    comand.Parameters.Add(new SqlParameter("@Ativo", user.Ativo));
                    comand.Parameters.Add(new SqlParameter("@SexoID", user.SexoId));
                    data.Fill(table);
                }

                return "Atualizado com Sucesso";
            }
            catch (Exception)
            {
                return "Erro ao Atualizar";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersApiDB"].ConnectionString))
                using (var comand = new SqlCommand("[dbo].[SP_User_Delete]", con))
                using (var data = new SqlDataAdapter(comand))
                {
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.Add(new SqlParameter("@UsuarioId", id));
                    data.Fill(table);
                }

                return "Deletado com Sucesso";
            }
            catch (Exception)
            {
                return "Erro ao Deletar";
            }
        }
    }
}
