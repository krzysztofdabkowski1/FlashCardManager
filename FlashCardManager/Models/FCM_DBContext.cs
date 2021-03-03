using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class FCM_DBContext : DbContext
    {
        public FCM_DBContext()
        {
        }

        public FCM_DBContext(DbContextOptions<FCM_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<BundleCard> BundleCards { get; set; }
        public virtual DbSet<BundleCardDescription> BundleCardDescriptions { get; set; }
        public virtual DbSet<BundleCardExample> BundleCardExamples { get; set; }
        public virtual DbSet<BundleCardsSession> BundleCardsSessions { get; set; }
        public virtual DbSet<BundleOwner> BundleOwners { get; set; }
        public virtual DbSet<BundleSession> BundleSessions { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardReverse> CardReverses { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=fcmanager.database.windows.net;Initial Catalog=FCM_DB;User ID=Krzysztof@krzysztofdabkowski1hotmail.onmicrosoft.com;Password='Malina123.';Authentication='Active Directory Password'");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bundle>(entity =>
            {
                entity.ToTable("bundle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardsQuantity).HasColumnName("cards_quantity");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.ForeignLangId).HasColumnName("foreign_lang_id");

                entity.Property(e => e.NativeLangId).HasColumnName("native_lang_id");

                entity.Property(e => e.Public).HasColumnName("public");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.HasOne(d => d.ForeignLang)
                    .WithMany(p => p.BundleForeignLangs)
                    .HasForeignKey(d => d.ForeignLangId)
                    .HasConstraintName("FK__bundle__foreign___0D7A0286");

                entity.HasOne(d => d.NativeLang)
                    .WithMany(p => p.BundleNativeLangs)
                    .HasForeignKey(d => d.NativeLangId)
                    .HasConstraintName("FK__bundle__native_l__7C4F7684");
            });

            modelBuilder.Entity<BundleCard>(entity =>
            {
                entity.ToTable("bundle_cards");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BundleId).HasColumnName("bundle_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ForeignCardId).HasColumnName("foreign_card_id");

                entity.Property(e => e.NativeCardId).HasColumnName("native_card_id");

                entity.HasOne(d => d.Bundle)
                    .WithMany(p => p.BundleCards)
                    .HasForeignKey(d => d.BundleId)
                    .HasConstraintName("FK__bundle_ca__bundl__7B5B524B");

                entity.HasOne(d => d.ForeignCard)
                    .WithMany(p => p.BundleCards)
                    .HasForeignKey(d => d.ForeignCardId)
                    .HasConstraintName("FK__bundle_ca__forei__114A936A");

                entity.HasOne(d => d.NativeCard)
                    .WithMany(p => p.BundleCards)
                    .HasForeignKey(d => d.NativeCardId)
                    .HasConstraintName("FK__bundle_ca__nativ__0F624AF8");
            });

            modelBuilder.Entity<BundleCardDescription>(entity =>
            {
                entity.ToTable("bundle_card_description");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BundleCardId).HasColumnName("bundle_card_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.BundleCard)
                    .WithMany(p => p.BundleCardDescriptions)
                    .HasForeignKey(d => d.BundleCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bundle_ca__bundl__160F4887");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BundleCardDescriptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bundle_ca__user___151B244E");
            });

            modelBuilder.Entity<BundleCardExample>(entity =>
            {
                entity.ToTable("bundle_card_examples");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BundleCardId).HasColumnName("bundle_card_id");

                entity.Property(e => e.Example)
                    .HasMaxLength(255)
                    .HasColumnName("example");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.BundleCard)
                    .WithMany(p => p.BundleCardExamples)
                    .HasForeignKey(d => d.BundleCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bundle_ca__bundl__17F790F9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BundleCardExamples)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bundle_ca__user___17036CC0");
            });

            modelBuilder.Entity<BundleCardsSession>(entity =>
            {
                entity.ToTable("bundle_cards_session");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BundleSessionId).HasColumnName("bundle_session_id");

                entity.Property(e => e.IsGoodAnswers).HasColumnName("is_good_answers");

                entity.HasOne(d => d.BundleSession)
                    .WithMany(p => p.BundleCardsSessions)
                    .HasForeignKey(d => d.BundleSessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bundle_ca__bundl__1AD3FDA4");
            });

            modelBuilder.Entity<BundleOwner>(entity =>
            {
                entity.ToTable("bundle_owner");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BundleId).HasColumnName("bundle_id");

                entity.Property(e => e.IsUserActive).HasColumnName("is_user_active");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Bundle)
                    .WithMany(p => p.BundleOwners)
                    .HasForeignKey(d => d.BundleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bundle_ow__bundl__123EB7A3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BundleOwners)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__bundle_ow__user___14270015");
            });

            modelBuilder.Entity<BundleSession>(entity =>
            {
                entity.ToTable("bundle_session");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BadAnswers).HasColumnName("bad_answers");

                entity.Property(e => e.BundleId).HasColumnName("bundle_id");

                entity.Property(e => e.GoodAnswers).HasColumnName("good_answers");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.SessionDate)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("session_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Bundle)
                    .WithMany(p => p.BundleSessions)
                    .HasForeignKey(d => d.BundleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bundle_se__bundl__18EBB532");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BundleSessions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bundle_se__user___19DFD96B");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("card");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LangId).HasColumnName("lang_id");

                entity.Property(e => e.NativeTerm)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("native_term");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.LangId)
                    .HasConstraintName("FK__card__lang_id__7A672E12");
            });

            modelBuilder.Entity<CardReverse>(entity =>
            {
                entity.ToTable("card_reverse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LangId).HasColumnName("lang_id");

                entity.Property(e => e.Public).HasColumnName("public");

                entity.Property(e => e.Term)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("term");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardReverses)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("FK__card_reve__card___787EE5A0");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.CardReverses)
                    .HasForeignKey(d => d.LangId)
                    .HasConstraintName("FK__card_reve__lang___797309D9");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameFull)
                    .HasMaxLength(255)
                    .HasColumnName("name_full");

                entity.Property(e => e.NameShort)
                    .HasMaxLength(255)
                    .HasColumnName("name_short");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Login)
                    .HasMaxLength(255)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
