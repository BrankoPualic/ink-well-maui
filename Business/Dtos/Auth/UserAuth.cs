﻿namespace InkWell.MAUI.Business.Dtos.Auth;

public class UserAuth
{
	public Guid Id { get; set; }

	public string Username { get; set; }

	public TokenDto Token { get; set; }
}

public readonly record struct TokenDto(string Token);