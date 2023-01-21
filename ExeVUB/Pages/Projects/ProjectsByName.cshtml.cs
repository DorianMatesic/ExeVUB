using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExeVUB.Models;

namespace ExeVUB.Pages_Projects
{
    public class ProjectsByNameModel : PageModel
    {
        private readonly ExeVUBDbContext _context;

        public ProjectsByNameModel(ExeVUBDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync(string name, string SortBy)
        {
            if (_context.Project != null)
            {
                if(SortBy == "Date") {
                    Project = await _context.Project.Where(p => p.Name == name).OrderByDescending(p => p.Date).ToListAsync();
                }
                else if(SortBy == "Name") {
                    Project = await _context.Project.Where(p => p.Name == name).OrderBy(p => p.Name).ToListAsync();
                } else {
                    Project = await _context.Project.Where(p => p.Name == name).ToListAsync();
                }
            }
        }
    }
}
