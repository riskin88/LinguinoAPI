USE [master]
GO

/****** Object:  Database [linguino]    Script Date: 5/3/2024 12:14:04 PM ******/
CREATE DATABASE [linguino]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'linguino', FILENAME = N'/var/opt/mssql/data/linguino.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'linguino_log', FILENAME = N'/var/opt/mssql/data/linguino_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [linguino] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [linguino].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [linguino] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [linguino] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [linguino] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [linguino] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [linguino] SET ARITHABORT OFF 
GO
ALTER DATABASE [linguino] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [linguino] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [linguino] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [linguino] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [linguino] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [linguino] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [linguino] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [linguino] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [linguino] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [linguino] SET  DISABLE_BROKER 
GO
ALTER DATABASE [linguino] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [linguino] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [linguino] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [linguino] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [linguino] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [linguino] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [linguino] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [linguino] SET RECOVERY FULL 
GO
ALTER DATABASE [linguino] SET  MULTI_USER 
GO
ALTER DATABASE [linguino] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [linguino] SET DB_CHAINING OFF 
GO
ALTER DATABASE [linguino] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [linguino] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [linguino] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [linguino] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'linguino', N'ON'
GO
ALTER DATABASE [linguino] SET QUERY_STORE = ON
GO
ALTER DATABASE [linguino] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [linguino]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/3/2024 12:14:04 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Streak] [bigint] NULL,
	[Balance] [bigint] NULL,
	[AccountInitialized] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[LastSessionDate] [date] NULL,
	[DailyGoalMs] [bigint] NULL,
	[Name] [nvarchar](max) NULL,
	[Level] [int] NOT NULL,
	[ProfileImageUrl] [nvarchar](max) NULL,
	[Xp] [bigint] NOT NULL,
	[SelectedCourseId] [bigint] NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpirationDate] [datetime2](7) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Language1] [nvarchar](max) NOT NULL,
	[Language2] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ThumbnailUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exercise]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercise](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LessonItemId] [bigint] NULL,
	[RepeatAudioExercise_TextL2] [nvarchar](max) NULL,
	[ShortListeningExercise_TextL2] [nvarchar](max) NULL,
	[BlankCellCoords] [nvarchar](max) NULL,
	[BlankIndexes] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](34) NOT NULL,
	[Explanation] [nvarchar](max) NULL,
	[TextExercise_TextL1] [nvarchar](max) NULL,
	[TextExercise_TextL2] [nvarchar](max) NULL,
	[TextExercise_TextL2AudioUrl] [nvarchar](max) NULL,
	[ReadingExercise_ImageUrl] [nvarchar](max) NULL,
	[TextL1] [nvarchar](max) NULL,
	[TextL2] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Options] [nvarchar](max) NULL,
	[TextL2AudioUrl] [nvarchar](max) NULL,
	[TableRows] [nvarchar](max) NULL,
	[WordL1] [nvarchar](max) NULL,
	[WordL2] [nvarchar](max) NULL,
	[TextExercise_ImageUrl] [nvarchar](max) NULL,
	[WordL2AudioUrl] [nvarchar](max) NULL,
	[EstimatedTimeMs] [bigint] NOT NULL,
	[AnswerL2] [nvarchar](max) NULL,
	[Article] [nvarchar](max) NULL,
	[AssignmentTopicL2] [nvarchar](max) NULL,
	[AudioUrl] [nvarchar](max) NULL,
	[FillInSentenceExercise_ImageUrl] [nvarchar](max) NULL,
	[Letters] [nvarchar](max) NULL,
	[ListeningExercise_ImageUrl] [nvarchar](max) NULL,
	[ListeningExercise_QuestionL2] [nvarchar](max) NULL,
	[QuestionL2] [nvarchar](max) NULL,
	[Questions] [nvarchar](max) NULL,
	[ReadAloudExercise_ImageUrl] [nvarchar](max) NULL,
	[ReadAloudExercise_TextL2] [nvarchar](max) NULL,
	[ReadingExercise_AnswerL2] [nvarchar](max) NULL,
	[ReadingExercise_QuestionL2] [nvarchar](max) NULL,
	[RepeatAudioExercise_AudioUrl] [nvarchar](max) NULL,
	[TimeMs] [int] NULL,
 CONSTRAINT [PK_Exercise] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Following]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Following](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FollowerId] [nvarchar](450) NOT NULL,
	[FolloweeId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Following] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LearningStat]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LearningStat](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Points] [bigint] NOT NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_LearningStat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LearningStep]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LearningStep](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ToInterval] [int] NOT NULL,
	[LessonItemId] [bigint] NULL,
	[ExercisesInSession] [int] NOT NULL,
 CONSTRAINT [PK_LearningStep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LearningStepExercise]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LearningStepExercise](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LearningStepId] [bigint] NOT NULL,
	[ExerciseId] [bigint] NOT NULL,
 CONSTRAINT [PK_LearningStepExercise] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Type] [int] NULL,
	[Level] [int] NULL,
	[CourseId] [bigint] NULL,
	[AuthorId] [nvarchar](450) NULL,
	[IsCustom] [bit] NOT NULL,
	[BackgroundImageUrl] [nvarchar](max) NULL,
	[VideoId] [nvarchar](max) NULL,
	[OrderOnMap] [float] NULL,
	[ItemsTotal] [bigint] NOT NULL,
	[Icon] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonFeedback]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonFeedback](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_LessonFeedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonItem]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Discriminator] [nvarchar](13) NOT NULL,
	[AudioUrl] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[NameL1] [nvarchar](max) NULL,
	[NameL2] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_LessonItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonItemLesson]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonItemLesson](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LessonItemId] [bigint] NOT NULL,
	[LessonId] [bigint] NOT NULL,
	[OrderInLesson] [float] NULL,
 CONSTRAINT [PK_LessonItemLesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StripeCustomerId] [nvarchar](max) NULL,
	[StripeSubscriptionId] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ThumbnailUrl] [nvarchar](max) NULL,
	[IsFeatured] [bit] NOT NULL,
	[Category] [int] NULL,
	[CourseId] [bigint] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[LessonsTotal] [bigint] NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TopicLesson]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopicLesson](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TopicId] [bigint] NOT NULL,
	[LessonId] [bigint] NOT NULL,
 CONSTRAINT [PK_TopicLesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCourse]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCourse](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[CourseId] [bigint] NOT NULL,
	[SelectedLessonId] [bigint] NULL,
 CONSTRAINT [PK_UserCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLesson]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLesson](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[LessonId] [bigint] NOT NULL,
	[ItemsDone] [bigint] NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[IsFavorite] [bit] NOT NULL,
	[FeedbackId] [bigint] NULL,
	[IsLearned] [bit] NOT NULL,
 CONSTRAINT [PK_UserLesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLessonItem]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLessonItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[LessonItemId] [bigint] NOT NULL,
	[IsFavorite] [bit] NOT NULL,
	[Repetitions] [int] NOT NULL,
	[Interval] [int] NOT NULL,
	[Easiness] [float] NOT NULL,
	[DateToReview] [date] NULL,
	[ItemState] [int] NOT NULL,
 CONSTRAINT [PK_UserLessonItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTopic]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTopic](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[TopicId] [bigint] NOT NULL,
	[LessonsActive] [bigint] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_UserTopic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WordExample]    Script Date: 5/3/2024 12:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordExample](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TextL1] [nvarchar](max) NOT NULL,
	[TextL2] [nvarchar](max) NOT NULL,
	[AudioUrl] [nvarchar](max) NULL,
	[WordId] [bigint] NULL,
 CONSTRAINT [PK_WordExample] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240318134557_init', N'8.0.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240323165403_subscription', N'8.0.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240323174430_subscription2', N'8.0.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240328193158_remove_userCourse_isSelected', N'8.0.2')
