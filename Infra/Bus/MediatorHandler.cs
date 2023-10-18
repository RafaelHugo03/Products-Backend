using Domain.Commands;
using FluentValidation.Results;
using MediatR;

namespace Infra.Bus
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediatr;

        public MediatorHandler(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }
        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await mediatr.Send(command);
        }
    }
}