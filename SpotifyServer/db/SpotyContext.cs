using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SpotifyServer.db
{
    public partial class SpotyContext : DbContext
    {
        public SpotyContext()
        {
        }

        public SpotyContext(DbContextOptions<SpotyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumTrack> AlbumTracks { get; set; }
        public virtual DbSet<AlbumsArtist> AlbumsArtists { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistsTrak> ArtistsTraks { get; set; }
        public virtual DbSet<LikesAlbum> LikesAlbums { get; set; }
        public virtual DbSet<LikesTrack> LikesTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrackHistory> TrackHistories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAlbum> UserAlbums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Integrated Security = True; Server=DESKTOP-GN3IAH8\\SQLEXPRESS; Initial Catalog=Spoty;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AlbumTrack>(entity =>
            {
                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.AlbumTracks)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumTracks_Albums");

                entity.HasOne(d => d.IdTrackNavigation)
                    .WithMany(p => p.AlbumTracks)
                    .HasForeignKey(d => d.IdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumTracks_Tracks");
            });

            modelBuilder.Entity<AlbumsArtist>(entity =>
            {
                entity.HasOne(d => d.IdAlbumsNavigation)
                    .WithMany(p => p.AlbumsArtists)
                    .HasForeignKey(d => d.IdAlbums)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumsArtists_Albums");

                entity.HasOne(d => d.IdArtistsNavigation)
                    .WithMany(p => p.AlbumsArtists)
                    .HasForeignKey(d => d.IdArtists)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumsArtists_Artists");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ArtistsTrak>(entity =>
            {
                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany(p => p.ArtistsTraks)
                    .HasForeignKey(d => d.IdArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistsTraks_Artists");

                entity.HasOne(d => d.IdTrackNavigation)
                    .WithMany(p => p.ArtistsTraks)
                    .HasForeignKey(d => d.IdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistsTraks_Tracks");
            });

            modelBuilder.Entity<LikesAlbum>(entity =>
            {
                entity.ToTable("LikesAlbum");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.LikesAlbums)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikesAlbum_Albums");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.LikesAlbums)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikesAlbum_User");
            });

            modelBuilder.Entity<LikesTrack>(entity =>
            {
                entity.HasOne(d => d.IdTrackNavigation)
                    .WithMany(p => p.LikesTracks)
                    .HasForeignKey(d => d.IdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikesTracks_Tracks");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.LikesTracks)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikesTracks_User");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Track1)
                    .IsRequired()
                    .HasColumnName("Track");
            });

            modelBuilder.Entity<TrackHistory>(entity =>
            {
                entity.ToTable("Track_History");

                entity.Property(e => e.IdAlbum).HasColumnName("Id_Album");

                entity.Property(e => e.IdTrack).HasColumnName("Id_Track");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.TrackHistories)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_History_Albums");

                entity.HasOne(d => d.IdTrackNavigation)
                    .WithMany(p => p.TrackHistories)
                    .HasForeignKey(d => d.IdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_History_Tracks");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TrackHistories)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_History_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<UserAlbum>(entity =>
            {
                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.UserAlbums)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAlbums_Albums");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserAlbums)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAlbums_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
