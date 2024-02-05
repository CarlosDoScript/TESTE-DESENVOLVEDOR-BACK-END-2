-- ----------------------------
-- Table structure for Candidate
-- ----------------------------
DROP TABLE [dbo].[Candidate]
GO
CREATE TABLE [dbo].[Candidate] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(255) NULL ,
[Active] bit NULL ,
[IdJobOpening] int NULL ,
[Email] varchar(255) NULL ,
[CellPhone] varchar(255) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Candidate]', RESEED, 29)
GO

-- ----------------------------
-- Records of Candidate
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Candidate] ON
GO
SET IDENTITY_INSERT [dbo].[Candidate] OFF
GO

-- ----------------------------
-- Table structure for CandidateJobOpening
-- ----------------------------
DROP TABLE [dbo].[CandidateJobOpening]
GO
CREATE TABLE [dbo].[CandidateJobOpening] (
[IdCandidate] int NOT NULL ,
[IdJobOpening] int NOT NULL ,
[Active] bit NULL 
)


GO

-- ----------------------------
-- Records of CandidateJobOpening
-- ----------------------------

-- ----------------------------
-- Table structure for CandidateTechnology
-- ----------------------------
DROP TABLE [dbo].[CandidateTechnology]
GO
CREATE TABLE [dbo].[CandidateTechnology] (
[IdCandidate] int NOT NULL ,
[IdTechnology] int NOT NULL ,
[Active] bit NULL 
)


GO

-- ----------------------------
-- Records of CandidateTechnology
-- ----------------------------

-- ----------------------------
-- Table structure for JobOpening
-- ----------------------------
DROP TABLE [dbo].[JobOpening]
GO
CREATE TABLE [dbo].[JobOpening] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Title] varchar(255) NULL ,
[Description] varchar(255) NULL ,
[ScreeningPeriod] date NULL ,
[Active] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[JobOpening]', RESEED, 4)
GO

-- ----------------------------
-- Records of JobOpening
-- ----------------------------
SET IDENTITY_INSERT [dbo].[JobOpening] ON
GO
SET IDENTITY_INSERT [dbo].[JobOpening] OFF
GO

-- ----------------------------
-- Table structure for JobOpeningTechnology
-- ----------------------------
DROP TABLE [dbo].[JobOpeningTechnology]
GO
CREATE TABLE [dbo].[JobOpeningTechnology] (
[IdJobOpening] int NOT NULL ,
[IdTechnology] int NOT NULL ,
[Active] bit NULL 
)


GO

-- ----------------------------
-- Records of JobOpeningTechnology
-- ----------------------------

-- ----------------------------
-- Table structure for RHPeople
-- ----------------------------
DROP TABLE [dbo].[RHPeople]
GO
CREATE TABLE [dbo].[RHPeople] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Username] varchar(255) NULL ,
[Password] varchar(255) NOT NULL ,
[Active] bit NULL 
)


GO

-- ----------------------------
-- Records of RHPeople
-- ----------------------------
SET IDENTITY_INSERT [dbo].[RHPeople] ON
GO
SET IDENTITY_INSERT [dbo].[RHPeople] OFF
GO

-- ----------------------------
-- Table structure for Technology
-- ----------------------------
DROP TABLE [dbo].[Technology]
GO
CREATE TABLE [dbo].[Technology] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(255) NULL ,
[Description] varchar(255) NULL ,
[Weight] int NULL ,
[Active] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Technology]', RESEED, 15)
GO

-- ----------------------------
-- Records of Technology
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Technology] ON
GO
SET IDENTITY_INSERT [dbo].[Technology] OFF
GO

-- ----------------------------
-- Indexes structure for table Candidate
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Candidate
-- ----------------------------
ALTER TABLE [dbo].[Candidate] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table CandidateJobOpening
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table CandidateJobOpening
-- ----------------------------
ALTER TABLE [dbo].[CandidateJobOpening] ADD PRIMARY KEY ([IdCandidate], [IdJobOpening])
GO

-- ----------------------------
-- Indexes structure for table CandidateTechnology
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table CandidateTechnology
-- ----------------------------
ALTER TABLE [dbo].[CandidateTechnology] ADD PRIMARY KEY ([IdCandidate], [IdTechnology])
GO

-- ----------------------------
-- Indexes structure for table JobOpening
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table JobOpening
-- ----------------------------
ALTER TABLE [dbo].[JobOpening] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table JobOpeningTechnology
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table JobOpeningTechnology
-- ----------------------------
ALTER TABLE [dbo].[JobOpeningTechnology] ADD PRIMARY KEY ([IdJobOpening], [IdTechnology])
GO

-- ----------------------------
-- Indexes structure for table RHPeople
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table RHPeople
-- ----------------------------
ALTER TABLE [dbo].[RHPeople] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Uniques structure for table RHPeople
-- ----------------------------
ALTER TABLE [dbo].[RHPeople] ADD UNIQUE ([Username] ASC)
GO

-- ----------------------------
-- Indexes structure for table Technology
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Technology
-- ----------------------------
ALTER TABLE [dbo].[Technology] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Candidate]
-- ----------------------------
ALTER TABLE [dbo].[Candidate] ADD FOREIGN KEY ([IdJobOpening]) REFERENCES [dbo].[JobOpening] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[CandidateJobOpening]
-- ----------------------------
ALTER TABLE [dbo].[CandidateJobOpening] ADD FOREIGN KEY ([IdCandidate]) REFERENCES [dbo].[Candidate] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[CandidateJobOpening] ADD FOREIGN KEY ([IdJobOpening]) REFERENCES [dbo].[JobOpening] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[CandidateTechnology]
-- ----------------------------
ALTER TABLE [dbo].[CandidateTechnology] ADD FOREIGN KEY ([IdCandidate]) REFERENCES [dbo].[Candidate] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[CandidateTechnology] ADD FOREIGN KEY ([IdTechnology]) REFERENCES [dbo].[Technology] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[JobOpeningTechnology]
-- ----------------------------
ALTER TABLE [dbo].[JobOpeningTechnology] ADD FOREIGN KEY ([IdJobOpening]) REFERENCES [dbo].[JobOpening] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[JobOpeningTechnology] ADD FOREIGN KEY ([IdTechnology]) REFERENCES [dbo].[Technology] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO