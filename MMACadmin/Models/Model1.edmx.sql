
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/21/2014 20:23:18
-- Generated from EDMX file: c:\users\mc\documents\visual studio 2013\Projects\MMACadmin\MMACadmin\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mmacadmindb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [GroupID] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Owner] nvarchar(max)  NOT NULL,
    [BackUpOwner] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ProjectID] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Owner] nvarchar(max)  NOT NULL,
    [BackUpOwner] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectReleases'
CREATE TABLE [dbo].[ProjectReleases] (
    [ReleaseID] int IDENTITY(1,1) NOT NULL,
    [ReleaseName] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Owner] nvarchar(max)  NOT NULL,
    [BackUpOwner] nvarchar(max)  NOT NULL,
    [ProjectID] int  NOT NULL,
    [Project_ProjectID] int  NOT NULL
);
GO

-- Creating table 'ReqSets'
CREATE TABLE [dbo].[ReqSets] (
    [ReqSetID] int IDENTITY(1,1) NOT NULL,
    [ProjectID] datetime  NULL,
    [ReleaseID] int  NULL,
    [GroupID] int  NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL,
    [RoleID] nvarchar(max)  NOT NULL,
    [EnvID] nvarchar(max)  NOT NULL,
    [Role_RoleID] int  NOT NULL,
    [Env_EnvID] int  NOT NULL,
    [ProjectRelease_ReleaseID] int  NULL,
    [Group_GroupID] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Envs'
CREATE TABLE [dbo].[Envs] (
    [EnvID] int IDENTITY(1,1) NOT NULL,
    [EnvName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MACRequests'
CREATE TABLE [dbo].[MACRequests] (
    [MACID] int IDENTITY(1,1) NOT NULL,
    [AccSystem] nvarchar(max)  NOT NULL,
    [AccEnv] nvarchar(max)  NOT NULL,
    [AccGroup] nvarchar(max)  NULL,
    [AccServer] nvarchar(max)  NULL,
    [AccDB] nvarchar(max)  NULL,
    [AccJust] nvarchar(max)  NULL,
    [isElevated] bit  NOT NULL,
    [ReqSetID] nvarchar(max)  NOT NULL,
    [ReqSet_ReqSetID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GroupID] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([GroupID] ASC);
GO

-- Creating primary key on [ProjectID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ProjectID] ASC);
GO

-- Creating primary key on [ReleaseID] in table 'ProjectReleases'
ALTER TABLE [dbo].[ProjectReleases]
ADD CONSTRAINT [PK_ProjectReleases]
    PRIMARY KEY CLUSTERED ([ReleaseID] ASC);
GO

-- Creating primary key on [ReqSetID] in table 'ReqSets'
ALTER TABLE [dbo].[ReqSets]
ADD CONSTRAINT [PK_ReqSets]
    PRIMARY KEY CLUSTERED ([ReqSetID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [EnvID] in table 'Envs'
ALTER TABLE [dbo].[Envs]
ADD CONSTRAINT [PK_Envs]
    PRIMARY KEY CLUSTERED ([EnvID] ASC);
GO

-- Creating primary key on [MACID] in table 'MACRequests'
ALTER TABLE [dbo].[MACRequests]
ADD CONSTRAINT [PK_MACRequests]
    PRIMARY KEY CLUSTERED ([MACID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Project_ProjectID] in table 'ProjectReleases'
ALTER TABLE [dbo].[ProjectReleases]
ADD CONSTRAINT [FK_ProjectProjectRelease]
    FOREIGN KEY ([Project_ProjectID])
    REFERENCES [dbo].[Projects]
        ([ProjectID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectRelease'
CREATE INDEX [IX_FK_ProjectProjectRelease]
ON [dbo].[ProjectReleases]
    ([Project_ProjectID]);
GO

-- Creating foreign key on [Role_RoleID] in table 'ReqSets'
ALTER TABLE [dbo].[ReqSets]
ADD CONSTRAINT [FK_RoleReqSet]
    FOREIGN KEY ([Role_RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleReqSet'
CREATE INDEX [IX_FK_RoleReqSet]
ON [dbo].[ReqSets]
    ([Role_RoleID]);
GO

-- Creating foreign key on [Env_EnvID] in table 'ReqSets'
ALTER TABLE [dbo].[ReqSets]
ADD CONSTRAINT [FK_EnvReqSet]
    FOREIGN KEY ([Env_EnvID])
    REFERENCES [dbo].[Envs]
        ([EnvID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnvReqSet'
CREATE INDEX [IX_FK_EnvReqSet]
ON [dbo].[ReqSets]
    ([Env_EnvID]);
GO

-- Creating foreign key on [ProjectRelease_ReleaseID] in table 'ReqSets'
ALTER TABLE [dbo].[ReqSets]
ADD CONSTRAINT [FK_ProjectReleaseReqSet]
    FOREIGN KEY ([ProjectRelease_ReleaseID])
    REFERENCES [dbo].[ProjectReleases]
        ([ReleaseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectReleaseReqSet'
CREATE INDEX [IX_FK_ProjectReleaseReqSet]
ON [dbo].[ReqSets]
    ([ProjectRelease_ReleaseID]);
GO

-- Creating foreign key on [Group_GroupID] in table 'ReqSets'
ALTER TABLE [dbo].[ReqSets]
ADD CONSTRAINT [FK_GroupReqSet]
    FOREIGN KEY ([Group_GroupID])
    REFERENCES [dbo].[Groups]
        ([GroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupReqSet'
CREATE INDEX [IX_FK_GroupReqSet]
ON [dbo].[ReqSets]
    ([Group_GroupID]);
GO

-- Creating foreign key on [ReqSet_ReqSetID] in table 'MACRequests'
ALTER TABLE [dbo].[MACRequests]
ADD CONSTRAINT [FK_ReqSetMACRequest]
    FOREIGN KEY ([ReqSet_ReqSetID])
    REFERENCES [dbo].[ReqSets]
        ([ReqSetID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReqSetMACRequest'
CREATE INDEX [IX_FK_ReqSetMACRequest]
ON [dbo].[MACRequests]
    ([ReqSet_ReqSetID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------