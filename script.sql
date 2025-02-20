USE [Spoty]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumsArtists]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumsArtists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAlbums] [int] NOT NULL,
	[IdArtists] [int] NOT NULL,
 CONSTRAINT [PK_AlbumsArtists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumTracks]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumTracks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTrack] [int] NOT NULL,
	[IdAlbum] [int] NOT NULL,
 CONSTRAINT [PK_AlbumTracks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArtistsTraks]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistsTraks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTrack] [int] NOT NULL,
	[IdArtist] [int] NOT NULL,
 CONSTRAINT [PK_ArtistsTraks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikesAlbum]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikesAlbum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAlbum] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_LikesAlbum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikesTracks]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikesTracks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTrack] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_LikesTracks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Track_History]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track_History](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Track] [int] NOT NULL,
	[Id_Album] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_Track_History] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tracks]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Duration] [time](7) NOT NULL,
	[Track] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tracks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAlbums]    Script Date: 17.06.2023 7:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAlbums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdAlbum] [int] NOT NULL,
 CONSTRAINT [PK_UserAlbums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1, N'Dimon', N'/Resource/IMG_20210421_065604_944.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2, N'string', N'/Resource/IMG_20210502_071034_942.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (3, N'Dimon2', N'/Resource/IMG_20210428_173945_138.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1002, N'delete', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1003, N'delet', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1004, N'del', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1005, N'rhrth', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1006, N'ewfwe', N'/Resource/IMG_20210417_150554_365.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1007, N'efwef', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1008, N'Удалить сейчас', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1009, N'йцйцйц', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (1013, N'werfewr', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2002, N'qwqw', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2003, N'qweqw', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2004, N'qweqwe', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2005, N'qwqw', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2006, N'ergergerg', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2007, N'45y45y45', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2008, N'yjtyjtyj', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2009, N'fgfghfg', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2010, N'ewrewrwe', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2011, N'wetrthrth', N'/Resource/IMG_20210417_150554_365.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2012, N'qwqw', N'/Resource/IMG_20210417_150554_365.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2013, N'aaa', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2014, N'sdsdfsd', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2015, N'qweqqw', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2016, N'werwe', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2017, N'werwe', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2018, N'asdasd', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2019, N'ewfwe', N'/Resource/IMG_20210428_173945_138.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2020, N'qwqw', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2021, N'ergergerg', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2022, N'ergerg', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2023, N'ewefwefw', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2024, N'qwqw', N'/Resource/IMG_20210421_065604_944.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2025, N'wefwe', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2026, N'ertert', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2027, N'wefwe', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2028, N'qwdqw', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2029, N'werfw', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2030, N'qwq', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2031, N'12', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2032, N'Meteora', N'/Resource/20.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2033, N'Meteora', N'/Resource/20.jpg')
INSERT [dbo].[Albums] ([Id], [Name], [Image]) VALUES (2034, N'Memes', N'/Resource/13.jpg')
SET IDENTITY_INSERT [dbo].[Albums] OFF
GO
SET IDENTITY_INSERT [dbo].[AlbumsArtists] ON 

INSERT [dbo].[AlbumsArtists] ([Id], [IdAlbums], [IdArtists]) VALUES (7, 1013, 1)
INSERT [dbo].[AlbumsArtists] ([Id], [IdAlbums], [IdArtists]) VALUES (1002, 2033, 1)
SET IDENTITY_INSERT [dbo].[AlbumsArtists] OFF
GO
SET IDENTITY_INSERT [dbo].[AlbumTracks] ON 

INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (3, 3, 1)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (4, 4, 1)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1002, 4, 3)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1003, 3, 3)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1004, 1002, 3)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1005, 1002, 1013)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1006, 4, 1013)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1007, 3003, 1013)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1008, 4, 2034)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1009, 3017, 2033)
INSERT [dbo].[AlbumTracks] ([Id], [IdTrack], [IdAlbum]) VALUES (1010, 3017, 2033)
SET IDENTITY_INSERT [dbo].[AlbumTracks] OFF
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([Id], [Name], [Email], [Password], [Image]) VALUES (1, N'Memes', N'zx', N'zx', N'/Resource/IMG_20210421_065604_944.jpg')
SET IDENTITY_INSERT [dbo].[Artists] OFF
GO
SET IDENTITY_INSERT [dbo].[ArtistsTraks] ON 

INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (1, 3, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (2, 4, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (1002, 1002, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3003, 3003, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3012, 3013, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3013, 3014, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3014, 3015, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3015, 3016, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3016, 3017, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3017, 3018, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3018, 3019, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3019, 3020, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3020, 3021, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3021, 3022, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3022, 3023, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3023, 3024, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3024, 3025, 1)
INSERT [dbo].[ArtistsTraks] ([Id], [IdTrack], [IdArtist]) VALUES (3025, 3026, 1)
SET IDENTITY_INSERT [dbo].[ArtistsTraks] OFF
GO
SET IDENTITY_INSERT [dbo].[LikesAlbum] ON 

INSERT [dbo].[LikesAlbum] ([Id], [IdAlbum], [IdUser]) VALUES (1, 1, 2)
INSERT [dbo].[LikesAlbum] ([Id], [IdAlbum], [IdUser]) VALUES (2, 1, 2)
INSERT [dbo].[LikesAlbum] ([Id], [IdAlbum], [IdUser]) VALUES (3, 1, 2)
INSERT [dbo].[LikesAlbum] ([Id], [IdAlbum], [IdUser]) VALUES (1002, 3, 2)
INSERT [dbo].[LikesAlbum] ([Id], [IdAlbum], [IdUser]) VALUES (1003, 2023, 2)
INSERT [dbo].[LikesAlbum] ([Id], [IdAlbum], [IdUser]) VALUES (1004, 2, 2)
SET IDENTITY_INSERT [dbo].[LikesAlbum] OFF
GO
SET IDENTITY_INSERT [dbo].[LikesTracks] ON 

INSERT [dbo].[LikesTracks] ([Id], [IdTrack], [IdUser]) VALUES (4, 3, 2)
INSERT [dbo].[LikesTracks] ([Id], [IdTrack], [IdUser]) VALUES (5, 4, 2)
INSERT [dbo].[LikesTracks] ([Id], [IdTrack], [IdUser]) VALUES (6, 4, 2)
INSERT [dbo].[LikesTracks] ([Id], [IdTrack], [IdUser]) VALUES (1002, 4, 2)
INSERT [dbo].[LikesTracks] ([Id], [IdTrack], [IdUser]) VALUES (2002, 4, 2)
INSERT [dbo].[LikesTracks] ([Id], [IdTrack], [IdUser]) VALUES (2003, 3, 2)
INSERT [dbo].[LikesTracks] ([Id], [IdTrack], [IdUser]) VALUES (2004, 4, 2)
SET IDENTITY_INSERT [dbo].[LikesTracks] OFF
GO
SET IDENTITY_INSERT [dbo].[Tracks] ON 

INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3, CAST(N'00:02:25' AS Time), N'/Resource/NoTrack.mp3', N'no', N'/Resource/IMG_20210502_071034_942.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (4, CAST(N'00:02:25' AS Time), N'/Resource/NoTrack.mp3', N'pls', N'/Resource/8.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (1002, CAST(N'00:02:25' AS Time), N'/Resource/MORGENSHTERN - ДУЛО [vocals].wav', N'Andrey', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (2002, CAST(N'00:00:01' AS Time), N'/Resource/untitled - Track 8.wav', N'wefwef', N'/Resource/IMG_20210413_180100_224.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3003, CAST(N'00:00:41' AS Time), N'/Resource/By Mitek - Керш.mp3', N'By Mitek - Керш.mp3', N'/Resource/11.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3013, CAST(N'00:06:14' AS Time), N'/Resource/$wing - FEVER 333 (128).mp3', N'FEVER 333', N'/Resource/2.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3014, CAST(N'00:02:30' AS Time), N'/Resource/1. Our Last Night - Astronaut In The Ocean (128).mp3', N'Our Last Night', N'/Resource/3.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3015, CAST(N'00:04:24' AS Time), N'/Resource/Avalanche - Bring Me the Horizon (128).mp3', N'Avalanche', N'/Resource/17.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3016, CAST(N'00:03:45' AS Time), N'/Resource/Autoimmune - Dream Demon (128).mp3', N'Autoimmune', N'/Resource/16.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3017, CAST(N'00:03:34' AS Time), N'/Resource/Fighting Myself - Linkin Park (128).mp3', N'Fighting Myself', N'/Resource/20.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3018, CAST(N'00:11:06' AS Time), N'/Resource/abcdefu - Our Last Night (128).mp3', N'abcdefu', N'/Resource/13.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3019, CAST(N'00:02:49' AS Time), N'/Resource/Faint - Linkin Park (128).mp3', N'Faint - Linkin Park', N'/Resource/22.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3020, CAST(N'00:03:58' AS Time), N'/Resource/Glass Heart - Caskets (128).mp3', N'Glass Heart - Caskets', N'/Resource/19.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3021, CAST(N'00:03:16' AS Time), N'/Resource/F.L.Y. - Ice Nine Kills  Buddy Nielsen (128).mp3', N'F.L.Y.', N'/Resource/4.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3022, CAST(N'00:03:40' AS Time), N'/Resource/Dial Tone - Catch Your Breath (128).mp3', N'Dial Tone', N'/Resource/21.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3023, CAST(N'00:06:24' AS Time), N'/Resource/Never Forget The Name - Divide Music (128).mp3', N'N.F.T.N.', N'/Resource/загружено.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3024, CAST(N'00:03:23' AS Time), N'/Resource/Cannibals - Of Virtue (128).mp3', N'Cannibals Of Virtue', N'/Resource/6.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3025, CAST(N'00:03:08' AS Time), N'/Resource/Soul Eternal - Nik Nocturnal  Victor Borba (128).mp3', N'Soul Eternal', N'/Resource/9.jpg')
INSERT [dbo].[Tracks] ([Id], [Duration], [Track], [Name], [Image]) VALUES (3026, CAST(N'00:02:21' AS Time), N'/Resource/Reasons - Until I Wake (128).mp3', N'Reasons Until I Wake', N'/Resource/15.jpg')
SET IDENTITY_INSERT [dbo].[Tracks] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Image]) VALUES (2, N'Vova', N'qw', N'qw', N'/Resource/IMG_20210413_180100_224.jpg')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAlbums] ON 

