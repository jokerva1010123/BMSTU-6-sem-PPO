drop table users;
create table users(
	id serial,
	login varchar,
	password varchar,
	level int
);
insert into users(login, password, level) values ('alex', 'alex', 1);

drop table rooms;
create table rooms(
	id_room serial,
	number integer,
	roomtype integer
);
insert into rooms(number, roomtype) values (312, 1);
select * from rooms;

drop table students;
create table students(
	id_student serial,
	name varchar,
	groupStudent varchar,
	studentCode varchar,
	id_room integer,
	date varchar
);
insert into Students(name, groupStudent, studentCode, id_room, date)
values ('Alex', 'IU7-64', '1234321', 1, 'Jan 01 2023');
select * from students;

drop table things;
create table things(
	id_thing serial,
	code integer,
	type varchar,
	id_room integer,
	id_student integer
);
insert into things(code, type, id_room, id_student) values (1234321, 'Table', 1, 1);
select * from things;