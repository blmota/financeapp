using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.User.ChangeUserToManager;

public class ChangeUserToManagerResponse(int Id, string FullName, string Email, UserLevelEnum Level, UserStatusEnum Status);