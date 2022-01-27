using DvdLibraryWebApi.Data.Repositories;
using DvdLibraryWebApi.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Tests
{
    [TestFixture]
    public class DvdRepositoryMockTests
    {
        [Test]
        public void CanGetAllDvds()
        {
            var repo = new DvdRepositoryMock();

            var dvds = repo.GetAll();

            Assert.AreEqual(5, dvds.Count());
            Assert.AreEqual(1, dvds[0].DvdId);
            Assert.AreEqual("Star Wars: A New Hope", dvds[0].Title);
            Assert.AreEqual("1977", dvds[0].ReleaseYear);
            Assert.AreEqual("George Lucas", dvds[0].Director);
            Assert.AreEqual("PG", dvds[0].Rating);
        }

        [Test]
        public void CanGetDvdById()
        {
            var repo = new DvdRepositoryMock();
            var dvd = repo.GetById(1);

            Assert.AreEqual("Star Wars: A New Hope", dvd.Title);
            Assert.AreEqual("1977", dvd.ReleaseYear);
            Assert.AreEqual("George Lucas", dvd.Director);
            Assert.AreEqual("PG", dvd.Rating);
        }

        [Test]
        public void CanInsertDvd()
        {
            var repo = new DvdRepositoryMock();
            var dvd = new Dvd { Title = "Avatar", ReleaseYear = "2009", Director = "James Cameron", Rating = "PG-13", Notes = "A VERY overrated movie." };
            repo.DvdInsert(dvd);

            var dvds = repo.GetAll();

            Assert.AreEqual(6, dvds.Count());
            Assert.AreEqual(6, dvds[5].DvdId);
            Assert.AreEqual("Avatar", dvds[5].Title);
            Assert.AreEqual("2009", dvds[5].ReleaseYear);
            Assert.AreEqual("James Cameron", dvds[5].Director);
            Assert.AreEqual("PG-13", dvds[5].Rating);
        }

        [Test]
        public void CanUpdateDvd()
        {
            var repo = new DvdRepositoryMock();
            var dvd = new Dvd { Title = "Avatar", ReleaseYear = "2009", Director = "James Cameron", Rating = "PG-13", Notes = "A VERY overrated movie." };
            repo.DvdInsert(dvd);

            dvd.ReleaseYear = "2021";
            dvd.Notes = "It's actually a bad film";

            repo.DvdUpdate(dvd);

            var updatedDvd = repo.GetById(dvd.DvdId);

            Assert.AreEqual("Avatar", updatedDvd.Title);
            Assert.AreEqual("2021", updatedDvd.ReleaseYear);
            Assert.AreEqual("It's actually a bad film", updatedDvd.Notes);
        }

        [Test]
        public void CanDeleteDvd()
        {
            var repo = new DvdRepositoryMock();
            var dvd = new Dvd { Title = "Avatar", ReleaseYear = "2009", Director = "James Cameron", Rating = "PG-13", Notes = "A VERY overrated movie." };
            repo.DvdInsert(dvd);

            var dvdAdded = repo.GetById(6);

            Assert.IsNotNull(dvdAdded);

            repo.DvdDelete(6);
            dvdAdded = repo.GetById(6);
            Assert.IsNull(dvdAdded);
        }

        [Test]
        public void CanGetDvdsByTitle()
        {
            var titleToSearch = "Star";
            var repo = new DvdRepositoryMock();
            var dvds = repo.GetByTitle(titleToSearch);

            Assert.AreEqual(1, dvds.Count());
            Assert.AreEqual("Star Wars: A New Hope", dvds[0].Title);
        }

        [Test]
        public void CanGetDvdsByDirectorName()
        {
            var directorNameToSearch = "Lucas";
            var repo = new DvdRepositoryMock();
            var dvds = repo.GetByDirectorName(directorNameToSearch);

            Assert.AreEqual(1, dvds.Count());
            Assert.AreEqual("George Lucas", dvds[0].Director);
        }

        [Test]
        public void CanGetDvdsByReleaseYear()
        {
            var releaseYearToSearch = "2008";
            var repo = new DvdRepositoryMock();
            var dvds = repo.GetByReleaseYear(releaseYearToSearch);

            Assert.AreEqual(1, dvds.Count());
            Assert.AreEqual("The Dark Knight", dvds[0].Title);
        }

        [Test]
        public void CanGetDvdsByRating()
        {
            var ratingToSearch = "NR";
            var repo = new DvdRepositoryMock();
            var dvds = repo.GetByRating(ratingToSearch);

            Assert.AreEqual(2, dvds.Count());

            Assert.AreEqual("North by Northwest", dvds[0].Title);
            Assert.AreEqual("On The Waterfront", dvds[1].Title);
        }
    }
}

