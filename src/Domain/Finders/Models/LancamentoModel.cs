using System;
using System.Collections.Generic;

namespace Domain.Finders.Models
{
    public class LancamentoModel
    {
        public IEnumerable<LancamentoTransacaoModel> Transacoes { get; set; }
        public decimal Saldo { get; set; }
    }

    public class LancamentoTransacaoModel
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}