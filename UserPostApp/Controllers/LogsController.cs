using Microsoft.AspNetCore.Mvc;
using UserPostApp.Models.DB;

namespace UserPostApp.Controllers
{
    public class LogsController: Controller
    {
        private readonly ILogRepository _repoLog;
        public LogsController(ILogRepository repoLog) 
        {
            _repoLog = repoLog;
        }

        public async Task<IActionResult> ViewLogs()
        {
            var logs = await _repoLog.GetLog();
            return View(logs);
        }
    }
}
