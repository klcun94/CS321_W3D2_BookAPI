using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D2_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _bookContext.Publishers
                .Include(a => a.Books)
                .ToList();
        }

        public Publisher Get(int publisherId)
        {
            return _bookContext.Publishers
                .FirstOrDefault(p => p.Id == publisherId);

        }
        public Publisher Add(Publisher newPublisher)
        {
            _bookContext.Publishers.Add(newPublisher);
            _bookContext.SaveChanges();
            return newPublisher;
        }

        public Publisher Update(Publisher updatedPublisher)
        {
            var currentPublisher = this.Get(updatedPublisher.Id);
            if (currentPublisher == null) return null;
            _bookContext.Entry(currentPublisher).CurrentValues
                .SetValues(updatedPublisher);
            _bookContext.Publishers.Update(currentPublisher);
            _bookContext.SaveChanges();
            return currentPublisher;
        }
        public void Remove(Publisher publisher)
        {
            _bookContext.Publishers.Remove(publisher);
            _bookContext.SaveChanges();
        }
    }
}
