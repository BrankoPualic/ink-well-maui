﻿using Microsoft.AspNetCore.Http;

namespace InkWell.MAUI.Business.Dtos.Auth;

public class SignupDto
{
	public string Username { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string Password { get; set; } = string.Empty;

	public string ConfirmPassword { get; set; } = string.Empty;

	public IFormFile? ProfilePicture { get; set; }

	public DateOnly DateOfBirth { get; set; }
}