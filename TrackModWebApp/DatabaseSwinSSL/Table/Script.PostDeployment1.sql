/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF '$(LoadTestData)' = 'true'

BEGIN
-- ENSURE THERE IS NOT DATA IN THE TABLEES BEFORE DEPLOYING TEST DATA

DELETE FROM WirelessModule;
DELETE FROM Student;


-- insert test data


INSERT INTO Student(Id,studentFname,studentLastname) Values
('s1404326303', 'Kandace', 'WyettR'),
('s0852437381',	'Kellby', 'GrayshanR'),
('s5332613405',	'Lula', 'DarnboroughR'),
('s0093188549',	'Nerti', 'SteelyR'),
('s3357087510',	'Christabel', 'StairsR'),
('s1465001145',	'Jock', 'AndersenR');


INSERT INTO WirelessModule(MacAddress, IssueDate, Id) VALUES
('4B-9C-6D-09-C0-C3','2017-01-11', 's1404326303'),
('76-37-47-F0-2D-98','2018-05-14', 's0852437381'),
('51-7E-BA-E5-15-F6','2018-08-09', 's5332613405'),
('66-CB-11-81-0F-70','2017-12-05', 's0093188549'),
('E4-24-1A-2F-FE-78','2018-07-16', 's3357087510'),
('90-FF-D9-5A-A6-BB', '2018-01-20', 's1404326303'),
('E0-52-35-F7-B1-B5', '2018-03-27', 's0852437381'),
('51-64-DE-7B-3B-D0', '2017-11-30', 's5332613405');
End;

