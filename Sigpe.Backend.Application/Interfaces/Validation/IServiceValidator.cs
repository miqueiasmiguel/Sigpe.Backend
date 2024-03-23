namespace Sigpe.Backend.Application.Interfaces.Validation
{
    public interface IServiceValidator<T>
    {
        Task Validar(T dto);
    }
}
