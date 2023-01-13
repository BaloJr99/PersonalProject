using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PersonalProject.Data.Models;

public partial class MedicalContext : DbContext
{
    public MedicalContext()
    {
    }

    public MedicalContext(DbContextOptions<MedicalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientDiagnosis> PatientDiagnoses { get; set; }

    public virtual DbSet<PatientsAppointment> PatientsAppointments { get; set; }

    public virtual DbSet<PatientsHistory> PatientsHistories { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BRAULIOJR\\SQLEXPRESS;Initial Catalog=medical;User Id=sa;Password=Pirata99*;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("PK__Addresse__67E8C78C29362B92");

            entity.Property(e => e.IdAddress)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idAddress");
            entity.Property(e => e.Apartment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apartment");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("zipCode");
        });

        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.HasKey(e => e.IdDoctorSchedule).HasName("PK__DoctorSc__1D787F56D590108A");

            entity.Property(e => e.IdDoctorSchedule)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idDoctorSchedule");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdSchedule).HasColumnName("idSchedule");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorSchedules_Schedules");

            entity.HasOne(d => d.IdScheduleNavigation).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.IdSchedule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorSchedules_Employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PK__Employee__227F26A5E1EA0154");

            entity.Property(e => e.IdEmployee)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idEmployee");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.IdAddress).HasColumnName("idAddress");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Scholarity)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("scholarity");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Addresses");
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.IdMedicalHistories).HasName("PK__MedicalH__834157AD9481D0BF");

            entity.Property(e => e.IdMedicalHistories)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idMedicalHistories");
            entity.Property(e => e.AssignationHistory)
                .HasColumnType("datetime")
                .HasColumnName("assignationHistory");
            entity.Property(e => e.PatientCondition)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("patientCondition");
            entity.Property(e => e.PatientMedication)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("patientMedication");
            entity.Property(e => e.PatientSurgeries)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("patientSurgeries");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient).HasName("PK__Patients__8C242805C2AC044D");

            entity.Property(e => e.IdPatient)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idPatient");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.IdAddress).HasColumnName("idAddress");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.IdAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_Addresses");
        });

        modelBuilder.Entity<PatientDiagnosis>(entity =>
        {
            entity.HasKey(e => e.IdPatientDiagnose).HasName("PK__PatientD__DA6B27238D055E01");

            entity.Property(e => e.IdPatientDiagnose)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idPatientDiagnose");
            entity.Property(e => e.Diagnose)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("diagnose");
            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");
            entity.Property(e => e.IdPatientAppointment).HasColumnName("idPatientAppointment");
            entity.Property(e => e.Prescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("prescription");
            entity.Property(e => e.Symptoms)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("symptoms");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.PatientDiagnoses)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDiagnoses_Users");

            entity.HasOne(d => d.IdPatientAppointmentNavigation).WithMany(p => p.PatientDiagnoses)
                .HasForeignKey(d => d.IdPatientAppointment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDiagnoses_PatientsAppointments");
        });

        modelBuilder.Entity<PatientsAppointment>(entity =>
        {
            entity.HasKey(e => e.IdPatientsAppointments).HasName("PK__Patients__1C03D0AE13CED47F");

            entity.Property(e => e.IdPatientsAppointments)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idPatientsAppointments");
            entity.Property(e => e.AppointmentStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("appointmentStatus");
            entity.Property(e => e.AssignationDate)
                .HasColumnType("datetime")
                .HasColumnName("assignationDate");
            entity.Property(e => e.IdPatient).HasColumnName("idPatient");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.PatientsAppointments)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientsAppointments_Patients");
        });

        modelBuilder.Entity<PatientsHistory>(entity =>
        {
            entity.HasKey(e => e.IdPatientsHistory).HasName("PK__Patients__285A25ED6DF4C84F");

            entity.ToTable("PatientsHistory");

            entity.Property(e => e.IdPatientsHistory)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idPatientsHistory");
            entity.Property(e => e.IdHistory).HasColumnName("idHistory");
            entity.Property(e => e.IdPatient).HasColumnName("idPatient");

            entity.HasOne(d => d.IdHistoryNavigation).WithMany(p => p.PatientsHistories)
                .HasForeignKey(d => d.IdHistory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientsHistory_MedicalHistories");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.PatientsHistories)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientsHistory_Patients");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.IdSchedule).HasName("PK__Schedule__5717CA94E3CED5FB");

            entity.Property(e => e.IdSchedule)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idSchedule");
            entity.Property(e => e.BreakTime)
                .HasColumnType("datetime")
                .HasColumnName("breakTime");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dayOfWeek");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("endTime");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("startTime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C982E334FCCE");

            entity.Property(e => e.IdUser)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Employees");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
