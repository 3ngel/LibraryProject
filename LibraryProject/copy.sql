USE [master]
GO
/****** Object:  Database [Library]    Script Date: 16.05.2022 6:47:53 ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Users\user\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Users\user\Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Library] SET QUERY_STORE = OFF
GO
USE [Library]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Library]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[IdAuthor] [int] IDENTITY(1,1) NOT NULL,
	[FullNameAuthor] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[IdAuthor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BBK]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BBK](
	[IdBBK] [nchar](5) NOT NULL,
	[TitleBBK] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BBK] PRIMARY KEY CLUSTERED 
(
	[IdBBK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ISBN] [nchar](13) NOT NULL,
	[Author] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[BBK] [nchar](5) NOT NULL,
	[HousePublication] [int] NOT NULL,
	[IdCity] [int] NOT NULL,
	[YearOfPublication] [int] NOT NULL,
	[PageCounts] [int] NOT NULL,
	[BooksCount] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[IdCity] [int] IDENTITY(1,1) NOT NULL,
	[NameCity] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[IdCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extradition]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extradition](
	[IdReaderBillet] [nchar](8) NOT NULL,
	[IdBook] [nchar](13) NOT NULL,
	[DateOfIssue] [date] NOT NULL,
	[ReturnDate] [date] NOT NULL,
	[IdReader] [int] NOT NULL,
 CONSTRAINT [PK_Extradition] PRIMARY KEY CLUSTERED 
(
	[IdReaderBillet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Halls]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Halls](
	[IdHall] [int] NOT NULL,
	[NameHall] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Halls] PRIMARY KEY CLUSTERED 
(
	[IdHall] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HousePublication]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HousePublication](
	[IdHouse] [int] IDENTITY(1,1) NOT NULL,
	[NameHouse] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_HousePublication] PRIMARY KEY CLUSTERED 
(
	[IdHouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rank](
	[IdRank] [int] NOT NULL,
	[NameRank] [nchar](12) NOT NULL,
 CONSTRAINT [PK_Rank] PRIMARY KEY CLUSTERED 
(
	[IdRank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reader]    Script Date: 16.05.2022 6:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reader](
	[IdReader] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PatronymicName] [nvarchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Adress] [nvarchar](max) NOT NULL,
	[StudyOrWork] [nvarchar](max) NOT NULL,
	[NumberPhone] [nchar](11) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdRank] [int] NOT NULL,
	[Hall] [int] NOT NULL,
 CONSTRAINT [PK_Reader] PRIMARY KEY CLUSTERED 
(
	[IdReader] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([IdAuthor], [FullNameAuthor]) VALUES (1, N'Александр Сергеевич Пушкин')
INSERT [dbo].[Author] ([IdAuthor], [FullNameAuthor]) VALUES (2, N'Николай Василевич Гоголь')
INSERT [dbo].[Author] ([IdAuthor], [FullNameAuthor]) VALUES (3, N'Мария Громова')
INSERT [dbo].[Author] ([IdAuthor], [FullNameAuthor]) VALUES (4, N'А.М.Голова')
INSERT [dbo].[Author] ([IdAuthor], [FullNameAuthor]) VALUES (5, N'Лев Николаевич Толстой')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'1    ', N'Общенаучное и междисциплинарное знание
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'2    ', N'Естесвтенные науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'20   ', N'Естественные науки в целом
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'22   ', N'Физико-математические науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'24   ', N'Химические науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'26   ', N'Науки о Земле
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'28   ', N'Биологические науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'3    ', N'Техника. Технические науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'30   ', N'Техника и технические науки в целом
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'31   ', N'Энергетика
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'32   ', N'Радиоэлектроника
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'33   ', N'Горное дело
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'34   ', N'Технология металлов. Машиностроение. Приборостроение
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'35   ', N'Химическая технология. Химические производства
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'36   ', N'Пищевые производства
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'37   ', N'Технология древесины. Производства легкой промышленности. Домоводство. Бытовые услуги. Полиграфическое производство. Фотокинотехника
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'38   ', N'Строительство
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'39   ', N'Транспорт
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'4    ', N'Сельское и лесное хозяйство. Сельскохозяйственные и лесохозяйственные науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'5    ', N'Здравоохранение. Медицинские науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'6/8  ', N'Социальные (Общественные) и гуманитарные науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'60   ', N'Социальные науки в целом. Обществознание
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'63   ', N'История. Исторические науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'65   ', N'Экономика. Экономические науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'66   ', N'Политика. Политическая наука
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'67   ', N'Право. Юридические науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'68   ', N'Военное дело. Военная наука
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'7    ', N'Культура. Наука. Просвещение
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'71   ', N'Культура. Культурология
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'72   ', N'Наука. Науковедение
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'74   ', N'Образование. Педагогические науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'75   ', N'Физическая культура и спорт
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'76   ', N'Средства массовой информации. Книжное дело
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'77   ', N'Культурно-досуговая деятельность
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'78   ', N'Библиотечная, библиографическая и научно-информационная деятельность
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'79   ', N'Охрана памятников истории и культуры. Музейное дело. Выставочное дело. Архивное дело
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'80   ', N'Филологические науки в целом
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'80/84', N'Филологические науки. Художественная литература
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'81   ', N'Языкознание (лингвистика)
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'82   ', N'Фольклор. Фольклористика
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'83   ', N'Литературоведение
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'84   ', N'Художественная литература
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'85   ', N'Искусство. Искусствознание
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'85.03', N'История искусства
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'85.1 ', N'Изобразительное искусство и архитектура
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'85.3 ', N'Музыка и зрелищные искусства
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'85.7 ', N'Другие виды и формы искусства
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'86   ', N'Религия
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'86.2 ', N'Религия в целом. Религиоведение
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'86.3 ', N'Отдельные религии
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'86.4 ', N'Мистика. Магия. Эзотерика и оккультизм
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'86.7 ', N'Свободомыслие
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87   ', N'Философия
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.0 ', N'Философия в целом
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.1 ', N'Метафизика. Онтология
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.2 ', N'Гносеология (эпистемология). Философия науки
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.3 ', N'История философии
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.4 ', N'Логика
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.5 ', N'Философская антропология. Аксиология
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.6 ', N'Социальная философия
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.7 ', N'Этика
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'87.8 ', N'Эстетика
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'88   ', N'Психология
')
INSERT [dbo].[BBK] ([IdBBK], [TitleBBK]) VALUES (N'9    ', N'Литература универсального содержания
')
GO
INSERT [dbo].[Books] ([ISBN], [Author], [Title], [BBK], [HousePublication], [IdCity], [YearOfPublication], [PageCounts], [BooksCount]) VALUES (N'5-123-56411-8', 1, N'Евгений Онегин', N'84   ', 4, 2, 1822, 233, 9)
INSERT [dbo].[Books] ([ISBN], [Author], [Title], [BBK], [HousePublication], [IdCity], [YearOfPublication], [PageCounts], [BooksCount]) VALUES (N'5-123-56412-9', 2, N'Мёртвые души', N'84   ', 4, 3, 1824, 134, 23)
INSERT [dbo].[Books] ([ISBN], [Author], [Title], [BBK], [HousePublication], [IdCity], [YearOfPublication], [PageCounts], [BooksCount]) VALUES (N'5-300-01588-1', 3, N'Удивительный мир животных: певчие птицы', N'28   ', 11, 2, 1998, 127, 1)
INSERT [dbo].[Books] ([ISBN], [Author], [Title], [BBK], [HousePublication], [IdCity], [YearOfPublication], [PageCounts], [BooksCount]) VALUES (N'5-579-69047-1', 4, N'География энциклопедия', N'26   ', 12, 2, 1994, 127, 5)
INSERT [dbo].[Books] ([ISBN], [Author], [Title], [BBK], [HousePublication], [IdCity], [YearOfPublication], [PageCounts], [BooksCount]) VALUES (N'5-7519-0485-0', 4, N'История открытий', N'20   ', 12, 2, 1995, 150, 7)
INSERT [dbo].[Books] ([ISBN], [Author], [Title], [BBK], [HousePublication], [IdCity], [YearOfPublication], [PageCounts], [BooksCount]) VALUES (N'5-963-80432-0', 4, N'Наука энциклопедия', N'20   ', 12, 2, 1998, 125, 13)
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (1, N'Екатеринбург')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (2, N'Москва')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (3, N'Санкт-Петербург')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (4, N'Новосибирск')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (5, N'Берлин')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (6, N'Париж')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (7, N'Прага')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (8, N'Осло')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (9, N'Вашингтон')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (10, N'Нью-Йорк')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (11, N'Омск')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (12, N'Хургада')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (13, N'Каир')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (14, N'Дубай')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (15, N'Отто')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (16, N'Нью-Мексико')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (17, N'Бразилио')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (18, N'Астрахань')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (19, N'Владивосток')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (20, N'Сеул')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (21, N'Пекин')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (22, N'Шанхай')
INSERT [dbo].[City] ([IdCity], [NameCity]) VALUES (23, N'Токио')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
INSERT [dbo].[Extradition] ([IdReaderBillet], [IdBook], [DateOfIssue], [ReturnDate], [IdReader]) VALUES (N'А0007-22', N'5-7519-0485-0', CAST(N'2022-05-02' AS Date), CAST(N'2022-05-16' AS Date), 3)
INSERT [dbo].[Extradition] ([IdReaderBillet], [IdBook], [DateOfIssue], [ReturnDate], [IdReader]) VALUES (N'А0008-22', N'5-7519-0485-0', CAST(N'2022-05-02' AS Date), CAST(N'2022-05-16' AS Date), 3)
INSERT [dbo].[Extradition] ([IdReaderBillet], [IdBook], [DateOfIssue], [ReturnDate], [IdReader]) VALUES (N'О0003-22', N'5-300-01588-1', CAST(N'2022-04-12' AS Date), CAST(N'2022-04-26' AS Date), 4)
INSERT [dbo].[Extradition] ([IdReaderBillet], [IdBook], [DateOfIssue], [ReturnDate], [IdReader]) VALUES (N'Ч0001-22', N'5-123-56411-8', CAST(N'2022-04-05' AS Date), CAST(N'2022-04-19' AS Date), 2)
INSERT [dbo].[Extradition] ([IdReaderBillet], [IdBook], [DateOfIssue], [ReturnDate], [IdReader]) VALUES (N'Ч0005-22', N'5-579-69047-1', CAST(N'2022-05-02' AS Date), CAST(N'2022-05-16' AS Date), 2)
GO
INSERT [dbo].[Halls] ([IdHall], [NameHall]) VALUES (1, N'Абонимент')
INSERT [dbo].[Halls] ([IdHall], [NameHall]) VALUES (2, N'Читательский зал')
INSERT [dbo].[Halls] ([IdHall], [NameHall]) VALUES (3, N'читательский зал и абонимент')
GO
SET IDENTITY_INSERT [dbo].[HousePublication] ON 

INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (1, N'Аванта')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (2, N'Азбука')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (3, N'Арка')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (4, N'Белый город')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (5, N'Вильямс')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (6, N'Время')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (7, N'Дрофа')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (8, N'Захаров')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (9, N'Литера')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (10, N'Махаон')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (11, N'Time-Life films')
INSERT [dbo].[HousePublication] ([IdHouse], [NameHouse]) VALUES (12, N'Росмэн')
SET IDENTITY_INSERT [dbo].[HousePublication] OFF
GO
INSERT [dbo].[Rank] ([IdRank], [NameRank]) VALUES (1, N'Читатель    ')
INSERT [dbo].[Rank] ([IdRank], [NameRank]) VALUES (2, N'Библиотекарь')
INSERT [dbo].[Rank] ([IdRank], [NameRank]) VALUES (3, N'Админ       ')
GO
SET IDENTITY_INSERT [dbo].[Reader] ON 

INSERT [dbo].[Reader] ([IdReader], [LastName], [Name], [PatronymicName], [Birthday], [Adress], [StudyOrWork], [NumberPhone], [Login], [Password], [IdRank], [Hall]) VALUES (1, N'Панфилова', N'Ангелина', N'Олегвна', CAST(N'2003-06-02' AS Date), N'Екатеринбург, Чкаловский район', N'ЕМК', N'89827396250', N'3ngel', N'1568493AbC*', 3, 3)
INSERT [dbo].[Reader] ([IdReader], [LastName], [Name], [PatronymicName], [Birthday], [Adress], [StudyOrWork], [NumberPhone], [Login], [Password], [IdRank], [Hall]) VALUES (2, N'Попов', N'Арсений', N'Александрович', CAST(N'1990-08-16' AS Date), N'Москва, Центр', N'Библиотека', N'89827549288', N'Pups', N'123Ab*87', 2, 2)
INSERT [dbo].[Reader] ([IdReader], [LastName], [Name], [PatronymicName], [Birthday], [Adress], [StudyOrWork], [NumberPhone], [Login], [Password], [IdRank], [Hall]) VALUES (3, N'Рыбинской', N'Иван', N'Сергеевич', CAST(N'2002-05-12' AS Date), N'Екатеринбург, Вторчермет', N'УрФУ', N'89825673454', N'Fish', N'342SDnh?', 1, 1)
INSERT [dbo].[Reader] ([IdReader], [LastName], [Name], [PatronymicName], [Birthday], [Adress], [StudyOrWork], [NumberPhone], [Login], [Password], [IdRank], [Hall]) VALUES (4, N'Леунов', N'Кирилл', N'Александрович', CAST(N'2002-12-01' AS Date), N'Екатеринбург', N'ЕМК', N'89827396243', N'ReeLune', N'AmgysW4hm?6Gp', 2, 3)
INSERT [dbo].[Reader] ([IdReader], [LastName], [Name], [PatronymicName], [Birthday], [Adress], [StudyOrWork], [NumberPhone], [Login], [Password], [IdRank], [Hall]) VALUES (5, N'Иванов', N'Иван', N'Иванович', CAST(N'2000-01-01' AS Date), N'Екатеринбург', N'ЕМК', N'89123456789', N'MMMMM', N'1234Abb**', 1, 1)
SET IDENTITY_INSERT [dbo].[Reader] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Author] FOREIGN KEY([Author])
REFERENCES [dbo].[Author] ([IdAuthor])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Author]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_BBK] FOREIGN KEY([BBK])
REFERENCES [dbo].[BBK] ([IdBBK])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_BBK]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[City] ([IdCity])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_City]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_HousePublication] FOREIGN KEY([HousePublication])
REFERENCES [dbo].[HousePublication] ([IdHouse])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_HousePublication]
GO
ALTER TABLE [dbo].[Extradition]  WITH CHECK ADD  CONSTRAINT [FK_Extradition_Books] FOREIGN KEY([IdBook])
REFERENCES [dbo].[Books] ([ISBN])
GO
ALTER TABLE [dbo].[Extradition] CHECK CONSTRAINT [FK_Extradition_Books]
GO
ALTER TABLE [dbo].[Extradition]  WITH CHECK ADD  CONSTRAINT [FK_Extradition_Reader] FOREIGN KEY([IdReader])
REFERENCES [dbo].[Reader] ([IdReader])
GO
ALTER TABLE [dbo].[Extradition] CHECK CONSTRAINT [FK_Extradition_Reader]
GO
ALTER TABLE [dbo].[Reader]  WITH CHECK ADD  CONSTRAINT [FK_Reader_Halls] FOREIGN KEY([Hall])
REFERENCES [dbo].[Halls] ([IdHall])
GO
ALTER TABLE [dbo].[Reader] CHECK CONSTRAINT [FK_Reader_Halls]
GO
ALTER TABLE [dbo].[Reader]  WITH CHECK ADD  CONSTRAINT [FK_Reader_Rank] FOREIGN KEY([IdRank])
REFERENCES [dbo].[Rank] ([IdRank])
GO
ALTER TABLE [dbo].[Reader] CHECK CONSTRAINT [FK_Reader_Rank]
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
