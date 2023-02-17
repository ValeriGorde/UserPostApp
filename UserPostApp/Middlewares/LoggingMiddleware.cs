using UserPostApp.Models.DB;

namespace UserPostApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private IBlogRepository _repository;
        private readonly ILogRepository _repoLog;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IBlogRepository repository, ILogRepository repoLog)
        {
            _next = next;
            _repository = repository;   
            _repoLog = repoLog;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            var newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };
            await _repoLog.AddLog(newRequest);

            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
