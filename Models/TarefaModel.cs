using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetApi.enums;

namespace FirstDotNetApi.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}