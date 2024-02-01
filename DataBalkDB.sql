USE [master]
GO
/****** Object:  Database [DataBalkDB]    Script Date: 2024/02/01 13:22:24 ******/
CREATE DATABASE [DataBalkDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataBalkDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLSERVER2022\MSSQL\DATA\DataBalkDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DataBalkDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLSERVER2022\MSSQL\DATA\DataBalkDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DataBalkDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataBalkDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataBalkDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataBalkDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataBalkDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataBalkDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataBalkDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataBalkDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataBalkDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataBalkDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataBalkDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataBalkDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataBalkDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataBalkDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataBalkDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataBalkDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataBalkDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataBalkDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataBalkDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataBalkDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataBalkDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataBalkDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataBalkDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataBalkDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataBalkDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DataBalkDB] SET  MULTI_USER 
GO
ALTER DATABASE [DataBalkDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataBalkDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataBalkDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataBalkDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DataBalkDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DataBalkDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataBalkDB', N'ON'
GO
ALTER DATABASE [DataBalkDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [DataBalkDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DataBalkDB]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[Assignee] [int] NULL,
	[DueDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Password] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD FOREIGN KEY([Assignee])
REFERENCES [dbo].[User] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[pr_CreateTask]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_CreateTask]
(
	@Title [varchar](50),
	@Description [varchar](200),
	@Assignee int,
	@DueDate [date] 
)
AS
BEGIN
	INSERT INTO [dbo].[Task](Title,Description,Assignee,DueDate) VALUES (@Title,@Description,@Assignee,@DueDate)
END
GO
/****** Object:  StoredProcedure [dbo].[pr_DeleteTask]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_DeleteTask]
(
	@TaskID [int]
)
AS
BEGIN
	DELETE FROM [dbo].[Task] WHERE [ID]=@TaskID
END
GO
/****** Object:  StoredProcedure [dbo].[pr_DeleteUser]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_DeleteUser]
(
	@UserID INT
)
AS
BEGIN
	DELETE FROM [dbo].[User] WHERE [ID]=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetActiveTask]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_GetActiveTask]
AS
BEGIN
	DECLARE @today DATETIME;
	SET @today=GETDATE();

	SELECT * FROM [dbo].[Task] WHERE [DueDate]>=@today
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAllTasks]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_GetAllTasks]
AS
BEGIN
	SELECT * FROM [dbo].[Task]
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAllUsers]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_GetAllUsers]
AS
BEGIN
	SELECT * FROM [dbo].[User]
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetExpiredTask]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_GetExpiredTask]
AS
BEGIN
	DECLARE @today DATETIME;
	SET @today=GETDATE();

	SELECT * FROM [dbo].[Task] WHERE [DueDate]<@today
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetTask]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_GetTask]
(@TaskID INT)
AS
BEGIN
	SELECT * FROM [dbo].[Task] WHERE [ID]=@TaskID
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetTaskByDate]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_GetTaskByDate]
(@Date DATETIME)
AS
BEGIN
	SELECT * FROM [dbo].[Task] WHERE [DueDate]=@Date
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetUser]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_GetUser]
(@UserID INT)
AS
BEGIN
	SELECT * FROM [dbo].[User] WHERE [ID]=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[pr_RegisterUser]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_RegisterUser]
(
	@Username [varchar](50) ,
	@Email [varchar](200) ,
	@Password [nvarchar](max)
)
AS
BEGIN
	INSERT INTO [dbo].[User](Username,Email,Password) VALUES (@Username,@Email,@Password)
END
GO
/****** Object:  StoredProcedure [dbo].[pr_UpdateTask]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_UpdateTask]
(
	@Title [varchar](50),
	@Description [varchar](200),
	@Assignee int,
	@DueDate [date] 
)
AS
BEGIN
	UPDATE [dbo].[Task] SET Title=@Title ,Description=@Description ,Assignee=@Assignee ,DueDate=@DueDate
END
GO
/****** Object:  StoredProcedure [dbo].[pr_UpdateUser]    Script Date: 2024/02/01 13:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_UpdateUser]
(
	@Username [varchar](50) ,
	@Email [varchar](200) ,
	@Password [nvarchar](max)
)
AS
BEGIN
	UPDATE [dbo].[User] SET Username=@Username,Email=@Email,Password=@Password
END
GO
USE [master]
GO
ALTER DATABASE [DataBalkDB] SET  READ_WRITE 
GO
