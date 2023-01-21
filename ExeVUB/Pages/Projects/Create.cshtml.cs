using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExeVUB.Models;

namespace ExeVUB.Pages_Projects
{
    public class CreateModel : PageModel
    {
        private readonly ExeVUBDbContext _context;

        public CreateModel(ExeVUBDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(Project.Img != null)
            {
                //generate a unique name for the file
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Project.Img.FileName);
                
                //save the file to the wwwroot/images folder
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Project.Img.CopyToAsync(fileStream);
                }

                //Save the file path to the database
                Project.Image = "/images/" + fileName;
            }

            _context.Project.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
