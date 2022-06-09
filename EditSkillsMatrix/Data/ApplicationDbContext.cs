using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EditSkillsMatrix.Models;
using Microsoft.EntityFrameworkCore;
using Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<QtypeMod> Qtypedb { get; set; }
    public DbSet<TeamMod> Teams { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Category> Category { get; set; }

    
    public DbSet<SubjectModel> Subjects { get; set; }
    public DbSet<Category2> Category2 { get; set; }
    public DbSet<AnswerModel> Answers { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Category>().ToTable();
        //modelBuilder.Entity<Question>().ToTable();

        modelBuilder.Entity<Booking>().ToTable(action =>
        {
            action.IsTemporal();
        });
    }




}
