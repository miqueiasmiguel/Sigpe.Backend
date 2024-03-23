namespace Sigpe.Backend.Application.Interfaces.Validation
{
    public interface IServiceValidatorValidator<T>
    {
        void Validar(T dto);
    }
}
