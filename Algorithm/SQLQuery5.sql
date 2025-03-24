create database student_records
use student_records

create table students (
    id int primary key not null,
    name varchar(100) not null,
    course varchar(50),
    grade varchar(2),
    marks int
)

insert into students (id, name, course, grade, marks)
values
(101, 'john doe', 'mathematics', 'a', 85),
(102, 'jane smith', 'physics', 'b', 70),
(103, 'emma brown', 'biology', 'a', 90),
(104, 'david wilson', 'chemistry', 'c', 60),
(105, 'sophia lee', 'physics', 'b', 75),
(106, 'michael clark', 'mathematics', 'a', 95),
(107, 'olivia scott', 'chemistry', 'b', 80),
(108, 'james harris', 'biology', 'a', 88)

select count(id) as no_of_students from students

select min(marks) as minimum_marks from students

select max(marks) as maximum_marks from students

select avg(marks) as average_marks from students

select sum(marks) as total_marks from students

select course, count(id) as no_of_students from students
group by course

select course, count(id) as no_of_students, marks
from students
group by course, marks
having marks <= 75




