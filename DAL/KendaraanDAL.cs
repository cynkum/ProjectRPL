using System.Collections.Generic;
using ASPChangTravel.Models;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace ASPChangTravel.DAL{
    public class KendaraanDAL : IKendaraan
    {
        private IConfiguration _config;

        public KendaraanDAL(IConfiguration config)
        {
            _config = config;
        }
        private string GetConnStr(){
            return _config.GetConnectionString("DefaultConnection");
        }
        public void Delete(string no_plat)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"delete from Kendaraan where no_plat=@no_plat";
                try{
                    var param = new {no_plat=no_plat};
                    conn.Execute(strSql,param);
                }catch(SqlException sqlEx){
                    throw new Exception($"Error: {sqlEx.Message}");
                }               
            }
        }

        public IEnumerable<Kendaraan> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"select * from Kendaraan order by merk";
                return conn.Query<Kendaraan>(strSql);
            }
        }

        public Kendaraan GetByno_plat(string no_plat)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"select * from Kendaraan where no_plat=@no_plat";
                var param = new {no_plat=no_plat};
                var result = conn.QuerySingleOrDefault<Kendaraan>(strSql,param);
                if(result==null)
                    throw new Exception("Error: data tidak ditemukan !");
                
                return result;
            }
        }

        public void Insert(Kendaraan ken)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"insert into Kendaraan(no_plat,merk,tahun,jenis_kendaraan,jml_muatan,harga)
                values(@no_plat,@merk,@tahun,@jenis_kendaraan,@jml_muatan,@harga)";

                try{
                    var param = new{no_plat=ken.no_plat,merk=ken.merk,tahun=ken.tahun,jenis_kendaraan=ken.jenis_kendaraan,jml_muatan=ken.jml_muatan,harga=ken.harga };
                    conn.Execute(strSql);

                }
                catch(SqlException sqlEx){
                    throw new Exception($"Error : {sqlEx.Message}");
                }
            }
        }

        public void Update(Kendaraan ken)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"update Kendaraan set merk=@merk, tahun=@tahun, jenis_kendaraan=@jenis_kendaraan,
                    jml_muatan=@jml_muatan,harga=@harga where no_plat=@no_plat";
                try{
                    var param = new {merk=ken.merk,tahun=ken.tahun,
                    jenis_kendaraan=ken.jenis_kendaraan,jml_muatan=ken.jml_muatan, harga=ken.harga,no_plat=ken.no_plat};
                    conn.Execute(strSql,param);
                }catch(SqlException sqlEx){
                    throw new Exception(sqlEx.Message);
                }
            }
         }
         public IEnumerable<Kendaraan> GetAllByMerk(string merk){
            using(SqlConnection conn=new SqlConnection(GetConnStr())){
                var strSql = @"select * from Kendaraan where merk LIKE @merk order by merk";
                var param = new {merk="%"+merk+"%"};
                return conn.Query<Kendaraan>(strSql,param);
            }
        }
    }
}