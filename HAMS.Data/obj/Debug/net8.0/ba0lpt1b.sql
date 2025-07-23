IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Departments] (
    [DepartmentId] int NOT NULL IDENTITY,
    [DeptName] nvarchar(max) NOT NULL,
    [Description] nvarchar(100) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentId])
);
GO

CREATE TABLE [Users] (
    [UserId] uniqueidentifier NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [ContactNo] nvarchar(10) NOT NULL,
    [Role] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Doctors] (
    [DoctorId] uniqueidentifier NOT NULL,
    [DoctorName] nvarchar(max) NOT NULL,
    [Specialization] nvarchar(max) NOT NULL,
    [DepartmentId] int NOT NULL,
    CONSTRAINT [PK_Doctors] PRIMARY KEY ([DoctorId]),
    CONSTRAINT [FK_Doctors_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([DepartmentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Doctors_Users_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Patients] (
    [PatientId] uniqueidentifier NOT NULL,
    [PatientName] nvarchar(100) NOT NULL,
    [Gender] nvarchar(20) NOT NULL,
    [BloodGroup] nvarchar(5) NOT NULL,
    [Address] nvarchar(50) NOT NULL,
    [DOB] date NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([PatientId]),
    CONSTRAINT [FK_Patients_Users_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [DoctorSchedules] (
    [ScheduleId] int NOT NULL IDENTITY,
    [DoctorId] uniqueidentifier NOT NULL,
    [Day] nvarchar(max) NOT NULL,
    [StartTime] time NULL,
    [EndTime] time NULL,
    [IsOnLeave] bit NOT NULL,
    CONSTRAINT [PK_DoctorSchedules] PRIMARY KEY ([ScheduleId]),
    CONSTRAINT [FK_DoctorSchedules_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([DoctorId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Appointments] (
    [AppointmentId] int NOT NULL IDENTITY,
    [DoctorId] uniqueidentifier NOT NULL,
    [PatientId] uniqueidentifier NOT NULL,
    [AppointmentTime] datetime2 NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY ([AppointmentId]),
    CONSTRAINT [FK_Appointments_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([DoctorId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Appointments_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([PatientId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [MedicalRecords] (
    [RecordId] int NOT NULL IDENTITY,
    [AppointmentId] int NOT NULL,
    [VisitNotes] nvarchar(500) NOT NULL,
    [Prescription] nvarchar(500) NOT NULL,
    [FollowUpInstructions] nvarchar(500) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_MedicalRecords] PRIMARY KEY ([RecordId]),
    CONSTRAINT [FK_MedicalRecords_Appointments_AppointmentId] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointments] ([AppointmentId]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentId', N'CreatedAt', N'DeptName', N'Description', N'IsActive') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] ON;
INSERT INTO [Departments] ([DepartmentId], [CreatedAt], [DeptName], [Description], [IsActive])
VALUES (1, '2025-07-22T04:20:50.1419718Z', N'Cardiology', N'Heart & vascular care', CAST(1 AS bit)),
(2, '2025-07-22T04:20:50.1419720Z', N'Orthopedics', N'Bones, joints & spine', CAST(1 AS bit)),
(3, '2025-07-22T04:20:50.1419722Z', N'Dermatology', N'Skin & hair', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentId', N'CreatedAt', N'DeptName', N'Description', N'IsActive') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'ContactNo', N'CreatedAt', N'Email', N'IsActive', N'PasswordHash', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [ContactNo], [CreatedAt], [Email], [IsActive], [PasswordHash], [Role])
VALUES ('11111111-1111-1111-1111-111111111111', N'9876543210', '2025-07-22T04:20:50.2170884Z', N'admin@hams.com', CAST(1 AS bit), N'AQAAAAIAAYagAAAAECaVhtvDOJZJN4ui03fOIRtdhGWyGfk8zafmn1Q1aX7ttuYiZ7/gr8igdmeKYZacWg==', N'Admin'),
('22222222-2222-2222-2222-222222222222', N'9123456780', '2025-07-22T04:20:50.2967891Z', N'reception@hams.com', CAST(1 AS bit), N'AQAAAAIAAYagAAAAECd+0C/LjQDFcTrjfeyfO+XPePC1SzTLnMxoSDWLdibyLmhFE8uSrK4q36/VqraPAA==', N'Receptionist');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'ContactNo', N'CreatedAt', N'Email', N'IsActive', N'PasswordHash', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

CREATE INDEX [IX_Appointments_DoctorId] ON [Appointments] ([DoctorId]);
GO

CREATE INDEX [IX_Appointments_PatientId] ON [Appointments] ([PatientId]);
GO

CREATE INDEX [IX_Doctors_DepartmentId] ON [Doctors] ([DepartmentId]);
GO

CREATE INDEX [IX_DoctorSchedules_DoctorId] ON [DoctorSchedules] ([DoctorId]);
GO

CREATE UNIQUE INDEX [IX_MedicalRecords_AppointmentId] ON [MedicalRecords] ([AppointmentId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250722042050_Init', N'8.0.18');
GO

COMMIT;
GO

