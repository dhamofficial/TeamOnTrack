USE [teamontrack]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

GO
INSERT [dbo].[Articles] ([UID], [Title], [CreatedBy], [CreatedDate], [LastUpdated], [Status], [ShortDescription], [TagId], [CategoryId]) VALUES (1, N'Single Page Apps with AngularJS Routing and Templating', 1, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime), N'New', NULL, NULL, 1)
GO
INSERT [dbo].[Articles] ([UID], [Title], [CreatedBy], [CreatedDate], [LastUpdated], [Status], [ShortDescription], [TagId], [CategoryId]) VALUES (2, N'Everything you need to understand to start with AngularJS', 1, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime), N'New', NULL, NULL, 2)
GO
INSERT [dbo].[Articles] ([UID], [Title], [CreatedBy], [CreatedDate], [LastUpdated], [Status], [ShortDescription], [TagId], [CategoryId]) VALUES (3, N'Create a theme', 1, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime), N'New', NULL, NULL, 3)
GO
INSERT [dbo].[Articles] ([UID], [Title], [CreatedBy], [CreatedDate], [LastUpdated], [Status], [ShortDescription], [TagId], [CategoryId]) VALUES (4, N'Download or clone UIkit and install Node and Grunt.', 1, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime), N'New', NULL, NULL, 2)
GO
INSERT [dbo].[Articles] ([UID], [Title], [CreatedBy], [CreatedDate], [LastUpdated], [Status], [ShortDescription], [TagId], [CategoryId]) VALUES (5, N'Best theming practices', 1, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime), N'New', NULL, NULL, 2)
GO
INSERT [dbo].[Articles] ([UID], [Title], [CreatedBy], [CreatedDate], [LastUpdated], [Status], [ShortDescription], [TagId], [CategoryId]) VALUES (6, N'To prevent overhead selectors, we use Mixins from', 1, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime), N'New', NULL, NULL, 3)
GO
INSERT [dbo].[Articles] ([UID], [Title], [CreatedBy], [CreatedDate], [LastUpdated], [Status], [ShortDescription], [TagId], [CategoryId]) VALUES (7, N'Should there be neither a variable nor a hook available', 1, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime), N'New', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([UID], [CategoryName], [Description], [Active]) VALUES (1, N'Technology', NULL, 1)
GO
INSERT [dbo].[Categories] ([UID], [CategoryName], [Description], [Active]) VALUES (2, N'Interview', NULL, 1)
GO
INSERT [dbo].[Categories] ([UID], [CategoryName], [Description], [Active]) VALUES (3, N'Communication', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

GO
INSERT [dbo].[Teams] ([UID], [TeamName], [Description], [Active]) VALUES (1, N'Development', NULL, 1)
GO
INSERT [dbo].[Teams] ([UID], [TeamName], [Description], [Active]) VALUES (2, N'Testing', NULL, 1)
GO
INSERT [dbo].[Teams] ([UID], [TeamName], [Description], [Active]) VALUES (3, N'R & D', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
