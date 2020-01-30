using System;
using System.Collections.Generic;
using CS321_W3D2_BookAPI.Models;
using System.Threading.Tasks;

namespace CS321_W3D2_BookAPI.Services
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAll();
        Publisher Get(int id);
        Publisher Add(Publisher newPublisher);
        Publisher Update(Publisher updatedPublisher);
        void Remove(Publisher publisher);
    }
}
