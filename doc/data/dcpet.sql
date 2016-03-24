/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2016/3/24 11:12:44                           */
/*==============================================================*/


drop table if exists Dc_Area;

drop table if exists Dc_Pet;

drop table if exists Dc_PetType;

drop table if exists Dc_Pet_Image;

drop table if exists Dc_User;

drop table if exists Dc_UserData;

/*==============================================================*/
/* Table: Dc_Area                                               */
/*==============================================================*/
create table Dc_Area
(
   id                   int not null auto_increment,
   no                   varchar(32) not null,
   name                 varchar(500) not null,
   primary key (id)
);

/*==============================================================*/
/* Table: Dc_Pet                                                */
/*==============================================================*/
create table Dc_Pet
(
   id                   int not null auto_increment,
   pettype              int not null,
   name                 varchar(102) not null,
   sex                  int not null,
   date                 datetime not null,
   area                 varchar(32) not null,
   address              varchar(500),
   firsttime            datetime not null,
   lasttime             datetime,
   token                char(36) not null,
   demand               varchar(2000),
   disable              bit(1) not null,
   primary key (id)
);

/*==============================================================*/
/* Table: Dc_PetType                                            */
/*==============================================================*/
create table Dc_PetType
(
   id                   int not null auto_increment,
   pettype              varchar(500) not null,
   type                 int,
   primary key (id)
);

/*==============================================================*/
/* Table: Dc_Pet_Image                                          */
/*==============================================================*/
create table Dc_Pet_Image
(
   id                   int not null auto_increment,
   petid                int not null,
   image                varchar(500) not null,
   firsttime            datetime not null,
   primary key (id)
);

/*==============================================================*/
/* Table: Dc_User                                               */
/*==============================================================*/
create table Dc_User
(
   token                char(36) not null,
   uuid                 varchar(102) not null,
   device               varchar(102) not null,
   platform             varchar(102) not null,
   firstip              varchar(102) not null,
   lastip               varchar(102),
   firsttime            datetime not null,
   lasttime             datetime,
   disable              bit(1) not null,
   primary key (token)
);

/*==============================================================*/
/* Table: Dc_UserData                                           */
/*==============================================================*/
create table Dc_UserData
(
   token                char(36) not null,
   phonenumber          varchar(102) not null,
   name                 varchar(102) not null,
   primary key (token)
);

