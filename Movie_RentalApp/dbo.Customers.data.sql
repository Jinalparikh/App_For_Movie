SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsletter], [MembershipTypeId]) VALUES (1, N'John smith', 0, 1)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribedToNewsletter], [MembershipTypeId]) VALUES (2, N'Mary Williams', 1, 2)
SET IDENTITY_INSERT [dbo].[Customers] OFF
