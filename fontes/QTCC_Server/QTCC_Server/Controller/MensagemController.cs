﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QTCC_Server.DAO;
using QTCC_Server.VO;

namespace QTCC_Server.Controller
{
    class MensagemController : EntidadeBaseController<Mensagem>
    {
        public override int Insere(Mensagem entidade)
        {
            throw new NotImplementedException();
        }

        public override int Altera(Mensagem entidade)
        {
            throw new NotImplementedException();
        }

        public override int Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public override Mensagem Busca(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Mensagem> Lista()
        {
            throw new NotImplementedException();
        }

        public int InsereMensagem(Mensagem mensagem)
        {
            throw new NotImplementedException();
        }

        public Mensagem BuscaMensagem(int id_mensagem)
        {
            throw new NotImplementedException();
        }

        public List<Mensagem> ListaMensagensPorStatus(CONSTANTES.StatusEnvioEnum status_envio)
        {
            throw new NotImplementedException();
        }

        public int DeletaMensagemParaContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        internal List<Mensagem> ReceberNovasMensagens(int cont_id)
        {
            throw new NotImplementedException();
        }

        internal string EnviarNovaMensagem(Mensagem mensagem)
        {
            throw new NotImplementedException();
        }

        internal string StatusMensagem(int p)
        {
            throw new NotImplementedException();
        }
    }
}
