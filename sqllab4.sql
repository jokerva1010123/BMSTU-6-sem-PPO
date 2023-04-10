drop table users;
create table users(
	id integer,
	login varchar,
	password varchar,
	level int
);
insert into users(id, login, password, level) values (1, 'alex', 'alex', 1);

drop table rooms;
create table rooms(
	id_room integer,
	number integer,
	roomtype integer
);
insert into rooms(id_room, number, roomtype) values (1, 312, 1);
insert into rooms(id_room, number, roomtype) values (2, 12, 1);
select * from rooms;

drop table students;
create table students(
	id_student integer,
	name varchar,
	groupStudent varchar,
	studentCode varchar,
	id_room integer,
	date varchar
);
insert into Students(id_student, name, groupStudent, studentCode, id_room, date)
values (1, 'Alex', 'IU7-64', '1234321', 1, 'Jan 01 2023');
select * from students;

drop table things;
create table things(
	id_thing integer,
	code integer,
	type varchar,
	id_room integer,
	id_student integer
);
insert into things(id_thing, code, type, id_room, id_student) values (1, 1234321, 'Table', 1, 1);
select * from things;