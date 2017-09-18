using GigHub.Core;
using GigHub.Core.Dto;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var following = _unitOfWork.Followings.GetFollowing(userId, dto.FolloweeId);

            if (following != null)
            {
                return BadRequest("You already follow this artist");
            }
            else
            {
                _unitOfWork.Followings.Create(userId, dto.FolloweeId);
                _unitOfWork.Complete();

                return Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Followings.GetFollowing(userId, id);

            if (following == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.Followings.Delete(following);
                _unitOfWork.Complete();
                return Ok(id);
            }
        }
    }
}