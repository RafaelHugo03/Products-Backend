using Domain.Commands;
using FluentValidation.Results;

namespace Infra.Bus
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}