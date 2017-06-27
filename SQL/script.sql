USE [master]
GO
/****** Object:  Database [EthanOllinsBattleships2017]    Script Date: 6/27/2017 2:17:18 PM ******/
CREATE DATABASE [EthanOllinsBattleships2017]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EthanOllinsBattleships2017', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EthanOllinsBattleships2017.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EthanOllinsBattleships2017_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EthanOllinsBattleships2017_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EthanOllinsBattleships2017].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET ARITHABORT OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET  MULTI_USER 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [EthanOllinsBattleships2017]
GO
/****** Object:  User [EthanOllinsAppUser]    Script Date: 6/27/2017 2:17:18 PM ******/
CREATE USER [EthanOllinsAppUser] FOR LOGIN [EthanOllinsAppUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [EthanOllins]    Script Date: 6/27/2017 2:17:18 PM ******/
CREATE USER [EthanOllins] FOR LOGIN [EthanOllins] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [AaronOpell]    Script Date: 6/27/2017 2:17:18 PM ******/
CREATE USER [AaronOpell] FOR LOGIN [AaronOpell] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [EthanOllins]
GO
ALTER ROLE [db_owner] ADD MEMBER [AaronOpell]
GO
/****** Object:  UserDefinedFunction [dbo].[assignCells]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[assignCells] (@GridID int, @x int, @y int, @status char(1))
returns int
as begin
	declare @test int;
	set @test = (select top 1 CellID from Cells where X = @x and Y = @y and GridID = @GridID)

	if exists (select * from Cells where X = @x and Y = @y and GridID = @GridID)
	begin
		return 1
	end
	else
	begin
		return 0
	end

	return 0
end

GO
/****** Object:  Table [dbo].[Cells]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cells](
	[GridID] [int] NULL,
	[X] [int] NOT NULL,
	[Y] [int] NOT NULL,
	[Status] [varchar](1) NOT NULL,
	[CellID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Cells] PRIMARY KEY CLUSTERED 
(
	[CellID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Games]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[RoomID] [int] NOT NULL,
	[Grid] [varchar](max) NOT NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grids]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grids](
	[GridID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Grids] PRIMARY KEY CLUSTERED 
(
	[GridID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[Host] [int] NOT NULL,
	[Guest] [int] NULL,
	[Status] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[P1Ready] [int] NOT NULL,
	[P2Ready] [int] NOT NULL,
	[HostGridID] [int] NULL,
	[GuestGridID] [int] NULL,
	[Turn] [int] NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ships]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ships](
	[GridID] [int] NOT NULL,
	[StartCoordinates] [varchar](50) NOT NULL,
	[EndCoordinates] [varchar](50) NOT NULL,
	[HitCoordinates] [varchar](50) NOT NULL,
	[Sunk] [int] NOT NULL,
 CONSTRAINT [PK_Ships] PRIMARY KEY CLUSTERED 
(
	[GridID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[Counts]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Counts]
as
SELECT Status, count(1) as 'Count' FROM Cells 
GROUP by Status
GO
/****** Object:  View [dbo].[HostList]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[HostList]
AS

select Users.UserID
, Users.Name AS Username
, Rooms.RoomID
, Rooms.Name AS RoomName
from Users
JOIN Rooms
ON Users.UserID = Rooms.Host

GO
ALTER TABLE [dbo].[Cells]  WITH CHECK ADD  CONSTRAINT [FK_Cells_Grids] FOREIGN KEY([GridID])
REFERENCES [dbo].[Grids] ([GridID])
GO
ALTER TABLE [dbo].[Cells] CHECK CONSTRAINT [FK_Cells_Grids]
GO
ALTER TABLE [dbo].[Grids]  WITH CHECK ADD  CONSTRAINT [FK_Grids_Rooms1] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Rooms] ([RoomID])
GO
ALTER TABLE [dbo].[Grids] CHECK CONSTRAINT [FK_Grids_Rooms1]
GO
ALTER TABLE [dbo].[Grids]  WITH CHECK ADD  CONSTRAINT [FK_Grids_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Grids] CHECK CONSTRAINT [FK_Grids_Users]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Grids] FOREIGN KEY([HostGridID])
REFERENCES [dbo].[Grids] ([GridID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Grids]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Grids1] FOREIGN KEY([GuestGridID])
REFERENCES [dbo].[Grids] ([GridID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Grids1]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Grids2] FOREIGN KEY([HostGridID])
REFERENCES [dbo].[Grids] ([GridID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Grids2]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Grids3] FOREIGN KEY([GuestGridID])
REFERENCES [dbo].[Grids] ([GridID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Grids3]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Users] FOREIGN KEY([Host])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Users]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Users1] FOREIGN KEY([Guest])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Users1]
GO
/****** Object:  StoredProcedure [dbo].[usp_addGuest]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_addGuest] @Username varchar(50), @RoomID int
AS

--create new user as guest
insert into Users values (@Username, 1)
--set user id in rooms table
declare @userID int
set @UserID = (select top 1 UserID from Users where Name = @Username)
update Rooms set Guest = @UserID, Status = 1 where RoomID = @RoomID
--create new grid for host
declare @HostID int
set @HostID = (select top 1 Host from Rooms where RoomID = @RoomID)
insert into Grids values (@RoomID, @HostID)
--assign gridID
declare @gridID int
set @gridID = (select top 1 GridID from Grids where UserID = @HostID)
--create new grid for guest
insert into Grids values (@RoomID, @userID)
--assign gridID
declare @guestGridID int
set @guestGridID = (select top 1 GridID from Grids where UserID = @userID)

update Rooms set HostGridID = @gridID, GuestGridID = @guestGridID where RoomID = @RoomID
GO
/****** Object:  StoredProcedure [dbo].[usp_addHost]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_addHost] @Username varchar(50), @RoomName varchar(50)
AS
insert into Users values (@Username, 0)
DECLARE @UserID int
SET @UserID = (SELECT TOP 1 UserID FROM Users WHERE Name = @Username)
insert into Rooms values (@UserID, NULL, 0, @RoomName, 0, 0, NULL, NULL)
GO
/****** Object:  StoredProcedure [dbo].[usp_addShip]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_addShip] @UserID int, @RoomID int, @GridID int, @CellID int, @Orientation int, @Length int
as
declare @OriginX int;
set @OriginX = (select top 1 X from Cells where @CellID = CellID)
declare @OriginY int;
set @OriginY = (select top 1 Y from Cells where @CellID = CellID)

declare @status varchar(1)

if (@Length = 5)
	set @status = 'B'
else if (@Length = 4)
	set @status = 'C'
else if (@Length = 3)
	set @status = 'D'
else if (@Length = 2)
	set @status = 'E'

declare @test int;
set @test = (select top 1 CellID from Cells where X = @OriginX and Y = @OriginY and GridID = @GridID)

	select 'Sauce'
	declare @count int = 0;
	while (@count < @Length)
	begin
		declare @result int
		set @result = dbo.assignCells(@GridID, @OriginX, @OriginY, @status)
		if (@result = 0)
			insert into Cells values(@GridID, @OriginX, @OriginY, @status)
		else if (@result = 1) 
			update Cells set Status = @status where CellID = @test and GridID = @GridID

		if (@Orientation = 0)
			set @OriginY = @OriginY + 1
		if (@Orientation = 1)
			set @OriginX = @OriginX + 1
		if (@Orientation = 2)
			set @OriginY = @OriginY - 1
		if (@Orientation = 3)
			set @OriginX = @OriginX -1
		
		set @count = @count + 1

		select @result as 'Result', @OriginY as 'Y', @count as 'Count'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_assignCell]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_assignCell] @GridID int, @x int, @y int, @status varchar(1)
as
declare @test int;
set @test = (select top 1 CellID from Cells where X = @x and Y = @y and GridID = @GridID)

if exists (select * from Cells where X = @x and Y = @y and GridID = @GridID)
begin
	update Cells set Status = @Status where CellID = @test and GridID = @GridID
end
else
begin
	insert into Cells values(@GridID, @x, @y, @status)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_Attack]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Attack] @RoomID int, @x int, @y int
as
declare @turn2 int = (select Turn from Rooms where RoomID = @RoomID)
declare @AttackerGrid int
declare @ReceiverGrid int
if (@turn2 = 0)
begin
	set @AttackerGrid = (select HostGridID from Rooms where @RoomID = RoomID)
	set @ReceiverGrid = (select GuestGridID from Rooms where @RoomID = RoomID)
end
else
begin
	set @AttackerGrid = (select GuestGridID from Rooms where @RoomID = RoomID)
	set @ReceiverGrid = (select HostGridID from Rooms where @RoomID = RoomID)
end

declare @cellID int = (select CellID from Cells where GridID = @ReceiverGrid and X = @x and Y = @y)
print @cellID
declare @cellStatus char(1) = (select Status from Cells where CellID = @cellID)

if (@cellStatus = 'A')
	update Cells set Status = 'a' where CellID = @cellID
else if (@cellStatus = 'B')
	update Cells set Status = 'c' where CellID = @cellID

declare @count int = (select Count from Counts where Status = 'C')
print(@count)

declare @turn int = (select Turn from Rooms where RoomID = @RoomID)
if (@turn = 0)
	update Rooms set Turn = 1 where RoomID = @RoomID
else if (@turn = 1)
	update Rooms set Turn = 0 where RoomID = @RoomID

if (@count = 15)
begin
	update Rooms set Status = 3 where RoomID = @RoomID
	return
end

GO
/****** Object:  StoredProcedure [dbo].[usp_insertCell]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_insertCell] @GridID int, @x int, @y int, @status varchar(1)
as
insert into Cells values (@GridID, @x, @y, @status)
GO
/****** Object:  StoredProcedure [dbo].[usp_toggleReady]    Script Date: 6/27/2017 2:17:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_toggleReady] @RoomID int, @PlayerType int
as
if (@PlayerType = 0)
	update Rooms set P1Ready = 1 where RoomID = @RoomID
else
	update Rooms set P2Ready = 1 where RoomID = @RoomID

declare @p1ready int = (select P1Ready from Rooms where RoomID = @RoomID)
declare @p2ready int = (select P2Ready from Rooms where RoomID = @RoomID)
if (@p1ready = 1 and @p2ready = 1)
	update Rooms set Turn = 0 where RoomID = @RoomID
	update Rooms set Status = 2 where RoomID = @RoomID
GO
USE [master]
GO
ALTER DATABASE [EthanOllinsBattleships2017] SET  READ_WRITE 
GO
