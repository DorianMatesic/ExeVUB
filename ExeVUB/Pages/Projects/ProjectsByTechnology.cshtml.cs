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
    public class ProjectsByTechnologyModel : PageModel
    {
        private readonly ExeVUBDbContext _context;

        public ProjectsByTechnologyModel(ExeVUBDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync(string technology)
        {
           if (_context.Project != null)
            {
                Project = await _context.Project.Where(p => p.Technologies.Contains(technology)).ToListAsync();
            }
        }
    }
}
