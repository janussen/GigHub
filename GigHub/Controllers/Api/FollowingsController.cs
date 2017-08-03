﻿using GigHub.Dto;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Followings
                            .Any(f => f.FolloweeId == dto.FolloweeId && f.FollowerId == userId);

            if (exists)
            {
                return BadRequest("You already follow this artist");
            }

            var following = new Following
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = userId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}