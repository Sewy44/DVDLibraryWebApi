using DvdLibraryWebApi.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Data.Interface
{
    public interface DVDRepository
    {
        List<Dvd> GetAllDVDs();
        Dvd GetDVDById(int dvdId);
        List<Dvd> GetDVDByTitle(string dvdTitle);
        List<Dvd> GetDVDByReleaseYear(string releaseYear);
        List<Dvd> GetDVDByDirectorName(string directorName);
        List<Dvd> GetDVDByRating(string ratingName);
        void InsertDVD(Dvd dvd);
        void UpdateDVD(Dvd dvd);
        void DeleteDVD(int dvdId);
    }
}
