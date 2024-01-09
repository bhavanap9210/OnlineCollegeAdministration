
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2015 21:05:24
-- Generated from EDMX file: C:\Users\king\Documents\Visual Studio 2012\Projects\Others\OnlineCollegeAdministration\OnlineCollegeAdministration\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OnlineCollegeAdministration];
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

-- Creating table 'user_tb'
CREATE TABLE [dbo].[user_tb] (
    [user_id] int IDENTITY(1,1) NOT NULL,
    [user_name] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [active_ind] bit  NOT NULL
);
GO

-- Creating table 'user_role_tb'
CREATE TABLE [dbo].[user_role_tb] (
    [user_role_id] int IDENTITY(1,1) NOT NULL,
    [user_id] nvarchar(max)  NOT NULL,
    [role_id] nvarchar(max)  NOT NULL,
    [user_tb_user_id] int  NOT NULL,
    [role_tb_role_id] int  NOT NULL
);
GO

-- Creating table 'role_tb'
CREATE TABLE [dbo].[role_tb] (
    [role_id] int IDENTITY(1,1) NOT NULL,
    [role_desc] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'role_menu_tb'
CREATE TABLE [dbo].[role_menu_tb] (
    [role_menu_id] int IDENTITY(1,1) NOT NULL,
    [role_id] nvarchar(max)  NOT NULL,
    [menu_id] nvarchar(max)  NOT NULL,
    [menu_tb_menu_id] int  NOT NULL,
    [role_tb_role_id] int  NOT NULL
);
GO

-- Creating table 'menu_tb'
CREATE TABLE [dbo].[menu_tb] (
    [menu_id] int IDENTITY(1,1) NOT NULL,
    [menu_name] nvarchar(max)  NOT NULL,
    [page_url] nvarchar(max)  NOT NULL,
    [active_ind] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'student_tb'
CREATE TABLE [dbo].[student_tb] (
    [student_id] int IDENTITY(1,1) NOT NULL,
    [student_last_name] nvarchar(max)  NOT NULL,
    [student_first_name] nvarchar(max)  NOT NULL,
    [student_middle_name] nvarchar(max)  NOT NULL,
    [dob_dt] nvarchar(max)  NOT NULL,
    [addr1] nvarchar(max)  NOT NULL,
    [addr2] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NOT NULL,
    [zip_code] nvarchar(max)  NOT NULL,
    [country] nvarchar(max)  NOT NULL,
    [student_email] nvarchar(max)  NOT NULL,
    [mobile_no] nvarchar(max)  NOT NULL,
    [active_ind] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'courses'
CREATE TABLE [dbo].[courses] (
    [course_id] int IDENTITY(1,1) NOT NULL,
    [course_name] nvarchar(max)  NOT NULL,
    [course_desc] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'course_duration_tb'
CREATE TABLE [dbo].[course_duration_tb] (
    [course_duration_id] int IDENTITY(1,1) NOT NULL,
    [course_id] nvarchar(max)  NOT NULL,
    [course_day_id] nvarchar(max)  NOT NULL,
    [course_start_time] nvarchar(max)  NOT NULL,
    [course_end_time] nvarchar(max)  NOT NULL,
    [course_duration_desc] nvarchar(max)  NOT NULL,
    [active_ind] nvarchar(max)  NOT NULL,
    [course_course_id] int  NOT NULL,
    [days_tb_day_id] int  NOT NULL
);
GO

-- Creating table 'days_tb'
CREATE TABLE [dbo].[days_tb] (
    [day_id] int IDENTITY(1,1) NOT NULL,
    [day_name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'staff_tb'
CREATE TABLE [dbo].[staff_tb] (
    [staff_id] int IDENTITY(1,1) NOT NULL,
    [staff_last_name] nvarchar(max)  NOT NULL,
    [staff_first_name] nvarchar(max)  NOT NULL,
    [staff_middle_name] nvarchar(max)  NOT NULL,
    [dob_dt] nvarchar(max)  NOT NULL,
    [addr1] nvarchar(max)  NOT NULL,
    [addr2] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NOT NULL,
    [zip_code] nvarchar(max)  NOT NULL,
    [country] nvarchar(max)  NOT NULL,
    [staff_email] nvarchar(max)  NOT NULL,
    [mobile_no] nvarchar(max)  NOT NULL,
    [active_ind] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'staff_course_tb'
CREATE TABLE [dbo].[staff_course_tb] (
    [staff_course_id] int IDENTITY(1,1) NOT NULL,
    [staff_id] nvarchar(max)  NOT NULL,
    [course_duration_id] nvarchar(max)  NOT NULL,
    [year_nbr] nvarchar(max)  NOT NULL,
    [month_nbr] nvarchar(max)  NOT NULL,
    [course_duration_tb_course_duration_id] int  NOT NULL,
    [staff_tb_staff_id] int  NOT NULL
);
GO

-- Creating table 'student_course_tb'
CREATE TABLE [dbo].[student_course_tb] (
    [student_course_id] int IDENTITY(1,1) NOT NULL,
    [staff_course_id] nvarchar(max)  NOT NULL,
    [student_id] nvarchar(max)  NOT NULL,
    [staff_course_tb_staff_course_id] int  NOT NULL,
    [student_tb_student_id] int  NOT NULL
);
GO

-- Creating table 'books_course_tb'
CREATE TABLE [dbo].[books_course_tb] (
    [book_course_id] int IDENTITY(1,1) NOT NULL,
    [course_id] nvarchar(max)  NOT NULL,
    [book_id] nvarchar(max)  NOT NULL,
    [books_tb_book_id] int  NOT NULL,
    [course_course_id] int  NOT NULL
);
GO

-- Creating table 'books_tb'
CREATE TABLE [dbo].[books_tb] (
    [book_id] int IDENTITY(1,1) NOT NULL,
    [book_name] nvarchar(max)  NOT NULL,
    [book_author_name] nvarchar(max)  NOT NULL,
    [active_ind] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'student_grade_tb'
CREATE TABLE [dbo].[student_grade_tb] (
    [student_grade_id] int IDENTITY(1,1) NOT NULL,
    [grade_id] nvarchar(max)  NOT NULL,
    [course_duration_id] nvarchar(max)  NOT NULL,
    [student_id] nvarchar(max)  NOT NULL,
    [staff_id] nvarchar(max)  NOT NULL,
    [finalized_ind] nvarchar(max)  NOT NULL,
    [student_course_tb_student_course_id] int  NOT NULL,
    [student_tb_student_id] int  NOT NULL,
    [grade_tb_grade_id] int  NOT NULL
);
GO

-- Creating table 'grade_tb'
CREATE TABLE [dbo].[grade_tb] (
    [grade_id] int IDENTITY(1,1) NOT NULL,
    [grade_cd] nvarchar(max)  NOT NULL,
    [grade_desc] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [user_id] in table 'user_tb'
ALTER TABLE [dbo].[user_tb]
ADD CONSTRAINT [PK_user_tb]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- Creating primary key on [user_role_id] in table 'user_role_tb'
ALTER TABLE [dbo].[user_role_tb]
ADD CONSTRAINT [PK_user_role_tb]
    PRIMARY KEY CLUSTERED ([user_role_id] ASC);
GO

-- Creating primary key on [role_id] in table 'role_tb'
ALTER TABLE [dbo].[role_tb]
ADD CONSTRAINT [PK_role_tb]
    PRIMARY KEY CLUSTERED ([role_id] ASC);
GO

-- Creating primary key on [role_menu_id] in table 'role_menu_tb'
ALTER TABLE [dbo].[role_menu_tb]
ADD CONSTRAINT [PK_role_menu_tb]
    PRIMARY KEY CLUSTERED ([role_menu_id] ASC);
GO

-- Creating primary key on [menu_id] in table 'menu_tb'
ALTER TABLE [dbo].[menu_tb]
ADD CONSTRAINT [PK_menu_tb]
    PRIMARY KEY CLUSTERED ([menu_id] ASC);
GO

-- Creating primary key on [student_id] in table 'student_tb'
ALTER TABLE [dbo].[student_tb]
ADD CONSTRAINT [PK_student_tb]
    PRIMARY KEY CLUSTERED ([student_id] ASC);
GO

-- Creating primary key on [course_id] in table 'courses'
ALTER TABLE [dbo].[courses]
ADD CONSTRAINT [PK_courses]
    PRIMARY KEY CLUSTERED ([course_id] ASC);
GO

-- Creating primary key on [course_duration_id] in table 'course_duration_tb'
ALTER TABLE [dbo].[course_duration_tb]
ADD CONSTRAINT [PK_course_duration_tb]
    PRIMARY KEY CLUSTERED ([course_duration_id] ASC);
GO

-- Creating primary key on [day_id] in table 'days_tb'
ALTER TABLE [dbo].[days_tb]
ADD CONSTRAINT [PK_days_tb]
    PRIMARY KEY CLUSTERED ([day_id] ASC);
GO

-- Creating primary key on [staff_id] in table 'staff_tb'
ALTER TABLE [dbo].[staff_tb]
ADD CONSTRAINT [PK_staff_tb]
    PRIMARY KEY CLUSTERED ([staff_id] ASC);
GO

-- Creating primary key on [staff_course_id] in table 'staff_course_tb'
ALTER TABLE [dbo].[staff_course_tb]
ADD CONSTRAINT [PK_staff_course_tb]
    PRIMARY KEY CLUSTERED ([staff_course_id] ASC);
GO

-- Creating primary key on [student_course_id] in table 'student_course_tb'
ALTER TABLE [dbo].[student_course_tb]
ADD CONSTRAINT [PK_student_course_tb]
    PRIMARY KEY CLUSTERED ([student_course_id] ASC);
GO

-- Creating primary key on [book_course_id] in table 'books_course_tb'
ALTER TABLE [dbo].[books_course_tb]
ADD CONSTRAINT [PK_books_course_tb]
    PRIMARY KEY CLUSTERED ([book_course_id] ASC);
GO

-- Creating primary key on [book_id] in table 'books_tb'
ALTER TABLE [dbo].[books_tb]
ADD CONSTRAINT [PK_books_tb]
    PRIMARY KEY CLUSTERED ([book_id] ASC);
GO

-- Creating primary key on [student_grade_id] in table 'student_grade_tb'
ALTER TABLE [dbo].[student_grade_tb]
ADD CONSTRAINT [PK_student_grade_tb]
    PRIMARY KEY CLUSTERED ([student_grade_id] ASC);
GO

-- Creating primary key on [grade_id] in table 'grade_tb'
ALTER TABLE [dbo].[grade_tb]
ADD CONSTRAINT [PK_grade_tb]
    PRIMARY KEY CLUSTERED ([grade_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [user_tb_user_id] in table 'user_role_tb'
ALTER TABLE [dbo].[user_role_tb]
ADD CONSTRAINT [FK_user_tbuser_role_tb]
    FOREIGN KEY ([user_tb_user_id])
    REFERENCES [dbo].[user_tb]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_user_tbuser_role_tb'
CREATE INDEX [IX_FK_user_tbuser_role_tb]
ON [dbo].[user_role_tb]
    ([user_tb_user_id]);
GO

-- Creating foreign key on [role_tb_role_id] in table 'user_role_tb'
ALTER TABLE [dbo].[user_role_tb]
ADD CONSTRAINT [FK_role_tbuser_role_tb]
    FOREIGN KEY ([role_tb_role_id])
    REFERENCES [dbo].[role_tb]
        ([role_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_role_tbuser_role_tb'
CREATE INDEX [IX_FK_role_tbuser_role_tb]
ON [dbo].[user_role_tb]
    ([role_tb_role_id]);
GO

-- Creating foreign key on [menu_tb_menu_id] in table 'role_menu_tb'
ALTER TABLE [dbo].[role_menu_tb]
ADD CONSTRAINT [FK_menu_tbrole_menu_tb]
    FOREIGN KEY ([menu_tb_menu_id])
    REFERENCES [dbo].[menu_tb]
        ([menu_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_menu_tbrole_menu_tb'
CREATE INDEX [IX_FK_menu_tbrole_menu_tb]
ON [dbo].[role_menu_tb]
    ([menu_tb_menu_id]);
GO

-- Creating foreign key on [role_tb_role_id] in table 'role_menu_tb'
ALTER TABLE [dbo].[role_menu_tb]
ADD CONSTRAINT [FK_role_tbrole_menu_tb]
    FOREIGN KEY ([role_tb_role_id])
    REFERENCES [dbo].[role_tb]
        ([role_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_role_tbrole_menu_tb'
CREATE INDEX [IX_FK_role_tbrole_menu_tb]
ON [dbo].[role_menu_tb]
    ([role_tb_role_id]);
GO

-- Creating foreign key on [course_course_id] in table 'course_duration_tb'
ALTER TABLE [dbo].[course_duration_tb]
ADD CONSTRAINT [FK_coursecourse_duration_tb]
    FOREIGN KEY ([course_course_id])
    REFERENCES [dbo].[courses]
        ([course_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_coursecourse_duration_tb'
CREATE INDEX [IX_FK_coursecourse_duration_tb]
ON [dbo].[course_duration_tb]
    ([course_course_id]);
GO

-- Creating foreign key on [days_tb_day_id] in table 'course_duration_tb'
ALTER TABLE [dbo].[course_duration_tb]
ADD CONSTRAINT [FK_days_tbcourse_duration_tb]
    FOREIGN KEY ([days_tb_day_id])
    REFERENCES [dbo].[days_tb]
        ([day_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_days_tbcourse_duration_tb'
CREATE INDEX [IX_FK_days_tbcourse_duration_tb]
ON [dbo].[course_duration_tb]
    ([days_tb_day_id]);
GO

-- Creating foreign key on [course_duration_tb_course_duration_id] in table 'staff_course_tb'
ALTER TABLE [dbo].[staff_course_tb]
ADD CONSTRAINT [FK_course_duration_tbstaff_course_tb]
    FOREIGN KEY ([course_duration_tb_course_duration_id])
    REFERENCES [dbo].[course_duration_tb]
        ([course_duration_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_course_duration_tbstaff_course_tb'
CREATE INDEX [IX_FK_course_duration_tbstaff_course_tb]
ON [dbo].[staff_course_tb]
    ([course_duration_tb_course_duration_id]);
GO

-- Creating foreign key on [staff_tb_staff_id] in table 'staff_course_tb'
ALTER TABLE [dbo].[staff_course_tb]
ADD CONSTRAINT [FK_staff_tbstaff_course_tb]
    FOREIGN KEY ([staff_tb_staff_id])
    REFERENCES [dbo].[staff_tb]
        ([staff_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_staff_tbstaff_course_tb'
CREATE INDEX [IX_FK_staff_tbstaff_course_tb]
ON [dbo].[staff_course_tb]
    ([staff_tb_staff_id]);
GO

-- Creating foreign key on [staff_course_tb_staff_course_id] in table 'student_course_tb'
ALTER TABLE [dbo].[student_course_tb]
ADD CONSTRAINT [FK_staff_course_tbstudent_course_tb]
    FOREIGN KEY ([staff_course_tb_staff_course_id])
    REFERENCES [dbo].[staff_course_tb]
        ([staff_course_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_staff_course_tbstudent_course_tb'
CREATE INDEX [IX_FK_staff_course_tbstudent_course_tb]
ON [dbo].[student_course_tb]
    ([staff_course_tb_staff_course_id]);
GO

-- Creating foreign key on [student_tb_student_id] in table 'student_course_tb'
ALTER TABLE [dbo].[student_course_tb]
ADD CONSTRAINT [FK_student_tbstudent_course_tb]
    FOREIGN KEY ([student_tb_student_id])
    REFERENCES [dbo].[student_tb]
        ([student_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_student_tbstudent_course_tb'
CREATE INDEX [IX_FK_student_tbstudent_course_tb]
ON [dbo].[student_course_tb]
    ([student_tb_student_id]);
GO

-- Creating foreign key on [books_tb_book_id] in table 'books_course_tb'
ALTER TABLE [dbo].[books_course_tb]
ADD CONSTRAINT [FK_books_tbbooks_course_tb]
    FOREIGN KEY ([books_tb_book_id])
    REFERENCES [dbo].[books_tb]
        ([book_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_books_tbbooks_course_tb'
CREATE INDEX [IX_FK_books_tbbooks_course_tb]
ON [dbo].[books_course_tb]
    ([books_tb_book_id]);
GO

-- Creating foreign key on [course_course_id] in table 'books_course_tb'
ALTER TABLE [dbo].[books_course_tb]
ADD CONSTRAINT [FK_coursebooks_course_tb]
    FOREIGN KEY ([course_course_id])
    REFERENCES [dbo].[courses]
        ([course_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_coursebooks_course_tb'
CREATE INDEX [IX_FK_coursebooks_course_tb]
ON [dbo].[books_course_tb]
    ([course_course_id]);
GO

-- Creating foreign key on [student_course_tb_student_course_id] in table 'student_grade_tb'
ALTER TABLE [dbo].[student_grade_tb]
ADD CONSTRAINT [FK_student_course_tbstudent_grade_tb]
    FOREIGN KEY ([student_course_tb_student_course_id])
    REFERENCES [dbo].[student_course_tb]
        ([student_course_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_student_course_tbstudent_grade_tb'
CREATE INDEX [IX_FK_student_course_tbstudent_grade_tb]
ON [dbo].[student_grade_tb]
    ([student_course_tb_student_course_id]);
GO

-- Creating foreign key on [student_tb_student_id] in table 'student_grade_tb'
ALTER TABLE [dbo].[student_grade_tb]
ADD CONSTRAINT [FK_student_tbstudent_grade_tb]
    FOREIGN KEY ([student_tb_student_id])
    REFERENCES [dbo].[student_tb]
        ([student_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_student_tbstudent_grade_tb'
CREATE INDEX [IX_FK_student_tbstudent_grade_tb]
ON [dbo].[student_grade_tb]
    ([student_tb_student_id]);
GO

-- Creating foreign key on [grade_tb_grade_id] in table 'student_grade_tb'
ALTER TABLE [dbo].[student_grade_tb]
ADD CONSTRAINT [FK_grade_tbstudent_grade_tb]
    FOREIGN KEY ([grade_tb_grade_id])
    REFERENCES [dbo].[grade_tb]
        ([grade_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_grade_tbstudent_grade_tb'
CREATE INDEX [IX_FK_grade_tbstudent_grade_tb]
ON [dbo].[student_grade_tb]
    ([grade_tb_grade_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------