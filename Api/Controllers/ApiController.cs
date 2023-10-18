using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly ICollection<string> errors = new List<string>();

        private ActionResult CustomResponse(object? result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", errors.ToArray() }
            }));
        }
        
        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool IsOperationValid()
        {
            return !errors.Any();
        }

        protected void AddError(string erro)
        {
            errors.Add(erro);
        }
    }
}