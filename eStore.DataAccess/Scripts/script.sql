
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO

IF OBJECT_ID(N'[dbo].[Genres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genres];
GO

CREATE TABLE [dbo].[Genres] (
    [GenreId] int IDENTITY(1,1) primary key nonclustered,
    [Title] nvarchar(30) NOT NULL unique nonclustered,
    [Description] nvarchar(200) NULL
);
GO

IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO

CREATE TABLE [dbo].[Authors] (
    [AuthorId] int IDENTITY(1,1) primary key nonclustered,
    [Name] nvarchar(200) NOT NULL unique nonclustered
);
GO

CREATE TABLE [dbo].[Books] (
    [BookId] int IDENTITY(1,1) primary key nonclustered,
    [GenreId] int NOT NULL references [dbo].[Genres](GenreId),
    [AuthorId] int NOT NULL references [dbo].[Authors](AuthorId),
    [Title] nvarchar(200) NOT NULL,
    [Price] float NOT NULL
);
GO

/* DATA */

set IDENTITY_INSERT [dbo].[Genres] ON
GO
insert into [dbo].[Genres] ([GenreId], [Title]) values (1, 'Poetry')
go
insert into [dbo].[Genres] ([GenreId], [Title]) values (2, 'Arts & Design')
go
insert into [dbo].[Genres] ([GenreId], [Title]) values (3, 'History')
go
insert into [dbo].[Genres] ([GenreId], [Title]) values (4, 'Philosofy')
go
insert into [dbo].[Genres] ([GenreId], [Title]) values (5, 'Science & Technology')
go
insert into [dbo].[Genres] ([GenreId], [Title]) values (6, 'Kid''s reading')
go
insert into [dbo].[Genres] ([GenreId], [Title]) values (7, 'Fiction')
go
insert into [dbo].[Genres] ([GenreId], [Title]) values (8, 'Fantasy')
go
set IDENTITY_INSERT [dbo].[Genres] off
GO