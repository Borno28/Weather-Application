create table admin1
(
		id int primary key identity(1,1),
		email varchar(max) null,
		username varchar(max) null,
		passowrd varchar(max) null,
		date_created date null

)
select * from admin1