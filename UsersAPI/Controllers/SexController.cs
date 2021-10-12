using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UsersAPI.Controllers
{
    public class SexController : ApiController
    {
        public HttpResponseMessage Get()
        {


            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersApiDB"].ConnectionString))
            using (var comand = new SqlCommand("[dbo].[SP_Sex_View]", con))
            using (var data = new SqlDataAdapter(comand))
            {
                comand.CommandType = CommandType.StoredProcedure;
                data.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersApiDB"].ConnectionString))
                using (var comand = new SqlCommand("[dbo].[SP_Sex_View_Single]", con))
                using (var data = new SqlDataAdapter(comand))
                {
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.Add(new SqlParameter("@SexoId", id));
                    data.Fill(table);
                }

                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }
    }
}
