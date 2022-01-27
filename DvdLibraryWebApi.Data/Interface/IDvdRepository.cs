using DvdLibraryWebApi.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Data.Interface
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd GetById(int dvdId);
        List<Dvd> GetByTitle(string dvdTitle);
        List<Dvd> GetByReleaseYear(string releaseYear);
        List<Dvd> GetByDirectorName(string directorName);
        List<Dvd> GetByRating(string ratingName);
        void DvdInsert(Dvd dvd);
        void DvdUpdate(Dvd dvd);
        void DvdDelete(int dvdId);
    }
}
