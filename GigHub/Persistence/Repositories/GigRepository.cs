﻿using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Core.Persistence.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Gig GetGig(int gigId)
        {
            return _context.Gigs.Single(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetGigsForArtist(string userId)
        {
            return _context.Gigs
                    .Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && !g.IsCanceled)
                    .Include(g => g.Genre)
                    .ToList();
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                    .Include(g => g.Attendances.Select(a => a.Attendee))
                    .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                    .Where(a => a.AttendeeId == userId)
                    .Select(a => a.Gig)
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .ToList();
        }

        public Gig GetGigWithArtistAndGenre(int gigId)
        {
            return _context.Gigs
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetFutureGigsWithArtistAndGenre()
        {
            return _context.Gigs
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);
        }

        public IEnumerable<Gig> SearchFutureGigsWithArtistAndGenre(string query)
        {
            return _context.Gigs
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled)
                    .Where(g => g.Artist.Name.Contains(query) ||
                                g.Genre.Name.Contains(query) ||
                                g.Venue.Contains(query));
        }

        public void AddGig(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}