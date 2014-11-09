--create database QTCC
--drop database QTCC
use QTCC

--Tabela de contato (base para usu�rio e grupo)
create table tbContato
(
	 cont_id int identity(1,1)		--ID �nico do contato (grupo ou usu�rio) (interno do sistema)
	,cont_nome varchar(100) not null--Nome de exibi��o do usu�rio
	,cont_foto image				--Imagem do usu�rio (salvos os bytes desta)
	,cont_inativo bit not null		--Contato inativo (Removido)
)
alter table tbContato add constraint PK_Contato primary key (cont_id)

--Tabela de usu�rio
create table tbUsuario
(
	 cont_id int not null			--ID do usu�rio
	--Exclusivo de Usuario
	,usu_email varchar(100) not null--E-mail do usu�rio
	,usu_senha varchar(50) not null	--Senha do usu�rio
	,usu_texto_status varchar(100)	--Mensagem de perfil do usu�rio

)
alter table tbUsuario add constraint FK_Usuario_Contato foreign key (cont_id) references tbContato (cont_id)

--Tabela de grupo
create table tbGrupo
(
	 cont_id int not null				--ID do grupo
	--Exclusivo de Grupo
	,grp_administrador int not null	--ID do administrador do grupo
)
alter table tbGrupo add constraint FK_Grupo_Contato foreign key (cont_id) references tbContato (cont_id)
alter table tbGrupo add constraint FK_Administrador_Grupo_Contato foreign key (grp_administrador) references tbContato (cont_id)

--Tabela de lista de contatos (Contatos), seja de um usu�rio ou grupo
create table tbListaContatos
(
	 cont_id int not null--ID do usu�rio
	,lst_id int not null	--ID do contato da pessoa (Pessoa ou Grupo)
)
alter table tbListaContatos add constraint PK_ListaContatos primary key (cont_id,lst_id)
alter table tbListaContatos add constraint FK_ListaContatos_Contato foreign key (cont_id) references tbContato (cont_id)
alter table tbListaContatos add constraint FK_Usuario_ListaContatos_Contato foreign key (lst_id) references tbContato (cont_id)

--Tabela tempor�ria de mensagens a ser entregues
create table tmpMensagensPendentes
(
	 cont_id int	not null		--ID do contato a receber as mensagens
	,msg_usu_ori int not null		--Usu�rio que enviou a mensagem
	,msg_dta_envio datetime	not null--Data de envio da mensagem (data que a mensagem foi recebida pelo servidor)
	,msg_texto image not null		--Bytes da mensagem a ser enviada (texto, m�dia)
	,msg_tamanho int				--Tamanho da m�dia (para imagem, �udio, v�deo)
)
alter table tmpMensagensPendentes add constraint PK_MensagensPendentes primary key (cont_id,msg_usu_ori,msg_dta_envio)
alter table tmpMensagensPendentes add constraint FK_MensagensPendentes_Contato foreign key (cont_id) references tbContato (cont_id)

create table tmpUsuariosLogados
(
	 cont_id int not null				--ID do contato
	--,log_ip varchar(20) not null		--IP da m�quina onde est� conectado (para o caso de estar logado em v�rios lugares
	,log_visto_ultimo datetime not null	--"Visto por �ltimo" do contato
)
alter table tmpUsuariosLogados add constraint PK_UsuariosLogados primary key (cont_id/*,log_ip*/)
go

--create table tbMensagens
--(
--	 msg_id int not null
--	,cont_de int not null
--	,cont_para int not null
--	,msg_dta_envio datetime not null
--	,msg_dados image not null
--	,msg_tipo_mensagem int not null
--	,msg_cont_de_deletou bit not null
--	,msg_cont_para_deletou bit not null
--)
---------------------------------------------------------------
--------------------Stored Procedures--------------------------
---------------------------------------------------------------
if exists (select * from sys.procedures where name = 'spInsereUsuario' and is_ms_shipped=0)
	drop procedure spInsereUsuario
go

-- =============================================
-- Author:		Ricardo Petr�re
-- Create date: 05/11/2014
-- Description:	Procedure respons�vel por inserir
-- um novo usu�rio no banco de dados.
-- =============================================
create procedure spInsereUsuario
(
	@Cont_Nome			varchar(100),
	@Cont_Foto			image,
	@Usu_Email			varchar(100),
	@Usu_Senha			varchar(50),
	@Usu_Texto_Status	varchar(100),
	@Cont_Id			int output
)
as
begin
	declare @cont_inativo bit = 0  -- Por raz�es �bvias, cont_inativo vai com default = false
	set @Cont_Id = -1

	--Valida o E-mail informado.
	--� uma valida��o bem simples. N�o est� em branco, possui '@', '.' e algo antes e depois de ambos?
	--Passou.
	begin
		--http://stackoverflow.com/questions/15709712/what-is-best-way-to-get-last-indexof-character-in-sql
		set @Usu_Email = RTRIM(LTRIM(@Usu_Email))
		declare @index_@ int = PATINDEX('%@%',reverse(@Usu_Email))
		declare @index_ponto int = PATINDEX('%.%',reverse(@Usu_Email))
		declare @length_email int = LEN(@Usu_Email)
		if(@length_email<1) or (@index_ponto<1) or (@index_@<@index_ponto+2) or (@index_@=@length_email)
		begin;
			throw 51000,'E-mail inv�lido. O formato de e-mail deve ser <usuario>@<provedor>.<abrang�ncia (ex: com, co.uk)>',1
		end
	end

	--Checa se j� existe outro contato com o mesmo e-mail.
	if exists (select 'x' from tbUsuario where usu_email = @Usu_Email)
	begin;
		throw 51000,'E-mail j� utilizado',1
	end

	--Checa se o nome foi passado em branco
	if (LEN(RTRIM(LTRIM(@Cont_Nome)))<1)
	begin;
		throw 51000,'� necess�rio inserir um nome de usu�rio',1
	end

	begin transaction
	begin try
		insert into tbContato(cont_nome,Cont_Foto,cont_inativo)
		values(@Cont_Nome,@Cont_Foto,0)
		set @Cont_Id = @@IDENTITY

		insert into tbUsuario(cont_id,usu_email,usu_senha,usu_texto_status)
		values(@Cont_Id,@Usu_Email,@Usu_Senha,@Usu_Texto_Status)
		commit transaction
	end try
	begin catch
		rollback transaction;
		throw 51000,'Falha na inser��o do contato',1
	end catch
end
go
