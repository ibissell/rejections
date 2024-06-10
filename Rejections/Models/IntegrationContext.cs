using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rejections.Models;

public partial class IntegrationContext : DbContext
{
    public IntegrationContext()
    {
    }

    public IntegrationContext(DbContextOptions<IntegrationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<MessageAcknowledgment> MessageAcknowledgments { get; set; }

    public virtual DbSet<MessageNackMetadatum> MessageNackMetadata { get; set; }

    public virtual DbSet<MessageOrder> MessageOrders { get; set; }

    public virtual DbSet<MessageOrderId> MessageOrderIds { get; set; }

    public virtual DbSet<MessagePatientId> MessagePatientIds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tgh-sds02-sql.xtgh.nhs.uk;Database=Integration;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("Message", tb => tb.HasComment("Contains Messages that have been sent or received by the Trust Intergration Engine\r\n\r\nRhapsody:\r\nTGHRHAPSODY > PRODUCTION > # Active Communication Points > Message Repository\r\nTGHRHAPSODY > PRODUCTION > Lorenzo > Lorenzo_In_B2_Handles ACK > Read Original Message\r\n\r\nSSRS:\r\nTGHDATAWARE > Rhapsody > Lorenzo Rejections By Week and Department\r\n\r\nApplications:\r\nLorenzo Rejections\r\n"));

            entity.HasIndex(e => e.MessageControlId, "IX_Message_MessageControlID");

            entity.HasIndex(e => e.MessageDttm, "IX_Message_MessageDTTM");

            entity.HasIndex(e => e.MessageType, "IX_Message_MessageType");

            entity.HasIndex(e => e.ReceivingApplication, "IX_Message_ReceivingApplication");

            entity.HasIndex(e => e.SendingApplication, "IX_Message_SendingApplication");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InsertDttm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("InsertDTTM");
            entity.Property(e => e.Message1)
                .IsUnicode(false)
                .HasColumnName("Message");
            entity.Property(e => e.MessageControlId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("MessageControlID");
            entity.Property(e => e.MessageDttm)
                .HasColumnType("datetime")
                .HasColumnName("MessageDTTM");
            entity.Property(e => e.MessageType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ReceivingApplication)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.SendingApplication)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.TriggerEvent)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MessageAcknowledgment>(entity =>
        {
            entity.ToTable("Message_Acknowledgment", tb => tb.HasComment("Contains acknowledgment data that has been sent or received by the Trust Intergration Engine associated with a Message\r\n\r\nRhapsody:\r\nTGHRHAPSODY > PRODUCTION > # Active Communication Points > Message Repository\r\n\r\nSSRS:\r\nTGHDATAWARE > Rhapsody > Lorenzo Rejections By Week and Department\r\n\r\nApplications:\r\nLorenzo Rejections"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcknowledgementCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.MessageControlId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("MessageControlID");
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.TextMessage).IsUnicode(false);
        });

        modelBuilder.Entity<MessageNackMetadatum>(entity =>
        {
            entity.ToTable("Message_NACK_Metadata", tb => tb.HasComment("Contains a generic description and the cause/resolution of NACK Messages. Manually updated.\r\n\r\nSSRS:\r\nTGHDATAWARE > Rhapsody > Lorenzo Rejections By Week and Department\r\n\r\nApplications:\r\nLorenzo Rejections"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cause).IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.InsertDttm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("InsertDTTM");
            entity.Property(e => e.Resolution).IsUnicode(false);
            entity.Property(e => e.SendingApplication)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDttm)
                .HasColumnType("datetime")
                .HasColumnName("UpdateDTTM");
        });

        modelBuilder.Entity<MessageOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Message_Order_MessageID");

            entity.ToTable("Message_Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ExamDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.QuantityTimingStartDttm)
                .HasColumnType("datetime")
                .HasColumnName("QuantityTiming_StartDTTM");
        });

        modelBuilder.Entity<MessageOrderId>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Message_Order");

            entity.ToTable("Message_OrderID");

            entity.HasIndex(e => e.OrderId, "IX_Message_OrderID_OrderID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("IDType");
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.PlacerFiller)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MessagePatientId>(entity =>
        {
            entity.ToTable("Message_PatientID");

            entity.HasIndex(e => e.MessageId, "IX_Message_MessageID");

            entity.HasIndex(e => e.PatientId, "IX_Message_PatientID_PatientID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("IDType");
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.PatientId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PatientID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
