IF OBJECT_ID(N'[dbo].[Genres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genres];
GO

CREATE TABLE [dbo].[Genres] (
    [GenreId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(30) NOT NULL,
    [Description] nvarchar(200) NULL
);
GO