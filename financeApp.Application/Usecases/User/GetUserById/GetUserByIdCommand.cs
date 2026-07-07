using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.GetById;

public sealed record GetUserByIdCommand(int id) : IRequest<Result<GetUserByIdResponse>>;