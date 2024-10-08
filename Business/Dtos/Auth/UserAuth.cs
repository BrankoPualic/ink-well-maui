﻿namespace InkWell.MAUI.Business.Dtos.Auth;

public class UserAuth
{
	public Guid Id { get; set; }

	public string Username { get; set; } = string.Empty;

	public string Token { get; set; } = string.Empty;

	public string[] Roles { get; set; } = [];
}