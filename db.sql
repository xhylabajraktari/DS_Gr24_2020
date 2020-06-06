drop database if exists `keys`;
create database `keys`;
use `keys`;

create table shfrytezuesit
(
    perdoruesi     varchar(40) null,
    password       text        null,
    salt           text        null
);