
using Dapper;
using System.Collections.Generic;
using ASPChangTravel.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ASPChangTravel.DAL{
    public class SupirDAL : ISupir
    {
        private IConfiguration _config;
        public SupirDAL(IConfiguration config)
        {
            _config = config; 
        }
        private string GetConnStr(){
            return _config.GetConnectionString("DefaultConnection");
        }
        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Supir> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"select * from Supir order by nama_sup";
                return conn.Query<Supir>(strSql);
            }
        }

        public Supir GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Supir sp)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Supir sp)
        {
            throw new System.NotImplementedException();
        }
    }
}