﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notification = new List<Notifies>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notification;

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notification.Add(new Notifies {
                    Mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            if(valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notification.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {
            if(valor <= 0 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notification.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

    }
}