GO


INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3cf4378a-3fca-45d5-8782-db69e9bd5259', N'USER', N'USER', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7521910b-749d-4fbd-bf8e-dfddb9aa4fd6', N'ADMIN', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd05744d9-00ed-4cb8-8224-eb1e4abf31ba', N'PREMIUM_USER', N'PREMIUM_USER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', N'3cf4378a-3fca-45d5-8782-db69e9bd5259')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b5810e9d-77a2-475f-bb9d-403e022d19ee', N'7521910b-749d-4fbd-bf8e-dfddb9aa4fd6')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Streak], [Balance], [AccountInitialized], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [LastSessionDate], [DailyGoalMs], [Name], [Level], [ProfileImageUrl], [Xp], [SelectedCourseId], [RefreshToken], [RefreshTokenExpirationDate]) VALUES (N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 0, 0, 1, N'pepik', N'PEPIK', N'pepa@okurka', N'PEPA@OKURKA', 1, N'AQAAAAIAAYagAAAAEO0i1n2fIZVp7zlEIxeD3o1XvB5YvCuiUc7QFZcwyUe1lRLxi9T+q1N8D562YO2KRw==', N'7KIJ66EHIMJDLAX2B5WCO5J7JVZPHG4W', N'e1290360-bfab-4896-bfb1-ac46c718d7b9', NULL, 0, 0, NULL, 1, 0, NULL, 200000, N'Pepino', 1, NULL, 0, 1, N'0595F9BC3D5DC0C5D69E398FE891E3D90A8C4A5A1FD8F0936BDD230B29A6879E', CAST(N'2024-05-06T08:23:58.3486739' AS DateTime2))
GO
INSERT [dbo].[AspNetUsers] ([Id], [Streak], [Balance], [AccountInitialized], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [LastSessionDate], [DailyGoalMs], [Name], [Level], [ProfileImageUrl], [Xp], [SelectedCourseId], [RefreshToken], [RefreshTokenExpirationDate]) VALUES (N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 0, 0, 1, N'karlos', N'KARLOS', N'karlos@karlito.cz', N'KARLOS@KARLITO.CZ', 1, N'AQAAAAIAAYagAAAAEKCvIwS83T5Nm1P/pXtsG7NJWAke6JBq8fysAjB+CdV7b/pp2SzwlvXqxsyrTSc0Qw==', N'WTKTV7QIESE75U5YUNWV5BK2XIZZ3RAU', N'9020b851-86ae-4573-a4e1-b232f1d77dc5', NULL, 0, 0, NULL, 1, 0, NULL, 200000, N'Boza Novaku', 1, NULL, 0, 1, N'C0EFC92F6794DFCE1FBC4273AF9031AD4B2C9D9DB2F90603D30CE94999280591', CAST(N'2024-03-27T17:30:31.7357066' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([Id], [Language1], [Language2], [Name], [ThumbnailUrl]) VALUES (1, N'cs', N'en', N'Anglictina', N'string')
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Exercise] ON 
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (2, 1, NULL, NULL, NULL, NULL, N'TextExercise', N'string', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'string', N'string', N'string', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (3, 1, NULL, NULL, NULL, NULL, N'TextExercise', N'string', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'string', N'string', N'string', 1000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (6, 1, NULL, NULL, N'0,0|1,1', NULL, N'FillInTableExercise', NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL, NULL, N'string,string2|str,str2', NULL, NULL, NULL, NULL, 100000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (10003, 1, N'string', NULL, NULL, NULL, N'RepeatAudioExercise', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (10004, 1, NULL, NULL, NULL, NULL, N'SpeechExercise', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10000, NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, NULL, N'tvoje,mama', NULL, NULL, NULL, NULL, NULL, 1000000)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (20003, 1, NULL, NULL, NULL, NULL, N'SpeechExercise', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 100000, NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (20004, 10004, NULL, NULL, NULL, NULL, N'SpeechExercise', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 100000, NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (20005, 20002, NULL, N'string', NULL, NULL, N'ShortListeningExercise', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, 100000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (20006, 20002, N'string', NULL, NULL, NULL, N'RepeatAudioExercise', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 70000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (20007, 20003, N'string', NULL, NULL, NULL, N'RepeatAudioExercise', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 40000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (20008, 20003, NULL, NULL, NULL, NULL, N'ReadingExercise', NULL, NULL, NULL, NULL, N'string', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 60000, NULL, N'string', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'string', NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Id], [LessonItemId], [RepeatAudioExercise_TextL2], [ShortListeningExercise_TextL2], [BlankCellCoords], [BlankIndexes], [Discriminator], [Explanation], [TextExercise_TextL1], [TextExercise_TextL2], [TextExercise_TextL2AudioUrl], [ReadingExercise_ImageUrl], [TextL1], [TextL2], [ImageUrl], [Options], [TextL2AudioUrl], [TableRows], [WordL1], [WordL2], [TextExercise_ImageUrl], [WordL2AudioUrl], [EstimatedTimeMs], [AnswerL2], [Article], [AssignmentTopicL2], [AudioUrl], [FillInSentenceExercise_ImageUrl], [Letters], [ListeningExercise_ImageUrl], [ListeningExercise_QuestionL2], [QuestionL2], [Questions], [ReadAloudExercise_ImageUrl], [ReadAloudExercise_TextL2], [ReadingExercise_AnswerL2], [ReadingExercise_QuestionL2], [RepeatAudioExercise_AudioUrl], [TimeMs]) VALUES (30003, 10004, NULL, NULL, NULL, NULL, N'ListeningExercise', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 50000, N'string', NULL, NULL, N'string', NULL, NULL, N'string', N'string', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Exercise] OFF
GO
SET IDENTITY_INSERT [dbo].[Following] ON 
GO
INSERT [dbo].[Following] ([Id], [FollowerId], [FolloweeId]) VALUES (2, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', N'b5810e9d-77a2-475f-bb9d-403e022d19ee')
GO
SET IDENTITY_INSERT [dbo].[Following] OFF
GO
SET IDENTITY_INSERT [dbo].[LearningStat] ON 
GO
INSERT [dbo].[LearningStat] ([Id], [Date], [Points], [UserId]) VALUES (1, CAST(N'2024-03-15' AS Date), 3, N'b5810e9d-77a2-475f-bb9d-403e022d19ee')
GO
SET IDENTITY_INSERT [dbo].[LearningStat] OFF
GO
SET IDENTITY_INSERT [dbo].[LearningStep] ON 
GO
INSERT [dbo].[LearningStep] ([Id], [ToInterval], [LessonItemId], [ExercisesInSession]) VALUES (3, 1, 1, 2)
GO
INSERT [dbo].[LearningStep] ([Id], [ToInterval], [LessonItemId], [ExercisesInSession]) VALUES (10002, 6, 1, 2)
GO
INSERT [dbo].[LearningStep] ([Id], [ToInterval], [LessonItemId], [ExercisesInSession]) VALUES (20002, 1, 10004, 1)
GO
SET IDENTITY_INSERT [dbo].[LearningStep] OFF
GO
SET IDENTITY_INSERT [dbo].[LearningStepExercise] ON 
GO
INSERT [dbo].[LearningStepExercise] ([Id], [LearningStepId], [ExerciseId]) VALUES (2, 3, 10003)
GO
INSERT [dbo].[LearningStepExercise] ([Id], [LearningStepId], [ExerciseId]) VALUES (3, 3, 2)
GO
INSERT [dbo].[LearningStepExercise] ([Id], [LearningStepId], [ExerciseId]) VALUES (4, 3, 3)
GO
INSERT [dbo].[LearningStepExercise] ([Id], [LearningStepId], [ExerciseId]) VALUES (10003, 10002, 6)
GO
INSERT [dbo].[LearningStepExercise] ([Id], [LearningStepId], [ExerciseId]) VALUES (10004, 10002, 10004)
GO
INSERT [dbo].[LearningStepExercise] ([Id], [LearningStepId], [ExerciseId]) VALUES (20002, 20002, 20004)
GO
SET IDENTITY_INSERT [dbo].[LearningStepExercise] OFF
GO
SET IDENTITY_INSERT [dbo].[Lesson] ON 
GO
INSERT [dbo].[Lesson] ([Id], [Name], [Description], [Type], [Level], [CourseId], [AuthorId], [IsCustom], [BackgroundImageUrl], [VideoId], [OrderOnMap], [ItemsTotal], [Icon]) VALUES (1, N'string', N'string', 1, 5, 1, NULL, 0, NULL, NULL, 1, 1, NULL)
GO
INSERT [dbo].[Lesson] ([Id], [Name], [Description], [Type], [Level], [CourseId], [AuthorId], [IsCustom], [BackgroundImageUrl], [VideoId], [OrderOnMap], [ItemsTotal], [Icon]) VALUES (2, N'nazev', N'popis', 0, NULL, 1, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 1, NULL, NULL, NULL, 3, NULL)
GO
INSERT [dbo].[Lesson] ([Id], [Name], [Description], [Type], [Level], [CourseId], [AuthorId], [IsCustom], [BackgroundImageUrl], [VideoId], [OrderOnMap], [ItemsTotal], [Icon]) VALUES (10002, N'string2', N'string', 1, 0, 1, NULL, 0, NULL, NULL, 2, 1, NULL)
GO
INSERT [dbo].[Lesson] ([Id], [Name], [Description], [Type], [Level], [CourseId], [AuthorId], [IsCustom], [BackgroundImageUrl], [VideoId], [OrderOnMap], [ItemsTotal], [Icon]) VALUES (20002, N'string', N'string', 1, 0, 1, NULL, 0, NULL, NULL, 3, 1, NULL)
GO
INSERT [dbo].[Lesson] ([Id], [Name], [Description], [Type], [Level], [CourseId], [AuthorId], [IsCustom], [BackgroundImageUrl], [VideoId], [OrderOnMap], [ItemsTotal], [Icon]) VALUES (30002, N'slovicka', N'string', 0, 2, 1, NULL, 0, NULL, NULL, 4, 4, NULL)
GO
SET IDENTITY_INSERT [dbo].[Lesson] OFF
GO
SET IDENTITY_INSERT [dbo].[LessonItem] ON 
GO
INSERT [dbo].[LessonItem] ([Id], [Discriminator], [AudioUrl], [Description], [ImageUrl], [NameL1], [NameL2], [Type]) VALUES (1, N'LessonItem', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[LessonItem] ([Id], [Discriminator], [AudioUrl], [Description], [ImageUrl], [NameL1], [NameL2], [Type]) VALUES (10002, N'LessonItem', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[LessonItem] ([Id], [Discriminator], [AudioUrl], [Description], [ImageUrl], [NameL1], [NameL2], [Type]) VALUES (10003, N'LessonItem', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[LessonItem] ([Id], [Discriminator], [AudioUrl], [Description], [ImageUrl], [NameL1], [NameL2], [Type]) VALUES (10004, N'Word', N'https://www.chosic.com/wp-content/uploads/2021/02/Monkeys-Spinning-Monkeys.mp3', NULL, N'https://picsum.photos/id/168/512/512', N'jablko', N'apple', 0)
GO
INSERT [dbo].[LessonItem] ([Id], [Discriminator], [AudioUrl], [Description], [ImageUrl], [NameL1], [NameL2], [Type]) VALUES (20002, N'Word', NULL, NULL, NULL, N'hruska', N'pear', 0)
GO
INSERT [dbo].[LessonItem] ([Id], [Discriminator], [AudioUrl], [Description], [ImageUrl], [NameL1], [NameL2], [Type]) VALUES (20003, N'Word', NULL, NULL, NULL, N'kokos', N'coconut', 0)
GO
INSERT [dbo].[LessonItem] ([Id], [Discriminator], [AudioUrl], [Description], [ImageUrl], [NameL1], [NameL2], [Type]) VALUES (30002, N'Word', N'string', N'string', N'string', N'banan', N'banana', 0)
GO
SET IDENTITY_INSERT [dbo].[LessonItem] OFF
GO
SET IDENTITY_INSERT [dbo].[LessonItemLesson] ON 
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (3, 10004, 2, 1)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (10002, 10002, 10002, 1)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (30002, 10003, 20002, 1)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (30004, 10004, 30002, 2)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (30005, 20002, 30002, 3)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (30006, 20003, 30002, 1)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (30007, 20002, 2, 2)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (50002, 20003, 2, NULL)
GO
INSERT [dbo].[LessonItemLesson] ([Id], [LessonItemId], [LessonId], [OrderInLesson]) VALUES (60003, 30002, 30002, 0)
GO
SET IDENTITY_INSERT [dbo].[LessonItemLesson] OFF
GO
SET IDENTITY_INSERT [dbo].[Topic] ON 
GO
INSERT [dbo].[Topic] ([Id], [Name], [ThumbnailUrl], [IsFeatured], [Category], [CourseId], [IsDefault], [LessonsTotal]) VALUES (1, N'string', N'string', 1, 0, 1, 0, 2)
GO
INSERT [dbo].[Topic] ([Id], [Name], [ThumbnailUrl], [IsFeatured], [Category], [CourseId], [IsDefault], [LessonsTotal]) VALUES (2, N'string2', N'string', 0, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Topic] OFF
GO
SET IDENTITY_INSERT [dbo].[TopicLesson] ON 
GO
INSERT [dbo].[TopicLesson] ([Id], [TopicId], [LessonId]) VALUES (2, 1, 1)
GO
INSERT [dbo].[TopicLesson] ([Id], [TopicId], [LessonId]) VALUES (10002, 2, 10002)
GO
INSERT [dbo].[TopicLesson] ([Id], [TopicId], [LessonId]) VALUES (10003, 1, 10002)
GO
SET IDENTITY_INSERT [dbo].[TopicLesson] OFF
GO
SET IDENTITY_INSERT [dbo].[UserCourse] ON 
GO
INSERT [dbo].[UserCourse] ([Id], [UserId], [CourseId], [SelectedLessonId]) VALUES (10002, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 1, NULL)
GO
INSERT [dbo].[UserCourse] ([Id], [UserId], [CourseId], [SelectedLessonId]) VALUES (20002, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 1, 30002)
GO
SET IDENTITY_INSERT [dbo].[UserCourse] OFF
GO
SET IDENTITY_INSERT [dbo].[UserLesson] ON 
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (20003, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 1, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (20004, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 10002, 0, 1, 0, NULL, 0)
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (20005, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 20002, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (30003, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 2, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (30004, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 30002, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (40003, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 1, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (40004, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 10002, 0, 1, 0, NULL, 0)
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (40005, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 20002, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[UserLesson] ([Id], [UserId], [LessonId], [ItemsDone], [IsVisible], [IsFavorite], [FeedbackId], [IsLearned]) VALUES (40006, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 30002, 0, 0, 0, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[UserLesson] OFF
GO
SET IDENTITY_INSERT [dbo].[UserLessonItem] ON 
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (1, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 1, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (10002, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 10004, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (10004, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 20002, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (10005, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 20003, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (20002, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 10002, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (20003, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 10003, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (30002, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 1, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (30003, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 10002, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (30004, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 10003, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (30005, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 10004, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (30006, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 20002, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (30007, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 20003, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (40002, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 30002, 0, 0, 0, 2.5, NULL, 0)
GO
INSERT [dbo].[UserLessonItem] ([Id], [UserId], [LessonItemId], [IsFavorite], [Repetitions], [Interval], [Easiness], [DateToReview], [ItemState]) VALUES (40003, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 30002, 0, 0, 0, 2.5, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[UserLessonItem] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTopic] ON 
GO
INSERT [dbo].[UserTopic] ([Id], [UserId], [TopicId], [LessonsActive], [IsEnabled]) VALUES (20002, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 1, 0, 0)
GO
INSERT [dbo].[UserTopic] ([Id], [UserId], [TopicId], [LessonsActive], [IsEnabled]) VALUES (20003, N'b5810e9d-77a2-475f-bb9d-403e022d19ee', 2, 1, 1)
GO
INSERT [dbo].[UserTopic] ([Id], [UserId], [TopicId], [LessonsActive], [IsEnabled]) VALUES (30002, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 1, 0, 0)
GO
INSERT [dbo].[UserTopic] ([Id], [UserId], [TopicId], [LessonsActive], [IsEnabled]) VALUES (30003, N'dc547010-bb4f-4bfc-9fc3-fb63fba0687d', 2, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[UserTopic] OFF
GO
SET IDENTITY_INSERT [dbo].[WordExample] ON 
GO
INSERT [dbo].[WordExample] ([Id], [TextL1], [TextL2], [AudioUrl], [WordId]) VALUES (1, N'ja rad banan', N'i like banana', N'string', 30002)
GO
SET IDENTITY_INSERT [dbo].[WordExample] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_SelectedCourseId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_SelectedCourseId] ON [dbo].[AspNetUsers]
(
	[SelectedCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Exercise_LessonItemId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Exercise_LessonItemId] ON [dbo].[Exercise]
(
	[LessonItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Following_FolloweeId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Following_FolloweeId] ON [dbo].[Following]
(
	[FolloweeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Following_FollowerId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Following_FollowerId] ON [dbo].[Following]
(
	[FollowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_LearningStat_UserId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_LearningStat_UserId] ON [dbo].[LearningStat]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LearningStep_LessonItemId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_LearningStep_LessonItemId] ON [dbo].[LearningStep]
(
	[LessonItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LearningStepExercise_ExerciseId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_LearningStepExercise_ExerciseId] ON [dbo].[LearningStepExercise]
(
	[ExerciseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LearningStepExercise_LearningStepId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_LearningStepExercise_LearningStepId] ON [dbo].[LearningStepExercise]
(
	[LearningStepId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Lesson_AuthorId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Lesson_AuthorId] ON [dbo].[Lesson]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lesson_CourseId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Lesson_CourseId] ON [dbo].[Lesson]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LessonItemLesson_LessonId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_LessonItemLesson_LessonId] ON [dbo].[LessonItemLesson]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LessonItemLesson_LessonItemId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_LessonItemLesson_LessonItemId] ON [dbo].[LessonItemLesson]
(
	[LessonItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Subscription_UserId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Subscription_UserId] ON [dbo].[Subscription]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Topic_CourseId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Topic_CourseId] ON [dbo].[Topic]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TopicLesson_LessonId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_TopicLesson_LessonId] ON [dbo].[TopicLesson]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TopicLesson_TopicId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_TopicLesson_TopicId] ON [dbo].[TopicLesson]
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserCourse_CourseId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserCourse_CourseId] ON [dbo].[UserCourse]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserCourse_SelectedLessonId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserCourse_SelectedLessonId] ON [dbo].[UserCourse]
(
	[SelectedLessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserCourse_UserId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserCourse_UserId] ON [dbo].[UserCourse]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserLesson_FeedbackId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLesson_FeedbackId] ON [dbo].[UserLesson]
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserLesson_LessonId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLesson_LessonId] ON [dbo].[UserLesson]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLesson_UserId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLesson_UserId] ON [dbo].[UserLesson]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserLessonItem_LessonItemId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLessonItem_LessonItemId] ON [dbo].[UserLessonItem]
(
	[LessonItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLessonItem_UserId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLessonItem_UserId] ON [dbo].[UserLessonItem]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserTopic_TopicId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserTopic_TopicId] ON [dbo].[UserTopic]
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserTopic_UserId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserTopic_UserId] ON [dbo].[UserTopic]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WordExample_WordId]    Script Date: 5/3/2024 12:14:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_WordExample_WordId] ON [dbo].[WordExample]
(
	[WordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [Level]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [Xp]
GO
ALTER TABLE [dbo].[Exercise] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [EstimatedTimeMs]
GO
ALTER TABLE [dbo].[LearningStep] ADD  DEFAULT ((0)) FOR [ExercisesInSession]
GO
ALTER TABLE [dbo].[Lesson] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsCustom]
GO
ALTER TABLE [dbo].[Lesson] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [ItemsTotal]
GO
ALTER TABLE [dbo].[LessonItem] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Subscription] ADD  DEFAULT (N'') FOR [UserId]
GO
ALTER TABLE [dbo].[Topic] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDefault]
GO
ALTER TABLE [dbo].[Topic] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [LessonsTotal]
GO
ALTER TABLE [dbo].[UserLesson] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsLearned]
GO
ALTER TABLE [dbo].[UserLessonItem] ADD  DEFAULT ((0)) FOR [ItemState]
GO
ALTER TABLE [dbo].[UserTopic] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Course_SelectedCourseId] FOREIGN KEY([SelectedCourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Course_SelectedCourseId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD  CONSTRAINT [FK_Exercise_LessonItem_LessonItemId] FOREIGN KEY([LessonItemId])
REFERENCES [dbo].[LessonItem] ([Id])
GO
ALTER TABLE [dbo].[Exercise] CHECK CONSTRAINT [FK_Exercise_LessonItem_LessonItemId]
GO
ALTER TABLE [dbo].[Following]  WITH CHECK ADD  CONSTRAINT [FK_Following_AspNetUsers_FolloweeId] FOREIGN KEY([FolloweeId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Following] CHECK CONSTRAINT [FK_Following_AspNetUsers_FolloweeId]
GO
ALTER TABLE [dbo].[Following]  WITH CHECK ADD  CONSTRAINT [FK_Following_AspNetUsers_FollowerId] FOREIGN KEY([FollowerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Following] CHECK CONSTRAINT [FK_Following_AspNetUsers_FollowerId]
GO
ALTER TABLE [dbo].[LearningStat]  WITH CHECK ADD  CONSTRAINT [FK_LearningStat_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[LearningStat] CHECK CONSTRAINT [FK_LearningStat_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[LearningStep]  WITH CHECK ADD  CONSTRAINT [FK_LearningStep_LessonItem_LessonItemId] FOREIGN KEY([LessonItemId])
REFERENCES [dbo].[LessonItem] ([Id])
GO
ALTER TABLE [dbo].[LearningStep] CHECK CONSTRAINT [FK_LearningStep_LessonItem_LessonItemId]
GO
ALTER TABLE [dbo].[LearningStepExercise]  WITH CHECK ADD  CONSTRAINT [FK_LearningStepExercise_Exercise_ExerciseId] FOREIGN KEY([ExerciseId])
REFERENCES [dbo].[Exercise] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LearningStepExercise] CHECK CONSTRAINT [FK_LearningStepExercise_Exercise_ExerciseId]
GO
ALTER TABLE [dbo].[LearningStepExercise]  WITH CHECK ADD  CONSTRAINT [FK_LearningStepExercise_LearningStep_LearningStepId] FOREIGN KEY([LearningStepId])
REFERENCES [dbo].[LearningStep] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LearningStepExercise] CHECK CONSTRAINT [FK_LearningStepExercise_LearningStep_LearningStepId]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_AspNetUsers_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_AspNetUsers_AuthorId]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Course_CourseId]
GO
ALTER TABLE [dbo].[LessonItemLesson]  WITH CHECK ADD  CONSTRAINT [FK_LessonItemLesson_Lesson_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lesson] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LessonItemLesson] CHECK CONSTRAINT [FK_LessonItemLesson_Lesson_LessonId]
GO
ALTER TABLE [dbo].[LessonItemLesson]  WITH CHECK ADD  CONSTRAINT [FK_LessonItemLesson_LessonItem_LessonItemId] FOREIGN KEY([LessonItemId])
REFERENCES [dbo].[LessonItem] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LessonItemLesson] CHECK CONSTRAINT [FK_LessonItemLesson_LessonItem_LessonItemId]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_Course_CourseId]
GO
ALTER TABLE [dbo].[TopicLesson]  WITH CHECK ADD  CONSTRAINT [FK_TopicLesson_Lesson_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lesson] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TopicLesson] CHECK CONSTRAINT [FK_TopicLesson_Lesson_LessonId]
GO
ALTER TABLE [dbo].[TopicLesson]  WITH CHECK ADD  CONSTRAINT [FK_TopicLesson_Topic_TopicId] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topic] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TopicLesson] CHECK CONSTRAINT [FK_TopicLesson_Topic_TopicId]
GO
ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_UserCourse_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_UserCourse_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_UserCourse_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_UserCourse_Course_CourseId]
GO
ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_UserCourse_Lesson_SelectedLessonId] FOREIGN KEY([SelectedLessonId])
REFERENCES [dbo].[Lesson] ([Id])
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_UserCourse_Lesson_SelectedLessonId]
GO
ALTER TABLE [dbo].[UserLesson]  WITH CHECK ADD  CONSTRAINT [FK_UserLesson_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLesson] CHECK CONSTRAINT [FK_UserLesson_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserLesson]  WITH CHECK ADD  CONSTRAINT [FK_UserLesson_Lesson_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lesson] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLesson] CHECK CONSTRAINT [FK_UserLesson_Lesson_LessonId]
GO
ALTER TABLE [dbo].[UserLesson]  WITH CHECK ADD  CONSTRAINT [FK_UserLesson_LessonFeedback_FeedbackId] FOREIGN KEY([FeedbackId])
REFERENCES [dbo].[LessonFeedback] ([Id])
GO
ALTER TABLE [dbo].[UserLesson] CHECK CONSTRAINT [FK_UserLesson_LessonFeedback_FeedbackId]
GO
ALTER TABLE [dbo].[UserLessonItem]  WITH CHECK ADD  CONSTRAINT [FK_UserLessonItem_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLessonItem] CHECK CONSTRAINT [FK_UserLessonItem_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserLessonItem]  WITH CHECK ADD  CONSTRAINT [FK_UserLessonItem_LessonItem_LessonItemId] FOREIGN KEY([LessonItemId])
REFERENCES [dbo].[LessonItem] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLessonItem] CHECK CONSTRAINT [FK_UserLessonItem_LessonItem_LessonItemId]
GO
ALTER TABLE [dbo].[UserTopic]  WITH CHECK ADD  CONSTRAINT [FK_UserTopic_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTopic] CHECK CONSTRAINT [FK_UserTopic_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserTopic]  WITH CHECK ADD  CONSTRAINT [FK_UserTopic_Topic_TopicId] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topic] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTopic] CHECK CONSTRAINT [FK_UserTopic_Topic_TopicId]
GO
ALTER TABLE [dbo].[WordExample]  WITH CHECK ADD  CONSTRAINT [FK_WordExample_LessonItem_WordId] FOREIGN KEY([WordId])
REFERENCES [dbo].[LessonItem] ([Id])
GO
ALTER TABLE [dbo].[WordExample] CHECK CONSTRAINT [FK_WordExample_LessonItem_WordId]
GO
USE [master]
GO
ALTER DATABASE [linguino] SET  READ_WRITE 
GO
