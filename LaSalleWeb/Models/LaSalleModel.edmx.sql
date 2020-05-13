
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/12/2020 11:11:15
-- Generated from EDMX file: C:\Users\spg-admin\Documents\Visual Studio 2017\Projects\LaSalleWeb\LaSalleWeb\Models\LaSalleModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LaSalleWebBD];
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

-- Creating table 'Tutores'
CREATE TABLE [dbo].[Tutores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Telf] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Alumnos'
CREATE TABLE [dbo].[Alumnos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Carnet] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Celular] nvarchar(max)  NOT NULL,
    [FechaNac] nvarchar(max)  NOT NULL,
    [TutorId] int  NOT NULL
);
GO

-- Creating table 'Docentes'
CREATE TABLE [dbo].[Docentes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCompleto] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [INSS] nvarchar(max)  NOT NULL,
    [SalarioBase] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Asignaturas'
CREATE TABLE [dbo].[Asignaturas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Creditos] smallint  NOT NULL,
    [DocenteId] int  NOT NULL
);
GO

-- Creating table 'Notas'
CREATE TABLE [dbo].[Notas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Acumulado] decimal(18,0)  NOT NULL,
    [Examen] decimal(18,0)  NOT NULL,
    [AlumnoId] int  NOT NULL,
    [AsignaturaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Tutores'
ALTER TABLE [dbo].[Tutores]
ADD CONSTRAINT [PK_Tutores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Alumnos'
ALTER TABLE [dbo].[Alumnos]
ADD CONSTRAINT [PK_Alumnos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Docentes'
ALTER TABLE [dbo].[Docentes]
ADD CONSTRAINT [PK_Docentes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Asignaturas'
ALTER TABLE [dbo].[Asignaturas]
ADD CONSTRAINT [PK_Asignaturas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notas'
ALTER TABLE [dbo].[Notas]
ADD CONSTRAINT [PK_Notas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TutorId] in table 'Alumnos'
ALTER TABLE [dbo].[Alumnos]
ADD CONSTRAINT [FK_TutorAlumno]
    FOREIGN KEY ([TutorId])
    REFERENCES [dbo].[Tutores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutorAlumno'
CREATE INDEX [IX_FK_TutorAlumno]
ON [dbo].[Alumnos]
    ([TutorId]);
GO

-- Creating foreign key on [AlumnoId] in table 'Notas'
ALTER TABLE [dbo].[Notas]
ADD CONSTRAINT [FK_AlumnoNota]
    FOREIGN KEY ([AlumnoId])
    REFERENCES [dbo].[Alumnos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlumnoNota'
CREATE INDEX [IX_FK_AlumnoNota]
ON [dbo].[Notas]
    ([AlumnoId]);
GO

-- Creating foreign key on [DocenteId] in table 'Asignaturas'
ALTER TABLE [dbo].[Asignaturas]
ADD CONSTRAINT [FK_DocenteAsignatura]
    FOREIGN KEY ([DocenteId])
    REFERENCES [dbo].[Docentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocenteAsignatura'
CREATE INDEX [IX_FK_DocenteAsignatura]
ON [dbo].[Asignaturas]
    ([DocenteId]);
GO

-- Creating foreign key on [AsignaturaId] in table 'Notas'
ALTER TABLE [dbo].[Notas]
ADD CONSTRAINT [FK_AsignaturaNota]
    FOREIGN KEY ([AsignaturaId])
    REFERENCES [dbo].[Asignaturas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsignaturaNota'
CREATE INDEX [IX_FK_AsignaturaNota]
ON [dbo].[Notas]
    ([AsignaturaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------