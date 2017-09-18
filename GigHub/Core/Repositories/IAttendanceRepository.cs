using GigHub.Core.Dto;
using GigHub.Core.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(string userId, int gigId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        bool UserAttendsGig(string userId, int gigId);
        void Attend(string userId, int gigId);
        void Unattend(Attendance attendance);
    }
}