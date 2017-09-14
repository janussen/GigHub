﻿using GigHub.Core;
using GigHub.Core.Persistence.Repositories;
using GigHub.Core.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IAttendanceRepository Attendances { get; private set; }
        public IGigRepository Gigs { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IFollowingRepository Followings { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Attendances = new AttendanceRepository(_context);
            Gigs = new GigRepository(_context);
            Genres = new GenreRepository(_context);
            Followings = new FollowingRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}