using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Interfaces;

namespace Sigpe.Backend.Application.Validation
{
    public class UsuarioServiceValidator : IUsuarioServiceValidator
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServiceValidator(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Validar(UsuarioDto dto)
        {
            ValidarObjetoNulo(dto);
            ValidarCamposObrigatorios(dto);
            await ValidarUsuarioExistentePorEmail(dto);
            await ValidarUsuarioExistentePorTipo(dto);
        }

        private void ValidarObjetoNulo(UsuarioDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
        }

        private void ValidarCamposObrigatorios(UsuarioDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
            {
                throw new Exception($"{nameof(dto.Email)} é obrigatório.");
            }

            if (string.IsNullOrEmpty(dto.Senha))
            {
                throw new Exception($"{nameof(dto.Senha)} é obrigatório.");
            }

            if (!dto.PessoaId.HasValue)
            {
                throw new Exception($"{nameof(dto.PessoaId)} é obrigatório.");
            }

            if (!dto.TipoUsuario.HasValue)
            {
                throw new Exception($"{nameof(dto.TipoUsuario)} é obrigatório.");
            }
        }

        private async Task ValidarUsuarioExistentePorEmail(UsuarioDto dto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(dto.Email);

            if (usuario != null )
            {
                throw new Exception("Já existe um usuário cadastrado com este e-mail.");
            }
        }

        private async Task ValidarUsuarioExistentePorTipo(UsuarioDto dto)
        {
            var usuario = await _usuarioRepository.GetByPessoaIdTipoAsync(dto.PessoaId ?? 0, dto.TipoUsuario ?? 0);

            if (usuario != null)
            {
                throw new Exception("Já existe um usuário cadastrado para esta pessoa.");
            }
        }
    }
}
