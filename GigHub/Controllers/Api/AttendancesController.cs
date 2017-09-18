using GigHub.Core;
using GigHub.Core.Dto;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _unitOfWork.Attendances.UserAttendsGig(userId, dto.GigId);

            if (exists)
            {
                return BadRequest("The attendance already exists");
            }

            _unitOfWork.Attendances.Attend(userId, dto.GigId);

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unattend(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _unitOfWork.Attendances.GetAttendance(userId, id);

            if (attendance == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.Attendances.Unattend(attendance);
                _unitOfWork.Complete();

                return Ok(id);
            }
        }
    }
}
