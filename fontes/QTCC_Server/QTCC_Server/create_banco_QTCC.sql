create database QTCC

use QTCC

--Tabela de usuário
create table tbUsuario
(
	 usu_id bigint identity(1,1)	--ID único de usuário (interno do sistema)
	,usu_nome varchar(100)			--Nome de exibição do usuário
	,usu_email varchar(100)			--E-mail do usuário
	,usu_senha varchar(50)			--Senha do usuário
	,usu_imagem image				--Imagem do usuário (salvos os bytes desta)
	,usu_mensagem varchar(100)		--Mensagem de perfil do usuário
)
alter table usuario add constraint PK_Usuario primary key (usu_id)

--Tabela de lista de contatos (Contatos)
create table tbContatos
(
	 usu_id bigint --ID do usuário
	,cont_id bigint --ID do contato da pessoa (Pessoa ou Grupo)
)
alter table tbContatos add constraint PK_Contatos primary key (usu_id)

--Tabela de mensagens a ser entregues
create table tbMensagensPendentes
(
	 usu_id bigint --ID do usuário
	,msg_usu_ori bigint --Usuário que enviou a mensagem
	,msg_dta_envio datetime --Data de envio da mensagem (data que a mensagem foi recebida pelo servidor)
	,msg_texto varchar(1000) --Mensagem a ser enviada
)
alter table tbMensagensPendentes add constraint PK_MensagensPendentes primary key (usu_id,msg_usu_ori,msg_dta_envio)

--Tabela de membros de um grupo
create table tbMembrosGrupo
(
	 usu_id bigint	--ID do grupo
	,memb_id bigint	--ID do membro
)
alter table tbMembrosGrupo add constraint PK_MembrosGrupo primary key (usu_id)