using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkTogetherDBLib.Class;

public partial class PpeContext : DbContext
{
    public PpeContext()
    {
    }

    public PpeContext(DbContextOptions<PpeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonnement> Abonnements { get; set; }

    public virtual DbSet<Baie> Baies { get; set; }

    public virtual DbSet<DoctrineMigrationVersion> DoctrineMigrationVersions { get; set; }

    public virtual DbSet<MessengerMessage> MessengerMessages { get; set; }

    public virtual DbSet<Renouvellement> Renouvellements { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<TypeUnite> TypeUnites { get; set; }

    public virtual DbSet<Unite> Unites { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PPE;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abonnement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__abonneme__3213E83FCABA24ED");

            entity.ToTable("abonnement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ImgPath)
                .HasMaxLength(255)
                .HasColumnName("img_path");
            entity.Property(e => e.NbrEmplacement).HasColumnName("nbr_emplacement");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
            entity.Property(e => e.Prix).HasColumnName("prix");
            entity.Property(e => e.Reduction).HasColumnName("reduction");
        });

        modelBuilder.Entity<Baie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__baie__3213E83FF446A79F");

            entity.ToTable("baie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NbrEmplacement).HasColumnName("nbr_emplacement");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<DoctrineMigrationVersion>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK__doctrine__79B5C94CF4B51231");

            entity.ToTable("doctrine_migration_versions");

            entity.Property(e => e.Version)
                .HasMaxLength(191)
                .HasColumnName("version");
            entity.Property(e => e.ExecutedAt)
                .HasPrecision(6)
                .HasColumnName("executed_at");
            entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");
        });

        modelBuilder.Entity<MessengerMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__messenge__3213E83F239F0C58");

            entity.ToTable("messenger_messages");

            entity.HasIndex(e => e.DeliveredAt, "IDX_75EA56E016BA31DB");

            entity.HasIndex(e => e.AvailableAt, "IDX_75EA56E0E3BD61CE");

            entity.HasIndex(e => e.QueueName, "IDX_75EA56E0FB7336F0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("available_at");
            entity.Property(e => e.Body)
                .IsUnicode(false)
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("created_at");
            entity.Property(e => e.DeliveredAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("delivered_at");
            entity.Property(e => e.Headers)
                .IsUnicode(false)
                .HasColumnName("headers");
            entity.Property(e => e.QueueName)
                .HasMaxLength(190)
                .HasColumnName("queue_name");
        });

        modelBuilder.Entity<Renouvellement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__renouvel__3213E83F9408B8C5");

            entity.ToTable("renouvellement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservat__3213E83FA0524919");

            entity.ToTable("reservation");

            entity.HasIndex(e => e.IdentifiantAbonnementId, "IDX_42C8495525ABD6B9");

            entity.HasIndex(e => e.RenouvellementId, "IDX_42C849552D421B0");

            entity.HasIndex(e => e.CustomerId, "IDX_42C849559395C3F3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DateDeb)
                .HasPrecision(6)
                .HasColumnName("date_deb");
            entity.Property(e => e.DateEnd)
                .HasPrecision(6)
                .HasColumnName("date_end");
            entity.Property(e => e.Delaie).HasColumnName("delaie");
            entity.Property(e => e.IdentifiantAbonnementId).HasColumnName("identifiant_abonnement_id");
            entity.Property(e => e.Numero)
                .HasMaxLength(255)
                .HasColumnName("numero");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RenAuto).HasColumnName("ren_auto");
            entity.Property(e => e.RenouvellementId).HasColumnName("renouvellement_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_42C849559395C3F3");

            entity.HasOne(d => d.IdentifiantAbonnement).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdentifiantAbonnementId)
                .HasConstraintName("FK_42C8495525ABD6B9");

            entity.HasOne(d => d.Renouvellement).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RenouvellementId)
                .HasConstraintName("FK_42C849552D421B0");
        });

        modelBuilder.Entity<TypeUnite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_uni__3213E83FDE672AC9");

            entity.ToTable("type_unite");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Unite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unite__3213E83FEBEA2C7E");

            entity.ToTable("unite");

            entity.HasIndex(e => e.IdentifiantReservationId, "IDX_1D64C1188EE5A183");

            entity.HasIndex(e => e.IdentifiantBaieId, "IDX_1D64C11890C0C5E");

            entity.HasIndex(e => e.IdentifiantTypeUniteId, "IDX_1D64C118F5C9C1FD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdentifiantBaieId).HasColumnName("identifiant_baie_id");
            entity.Property(e => e.IdentifiantReservationId).HasColumnName("identifiant_reservation_id");
            entity.Property(e => e.IdentifiantTypeUniteId).HasColumnName("identifiant_type_unite_id");
            entity.Property(e => e.Numero)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdentifiantBaie).WithMany(p => p.Unites)
                .HasForeignKey(d => d.IdentifiantBaieId)
                .HasConstraintName("FK_1D64C11890C0C5E");

            entity.HasOne(d => d.IdentifiantReservation).WithMany(p => p.Unites)
                .HasForeignKey(d => d.IdentifiantReservationId)
                .HasConstraintName("FK_1D64C1188EE5A183");

            entity.HasOne(d => d.IdentifiantTypeUnite).WithMany(p => p.Unites)
                .HasForeignKey(d => d.IdentifiantTypeUniteId)
                .HasConstraintName("FK_1D64C118F5C9C1FD");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F8431C913");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UNIQ_8D93D649E7927C74")
                .IsUnique()
                .HasFilter("([email] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(180)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .HasColumnName("prenom");
            entity.Property(e => e.Roles)
                .IsUnicode(false)
                .HasComment("(DC2Type:json)")
                .HasColumnName("roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
