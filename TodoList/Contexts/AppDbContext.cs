

using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Models;

namespace TodoList.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDo> Todos { get; set; }
        public DbSet<Detail> Details { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ToDo>().ToTable("ToDo");
            builder.Entity<ToDo>().HasKey(p => p.Id);
            builder.Entity<ToDo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<ToDo>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<ToDo>().HasMany(p => p.details).WithOne(p => p.ToDo).HasForeignKey(p => p.ToDoId);

            builder.Entity<ToDo>().HasData
            (
                new ToDo { Id = 100, Name = "List Of Travel" }, // Id set manually due to in-memory provider
                new ToDo { Id = 101, Name = "List of Food" }
            );

            builder.Entity<Detail>().ToTable("Detail");
            builder.Entity<Detail>().HasKey(p => p.Id);
            builder.Entity<Detail>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Detail>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Detail>().Property(p => p.Check);

            builder.Entity<Detail>().HasData
            (
                new Detail
                {
                    Id = 100,
                    Name = "Bali",
                    Check = false,
                    ToDoId = 100
                },
                new Detail
                {
                    Id = 101,
                    Name = "Jakarta",
                    Check = true,
                    ToDoId = 100,
                },
                new Detail
                {
                    Id = 102,
                    Name = "Surabaya",
                    Check = false,
                    ToDoId = 100,
                },
                new Detail
                {
                    Id = 103,
                    Name = "Pizza",
                    Check = false,
                    ToDoId = 101,
                },
                new Detail
                {
                    Id = 104,
                    Name = "Gado-Gado",
                    Check = true,
                    ToDoId = 101,
                }
            );

        }
    }
}
