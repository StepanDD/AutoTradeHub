namespace AutoTradeHub.Middleware
{
	public class CookiePresetMiddleware
	{
		private readonly RequestDelegate _next;

        public CookiePresetMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
			if (context.Request.Cookies.ContainsKey("colorTheme"))
				context.Items.Add("colorTheme", context.Request.Cookies["colorTheme"]);
            else
				context.Items.Add("colorTheme", "light");
			await _next(context);
        }
    }
}
