use student_records

create table courses (
    course_id int primary key,
    instructor_name varchar(100),
    id int,
    foreign key (id) references students(id)
)

insert into courses (course_id, instructor_name, id)
values
(1, 'dr. smith', 101),
(2, 'dr. johnson', 102), 
(3, 'dr. clark', 103), 
(4, 'dr. lee', 104),   
(5, 'dr. brown', 105), 
(6, 'dr. davis', 106), 
(7, 'dr. wilson', 107),
(8, 'dr. harris', 108)


select s.id, s.name, c.course_id, c.instructor_name
from students s
inner join courses c on s.id = c.id;

select s.id, s.name, c.course_id, c.instructor_name
from students s
left join courses c on s.id = c.id;

select s.id, s.name, c.course_id, c.instructor_name
from students s
right join courses c on s.id = c.id;

select s.id, s.name, c.course_id, c.instructor_name
from students s
full outer join courses c on s.id = c.id;

select s.name,(select count(*) from courses c where c.id = s.id) as course_count
from students s

select s.id, s.name from students s
where s.id in (select c.id from courses c where c.course_id = 1)

select s.id, s.name from students s
where exists (select 1 from courses c where c.id = s.id)

