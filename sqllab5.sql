drop table users;
create table users(
	id serial,
	login varchar,
	password varchar,
	level int
);
insert into users(login, password, level) values ('alex', 'alex', 1);
insert into users(login, password, level) values ('manager', 'manager', 3);
insert into users(login, password, level) values ('kamedan', 'kamedan', 2);

drop table rooms;
create table rooms(
	id_room serial,
	number integer,
	roomtype integer
);
insert into rooms(number, roomtype) values (101, 2);
insert into rooms(number, roomtype) values (312, 1);
insert into rooms(number, roomtype) values (412, 1);
select * from rooms;

drop table students;
create table students(
	id_student serial,
	name varchar,
	groupStudent varchar,
	studentCode varchar,
	id_room integer,
	date varchar,
	id_user integer
);
insert into Students(name, groupStudent, studentCode, id_room, date)
values ('Alex', 'IU7-64', '1234321', 1, 'Jan 01 2023', 1);
select * from students;

drop table things;
create table things(
	id_thing serial,
	code integer,
	type varchar,
	id_room integer,
	id_student integer
);
insert into things(code, type, id_room, id_student) values (1234321, 'Table', 1, -1);
insert into things(code, type, id_room, id_student) values (1234321, 'Table', 2, 1);
select * from things where code = 12345;