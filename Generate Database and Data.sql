USE [TicketManagementSystem]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 4/05/2018 9:53:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](25) NULL,
	[LastName] [nvarchar](25) NULL,
	[UserName] [nvarchar](25) NULL,
	[Password] [nvarchar](25) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[Email] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (1, N'Ehsan', N'Sajjad', N'ehsan', N'12345', 1, 0, 1, CAST(N'2015-08-15 00:00:00.000' AS DateTime), 1, CAST(N'2015-08-15 00:00:00.000' AS DateTime), N'ehsansajjad465@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (2, N'', N'', N'', N'', 1, 0, 1, CAST(N'2015-08-16 17:05:00.000' AS DateTime), 1, CAST(N'2015-08-16 17:05:00.000' AS DateTime), N'')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (3, N'', N'', N'', N'', 1, 0, 1, CAST(N'2015-08-16 17:13:39.610' AS DateTime), 1, CAST(N'2015-08-16 17:13:39.610' AS DateTime), N'')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (4, N'', N'', N'', N'', 1, 0, 1, CAST(N'2015-08-16 17:23:32.740' AS DateTime), 1, CAST(N'2015-08-16 17:23:32.740' AS DateTime), N'')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (5, N'Test', N'abc', N'abc', N'123456', 1, 0, 1, CAST(N'2015-08-16 17:30:22.420' AS DateTime), 1, CAST(N'2015-08-16 17:30:22.420' AS DateTime), N'abs@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (6, N'Kaleem', N'Ullah', N'kaleem', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:01:53.843' AS DateTime), 1, CAST(N'2015-08-16 18:01:53.843' AS DateTime), N'kaleem@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (7, N'Kaleem', N'Ullah', N'kaleem', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:09:22.480' AS DateTime), 1, CAST(N'2015-08-16 18:09:22.480' AS DateTime), N'kaleem@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (8, N'Kaleem', N'Ullah', N'kaleem', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:10:03.120' AS DateTime), 1, CAST(N'2015-08-16 18:10:03.120' AS DateTime), N'kaleem@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (9, N'Test', N'Last', N'testing', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:13:32.323' AS DateTime), 1, CAST(N'2015-08-16 18:13:32.323' AS DateTime), N'testing@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (10, N'Test', N'Last', N'testing', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:13:55.633' AS DateTime), 1, CAST(N'2015-08-16 18:13:55.633' AS DateTime), N'testing@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (11, N'Test', N'Last', N'testing', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:15:07.790' AS DateTime), 1, CAST(N'2015-08-16 18:15:07.790' AS DateTime), N'testing@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (12, N'Test', N'Last', N'testing', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:15:52.577' AS DateTime), 1, CAST(N'2015-08-16 18:15:52.577' AS DateTime), N'testing@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (13, N'Test', N'Last', N'testing', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:21:59.250' AS DateTime), 1, CAST(N'2015-08-16 18:21:59.250' AS DateTime), N'testing@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (14, N'Jon', N'Doe', N'Jon', N'12345', 1, 0, 1, CAST(N'2015-08-16 18:33:19.510' AS DateTime), 1, CAST(N'2015-08-16 18:33:19.510' AS DateTime), N'jon@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (15, N'Jon', N'Calire', N'Jon', N'123', 1, 0, 1, CAST(N'2015-08-16 18:34:39.920' AS DateTime), 1, CAST(N'2015-08-16 18:34:39.920' AS DateTime), N'jon@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (16, N'Jonathan', N'Calire', N'Jonathan', N'1234', 1, 0, 1, CAST(N'2015-08-16 18:35:44.860' AS DateTime), 1, CAST(N'2015-08-16 18:35:44.860' AS DateTime), N'jon@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (17, N'Jonathan', N'Calire', N'Jonathan', N'1234', 1, 0, 1, CAST(N'2015-08-16 18:40:36.387' AS DateTime), 1, CAST(N'2015-08-16 18:40:36.387' AS DateTime), N'jon@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (18, N'Jonathan', N'Calire', N'Jonathan', N'1234', 1, 0, 1, CAST(N'2015-08-16 18:43:39.480' AS DateTime), 1, CAST(N'2015-08-16 18:43:39.480' AS DateTime), N'jon@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (19, N'Jonathan', N'Calire', N'Jonathan', N'1234', 1, 0, 1, CAST(N'2015-08-16 18:45:34.733' AS DateTime), 1, CAST(N'2015-08-16 18:45:34.733' AS DateTime), N'jon@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (20, N'Muhammad', N'Babar', N'babar', N'1234', 1, 0, 1, CAST(N'2015-08-16 19:31:54.563' AS DateTime), 1, CAST(N'2015-08-16 19:31:54.563' AS DateTime), N'babar@yahoo.com')
INSERT [dbo].[tblUser] ([UserID], [FirstName], [LastName], [UserName], [Password], [IsActive], [IsDeleted], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt], [Email]) VALUES (21, N'Aleem', N'Jan', N'jan', N'1234', 1, 0, 1, CAST(N'2015-08-16 19:34:20.543' AS DateTime), 1, CAST(N'2015-08-16 19:34:20.543' AS DateTime), N'aleem@yahoo.com')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
