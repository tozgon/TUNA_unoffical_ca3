﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CA3.API.DBContext;
using CA3.DataModels;

namespace CA3.API.Middleware
{
	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;
		private
			const string APIKEY = "XApiKey";
		public ApiKeyMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			if (!context.Request.Headers.TryGetValue(APIKEY, out
					var extractedApiKey))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Api Key was not provided ");
				return;
			}
			var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
			var apiKey = appSettings.GetValue<string>(APIKEY);
			if (!apiKey.Equals(extractedApiKey))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Unauthorized client");
				return;
			}
			await _next(context);
		}
	}
}
