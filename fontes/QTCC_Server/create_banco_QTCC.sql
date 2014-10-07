create database QTCC

use QTCC

create table usuario
(
	id bigint primary key identity(1000000,1)
	,nome_usuario varchar(100)
	,email varchar(1000)
	,senha varchar(50)
	,imagem_perfil image
)