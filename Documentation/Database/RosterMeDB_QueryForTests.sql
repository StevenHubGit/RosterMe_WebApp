/* ---------- Create Tables ---------- */
/*
CREATE TABLE [dbo].[Availability] (
    [AvailabilityId]    INT      NOT NULL,
    [EmployeeId]        INT      NOT NULL,
    [AvailableDate]     DATE     NOT NULL,
    [AvailableFromTime] TIME (7) NOT NULL,
    [AvailableToTime]   TIME (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([AvailabilityId] ASC)
);

CREATE TABLE [dbo].[BookedShifts] (
    [BookingId]  INT      NOT NULL,
    [ShiftId]    INT      NOT NULL,
    [EmployeeId] INT      NOT NULL,
    [BookedTime] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([BookingId] ASC)
);

CREATE TABLE [dbo].[Department] (
    [DeptId]   INT           NOT NULL,
    [DeptName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([DeptId] ASC)
);

CREATE TABLE [dbo].[Employees] (
    [EmployeeId]         INT            NOT NULL,
    [FirstName]          NVARCHAR (50)  NOT NULL,
    [LastName]           NVARCHAR (50)  NOT NULL,
    [Gender]             NVARCHAR (50)  NOT NULL,
    [ProfilePicture]     VARCHAR (MAX)  NULL,
    [DOB]                DATE           NOT NULL,
    [JoiningDate]        DATE           NOT NULL,
    [Position]           VARCHAR (50)   NOT NULL,
    [UserRole]           VARBINARY (50) NOT NULL,
    [PhoneNumber]        NUMERIC (18)   NOT NULL,
    [Email]              NVARCHAR (50)  NOT NULL,
    [Contract]           NVARCHAR (50)  NOT NULL,
    [ReportingManagerId] NVARCHAR (50)  NOT NULL,
    [DepartmentId]       NVARCHAR (50)  NOT NULL,
    [HourlySalary]       NUMERIC (18)   NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

CREATE TABLE [dbo].[Login] (
    [LoginId]    INT           NOT NULL,
    [EmployeeId] INT           NOT NULL,
    [Username]   NVARCHAR (50) NOT NULL,
    [Password]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([LoginId] ASC)
);

CREATE TABLE [dbo].[LoginTrail] (
    [LoginId]    INT      NOT NULL,
    [LogInTime]  TIME (7) NOT NULL,
    [LogOutTime] TIME (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([LoginId] ASC)
);

CREATE TABLE [dbo].[Shift] (
    [ShiftId]         INT           NOT NULL,
    [ShiftName]       NVARCHAR (50) NOT NULL,
    [StartTime]       TIME (7)      NOT NULL,
    [FinishTime]      TIME (7)      NOT NULL,
    [ShftCreatedDate] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([ShiftId] ASC)
);

CREATE TABLE [dbo].[ShiftInvitation] (
    [InvitationId]       INT           NOT NULL,
    [EmployeeId]         INT           NOT NULL,
    [ShiftId]            INT           NOT NULL,
    [InvitationStatus]   NVARCHAR (50) NOT NULL,
    [InvitationDate]     DATE          NOT NULL,
    [NotificationStatus] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([InvitationId] ASC)
);

CREATE TABLE [dbo].[TimeSheet] (
    [AttendanceId]   INT           NOT NULL,
    [EmployeeId]     INT           NOT NULL,
    [TimeIn]         TIME (7)      NOT NULL,
    [TimeOut]        TIME (7)      NOT NULL,
    [AttendanceDate] DATE          NOT NULL,
    [ShiftId]        INT           NOT NULL,
    [ApprovalStatus] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AttendanceId] ASC)
);
*/

/* ---------- Insert Queries ---------- */
/*
Insert Into dbo.BookedShifts (ShiftId, EmployeeId, BookedTime)
Values (2, 6, CURRENT_TIMESTAMP);
*/

/* ---------- Alter Queries ---------- */
DBCC CHECKIDENT(BookedShifts, RESEED, 0)


/* ---------- Delete Queries ---------- */


/* ---------- Update Queries ---------- */
/*
Update dbo.ShiftInvitation Set ShiftId = 1, InvitationStatus = 'Invited', InvitationDate = '2019-05-04', NotificationStatus = 'Sent'
Where EmployeeId = 7;
*/

/* ---------- Select Queries ---------- */
/*
Select EmployeeId, Count(InvitationId) As invitationCount From dbo.ShiftInvitation
Group By InvitationId, EmployeeId;
*/
Select LoginId, Sum(LoginTrailId) As loginTrailCount From dbo.LoginTrail
Group By LogInId, LoginTrailId;