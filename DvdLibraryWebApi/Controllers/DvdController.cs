using DvdLibraryWebApi.Data;
using DvdLibraryWebApi.Models;
using DvdLibraryWebApi.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DvdLibraryWebApi.Controllers
{
    public class DVDController : ApiController
    {

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            var model = DVDRepositoryFactory.GetRepository();

            return Ok(model.GetAllDVDs());
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvd(int dvdId)
        {
            var model = DVDRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetDVDById(dvdId));
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByTitle(string title)
        {
            var model = DVDRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetDVDByTitle(title));
            }
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByReleaseYear(string releaseYear)
        {
            var model = DVDRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetDVDByReleaseYear(releaseYear));
            }
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByDirector(string director)
        {
            var model = DVDRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetDVDByDirectorName(director));
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByRating(string rating)
        {
            var model = DVDRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetDVDByRating(rating));
            }
        }
        
        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddDvd(AddDvdRequest request)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = new Dvd()
            {
                Title = request.Title,
                Director = request.Director,
                Rating = request.Rating,
                ReleaseYear = request.ReleaseYear,
                Notes = request.Notes
            };
           
            var model = DVDRepositoryFactory.GetRepository();
            model.InsertDVD(dvd);

            return Created($"dvd/get/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateDvd(UpdateDvdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = DVDRepositoryFactory.GetRepository();
            Dvd dvd = model.GetDVDById(request.DvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            dvd.Title = request.Title;
            dvd.Director = request.Director;
            dvd.Rating = request.Rating;
            dvd.ReleaseYear = request.ReleaseYear;
            dvd.Notes = request.Notes;

            model.UpdateDVD(dvd);
            return Ok(dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteDvd(int dvdId)
        {
            var model = DVDRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                model.DeleteDVD(dvdId);
                return Ok();
            }
        }
    }
}