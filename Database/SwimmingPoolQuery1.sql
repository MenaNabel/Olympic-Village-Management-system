create database swimmingPool
use swimmingPool
create table customer(
ID int IDENTITY(1,1),
ssna nvarchar(14) ,
first_name nvarchar(255) not null,
last_name nvarchar(255) not null,
Number_of_member int,
phone nvarchar(11) not null,
strat_subscription date not null,
Num_of_receipt nvarchar(MAX),
school_ID int not null,
primary key(ID,ssna)
);
create table activity(
ID int IDENTITY(1,1),
name nvarchar(MAX),
primary key(ID)
);

create table customer_activity(
customer_ssna nvarchar(14) not null,
foreign key(customer_ssna) references customer(ssna),
activity_ID int not null,
foreign key(activity_ID) references activity(ID)
);
create table type_school(
number int IDENTITY(1,1),
period decimal,
time time not null,
num_of_intervals int not null,
value_in decimal,
value_out decimal,
primary key(number)
);
create table school(
ID int IDENTITY(1,1),
name nvarchar(MAX),
number_type int not null,
foreign key(number_type) references type_school(number),
activity_ID int not null,
foreign key(activity_ID) references activity(ID),
);
create table trainer(
ID int IDENTITY(1,1),
ssna nvarchar(14) not null unique,
name nvarchar(MAX) not null,
salary decimal not null,
number_customer int not null,
primary key(ID)
);
create table school_trainer(
trainer_ID int not null,
foreign key(trainer_ID) references trainer(ID),
school_ID int not null,
foreign key(school_ID) references school(ID),
);
alter table customer add primary key(ssna)
alter table school add primary key(ID)
alter table customer add foreign key(school_ID) references school(ID)
