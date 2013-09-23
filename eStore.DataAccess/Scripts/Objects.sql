IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[Series]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Series];
GO
IF OBJECT_ID(N'[dbo].[Genres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genres];
GO

IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO

CREATE TABLE [dbo].[Genres] (
    [GenreId] int IDENTITY(1,1) primary key clustered,
    [Title] nvarchar(30) NOT NULL unique nonclustered,
    [Desc] nvarchar(200) NULL
);
GO

CREATE TABLE [dbo].[Authors] (
    [AuthorId] int IDENTITY(1,1) primary key clustered,
    [Name] nvarchar(200) NOT NULL unique nonclustered
);
GO

CREATE TABLE [dbo].[Series] (
    [SeriesId] int IDENTITY(1,1) primary key clustered,
    [GenreId] int NOT NULL references [dbo].[Genres](GenreId),
    [Title] nvarchar(30) NOT NULL unique nonclustered,
    [Desc] nvarchar(200) NULL
);
GO

CREATE TABLE [dbo].[Books] (
    [BookId] int IDENTITY(1,1) primary key clustered,
    [AuthorId] int NOT NULL references [dbo].[Authors](AuthorId),
    [GenreId] int NOT NULL references [dbo].[Genres](GenreId),
    [SeriesId] int NULL references [dbo].[Series](SeriesId),
    [Title] nvarchar(200) NOT NULL,
    [Price] float NOT NULL,
    [Year] smallint NOT NULL,
    [Pages] smallint NULL,
    [ISBN] varchar(20) NOT NULL,
    [Desc] nvarchar(max) NULL,
    [ImageFile] uniqueidentifier NULL
);
GO

CREATE TABLE [dbo].[Roles] (
    [RoleId] int IDENTITY(1,1) primary key clustered,
    [Name] nvarchar(15) NOT NULL unique nonclustered,
    [Desc] nvarchar(max) NOT NULL,
);
GO

CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) primary key clustered,
    [Name] nvarchar(10) NOT NULL unique nonclustered,
    [Password] nvarchar(12) NOT NULL,
    [Email] nvarchar(20) NULL,
    [RoleId] int NOT NULL references [dbo].[Roles](RoleId)
);
GO
