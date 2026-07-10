using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.User.ChangeUserToClient;

public class ChangeUserToClientResponse(int Id, string FullName, string Email, UserLevelEnum Level, UserStatusEnum Status);