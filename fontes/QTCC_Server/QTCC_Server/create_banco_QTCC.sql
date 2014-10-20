--create database QTCC
--drop database QTCC
use QTCC

--Tabela de contato (base para usu�rio e grupo)
create table tbContato
(
	 cont_id bigint identity(1,1)	--ID �nico do contato (grupo ou usu�rio) (interno do sistema)
	,cont_nome varchar(100) not null--Nome de exibi��o do usu�rio
	,cont_imagem image				--Imagem do usu�rio (salvos os bytes desta)
	,cont_inativo bit not null		--Contato inativo (Removido)
)
alter table tbContato add constraint PK_Contato primary key (cont_id)

--Tabela de usu�rio
create table tbUsuario
(
	 cont_id bigint not null			--ID do usu�rio
	--Exclusivo de Usuario
	,usu_email varchar(100) not null	--E-mail do usu�rio
	,usu_senha varchar(50) not null		--Senha do usu�rio
	,usu_mensagem_perfil varchar(100)	--Mensagem de perfil do usu�rio

)
alter table tbUsuario add constraint FK_Usuario_Contato foreign key (cont_id) references tbContato (cont_id)

--Tabela de grupo
create table tbGrupo
(
	 cont_id bigint not null			--ID do grupo
	--Exclusivo de Grupo
	,grp_administrador bigint not null	--ID do administrador do grupo
)
alter table tbGrupo add constraint FK_Grupo_Contato foreign key (cont_id) references tbContato (cont_id)
alter table tbGrupo add constraint FK_Administrador_Grupo_Contato foreign key (grp_administrador) references tbContato (cont_id)

--Tabela de lista de contatos (Contatos), seja de um usu�rio ou grupo
create table tbListaContatos
(
	 cont_id bigint not null--ID do usu�rio
	,lst_id bigint not null	--ID do contato da pessoa (Pessoa ou Grupo)
)
alter table tbListaContatos add constraint PK_ListaContatos primary key (cont_id,lst_id)
alter table tbListaContatos add constraint FK_ListaContatos_Contato foreign key (cont_id) references tbContato (cont_id)
alter table tbListaContatos add constraint FK_Usuario_ListaContatos_Contato foreign key (lst_id) references tbContato (cont_id)

--Tabela tempor�ria de mensagens a ser entregues
create table tmpMensagensPendentes
(
	 cont_id bigint	not null		--ID do contato a receber as mensagens
	,msg_usu_ori bigint not null	--Usu�rio que enviou a mensagem
	,msg_dta_envio datetime	not null--Data de envio da mensagem (data que a mensagem foi recebida pelo servidor)
	,msg_texto image not null		--Bytes da mensagem a ser enviada (texto, m�dia)
	,msg_tamanho int				--Tamanho da m�dia (para imagem, �udio, v�deo)
)
alter table tmpMensagensPendentes add constraint PK_MensagensPendentes primary key (cont_id,msg_usu_ori,msg_dta_envio)
alter table tmpMensagensPendentes add constraint FK_MensagensPendentes_Contato foreign key (cont_id) references tbContato (cont_id)

create table tmpUsuariosLogados
(
	 cont_id bigint not null			--ID do contato
	--,log_ip varchar(20) not null		--IP da m�quina onde est� conectado (para o caso de estar logado em v�rios lugares
	,log_visto_ultimo datetime not null	--"Visto por �ltimo" do contato
)
alter table tmpUsuariosLogados add constraint PK_UsuariosLogados primary key (cont_id/*,log_ip*/)