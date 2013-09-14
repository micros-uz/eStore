
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO

IF OBJECT_ID(N'[dbo].[Genres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genres];
GO

IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO

IF OBJECT_ID(N'[dbo].[Series]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Series];
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
insert into [dbo].[Genres] ([GenreId], [Title]) values (9, 'Computer Science')
go
set IDENTITY_INSERT [dbo].[Genres] off
GO

set IDENTITY_INSERT [dbo].[Authors] on
go
insert into [dbo].[Authors] ([AuthorId], [Name]) values (1, N'Эспозито Д.')
go
insert into [dbo].[Authors] ([AuthorId], [Name]) values (2, N'Руссинович М.')
go
insert into [dbo].[Authors] ([AuthorId], [Name]) values (3, N'Дж. Рихтер')
go
insert into [dbo].[Authors] ([AuthorId], [Name]) values (4, N'Таненбаум Э. С.')
go
insert into [dbo].[Authors] ([AuthorId], [Name]) values (5, N'Лафоре Р.')
go
insert into [dbo].[Authors] ([AuthorId], [Name]) values (6, N'Паттерсон Д.')
go
insert into [dbo].[Authors] ([AuthorId], [Name]) values (7, N'Хейлсберг А.')
go
insert into [dbo].[Authors] ([AuthorId], [Name]) values (8, N'Уайт Т.')
go
set IDENTITY_INSERT [dbo].[Authors] off
go

set IDENTITY_INSERT [dbo].[Series] on
go
insert into [dbo].[Series] ([SeriesId], [Title]) values (1, N'Классика computer science')
go
insert into [dbo].[Series] ([SeriesId], [Title]) values (2, N'Мастер-класс') 
go
insert into [dbo].[Series] ([SeriesId], [Title]) values (2, N'Бестселлеры O''Reilly') 
go
set IDENTITY_INSERT [dbo].[Series] off
go

set IDENTITY_INSERT [dbo].[Roles] on
go
insert into [dbo].[Roles] ([RoleId], [Name], [Desc]) values (1, 'Administrators', 'Have full access')
go
insert into [dbo].[Roles] ([RoleId], [Name], [Desc]) values (2, 'Managers', 'Have full access to the store')
go
set IDENTITY_INSERT [dbo].[Roles] off
go

set IDENTITY_INSERT [dbo].[Users] on
go
insert into [dbo].[Users] ([UserId], [Name], [Password], [RoleId]) values (1, 'admin', '123', 1)
go
insert into [dbo].[Users] ([UserId], [Name], [Password], [RoleId]) values (2, 'manager', '111', 2)
go

set IDENTITY_INSERT [dbo].[Users] off
go

set IDENTITY_INSERT [dbo].[Books] on
go
insert into [dbo].[Books] ([BookId], [AuthorId], [GenreId], [SeriesId],[Title], [Price], [Year], [Pages], [ISBN], [Desc], [ImageFile])
values (1, 1, 9, 2, N'Программирование с использованием Microsoft ASP.NET 4', 1531, 2012, 880, '978-5-459-00346-8',
N'Эта книга представляет собой наиболее полное руководство по Microsoft ASP.NET, полностью переработанное под версию ASP.NET 4. Вы узнаете обо всех возможностях данной технологии, в частности об использовании тем, мастеров и шаблонов страниц, применении динамических данных для построения и настройки веб-приложений, а также о работе с Microsoft Silverlight и ASP.NET MVC. Особое внимание уделяется рассмотрению внутренних механизмов и конфигурации ASP.NET, jQuery, AJAX и паттернов проектирования.',
'E91CF33E-609D-428A-9F16-49428959913D')
go
insert into [dbo].[Books] ([BookId], [AuthorId], [GenreId], [SeriesId], [Title], [Price], [Year], [Pages], [ISBN], [Desc], [ImageFile])
values (2, 2, 9, 2, N'Внутреннее устройство Microsoft Windows. 6-е изд.', 1313, 2013, 800, '978-5-496-00434-3',
N'Шестое издание этой легендарной книги посвящено внутреннему устройству и алгоритмам работы основных компонентов операционной системы Microsoft Windows 7, а также Windows Server 2008 R2. Определяются ключевые понятия и термины Windows, дается представление об инструментальных средствах, используемых для исследования внутреннего устройства системы, рассматривается общая архитектура и компоненты ОС. Также в книге дается представление о ключевых основополагающих системных и управляющих механизмах Windows.', 
'3B39B25C-6F4A-45E3-8CE5-F761ABA79C00')
go
insert into [dbo].[Books] ([BookId], [AuthorId], [GenreId], [SeriesId], [Title], [Price], [Year], [Pages], [ISBN], [Desc], [ImageFile])
values (3, 3, 9, 2, N'CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд.', 1238, 2013, 896, '978-5-496-00433-6',
N'Четвертое издание книги, написанной признанным экспертом в области программирования Джеффри Рихтером и уже ставшей классикой, полностью обновлено в соответствии со спецификацией платформы .NET Framework 4.5, а также среды Visual Studio 2012 и C# 5.0.', 
'1D14544D-C0DA-4AE3-AF05-01B5761C6E98')
go
insert into [dbo].[Books] ([BookId], [AuthorId], [GenreId], [SeriesId], [Title], [Price], [Year], [Pages], [ISBN], [Desc], [ImageFile])
values (4, 4, 9, 1, N'Компьютерные сети. 5-е изд.', 1238, 2012, 960, '978-5-4461-0068-2',
N'Перед вами — очередное, пятое издание самой авторитетной книги по современным сетевым технологиям, написанной признанным экспертом в этой области Эндрю Таненбаумом в соавторстве с профессором Вашингтонского университета Дэвидом Уэзероллом. Первая версия этого классического труда появилась на свет в далеком 1980 году, и с тех пор каждое издание книги неизменно становилось бестселлером и использовалось в качестве базового учебника в ведущих технических вузах. В книге последовательно изложены основные концепции, определяющие современное состояние и тенденции развития компьютерных сетей. Авторы подробнейшим образом объясняют устройство и принципы работы аппаратного и программного обеспечения, рассматривают все аспекты и уровни организации сетей — от физического до уровня прикладных программ. Изложение теоретических принципов дополняется яркими, показательными примерами функционирования Интернета и компьютерных сетей различного типа. Пятое издание полностью переработано с учетом изменений, происшедших в сфере сетевых технологий за последние годы и, в частности, освещает такие аспекты, как беспроводные сети стандарта 802.12 и 802.16, сети 3G, технология RFID, инфраструктура доставки контента CDN, пиринговые сети, потоковое вещание, интернет-телефония и многое другое.', 
'AB91E937-9C01-4C74-B9FB-ADD1D2645899')
go
insert into [dbo].[Books] ([BookId], [AuthorId], [GenreId], [SeriesId], [Title], [Price], [Year], [Pages], [ISBN], [Desc], [ImageFile])
values (5, 5, 9, 1, N'Объектно-ориентированное программирование в С++. ', 844, 2013, 928, '978-5-496-00353-7',
N'Благодаря этой книге тысячи пользователей овладели технологией объектно-ориентированного программирования в С++. В ней есть все: основные принципы языка, готовые полномасштабные приложения, небольшие примеры, поясняющие теорию, и множество полезных иллюстраций. Книга пользуется стабильным успехом в учебных заведениях благодаря тому, что содержит более 100 упражнений, позволяющих проверить знания по всем темам. Читатель может вообще не иметь подготовки в области языка С++. Необходимо лишь знание начальных основ программирования.', 
'6FB151FE-9BA2-470E-B846-558A0AAA5D46')
go
insert into [dbo].[Books] ([BookId], [AuthorId], [GenreId], [SeriesId], [Title], [Price], [Year], [Pages], [ISBN], [Desc], [ImageFile])
values (6, 6, 9, 1, N'Архитектура компьютера и проектирование компьютерных систем.', 856, 2011, 784, '978-5-459-00291-1',
N'Книга, выходящая уже в 4-м издании, посвящена структурной организации компьютера и отражает революционные изменения, происходящие в области аппаратного обеспечения, в частности стремительный переход от однопроцессорных систем к многоядерным микропроцессорам. В издании подробно описывается архитектура компьютера и устройство всех его компонентов: процессоров, блоков памяти, средств ввода-вывода и хранения данных. Отличительной особенностью книги является демонстрация взаимодействий между аппаратными средствами и системным программным обеспечением. Особое внимание уделяется многоядерным вычислительным системам и параллельному программированию. Многочисленные упражнения и задачи, приводимые после каждой темы, помогают закрепить материал. Книга рассчитана на широкий круг читателей: от студентов, изучающих компьютерные технологии, до опытных разработчиков, которые хотят освоить современные концепции многопроцессорного программирования. ', 
'D3A38E79-28A2-4D93-AF56-2BD85A416B6F')
go
insert into [dbo].[Books] ([BookId], [AuthorId], [GenreId], [SeriesId], [Title], [Price], [Year], [Pages], [ISBN], [Desc], [ImageFile])
values (7, 7, 9, 1, N'Язык программирования C#', 1188, 2011, 784, '978-5-459-00283-6',
N'Перед вами — четвертое издание главной книги по языку C#, написанной легендой программирования — Андерсом Хейлсбергом, архитектором C#, Delphi и Turbo Pascal, совместно с другими специалистами, входившими в группу разработчиков C# компании Microsoft. Издание является наиболее полным описанием языка и самым авторитетным источником информации по этой теме, построенным в формате сборника спецификаций, включающих в себя описание синтаксиса, сопутствующие материалы и примеры, а также образцы кода. Эта книга — своего рода «библия» разработчика, которая с легкостью может заменить как MSDN, так и остальные книги по C#. Четвертое издание содержит описание новых особенностей C# 4.0, включая динамическое связывание, именованные и необязательные параметры, а также ковариантные и контравариантные обобщенные типы. Цель этих новшеств — расширение возможностей C# для взаимодействия с объектами, не относящимися к платформе .NET. Отличительная особенность нового издания также состоит в том, что каждая глава книги содержит обширные комментарии, написанные известными «гуру» программирования, такими как Джон Скит, Джозеф Альбахари, Билл Вагнер, Кристиан Нейгел, Эрик Липперт и др.', 
'DB2D1F8E-555E-45B0-8D86-787E5CB3A1EE')
go
insert into [dbo].[Books] ([BookId], [AuthorId], [GenreId], [SeriesId], [Title], [Price], [Year], [Pages], [ISBN], [Desc], [ImageFile])
values (8, 8, 9, 3, N'Hadoop. Подробное руководство', 938, 2013, 672, '978-5-496-00662-0',
N'Apache Hadoop — фреймворк с открытым исходным кодом, в котором реализована вычислительная парадигма, известная как MapReduce, позволившая Google построить свою империю. Эта книга покажет вам, как использовать всю мощь Hadoop, чтобы создавать надежные, масштабируемые, распределенные системы и обрабатывать гигантские наборы данных.', 
'cb912ae0-49f8-4b44-812d-fa3844bbc5ff')
go
set IDENTITY_INSERT [dbo].[Books] off
go