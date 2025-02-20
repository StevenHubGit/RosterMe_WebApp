USE [master]
GO
/****** Object:  Database [RosterMeDB]    Script Date: 22/10/2019 9:34:03 PM ******/
CREATE DATABASE [RosterMeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RosterMeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RosterMeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RosterMeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RosterMeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RosterMeDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RosterMeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RosterMeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RosterMeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RosterMeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RosterMeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RosterMeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RosterMeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RosterMeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RosterMeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RosterMeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RosterMeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RosterMeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RosterMeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RosterMeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RosterMeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RosterMeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RosterMeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RosterMeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RosterMeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RosterMeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RosterMeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RosterMeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RosterMeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RosterMeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RosterMeDB] SET  MULTI_USER 
GO
ALTER DATABASE [RosterMeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RosterMeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RosterMeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RosterMeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RosterMeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RosterMeDB] SET QUERY_STORE = OFF
GO
USE [RosterMeDB]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[ShiftName] [nvarchar](50) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[FinishTime] [time](7) NOT NULL,
	[ShftCreatedDate] [date] NOT NULL,
 CONSTRAINT [PK__Shift__C0A83881DC9EFE99] PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Login__4DDA2818F85EE918] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookedShifts]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookedShifts](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[ShiftId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[BookedTime] [datetime] NOT NULL,
 CONSTRAINT [PK__BookedSh__73951AED5267B2FF] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[ProfilePicture] [varchar](max) NULL,
	[DOB] [date] NOT NULL,
	[JoiningDate] [date] NOT NULL,
	[Position] [varchar](50) NOT NULL,
	[UserRole] [varchar](20) NOT NULL,
	[PhoneNumber] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Contract] [nvarchar](50) NOT NULL,
	[ReportingManagerId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[HourlySalary] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Availability]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Availability](
	[AvailabilityId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[AvailableDate] [date] NOT NULL,
	[AvailableFromTime] [datetime] NOT NULL,
	[AvailableToTime] [datetime] NOT NULL,
 CONSTRAINT [PK__Availabi__DA3979B109536BA5] PRIMARY KEY CLUSTERED 
(
	[AvailabilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginTrail]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTrail](
	[LoginTrailId] [int] IDENTITY(1,1) NOT NULL,
	[LogInId] [int] NULL,
	[LogInTime] [datetime2](7) NOT NULL,
	[LogOutTime] [datetime2](7) NULL,
 CONSTRAINT [PK__LoginTra__4DDA2818ADB13837] PRIMARY KEY CLUSTERED 
(
	[LoginTrailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AdminDataForEmployees]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AdminDataForEmployees]
AS
SELECT        dbo.Employees.FirstName, dbo.Employees.LastName
FROM            dbo.LoginTrail INNER JOIN
                         dbo.Login ON dbo.LoginTrail.LogInId = dbo.Login.LoginId LEFT OUTER JOIN
                         dbo.Availability LEFT OUTER JOIN
                         dbo.Shift INNER JOIN
                         dbo.BookedShifts ON dbo.Shift.ShiftId = dbo.BookedShifts.ShiftId LEFT OUTER JOIN
                         dbo.Employees ON dbo.BookedShifts.EmployeeId = dbo.Employees.EmployeeId ON dbo.Availability.EmployeeId = dbo.Employees.EmployeeId ON dbo.Login.EmployeeId = dbo.Employees.EmployeeId
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DeptId] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Departme__014881AE27E74209] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShiftInvitation]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShiftInvitation](
	[InvitationId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ShiftId] [int] NOT NULL,
	[InvitationStatus] [nvarchar](50) NOT NULL,
	[InvitationDate] [date] NOT NULL,
	[NotificationStatus] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__ShiftInv__033C8DCF0657DB03] PRIMARY KEY CLUSTERED 
(
	[InvitationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSheet]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSheet](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[TimeIn] [time](7) NOT NULL,
	[TimeOut] [time](7) NOT NULL,
	[AttendanceDate] [date] NOT NULL,
	[ShiftId] [int] NOT NULL,
	[ApprovalStatus] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__TimeShee__8B69261CFFFD9E39] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AdminDashboardData]    Script Date: 22/10/2019 9:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AdminDashboardData] 
	-- Declare variables
	--Int employeeID =
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Select query
SELECT *
FROM dbo.LoginTrail 

INNER JOIN
dbo.Login ON dbo.LoginTrail.LogInId = dbo.Login.LoginId 

LEFT OUTER JOIN
dbo.Availability 

LEFT OUTER JOIN
dbo.Shift 

INNER JOIN
dbo.BookedShifts ON dbo.Shift.ShiftId = dbo.BookedShifts.ShiftId 

LEFT OUTER JOIN
dbo.Employees ON dbo.BookedShifts.EmployeeId = dbo.Employees.EmployeeId 
ON dbo.Availability.EmployeeId = dbo.Employees.EmployeeId 
ON dbo.Login.EmployeeId = dbo.Employees.EmployeeId

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Shift"
            Begin Extent = 
               Top = 136
               Left = 697
               Bottom = 266
               Right = 872
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LoginTrail"
            Begin Extent = 
               Top = 0
               Left = 602
               Bottom = 130
               Right = 772
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Login"
            Begin Extent = 
               Top = 0
               Left = 384
               Bottom = 126
               Right = 554
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employees"
            Begin Extent = 
               Top = 0
               Left = 0
               Bottom = 130
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BookedShifts"
            Begin Extent = 
               Top = 128
               Left = 428
               Bottom = 258
               Right = 598
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Availability"
            Begin Extent = 
               Top = 143
               Left = 202
               Bottom = 273
               Right = 393
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 15' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AdminDataForEmployees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'00
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AdminDataForEmployees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AdminDataForEmployees'
GO
USE [master]
GO
ALTER DATABASE [RosterMeDB] SET  READ_WRITE 
GO
