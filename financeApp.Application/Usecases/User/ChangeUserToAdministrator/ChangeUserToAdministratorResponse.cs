using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.User.ChangeUserToAdministrator;

public class ChangeUserToAdministratorResponse(int Id, string FullName, string Email, UserLevelEnum Level, UserStatusEnum Status);