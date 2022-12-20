﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDataContext _context;

        public TodoRepository(TodoDataContext context) => _context = context;

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user) 
            => _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(x => x.Date);

        public IEnumerable<TodoItem> GetAllDone(string user)
            => _context.Todos.AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);

        public IEnumerable<TodoItem> GetAllUndone(string user)
            => _context.Todos.AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);

        public TodoItem GetById(Guid id, string user)
            => _context.Todos.AsNoTracking()
                .FirstOrDefault(x => x.Id == id && x.User == user);    

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
            => _context.Todos.AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
