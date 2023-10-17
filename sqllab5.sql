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
insert into users(login, password, level) values ('bob', 'bob', 1);
select * from Users;

drop table rooms;
create table rooms(
	id_room serial,
	number integer,
	roomtype integer
);
insert into rooms(number, roomtype) values (101, 2);
insert into rooms(number, roomtype) values (301, 1);
insert into rooms(number, roomtype) values (401, 1);
insert into rooms(number, roomtype) values (302, 1);
insert into rooms(number, roomtype) values (402, 1);
insert into rooms(number, roomtype) values (303, 1);
insert into rooms(number, roomtype) values (403, 1);
insert into rooms(number, roomtype) values (304, 1);
insert into rooms(number, roomtype) values (404, 1);
insert into rooms(number, roomtype) values (305, 1);
insert into rooms(number, roomtype) values (405, 1);
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
insert into Students(name, groupStudent, studentCode, id_room, date, id_user)
values ('Alex', 'IU7-64', '1234321', 2, 'Jan 01 2023', 1), 
('Bob', 'IU7-63', '1233321', 3, 'Dec 01 2022', 4);
select * from students;

drop table things;
create table things(
	id_thing serial,
	code integer,
	type varchar,
	id_room integer,
	id_student integer
);
insert into things(code, type, id_room, id_student) values (1233321, 'Table', 1, -1);
insert into things(code, type, id_room, id_student) values (1234321, 'Table', 2, 1);
insert into things(code, type, id_room, id_student) values (1235321, 'Table', 3, 2);
insert into things(code, type, id_room, id_student) values (2233321, 'Chair', 1, -1);
insert into things(code, type, id_room, id_student) values (2234321, 'Chair', 2, 1);
insert into things(code, type, id_room, id_student) values (2235321, 'Chair', 3, 2);
insert into things(code, type, id_room, id_student) values (3233321, 'Bed', 1, -1);
insert into things(code, type, id_room, id_student) values (3234321, 'Bed', 2, 1);
insert into things(code, type, id_room, id_student) values (3235321, 'Bed', 3, 2);
select * from things;

drop table if exists Reports;
create table Reports (
	id_report serial,
	code_student varchar,
	room_number integer,
	status integer,
	information varchar
);