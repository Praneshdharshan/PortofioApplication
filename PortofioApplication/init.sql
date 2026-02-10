DROP TABLE IF EXISTS Profile;
DROP TABLE IF EXISTS Skills;
DROP TABLE IF EXISTS Experience;
DROP TABLE IF EXISTS Projects;
DROP TABLE IF EXISTS ContactMessages;

CREATE TABLE Profile(
 Id INTEGER PRIMARY KEY AUTOINCREMENT,
 Name TEXT,
 Title TEXT,
 Summary TEXT,
 Email TEXT,
 Phone TEXT,
 LinkedIn TEXT,
 GitHub TEXT
);

CREATE TABLE Skills(
 Id INTEGER PRIMARY KEY AUTOINCREMENT,
 SkillName TEXT,
 SkillLevel TEXT
);

CREATE TABLE Experience(
 Id INTEGER PRIMARY KEY AUTOINCREMENT,
 Company TEXT,
 Role TEXT,
 StartYear TEXT,
 EndYear TEXT,
 Description TEXT
);

CREATE TABLE Projects(
 Id INTEGER PRIMARY KEY AUTOINCREMENT,
 Title TEXT,
 Description TEXT,
 TechStack TEXT
);

CREATE TABLE ContactMessages(
 Id INTEGER PRIMARY KEY AUTOINCREMENT,
 Name TEXT,
 Email TEXT,
 Message TEXT,
 CreatedAt TEXT DEFAULT CURRENT_TIMESTAMP
);

/* PROFILE */

INSERT INTO Profile
(Name, Title, Summary, Email, Phone, LinkedIn, GitHub)
VALUES
(
'Pranesh Dharshan M',
'Junior Software Associate | ASP.NET MVC & Full Stack Developer',
'Software Engineer with 1+ year of experience building backend and full-stack web applications using ASP.NET MVC, Node.js, REST APIs, and SQL Server. Strong in building internal systems, API integration, and improving performance in Agile environments.',
'vilasmanig@gmail.com',
'9003243440',
'https://linkedin.com/in/praneshdharshan2002',
'https://github.com/Praneshdharshan'
);

/* SKILLS */

INSERT INTO Skills (SkillName, SkillLevel) VALUES
('ASP.NET MVC','Advanced'),
('Node.js','Intermediate'),
('Express.js','Intermediate'),
('REST APIs','Advanced'),
('HTML5','Advanced'),
('CSS3','Advanced'),
('Bootstrap','Advanced'),
('JavaScript','Intermediate'),
('SQL Server','Advanced'),
('MySQL','Intermediate'),
('FileMaker Server','Intermediate'),
('AWS EC2','Beginner'),
('AWS S3','Beginner'),
('GitHub','Advanced'),
('Postman','Advanced'),
('Power BI','Intermediate');

/* EXPERIENCE */

INSERT INTO Experience
(Company, Role, StartYear, EndYear, Description)
VALUES
(
'eNoah iSolution, Chennai',
'Junior Software Associate',
'Apr 2024',
'Feb 2026',
'Developed internal web applications using ASP.NET MVC, Node.js and SQL Server. Built REST APIs, worked with FileMaker Server, supported production releases, bug fixes, and Agile development.'
);

/* PROJECTS */

INSERT INTO Projects (Title, Description, TechStack) VALUES
(
'Central Line Project',
'Developed backend APIs using Node.js and Express.js to centralize operational data. Integrated FileMaker Data API and implemented server-side validation.',
'Node.js, Express.js, FileMaker, REST APIs'
),
(
'eConnect Internal Employee Portal',
'Built employee portal using ASP.NET MVC and SQL Server with role-based access control and secure workflows.',
'ASP.NET MVC, SQL Server, REST APIs'
),
(
'Internal Analytics Dashboard',
'Developed dashboards and embedded Power BI reports. Integrated data from Airtable, Smartsheet, and SQL Server.',
'Power BI, SQL Server, ASP.NET MVC'
),
(
'Cloud-Based Blood Bank Management System',
'Designed cloud system for blood inventory and donor records. Deployed using AWS EC2 and S3. Won Best Research Paper Award.',
'AWS EC2, S3, ASP.NET MVC, SQL Server'
);
