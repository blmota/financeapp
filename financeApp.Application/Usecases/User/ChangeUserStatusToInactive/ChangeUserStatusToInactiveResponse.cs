using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToInactive;

public class ChangeUserStatusToInactiveResponse(int Id, string FullName, string Email, UserLevelEnum Level, UserStatusEnum Status);