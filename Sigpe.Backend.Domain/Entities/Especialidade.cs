﻿namespace Sigpe.Backend.Domain.Entities
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<Medico> Medicos { get; set; }
    }
}
