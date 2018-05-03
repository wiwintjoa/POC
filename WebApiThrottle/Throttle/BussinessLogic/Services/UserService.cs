using BussinessLogic.Interfaces;
using Dapper;
using DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BussinessLogic.Services
{
    public class UserService : IUserService
    {
        public void Add(UserModel User)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    var param = new DynamicParameters();

                    param.Add("@pFirstName", User.FirstName);
                    param.Add("@pLastName", User.LastName);
                    param.Add("@pUserName", User.UserName);
                    param.Add("@pPassword", User.Password);
                    param.Add("@pEmail", User.Email);                  
                    var result = con.Execute("uspSignUp",
                          param,
                          sqltans,
                          0,
                          commandType: CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        sqltans.Commit();
                    }
                    else
                    {
                        sqltans.Rollback();
                    }

                }
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public void Update(UserModel User)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    var param = new DynamicParameters();
                    param.Add("@pFirstName", User.FirstName);
                    param.Add("@pLastName", User.LastName);
                    param.Add("@pUserName", User.UserName);
                    param.Add("@pPassword", User.Password);
                    param.Add("@pEmail", User.Email);
                    var result = con.Execute("sprocUserTBInsertUpdateSingleItem",
                        param,
                        sqltans,
                        0,
                        commandType: CommandType.StoredProcedure);


                    if (result > 0)
                    {
                        sqltans.Commit();
                    }
                    else
                    {
                        sqltans.Rollback();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        //public void Delete(UserModel User)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //        {
        //            con.Open();
        //            SqlTransaction sqltans = con.BeginTransaction();
        //            var param = new DynamicParameters();
        //            param.Add("@UserID", User.UserID);
        //            var result = con.Execute("sprocUserTBDeleteSingleItem",
        //                param,
        //                sqltans,
        //                0,
        //                commandType: CommandType.StoredProcedure);

        //            if (result > 0)
        //            {
        //                sqltans.Commit();
        //            }
        //            else
        //            {
        //                sqltans.Rollback();
        //            }
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        throw;
        //    }
        //}

        public UserModel LoginUser(string id, string password)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];

            if (string.IsNullOrEmpty(connectionString.ConnectionString))
            {
                throw new System.Exception();
            }

            try
            {               
                using (SqlConnection con = new SqlConnection(connectionString.ConnectionString))
                {
                    con.Open();
                    var param = new DynamicParameters();
                    param.Add("@pId", id);
                    param.Add("@pPassword", password);                   
                    return con.Query<UserModel>("uspSignIn",
                        param,
                        null,
                        true,
                        0,
                        commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    var param = new DynamicParameters();
                    return con.Query<UserModel>("uspGetUsers",
                        null,
                        null,
                        true,
                        0,
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
