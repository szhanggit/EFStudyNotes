
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2020 18:12:54
-- Generated from EDMX file: C:\Users\zhang\Documents\eBooks\EF books\EFStudyNotes\Lesson02_ModelFirstApproach\EFDemo\EFDemo\EF\EmployeeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Interview];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MFDepartments'
CREATE TABLE [dbo].[MFDepartments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MFEmployees'
CREATE TABLE [dbo].[MFEmployees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Salary] int  NOT NULL,
    [MFDepartmentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MFDepartments'
ALTER TABLE [dbo].[MFDepartments]
ADD CONSTRAINT [PK_MFDepartments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MFEmployees'
ALTER TABLE [dbo].[MFEmployees]
ADD CONSTRAINT [PK_MFEmployees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MFDepartmentId] in table 'MFEmployees'
ALTER TABLE [dbo].[MFEmployees]
ADD CONSTRAINT [FK_MFDepartmentMFEmployee]
    FOREIGN KEY ([MFDepartmentId])
    REFERENCES [dbo].[MFDepartments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MFDepartmentMFEmployee'
CREATE INDEX [IX_FK_MFDepartmentMFEmployee]
ON [dbo].[MFEmployees]
    ([MFDepartmentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------


Insert into MFDepartments values ('IT', 'New York')
Insert into MFDepartments values ('HR', 'London')
Insert into MFDepartments values ('Payroll', 'Sydney')

Insert into MFEmployees values ('Mark', 'Hastings', 'Male', 60000, 1)
Insert into MFEmployees values ('Steve', 'Pound', 'Male', 45000, 3)
Insert into MFEmployees values ('Ben', 'Hoskins', 'Male', 70000, 1)
Insert into MFEmployees values ('Philip', 'Hastings', 'Male', 45000, 2)
Insert into MFEmployees values ('Mary', 'Lambeth', 'Female', 30000, 2)
Insert into MFEmployees values ('Valarie', 'Vikings', 'Female', 35000, 3)
Insert into MFEmployees values ('John', 'Stanmore', 'Male', 80000, 1)
