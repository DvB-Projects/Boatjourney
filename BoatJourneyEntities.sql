USE [master]
GO
/****** Object:  Database [BoatJourneyEntities]    Script Date: 4-11-2019 15:24:13 ******/
CREATE DATABASE [BoatJourneyEntities]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BoatJourneyEntities', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BoatJourneyEntities.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BoatJourneyEntities_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BoatJourneyEntities_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BoatJourneyEntities] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BoatJourneyEntities].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BoatJourneyEntities] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET ARITHABORT OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BoatJourneyEntities] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BoatJourneyEntities] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BoatJourneyEntities] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BoatJourneyEntities] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BoatJourneyEntities] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET RECOVERY FULL 
GO
ALTER DATABASE [BoatJourneyEntities] SET  MULTI_USER 
GO
ALTER DATABASE [BoatJourneyEntities] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BoatJourneyEntities] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BoatJourneyEntities] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BoatJourneyEntities] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BoatJourneyEntities] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BoatJourneyEntities', N'ON'
GO
USE [BoatJourneyEntities]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4-11-2019 15:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Address]    Script Date: 4-11-2019 15:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StreetName] [nvarchar](max) NOT NULL,
	[HouseNr] [int] NOT NULL,
	[ZipCodeId] [int] NULL,
 CONSTRAINT [PK_dbo.Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 4-11-2019 15:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[AddressId] [int] NULL,
 CONSTRAINT [PK_dbo.Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TravelOrganisers]    Script Date: 4-11-2019 15:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TravelOrganisers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOrganiser] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TravelOrganisers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Travels]    Script Date: 4-11-2019 15:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Travels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeTravel] [nvarchar](max) NULL,
	[TravelOrganiserId] [int] NULL,
	[BookingDate] [date] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_Travels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vessels]    Script Date: 4-11-2019 15:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vessels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfVessel] [nvarchar](max) NULL,
	[NameOfVessel] [nvarchar](max) NULL,
	[PassangerCapacity] [int] NOT NULL,
	[TravelId] [int] NULL,
 CONSTRAINT [PK_dbo.Vessels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zipcode]    Script Date: 4-11-2019 15:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zipcode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostCode] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Zipcode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_ZipCodeId]    Script Date: 4-11-2019 15:24:13 ******/
CREATE NONCLUSTERED INDEX [IX_ZipCodeId] ON [dbo].[Address]
(
	[ZipCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AddressId]    Script Date: 4-11-2019 15:24:13 ******/
CREATE NONCLUSTERED INDEX [IX_AddressId] ON [dbo].[Person]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TravelId]    Script Date: 4-11-2019 15:24:13 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TravelId] ON [dbo].[Vessels]
(
	[TravelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Address_dbo.Zipcode_ZipCodeId] FOREIGN KEY([ZipCodeId])
REFERENCES [dbo].[Zipcode] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_dbo.Address_dbo.Zipcode_ZipCodeId]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Person_dbo.Address_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_dbo.Person_dbo.Address_AddressId]
GO
ALTER TABLE [dbo].[Travels]  WITH CHECK ADD  CONSTRAINT [FK_Travels_dbo.TravelOrganisers_TravelOrgranisersId] FOREIGN KEY([TravelOrganiserId])
REFERENCES [dbo].[TravelOrganisers] ([Id])
GO
ALTER TABLE [dbo].[Travels] CHECK CONSTRAINT [FK_Travels_dbo.TravelOrganisers_TravelOrgranisersId]
GO
ALTER TABLE [dbo].[Travels]  WITH CHECK ADD  CONSTRAINT [FK_Travels_Travels] FOREIGN KEY([Id])
REFERENCES [dbo].[Travels] ([Id])
GO
ALTER TABLE [dbo].[Travels] CHECK CONSTRAINT [FK_Travels_Travels]
GO
ALTER TABLE [dbo].[Vessels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vessels_dbo.Travels_TravelId] FOREIGN KEY([TravelId])
REFERENCES [dbo].[Travels] ([Id])
GO
ALTER TABLE [dbo].[Vessels] CHECK CONSTRAINT [FK_dbo.Vessels_dbo.Travels_TravelId]
GO
ALTER TABLE [dbo].[Vessels]  WITH CHECK ADD  CONSTRAINT [FK_Vessels_Vessels] FOREIGN KEY([Id])
REFERENCES [dbo].[Vessels] ([Id])
GO
ALTER TABLE [dbo].[Vessels] CHECK CONSTRAINT [FK_Vessels_Vessels]
GO
USE [master]
GO
ALTER DATABASE [BoatJourneyEntities] SET  READ_WRITE 
GO
