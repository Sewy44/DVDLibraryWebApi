using DvdLibraryWebApi.Data.Interface;
using DvdLibraryWebApi.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Data.Repositories
{
    public class DVDRepositoryImplementationADO : DVDRepository
    {
        public void DeleteDVD(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertDVD(Dvd dvd)
        {
            using(var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)param.Value;
            }
        }

        public void UpdateDVD(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<Dvd> GetAllDVDs()
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();
                        row.ReleaseYear = dr["ReleaseYear"].ToString();
                        row.Notes = dr["Notes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetDVDByDirectorName(string directorName)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByDirectorName", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", directorName);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();
                        row.ReleaseYear = dr["ReleaseYear"].ToString();
                        row.Notes = dr["Notes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public Dvd GetDVDById(int dvdId)
        {
            Dvd dvd = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.Director = dr["Director"].ToString();
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.ReleaseYear = dr["ReleaseYear"].ToString();
                        dvd.Notes = dr["Notes"].ToString();
                    }
                }
            }
            return dvd;
        }

        public List<Dvd> GetDVDByRating(string ratingName)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rating", ratingName);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();
                        row.ReleaseYear = dr["ReleaseYear"].ToString();
                        row.Notes = dr["Notes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetDVDByReleaseYear(string releaseYear)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByReleaseYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();
                        row.ReleaseYear = dr["ReleaseYear"].ToString();
                        row.Notes = dr["Notes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetDVDByTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", title);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();
                        row.ReleaseYear = dr["ReleaseYear"].ToString();
                        row.Notes = dr["Notes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }
    }
}
