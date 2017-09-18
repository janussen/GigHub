using GigHub.Core.Dto;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Core.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                    .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                    .ToList();
        }

        public Attendance GetAttendance(string userId, int gigId)
        {
            return _context.Attendances
                    .SingleOrDefault(a => a.AttendeeId == userId && a.GigId == gigId);
        }

        public bool UserAttendsGig(string userId, int gigId)
        {
            return _context.Attendances
                    .Any(a => a.AttendeeId == userId && a.GigId == gigId);
        }

        public void Attend(string userId, int gigId)
        {
            var attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
        }

        public void Unattend(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }
    }
}