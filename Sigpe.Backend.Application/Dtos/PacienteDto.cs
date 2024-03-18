namespace Sigpe.Backend.Application.Dtos
{
    public class PacienteDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public int? PlanoSaudeId { get; set; }
    }
}
