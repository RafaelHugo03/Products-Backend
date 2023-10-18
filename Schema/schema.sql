create database "Products-APP"

use "Products-APP"

create table "user"(
	id uniqueidentifier,
	name varchar(150) not null,
	email varchar(150) not null,
	cpf varchar(150) not null,
	created_at datetime not null,
	
	constraint PK_USER primary key(id)
);
go

create table "product"(
	id uniqueidentifier,
	name varchar(150) not null,
	price decimal(18,0) not null,
	user_id uniqueidentifier not null,
	created_at datetime not null,
	
	constraint PK_PRODUCT primary key(id),
	constraint FK_product_user_user_id foreign key (user_id) references "user"(id)
)
go