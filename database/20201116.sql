USE [master]
GO
/****** Object:  Database [N2_bd_prog]    Script Date: 16/11/2020 19:30:02 ******/
CREATE DATABASE [N2_bd_prog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'N2_bd_prog', FILENAME = N'C:\Users\lucal\N2_bd_prog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'N2_bd_prog_log', FILENAME = N'C:\Users\lucal\N2_bd_prog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [N2_bd_prog] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [N2_bd_prog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [N2_bd_prog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [N2_bd_prog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [N2_bd_prog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [N2_bd_prog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [N2_bd_prog] SET ARITHABORT OFF 
GO
ALTER DATABASE [N2_bd_prog] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [N2_bd_prog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [N2_bd_prog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [N2_bd_prog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [N2_bd_prog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [N2_bd_prog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [N2_bd_prog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [N2_bd_prog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [N2_bd_prog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [N2_bd_prog] SET  ENABLE_BROKER 
GO
ALTER DATABASE [N2_bd_prog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [N2_bd_prog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [N2_bd_prog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [N2_bd_prog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [N2_bd_prog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [N2_bd_prog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [N2_bd_prog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [N2_bd_prog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [N2_bd_prog] SET  MULTI_USER 
GO
ALTER DATABASE [N2_bd_prog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [N2_bd_prog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [N2_bd_prog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [N2_bd_prog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [N2_bd_prog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [N2_bd_prog] SET QUERY_STORE = OFF
GO
USE [N2_bd_prog]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [N2_bd_prog]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[exhibitions]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exhibitions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[room_id] [int] NOT NULL,
	[movie_id] [int] NOT NULL,
	[language] [varchar](150) NOT NULL,
	[dubbing] [varchar](50) NULL,
	[subtitle_lang] [varchar](50) NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[zip_code] [varchar](50) NOT NULL,
	[address] [varchar](150) NOT NULL,
	[number] [varchar](50) NULL,
	[neighborhood] [varchar](150) NULL,
	[city] [varchar](150) NOT NULL,
	[state] [varchar](50) NOT NULL,
	[country] [varchar](50) NOT NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movies]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[description] [text] NOT NULL,
	[type] [varchar](150) NOT NULL,
	[length] [varchar](50) NULL,
	[min_age] [int] NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payments]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](100) NOT NULL,
	[card_number] [varchar](50) NOT NULL,
	[parcels] [int] NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[requests]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[requests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[schedules_exhibition_id] [int] NOT NULL,
	[payment_id] [int] NOT NULL,
	[seat_number] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rooms]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rooms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[theater_id] [int] NOT NULL,
	[name] [varchar](150) NOT NULL,
	[seats] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[schedules_exhibition]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schedules_exhibition](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[exhibition_id] [int] NOT NULL,
	[value] [decimal](8, 2) NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[schedules_theater]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schedules_theater](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[theater_id] [int] NOT NULL,
	[day] [int] NOT NULL,
	[start_hour] [varchar](50) NOT NULL,
	[end_hour] [varchar](50) NOT NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[theaters]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[theaters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[description] [text] NOT NULL,
	[location_id] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 16/11/2020 19:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[password] [varchar](150) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[cpf] [varchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clients] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[exhibitions] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[locations] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[movies] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[payments] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[requests] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[roles] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[rooms] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[schedules_exhibition] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[schedules_theater] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[theaters] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[clients]  WITH CHECK ADD FOREIGN KEY([location_id])
REFERENCES [dbo].[locations] ([id])
GO
ALTER TABLE [dbo].[clients]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[exhibitions]  WITH CHECK ADD FOREIGN KEY([movie_id])
REFERENCES [dbo].[movies] ([id])
GO
ALTER TABLE [dbo].[exhibitions]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[rooms] ([id])
GO
ALTER TABLE [dbo].[requests]  WITH CHECK ADD FOREIGN KEY([payment_id])
REFERENCES [dbo].[payments] ([id])
GO
ALTER TABLE [dbo].[requests]  WITH CHECK ADD FOREIGN KEY([schedules_exhibition_id])
REFERENCES [dbo].[schedules_exhibition] ([id])
GO
ALTER TABLE [dbo].[requests]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[rooms]  WITH CHECK ADD FOREIGN KEY([theater_id])
REFERENCES [dbo].[theaters] ([id])
GO
ALTER TABLE [dbo].[schedules_exhibition]  WITH CHECK ADD FOREIGN KEY([exhibition_id])
REFERENCES [dbo].[exhibitions] ([id])
GO
ALTER TABLE [dbo].[schedules_theater]  WITH CHECK ADD FOREIGN KEY([theater_id])
REFERENCES [dbo].[theaters] ([id])
GO
ALTER TABLE [dbo].[theaters]  WITH CHECK ADD FOREIGN KEY([location_id])
REFERENCES [dbo].[locations] ([id])
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[payments]  WITH CHECK ADD CHECK  (([type]='Boleto' OR [type]='Cartão Débito' OR [type]='Cartão Crédito'))
GO
ALTER TABLE [dbo].[schedules_theater]  WITH CHECK ADD CHECK  (([day]=(7) OR [day]=(6) OR [day]=(5) OR [day]=(4) OR [day]=(3) OR [day]=(2) OR [day]=(1)))
GO
USE [master]
GO
ALTER DATABASE [N2_bd_prog] SET  READ_WRITE 
GO
