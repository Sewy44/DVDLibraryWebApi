using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibraryWebApi.Data.Repositories;
using DvdLibraryWebApi.Models.Tables;
using NUnit.Framework;

namespace DvdLibraryWebApi.Tests
{
    [TestFixture]
    public class DvdRepositoryADOTests
    {
        [SetUp]
        public void Init()
        {
            using(var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanGetDvdById()
        {
            var repo = new DvdRepositoryADO();
            var dvd = repo.GetById(1);

            Assert.IsNotNull(dvd);

            Assert.AreEqual(1, dvd.DvdId);
            Assert.AreEqual("Avatar", dvd.Title);
            Assert.AreEqual("James Cameron", dvd.Director);
            Assert.AreEqual("PG-13", dvd.Rating);
            Assert.AreEqual("2019", dvd.ReleaseYear);
        }

        [Test]
        public void CanGetAllDvds()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetAll();

            Assert.AreEqual(9, dvds.Count());
            Assert.AreEqual("Avatar", dvds[0].Title);
            Assert.AreEqual("James Cameron", dvds[0].Director);
            Assert.AreEqual("R", dvds[7].Rating);
        }

        [Test]
        public void CanInsertDvd()
        {
            Dvd dvdToAdd = new Dvd();
            var repo = new DvdRepositoryADO();

            dvdToAdd.Title = "Ghostbusters";
            dvdToAdd.Director = "Ivan Reitman";
            dvdToAdd.Rating = "PG";
            dvdToAdd.ReleaseYear = "1988";
            dvdToAdd.Notes = "Who ya gonna call?";

            repo.DvdInsert(dvdToAdd);

            var expected = repo.GetAll();

            Assert.AreEqual(expected.Last().DvdId, dvdToAdd.DvdId);

            var loaded = repo.GetById(dvdToAdd.DvdId);

            Assert.IsNotNull(loaded);

            repo.DvdDelete(loaded.DvdId);
        }

        [Test]
        public void CanDeleteDvd()
        {
            Dvd dvdToAdd = new Dvd();
            var repo = new DvdRepositoryADO();

            dvdToAdd.Title = "Ghostbusters";
            dvdToAdd.Director = "Ivan Reitman";
            dvdToAdd.Rating = "PG";
            dvdToAdd.ReleaseYear = "1988";
            dvdToAdd.Notes = "Who ya gonna call?";

            repo.DvdInsert(dvdToAdd);

            var loaded = repo.GetById(dvdToAdd.DvdId);

            Assert.IsNotNull(loaded);

            repo.DvdDelete(dvdToAdd.DvdId);
            loaded = repo.GetById(dvdToAdd.DvdId);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanUpdateDvd()
        {
            Dvd dvdToUpdate = new Dvd();
            var repo = new DvdRepositoryADO();

            dvdToUpdate.Title = "Gattaca";
            dvdToUpdate.Director = "Andrew Niccol";
            dvdToUpdate.Rating = "PG-13";
            dvdToUpdate.ReleaseYear = "1997";
            dvdToUpdate.Notes = "I barely remember this one.";
            
            repo.DvdInsert(dvdToUpdate);

            dvdToUpdate.Title = "RattattaGattaca";
            dvdToUpdate.Director = "Andrew Niccol";
            dvdToUpdate.Rating = "PG-13";
            dvdToUpdate.ReleaseYear = "1997";
            dvdToUpdate.Notes = "I sorta remember this one.";

            repo.DvdUpdate(dvdToUpdate);

            var updatedDvd = repo.GetById(dvdToUpdate.DvdId);

            Assert.AreEqual("RattattaGattaca", updatedDvd.Title);
            Assert.AreEqual("I sorta remember this one.", updatedDvd.Notes);
        }

        [Test]
        public void CanGetByDirectorName()
        {
            string directorToSearch = "Cam";
            var repo = new DvdRepositoryADO();
            var found = repo.GetByDirectorName(directorToSearch);

            Assert.AreEqual(2, found.Count());

        }

        [Test]
        public void CanGetByRating()
        {
            string ratingToSearch = "PG";
            var repo = new DvdRepositoryADO();
            var found = repo.GetByRating(ratingToSearch);

            Assert.AreEqual(7, found.Count());

        }

        [Test]
        public void CanGetByReleaseYear()
        {
            string releaseYearToSearch = "19";
            var repo = new DvdRepositoryADO();
            var found = repo.GetByReleaseYear(releaseYearToSearch);

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanGetByTitle()
        {
            string titleToSearch = "The";
            var repo = new DvdRepositoryADO();
            var found = repo.GetByTitle(titleToSearch);

            Assert.AreEqual(3, found.Count());
        }
    }
}
