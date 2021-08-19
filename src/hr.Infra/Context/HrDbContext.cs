using hr.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace hr.Infra.Context
{
    public class HrDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HrDbContext(DbContextOptions<HrDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public DbSet<People> Peoples { get; set; }
    }
}
