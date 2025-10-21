using LibrarySystem.API.Models.Entities;
using LibrarySystem.API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using QubitTech.Repositories.Extensions;

namespace LibrarySystem.API.Repositories.Contexts;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
        : base(options)
    {
    }

    // DbSets
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Soft Delete Query Filter
        modelBuilder.ApplySoftDeleteQueryFilter();
        
        // Audit Indexes (CreatedBy, UpdatedBy için)
        modelBuilder.ConfigureAuditIndexes();
        

        // Book Configuration
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ISBN).HasMaxLength(13).IsRequired();
            entity.Property(e => e.Title).HasMaxLength(500).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(2000);
            
            entity.HasIndex(e => e.ISBN).IsUnique();
            entity.HasIndex(e => e.Title);
            entity.HasIndex(e => e.Status);

            entity.HasOne(e => e.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(e => e.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Author Configuration
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Biography).HasMaxLength(2000);
            entity.Property(e => e.Country).HasMaxLength(100);

            entity.HasIndex(e => new { e.FirstName, e.LastName });
        });

        // Publisher Configuration
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Website).HasMaxLength(500);

            entity.HasIndex(e => e.Name);
        });

        // Category Configuration
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasIndex(e => e.Name).IsUnique();
        });

        // Member Configuration
        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Address).HasMaxLength(500);

            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.MembershipType);
        });

        // Loan Configuration
        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LateFee).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.LoanDate);
            entity.HasIndex(e => e.DueDate);
            entity.HasIndex(e => new { e.MemberId, e.Status });
            entity.HasIndex(e => new { e.BookId, e.Status });

            entity.HasOne(e => e.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Member)
                .WithMany(m => m.Loans)
                .HasForeignKey(e => e.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Seed Data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Categories
        var categories = new[]
        {
            new Category { Id = 1, Name = "Fiction", Description = "Fiction books", CreatedTime = DateTime.UtcNow },
            new Category { Id = 2, Name = "Non-Fiction", Description = "Non-fiction books", CreatedTime = DateTime.UtcNow },
            new Category { Id = 3, Name = "Science", Description = "Science books", CreatedTime = DateTime.UtcNow },
            new Category { Id = 4, Name = "History", Description = "History books", CreatedTime = DateTime.UtcNow },
            new Category { Id = 5, Name = "Biography", Description = "Biography books", CreatedTime = DateTime.UtcNow }
        };
        modelBuilder.Entity<Category>().HasData(categories);

        // Authors
        var author1 = new Author 
        { 
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            FirstName = "George",
            LastName = "Orwell",
            Biography = "English novelist and essayist",
            DateOfBirth = new DateTime(1903, 6, 25),
            Country = "United Kingdom",
            CreatedTime = DateTime.UtcNow
        };

        var author2 = new Author
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            FirstName = "J.K.",
            LastName = "Rowling",
            Biography = "British author, best known for Harry Potter",
            DateOfBirth = new DateTime(1965, 7, 31),
            Country = "United Kingdom",
            CreatedTime = DateTime.UtcNow
        };

        var author3 = new Author
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            FirstName = "Isaac",
            LastName = "Asimov",
            Biography = "American writer and professor of biochemistry",
            DateOfBirth = new DateTime(1920, 1, 2),
            Country = "United States",
            CreatedTime = DateTime.UtcNow
        };

        modelBuilder.Entity<Author>().HasData(author1, author2, author3);

        // Publishers
        var publisher1 = new Publisher
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Name = "Penguin Books",
            Country = "United Kingdom",
            Website = "https://www.penguin.co.uk",
            FoundedYear = 1935,
            CreatedTime = DateTime.UtcNow
        };

        var publisher2 = new Publisher
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Name = "Bloomsbury Publishing",
            Country = "United Kingdom",
            Website = "https://www.bloomsbury.com",
            FoundedYear = 1986,
            CreatedTime = DateTime.UtcNow
        };

        modelBuilder.Entity<Publisher>().HasData(publisher1, publisher2);

        // Books
        var book1 = new Book
        {
            Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
            ISBN = "9780141036144",
            Title = "1984",
            Description = "A dystopian social science fiction novel",
            PublicationYear = 1949,
            TotalCopies = 5,
            AvailableCopies = 5,
            Status = BookStatus.Available,
            AuthorId = author1.Id,
            PublisherId = publisher1.Id,
            CategoryId = 1,
            CreatedTime = DateTime.UtcNow
        };

        var book2 = new Book
        {
            Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            ISBN = "9780747532699",
            Title = "Harry Potter and the Philosopher's Stone",
            Description = "A young wizard's first year at Hogwarts",
            PublicationYear = 1997,
            TotalCopies = 10,
            AvailableCopies = 8,
            Status = BookStatus.Available,
            AuthorId = author2.Id,
            PublisherId = publisher2.Id,
            CategoryId = 1,
            CreatedTime = DateTime.UtcNow
        };

        var book3 = new Book
        {
            Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
            ISBN = "9780553293357",
            Title = "Foundation",
            Description = "The first novel in Isaac Asimov's Foundation Trilogy",
            PublicationYear = 1951,
            TotalCopies = 3,
            AvailableCopies = 3,
            Status = BookStatus.Available,
            AuthorId = author3.Id,
            PublisherId = publisher1.Id,
            CategoryId = 3,
            CreatedTime = DateTime.UtcNow
        };

        modelBuilder.Entity<Book>().HasData(book1, book2, book3);
    }
}