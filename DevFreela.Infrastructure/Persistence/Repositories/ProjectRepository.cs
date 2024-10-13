﻿using DevFreela.API.Persistence;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;
        public ProjectRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return project.Id;
        }

        public async Task AddComment(ProjectComment comment)
        {
            await _context.ProjectComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Projects.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Project>> GetAll()
        {
            var projects = await _context.Projects
              .Include(x => x.Client)
              .Include(x => x.Freelancer)
              .Where(x => !x.IsDeleted).ToListAsync();

            return projects;
        }

        public async Task<Project?> GetById(int id)
        {
            return await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);                
        }

        public async Task<Project?> GetDetailsById(int id)
        {
            var project = await _context.Projects
              .Include(x => x.Client)
              .Include(x => x.Freelancer)
              .Include(x => x.Comments)
              .SingleOrDefaultAsync(x => x.Id == id);

            return project;
        }

        public async Task Update(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
