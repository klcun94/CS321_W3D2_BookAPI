using System.Collections.Generic;
using CS321_W3D2_BookAPI.Models;

namespace CS321_W3D2_BookAPI.Services
{
    public interface IBookService
    {
        // create
        Book Add(Book todo); 
        // read
        Book Get(int id);
        // update
        Book Update(Book todo); 
        // delete
        void Remove(Book todo);
        // list
        IEnumerable<Book> GetAll();
    }
}
