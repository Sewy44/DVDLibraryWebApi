using DvdLibraryWebApi.Data.Interface;
using DvdLibraryWebApi.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Data.Repositories
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd
            { DvdId = 1, Title="Star Wars: A New Hope", ReleaseYear = "1977", Director = "George Lucas", Rating = "PG", Notes = "She may not look like much, but she's got it where it counts." },
            new Dvd
            { DvdId = 2, Title="The Dark Knight", ReleaseYear = "2008", Director = "Christopher Nolan", Rating = "PG-13", Notes = "I'm not wearing hockey pads!" },
            new Dvd
            { DvdId = 3, Title="Thor Ragnarok", ReleaseYear = "2017", Director = "Taika Waititi", Rating = "PG-13", Notes = "Cate Blanchett as a villain!!!!" },
            new Dvd
            { DvdId = 4, Title="North by Northwest", ReleaseYear = "1959", Director = "Alfred Hitchcock", Rating = "NR", Notes = "One of the best of all time!" },
            new Dvd
            { DvdId = 5, Title="On The Waterfront", ReleaseYear = "1954", Director = "Elia Kazan", Rating = "NR", Notes = "I coulda been a contender!!" },
        };

        public void DvdDelete(int dvdId)
        {
            _dvds.RemoveAll(d => d.DvdId == dvdId);
        }

        public void DvdInsert(Dvd dvd)
        {
            dvd.DvdId = _dvds.Max(d => d.DvdId) + 1;
            _dvds.Add(dvd);
        }

        public void DvdUpdate(Dvd dvd)
        {
            var found = _dvds.FirstOrDefault(d => d.DvdId == dvd.DvdId);

            if (found != null)
                found = dvd;
        }

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd GetById(int dvdId)
        { 
            return _dvds.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetByRating(string ratingName)
        {
            var matchingRatings = _dvds.Where(r => r.Rating.Contains(ratingName));
            return matchingRatings.ToList();
        }

        public List<Dvd> GetByReleaseYear(string releaseYear)
        {
            var matchingReleaseYears = _dvds.Where(r => r.ReleaseYear.Contains(releaseYear));
            return matchingReleaseYears.ToList();
        }

        public List<Dvd> GetByTitle(string dvdTitle)
        {
            var matchingTitles = _dvds.Where(t => t.Title.Contains(dvdTitle));
            return matchingTitles.ToList();
        }

        public List<Dvd> GetByDirectorName(string directorName)
        {
            var matchingDirectorName = _dvds.Where(d => d.Director.Contains(directorName));
            return matchingDirectorName.ToList();
        }
    }

}
