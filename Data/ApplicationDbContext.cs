using comp2139.Models;
using Microsoft.EntityFrameworkCore;

namespace comp2139.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
    
    public DbSet<Project> Projects { get; set; }
    
    
}  