SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubcribedToNewsletter], [MembershipTypeId]) VALUES (1, N'John Smith', 0, 1)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubcribedToNewsletter], [MembershipTypeId]) VALUES (2, N'Mary William', 1, 2)
SET IDENTITY_INSERT [dbo].[Customers] OFF
