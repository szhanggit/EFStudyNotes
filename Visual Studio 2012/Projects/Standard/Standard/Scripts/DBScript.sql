use AdventureWorksLT2008


if OBJECT_ID('testDetail', 'U') is not null
drop table testDetail
if Object_id('testHeader', 'U') is not null
drop table testHeader

create table testHeader
(
	id int not null identity(1,1),
	name varchar(50) null,
	headerGUID varchar(50) not null default newid(),
	ModifiedDate datetime not null default getdate(),
	Active bit not null default 1,	
	constraint pk_testHeader primary key (id)
);



create table testDetail
(
	id int not null identity(1,1),
	testid int not null constraint fk_testDetail Foreign Key references testHeader(id),
	qty int not null default 0,
	ModifiedDate datetime not null default getdate(),
	detailGUID varchar(50) not null default newid(),
	constraint pk_testDetail primary key (id)
);

select * from testHeader
select * from testDetail

if OBJECT_ID('spCreateTest', 'P') is not null
drop proc spCreateTest

create procedure spCreateTest
@testid int out,
@name varchar(50),
@qty int
AS
begin transaction
insert into testHeader (name) values (@name);
select @testid = scope_identity();
if @@Error <> 0 goto ErrorHandler

insert into testDetail (testid, qty) values (@testid, @qty);
if @@Error <> 0 goto ErrorHandler
commit transaction
return

ErrorHandler:
rollback transaction
return