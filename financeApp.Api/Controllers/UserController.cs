using financeApp.Application.Usecases.User.CreateUser;
using financeApp.Application.Usecases.User.DeleteUser;
using financeApp.Application.Usecases.User.GetById;
using financeApp.Application.Usecases.User.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace financeApp.Api.Controllers;

[ApiController]
[Route("v1")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpGet("user/{id}")]
    public async Task<IResult> GetById(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var command = new GetUserByIdCommand(id);

        var result = await sender.Send(
            command,
            cancellationToken);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    }

    [HttpPost("user")]
    public async Task<IResult> Create(
        CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            command,
            cancellationToken);

        return result.IsSuccess
            ? Results.Created(
                $"/v1/users/{result.Value.Id}",
                result.Value)
            : Results.BadRequest(result.Error);
    }
    
    [HttpPut("user/{id}")]
    public async Task<IResult> Update(
        int id,
        UpdateUserCommand command,
        CancellationToken cancellationToken)
    {
        command = command  with { Id = id };
        
        var result = await sender.Send(
            command,
            cancellationToken);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    }
    
    [HttpDelete("user/{id}")]
    public async Task<IResult> Delete(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);
        
        var result = await sender.Send(
            command,
            cancellationToken);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    }
}