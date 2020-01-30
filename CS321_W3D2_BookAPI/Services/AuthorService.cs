﻿using System.Collections.Generic;
using System.Linq;
using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D2_BookAPI.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly BookContext _bookContext;

        public AuthorService(BookContext bookContext)
        {
            // keep a reference to the BookContext in _bookContext
            _bookContext = bookContext;
        }

        public Author Add(Author author)
        {
            // implement add
            _bookContext.Authors.Add(author);
            _bookContext.SaveChanges();
            return author;
        }

        public Author Get(int id)
        {
            // return the specified Author using Find()
            return _bookContext.Authors
                .Include(a => a.Books)
                .SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            // return all Authors using ToList()
            return _bookContext.Authors
                .Include(a => a.Books)
                .ToList();
        }

        public Author Update(Author updatedAuthor)
        {
            // get the ToDo object in the current list with this id 
            var currentAuthor = _bookContext.Authors.Find(updatedAuthor.Id);

            // return null if todo to update isn't found
            if (currentAuthor == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _bookContext.Entry(currentAuthor)
                .CurrentValues
                .SetValues(updatedAuthor);

            // update the todo and save
            _bookContext.Authors.Update(currentAuthor);
            _bookContext.SaveChanges();
            return currentAuthor;
        }

        public void Remove(Author author)
        {
            // remove the author
            _bookContext.Authors.Remove(author);
            _bookContext.SaveChanges();
        }

    }
}
