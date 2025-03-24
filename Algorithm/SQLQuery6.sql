use student_records

select * from students order by name asc;

select * from students where id >= 101 and id <= 103;

select * from students where id in (104, 107);

select * from students where id between 102 and 104;

select * from students where id = 104 or id = 105;

select * from students where id is not null;

select * from students where name like 'j%';

select * from students where name like 's%h';

select * from students where name like '%s';

select * from students where name like '%s_';

select * from students where id is not null;

select * from students order by id asc offset 2 rows fetch next 3 rows only;

select top 3 * from students;
