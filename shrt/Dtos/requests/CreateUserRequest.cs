namespace shrt.Dtos.requests;

public record CreateUserRequest(
    string Username,
    string Password,
    string ConfirmPassword,
    string PhoneNumber);