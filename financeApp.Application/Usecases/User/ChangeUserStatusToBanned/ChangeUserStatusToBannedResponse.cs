using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToBanned;

public class ChangeUserStatusToBannedResponse(int Id, string FullName, string Email, UserLevelEnum Level, UserStatusEnum Status);