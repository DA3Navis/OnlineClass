USE [OnlineClass]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/24/2018 9:29:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Code] [varchar](10) NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](250) NULL,
	[Price] [decimal](18, 0) NULL,
	[PromotonPrice] [decimal](18, 0) NULL,
	[CategoryID] [bigint] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [bit] NULL,
	[CountLesson] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseCategory]    Script Date: 5/24/2018 9:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_CourseCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 5/24/2018 9:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Advance] [float] NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Finish]    Script Date: 5/24/2018 9:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Finish](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[CourseID] [bigint] NOT NULL,
	[LessonID] [bigint] NOT NULL,
	[Done] [bit] NULL,
 CONSTRAINT [PK_Finish] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 5/24/2018 9:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[CourseID] [bigint] NOT NULL,
	[LinkURL] [varchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[YoutubeID] [varchar](250) NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 5/24/2018 9:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[Image] [varchar](250) NULL,
	[Link] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/24/2018 9:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](32) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [bit] NOT NULL,
	[Quyen] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [Price], [PromotonPrice], [CategoryID], [CreatedDate], [Status], [CountLesson]) VALUES (1, N'Java', N'Acv25cdfSv', N'java', NULL, N'/Image/images/Catogory/rsz_how-to-install-java-7-on-centos.jpg', CAST(100 AS Decimal(18, 0)), CAST(80 AS Decimal(18, 0)), 3, CAST(N'2018-03-29T15:25:16.137' AS DateTime), 1, 9)
INSERT [dbo].[Course] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [Price], [PromotonPrice], [CategoryID], [CreatedDate], [Status], [CountLesson]) VALUES (2, N'Toiec 450+', N'AkjfIxNBCH', N'toiec-450', NULL, N'/Image/images/Catogory/Webp_net-resizeimage%20(1).jpg', CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)), 5, CAST(N'2018-03-29T15:25:39.543' AS DateTime), 1, 6)
INSERT [dbo].[Course] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [Price], [PromotonPrice], [CategoryID], [CreatedDate], [Status], [CountLesson]) VALUES (3, N'Đại số', N'HdcndkCGBd', N'dai-so', N'<p>c&acirc;scasc</p>
', N'/Image/images/Catogory/Webp_net-resizeimage.png', CAST(500 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 4, CAST(N'2018-03-29T15:26:02.667' AS DateTime), 1, 60)
INSERT [dbo].[Course] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [Price], [PromotonPrice], [CategoryID], [CreatedDate], [Status], [CountLesson]) VALUES (4, N'Giải tích I', N'jg95vCd32D', N'giai-tich-i', NULL, N'/Image/images/Catogory/HTML5-250x200.jpg', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 3, CAST(N'2018-03-29T15:26:13.363' AS DateTime), 1, 3)
INSERT [dbo].[Course] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [Price], [PromotonPrice], [CategoryID], [CreatedDate], [Status], [CountLesson]) VALUES (5, N'ASP.Net MVC', N'u7fyGbVDg9', N'asp-net-mvc', N'<p>ASP.NET MVC&nbsp;l&agrave; một framework tuyệt vời hỗ trợ pattern MVC cho ASP.NET. Nếu bạn muốn hiểu ASP.NET MVC l&agrave;m việc như thế n&agrave;o, bạn cần phải c&oacute; một sự hiểu biết r&otilde; r&agrave;ng về m&ocirc; h&igrave;nh MVC. MVC l&agrave; cụm từ viết tắt của Model-View-Controller, n&oacute; ph&acirc;n chia pattern của ứng dụng th&agrave;nh 3 phần - model, controller v&agrave; view.</p>
', N'/Image/images/Catogory/Webp_net-resizeimage.jpg', CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)), 3, CAST(N'2018-03-29T15:26:33.203' AS DateTime), 1, 12)
INSERT [dbo].[Course] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [Price], [PromotonPrice], [CategoryID], [CreatedDate], [Status], [CountLesson]) VALUES (6, N'SQL Server', N'16frK5d2Sw', N'sql-server', NULL, N'/Image/images/Catogory/rsz_enable-service-broker-trong-sql-server.png', CAST(200 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), 3, CAST(N'2018-03-29T15:26:53.397' AS DateTime), 1, 20)
INSERT [dbo].[Course] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [Price], [PromotonPrice], [CategoryID], [CreatedDate], [Status], [CountLesson]) VALUES (10, N'SEO', N'Pc95r6of2z', N'seo', N'<p>vvv</p>
', N'/Image/images/Catogory/Webp_net-resizeimage%20(2).jpg', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 6, NULL, 1, 5)
INSERT [dbo].[Course] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [Price], [PromotonPrice], [CategoryID], [CreatedDate], [Status], [CountLesson]) VALUES (12, N'Văn tự sự', N'XjvXhUd7Jn', N'van-tu-su', NULL, N'/Image/images/Catogory/HTML5-250x200.jpg', CAST(50 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)), 5, NULL, 1, 2)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseCategory] ON 

