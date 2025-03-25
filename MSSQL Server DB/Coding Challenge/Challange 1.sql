CREATE database crime_management

USE crime_management

CREATE table crime(
crimeID int primary key not null,
incidenttype varchar(255),
incidentdate date,
location varchar(255),
description text,
status varchar(20))

CREATE table victim(
victimID int primary key not null,
crimeID int,
name varchar(255),
contactinfo varchar(225),
injuries varchar(255),
foreign key(crimeID) references crime(crimeID))

CREATE table suspect(
suspectID int primary key not null,
crimeID int,
name varchar(255),
description text,
criminalhistory text,
foreign key(crimeID) references crime(crimeID))

SELECT * FROM crime

INSERT INTO Crime (CrimeID, IncidentType, IncidentDate, Location, Description, Status) VALUES 
    (1, 'Robbery', '2023-09-15', '123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'), 
    (2, 'Homicide', '2023-09-20', '456 Elm St, Townsville', 'Investigation into a murder case', 'Under Investigation'), 
    (3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed'); 

INSERT INTO Victim (VictimID, CrimeID, Name, ContactInfo, Injuries) VALUES 
    (1, 1, 'John Doe', 'johndoe@example.com', 'Minor injuries'), 
    (2, 2, 'Jane Smith', 'janesmith@example.com', 'Deceased'), 
    (3, 3, 'Alice Johnson', 'alicejohnson@example.com', 'None');
	
INSERT INTO Suspect (SuspectID, CrimeID, Name, Description, CriminalHistory) VALUES 
	(1, 1, 'Robber 1', 'Armed and masked robber', 'Previous robbery convictions'), 
	(2, 2, 'Unknown', 'Investigation ongoing', NULL), 
	(3, 3, 'Suspect 1', 'Shoplifting suspect', 'Prior shoplifting arrests'); 

ALTER TABLE Victim add age int;
UPDATE victim SET age = 29 WHERE victimid = 1;
UPDATE victim SET age = 35 WHERE victimid = 2;
UPDATE victim SET age = 42 WHERE victimid = 3;

ALTER TABLE Suspect add age int;
UPDATE suspect SET age = 41 WHERE suspectid = 1;
UPDATE suspect SET age = 27 WHERE suspectid = 2;
UPDATE suspect SET age = 38 WHERE suspectid = 3;

SELECT * FROM crime 
WHERE status='open'

SELECT COUNT(crimeID) AS total_incidents FROM crime

SELECT DISTINCT IncidentType FROM crime

SELECT * FROM crime
WHERE IncidentDate BETWEEN '2023-09-01' AND '2023-09-10'

SELECT name,age FROM victim 
UNION ALL
SELECT name,age FROM suspect
ORDER BY age desc

SELECT AVG(age) AS avg_age FROM victim
UNION
SELECT AVG(age) AS avg_age FROM suspect

SELECT IncidentType,COUNT(IncidentType) AS Count FROM  crime
WHERE status='OPEN'
GROUP BY IncidentType

SELECT name FROM victim
WHERE name LIKE '%Doe%'
UNION ALL
SELECT name FROM Suspect
WHERE name LIKE '%Doe%';

SELECT v.name, c.status FROM victim v
JOIN crime c ON v.crimeID = c.crimeID
WHERE c.status IN('open','closed')
UNION
SELECT s.name, c.status FROM Suspect s
JOIN Crime c ON s.crimeID = c.crimeID
WHERE c.status IN('open','closed')

SELECT DISTINCT c.incidentType FROM crime c
JOIN victim v ON c.crimeID = v.crimeID
WHERE v.age IN (30, 35)
UNION
SELECT DISTINCT c.incidentType FROM crime c
JOIN suspect s ON c.crimeID = s.crimeID
WHERE s.age IN (30, 35)

SELECT v.name, c.incidenttype FROM victim v
JOIN crime c ON v.crimeID = c.crimeID
WHERE c.incidenttype='robbery'
UNION
SELECT s.name, c.incidenttype FROM Suspect s
JOIN Crime c ON s.crimeID = c.crimeID
WHERE c.incidenttype='robbery'

SELECT IncidentType FROM crime
WHERE status = 'open'
GROUP BY IncidentType
HAVING COUNT(*) > 1;

SELECT c.* FROM crime c
JOIN suspect s ON c.crimeID = s.crimeID
JOIN victim v ON s.name = v.name

select c.crimeID,c.incidentType,v.name as VictimName,s.name as SuspectName from crime c
join victim v on c.crimeID = v.crimeID
join suspect s on c.crimeID = s.crimeID;

SELECT c.* FROM Crime c
JOIN suspect s ON c.crimeID = s.crimeID
WHERE s.age > (SELECT MAX(v.age) FROM victim v WHERE v.crimeID = c.crimeID) 

SELECT name,COUNT(*) AS IncidentCount FROM suspect
GROUP BY name
HAVING COUNT(*)>1

SELECT c.CrimeID,c.IncidentType from crime c
JOIN suspect s ON s.crimeID=c.crimeID
WHERE s.name='unknown'

SELECT c.* FROM crime c
WHERE EXISTS (SELECT 1 FROM crime WHERE IncidentType = 'homicide')
AND NOT EXISTS (SELECT 1 FROM crime WHERE IncidentType NOT IN ('homicide','robbery'))

SELECT c.crimeID,c.IncidentType,ISNULL(s.name,'No Suspect') AS SuspectName FROM crime c
LEFT JOIN suspect s ON c.crimeID = s.crimeID

SELECT suspectID,name,incidenttype FROM suspect
JOIN crime ON crime.crimeID=suspect.crimeID
WHERE incidenttype IN('robbery','assault')
