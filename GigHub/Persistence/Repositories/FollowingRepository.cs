﻿using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System.Linq;

namespace GigHub.Core.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string followerId, string followeeId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FollowerId == followerId && f.FolloweeId == followeeId);
        }
    }
}