INSERT [dbo].[CourseCategory] ([ID], [Name], [MetaTitle], [CreatedDate], [Status]) VALUES (2, N'Toán học', N'toan-hoc', CAST(N'2018-03-29T15:21:50.913' AS DateTime), 0)
INSERT [dbo].[CourseCategory] ([ID], [Name], [MetaTitle], [CreatedDate], [Status]) VALUES (3, N'Công nghệ thông tin', N'cong-nghe-thong-tin', CAST(N'2018-03-29T15:22:49.780' AS DateTime), 1)
INSERT [dbo].[CourseCategory] ([ID], [Name], [MetaTitle], [CreatedDate], [Status]) VALUES (4, N'Kỹ năng mềm', N'ky-nang-mem', CAST(N'2018-03-29T15:23:17.060' AS DateTime), 1)
INSERT [dbo].[CourseCategory] ([ID], [Name], [MetaTitle], [CreatedDate], [Status]) VALUES (5, N'Văn học', N'van-hoc', NULL, 1)
INSERT [dbo].[CourseCategory] ([ID], [Name], [MetaTitle], [CreatedDate], [Status]) VALUES (6, N'Kinh doanh', N'kinh-doanh', NULL, 1)
SET IDENTITY_INSERT [dbo].[CourseCategory] OFF
SET IDENTITY_INSERT [dbo].[Enrollment] ON 

INSERT [dbo].[Enrollment] ([ID], [CourseID], [UserID], [Advance]) VALUES (3, 5, 20015, 5)
INSERT [dbo].[Enrollment] ([ID], [CourseID], [UserID], [Advance]) VALUES (4, 4, 20015, 0)
INSERT [dbo].[Enrollment] ([ID], [CourseID], [UserID], [Advance]) VALUES (5, 10, 20015, 3)
INSERT [dbo].[Enrollment] ([ID], [CourseID], [UserID], [Advance]) VALUES (6, 4, 20013, 0)
INSERT [dbo].[Enrollment] ([ID], [CourseID], [UserID], [Advance]) VALUES (10005, 10, 20013, 1)
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
SET IDENTITY_INSERT [dbo].[Finish] ON 

INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (101, 20015, 10, 17, NULL)
INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (102, 20015, 10, 18, NULL)
INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (106, 20015, 10, 19, NULL)
INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (107, 20015, 5, 5, NULL)
INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (108, 20015, 5, 6, NULL)
INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (109, 20015, 5, 7, NULL)
INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (110, 20015, 5, 12, NULL)
INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (111, 20015, 5, 11, NULL)
INSERT [dbo].[Finish] ([ID], [UserID], [CourseID], [LessonID], [Done]) VALUES (112, 20013, 10, 17, NULL)
SET IDENTITY_INSERT [dbo].[Finish] OFF
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (5, N'Bài 1: Giới thiệu ASP.NET MVC và tạo ứng dụng đầu tiên', N'bai-1-gioi-thieu-asp-net-mvc-va-tao-ung-dung-dau-tien', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/M0jdFS4ZyEk" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'M0jdFS4ZyEk')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (6, N'Bài 2: Cách tạo và tương tác giữa Model - View - Controller', N'bai-2-cach-tao-va-tuong-tac-giua-model---view---controller', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/B36H9eOELgY" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'B36H9eOELgY')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (7, N'Bài 3: Cách tạo vùng Admin bằng Area', N'bai-3-cach-tao-vung-admin-bang-area', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/NP0BGVfPD9s" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'NP0BGVfPD9s')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (8, N'Bài 4: Sử dụng Layout template dùng chung cho Views', N'bai-4-su-dung-layout-template-dung-chung-cho-views', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/_TQVelWQ_0A" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'_TQVelWQ_0A')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (9, N'Bài 5: Tạo trang đăng nhập qua Store Procedure', N'bai-5-tao-trang-dang-nhap-qua-store-procedure', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/ctxTfF1E8B4" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'ctxTfF1E8B4')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (10, N'Bài 6: Cách đăng nhập với Custom Membership Provider', N'bai-6-cach-dang-nhap-voi-custom-membership-provider', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/fVDXDL4P2zc" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'fVDXDL4P2zc')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (11, N'Bài 8: Validate dữ liệu form trong ASP.NET MVC', N'bai-8-validate-du-lieu-form-trong-asp-net-mvc', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/4kEVZQm03_A" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'4kEVZQm03_A')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (12, N'Bài 9: Insert dữ liệu với Store Procedure', N'bai-9-insert-du-lieu-voi-store-procedure', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/Ur58oeQ9nUE" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'Ur58oeQ9nUE')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (13, N'Bài 11: Thiết kế database cho dự án thực tế với SQL Server', N'bai-11-thiet-ke-database-cho-du-an-thuc-te-voi-sql-server', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/hUhIuktJYPc" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'hUhIuktJYPc')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (14, N'Bài 12: Tạo tầng Data Access với EF CodeFirst', N'bai-12-tao-tang-data-access-voi-ef-codefirst', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/VTEfMLk5jPE" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'VTEfMLk5jPE')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (15, N'Bài 10: Tạo project ASP.NET MVC với Visual Studio 2015', N'bai-10-tao-project-asp-net-mvc-voi-visual-studio-2015', 5, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/UC9k-XqRZO4?list=PLRhlTlpDUWsyK1TIsewrQ7WwC7QkCSCPD" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'UC9k-XqRZO4')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (16, N'Bài 2: File .java g?m nhưng g?', N'bai-2--file--java-gom-nhung-gi', 1, NULL, NULL, NULL)
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (17, N'Cách SEO Facebook Lên Top 1', N'cach-seo-facebook-len-top-1', 10, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/zSzmhO_5jNw" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'zSzmhO_5jNw')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (18, N'Ngày đầu tiên bắt đầu làm SEO', N'ngay-dau-tien-bat-dau-lam-seo', 10, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/iWvi-65tw1c" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'iWvi-65tw1c')
INSERT [dbo].[Lesson] ([ID], [Title], [MetaTitle], [CourseID], [LinkURL], [CreateDate], [YoutubeID]) VALUES (19, N'Nghiên cứu từ khóa SEO 2017 trong 5p', N'nghien-cuu-tu-khoa-seo-2017-trong-5p', 10, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/jKi8qw_NXgI" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>', NULL, N'jKi8qw_NXgI')
SET IDENTITY_INSERT [dbo].[Lesson] OFF
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [Name], [Image], [Link], [CreatedDate]) VALUES (2, N'aaaa', N'/Image/images/Slide/1.png', N'aa', NULL)
INSERT [dbo].[Slide] ([ID], [Name], [Image], [Link], [CreatedDate]) VALUES (3, N'bbbb', N'/Image/images/Slide/3.png', N'bbbb', NULL)
SET IDENTITY_INSERT [dbo].[Slide] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Email], [Phone], [CreatedDate], [Status], [Quyen]) VALUES (4, N'hieu', N'e10adc3949ba59abbe56e057f20f883e', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Email], [Phone], [CreatedDate], [Status], [Quyen]) VALUES (6, N'admin1', N'e10adc3949ba59abbe56e057f20f883e', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Email], [Phone], [CreatedDate], [Status], [Quyen]) VALUES (7, N'admin', N'e10adc3949ba59abbe56e057f20f883e', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Email], [Phone], [CreatedDate], [Status], [Quyen]) VALUES (20013, N'tuan1', N'25d55ad283aa400af464c76d713c07ad', N'ascv', N'tuandht97@gmail.com                               ', N'32105     ', CAST(N'2018-05-03T15:54:19.627' AS DateTime), 1, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Email], [Phone], [CreatedDate], [Status], [Quyen]) VALUES (20014, N'tuan3', N'e10adc3949ba59abbe56e057f20f883e', N'Đỗ Tuấn', N'accc@gmail.com', N'26359     ', CAST(N'2018-05-15T12:14:57.567' AS DateTime), 0, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Email], [Phone], [CreatedDate], [Status], [Quyen]) VALUES (20015, N'tuan', N'e10adc3949ba59abbe56e057f20f883e', N'Tuấn A', N'pokemonred97@gmail.com', N'6523595   ', CAST(N'2018-05-15T14:45:08.383' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_PromotonPrice]  DEFAULT ((0)) FOR [PromotonPrice]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[CourseCategory] ADD  CONSTRAINT [DF_CourseCategory_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CourseCategory] ADD  CONSTRAINT [DF_CourseCategory_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Finish] ADD  CONSTRAINT [DF_Finish_Done]  DEFAULT ((0)) FOR [Done]
GO
ALTER TABLE [dbo].[Lesson] ADD  CONSTRAINT [DF_Lesson_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Slide] ADD  CONSTRAINT [DF_Slide_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Level]  DEFAULT ((0)) FOR [Quyen]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_CourseCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[CourseCategory] ([ID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_CourseCategory]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Course]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_User]
GO
ALTER TABLE [dbo].[Finish]  WITH CHECK ADD  CONSTRAINT [FK_Finish_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Finish] CHECK CONSTRAINT [FK_Finish_Course]
GO
ALTER TABLE [dbo].[Finish]  WITH CHECK ADD  CONSTRAINT [FK_Finish_Lesson] FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lesson] ([ID])
GO
ALTER TABLE [dbo].[Finish] CHECK CONSTRAINT [FK_Finish_Lesson]
GO
ALTER TABLE [dbo].[Finish]  WITH CHECK ADD  CONSTRAINT [FK_Finish_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Finish] CHECK CONSTRAINT [FK_Finish_User]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Course]
GO
