create database EliSchool;

/*drop database EliSchool;*/


create table Students(
	StudentID int NOT NULL PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Department varchar(50) NOT NULL,
);

create table Teachers(
	TeacherID int NOT NULL PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Phone varchar(50),
);


create table Cources(
	CourceID int NOT NULL PRIMARY KEY,
	CourseName varchar(50) NOT NULL,
	Nakaz int,
	[Days] int NOT NULL,
	[Time] int,
	Department varchar(50) NOT NULL,
	TeacherID int FOREIGN KEY REFERENCES Teachers(TeacherID),
);

create table CourceRegistration(
	CourceID int FOREIGN KEY REFERENCES Cources(CourceID),
    StudentID int FOREIGN KEY REFERENCES Students(StudentID),
);


create table Grades(
	Grade int NOT NULL,
	CourceID int FOREIGN KEY REFERENCES Cources(CourceID),
    StudentID int FOREIGN KEY REFERENCES Students(StudentID),
);


create table [Login](
	KeyID int NOT NULL PRIMARY KEY,
	UserName varchar(50) NOT NULL,
	[Password] varchar(50) NOT NULL,
);


ALTER TABLE [Login]
ADD StudentID int FOREIGN KEY REFERENCES Students(StudentID);

ALTER TABLE [Login]
ADD TeacherID int FOREIGN KEY REFERENCES Teachers(TeacherID);
