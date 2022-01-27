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
    public class DvdController : ApiController
    {

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            var model = DvdRepositoryFactory.GetRepository();

            return Ok(model.GetAll());
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvd(int dvdId)
        {
            var model = DvdRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetById(dvdId));
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByTitle(string title)
        {
            var model = DvdRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetByTitle(title));
            }
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByReleaseYear(string releaseYear)
        {
            var model = DvdRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetByReleaseYear(releaseYear));
            }
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByDirector(string director)
        {
            var model = DvdRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetByDirectorName(director));
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByRating(string rating)
        {
            var model = DvdRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model.GetByRating(rating));
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
           
            var model = DvdRepositoryFactory.GetRepository();
            model.DvdInsert(dvd);

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

            var model = DvdRepositoryFactory.GetRepository();
            Dvd dvd = model.GetById(request.DvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            dvd.Title = request.Title;
            dvd.Director = request.Director;
            dvd.Rating = request.Rating;
            dvd.ReleaseYear = request.ReleaseYear;
            dvd.Notes = request.Notes;

            model.DvdUpdate(dvd);
            return Ok(dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteDvd(int dvdId)
        {
            var model = DvdRepositoryFactory.GetRepository();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                model.DvdDelete(dvdId);
                return Ok();
            }
        }
    }
}