INSERT [dbo].[UserAlbums] ([Id], [IdUser], [IdAlbum]) VALUES (3, 2, 3)
INSERT [dbo].[UserAlbums] ([Id], [IdUser], [IdAlbum]) VALUES (2002, 2, 2029)
INSERT [dbo].[UserAlbums] ([Id], [IdUser], [IdAlbum]) VALUES (2003, 2, 2030)
INSERT [dbo].[UserAlbums] ([Id], [IdUser], [IdAlbum]) VALUES (2004, 2, 2031)
INSERT [dbo].[UserAlbums] ([Id], [IdUser], [IdAlbum]) VALUES (2006, 2, 2034)
SET IDENTITY_INSERT [dbo].[UserAlbums] OFF
GO
ALTER TABLE [dbo].[AlbumsArtists]  WITH CHECK ADD  CONSTRAINT [FK_AlbumsArtists_Albums1] FOREIGN KEY([IdAlbums])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[AlbumsArtists] CHECK CONSTRAINT [FK_AlbumsArtists_Albums1]
GO
ALTER TABLE [dbo].[AlbumsArtists]  WITH CHECK ADD  CONSTRAINT [FK_AlbumsArtists_Artists1] FOREIGN KEY([IdArtists])
REFERENCES [dbo].[Artists] ([Id])
GO
ALTER TABLE [dbo].[AlbumsArtists] CHECK CONSTRAINT [FK_AlbumsArtists_Artists1]
GO
ALTER TABLE [dbo].[AlbumTracks]  WITH CHECK ADD  CONSTRAINT [FK_AlbumTracks_Albums] FOREIGN KEY([IdAlbum])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[AlbumTracks] CHECK CONSTRAINT [FK_AlbumTracks_Albums]
GO
ALTER TABLE [dbo].[AlbumTracks]  WITH CHECK ADD  CONSTRAINT [FK_AlbumTracks_Tracks] FOREIGN KEY([IdTrack])
REFERENCES [dbo].[Tracks] ([Id])
GO
ALTER TABLE [dbo].[AlbumTracks] CHECK CONSTRAINT [FK_AlbumTracks_Tracks]
GO
ALTER TABLE [dbo].[ArtistsTraks]  WITH CHECK ADD  CONSTRAINT [FK_ArtistsTraks_Artists] FOREIGN KEY([IdArtist])
REFERENCES [dbo].[Artists] ([Id])
GO
ALTER TABLE [dbo].[ArtistsTraks] CHECK CONSTRAINT [FK_ArtistsTraks_Artists]
GO
ALTER TABLE [dbo].[ArtistsTraks]  WITH CHECK ADD  CONSTRAINT [FK_ArtistsTraks_Tracks] FOREIGN KEY([IdTrack])
REFERENCES [dbo].[Tracks] ([Id])
GO
ALTER TABLE [dbo].[ArtistsTraks] CHECK CONSTRAINT [FK_ArtistsTraks_Tracks]
GO
ALTER TABLE [dbo].[LikesAlbum]  WITH CHECK ADD  CONSTRAINT [FK_LikesAlbum_Albums] FOREIGN KEY([IdAlbum])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[LikesAlbum] CHECK CONSTRAINT [FK_LikesAlbum_Albums]
GO
ALTER TABLE [dbo].[LikesAlbum]  WITH CHECK ADD  CONSTRAINT [FK_LikesAlbum_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LikesAlbum] CHECK CONSTRAINT [FK_LikesAlbum_User]
GO
ALTER TABLE [dbo].[LikesTracks]  WITH CHECK ADD  CONSTRAINT [FK_LikesTracks_Tracks] FOREIGN KEY([IdTrack])
REFERENCES [dbo].[Tracks] ([Id])
GO
ALTER TABLE [dbo].[LikesTracks] CHECK CONSTRAINT [FK_LikesTracks_Tracks]
GO
ALTER TABLE [dbo].[LikesTracks]  WITH CHECK ADD  CONSTRAINT [FK_LikesTracks_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LikesTracks] CHECK CONSTRAINT [FK_LikesTracks_User]
GO
ALTER TABLE [dbo].[Track_History]  WITH CHECK ADD  CONSTRAINT [FK_Track_History_Albums] FOREIGN KEY([Id_Album])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[Track_History] CHECK CONSTRAINT [FK_Track_History_Albums]
GO
ALTER TABLE [dbo].[Track_History]  WITH CHECK ADD  CONSTRAINT [FK_Track_History_Tracks] FOREIGN KEY([Id_Track])
REFERENCES [dbo].[Tracks] ([Id])
GO
ALTER TABLE [dbo].[Track_History] CHECK CONSTRAINT [FK_Track_History_Tracks]
GO
ALTER TABLE [dbo].[Track_History]  WITH CHECK ADD  CONSTRAINT [FK_Track_History_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Track_History] CHECK CONSTRAINT [FK_Track_History_User]
GO
ALTER TABLE [dbo].[UserAlbums]  WITH CHECK ADD  CONSTRAINT [FK_UserAlbums_Albums] FOREIGN KEY([IdAlbum])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[UserAlbums] CHECK CONSTRAINT [FK_UserAlbums_Albums]
GO
ALTER TABLE [dbo].[UserAlbums]  WITH CHECK ADD  CONSTRAINT [FK_UserAlbums_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserAlbums] CHECK CONSTRAINT [FK_UserAlbums_User]
GO
