using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Logging
{
    public class Logger
    {
		private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
		private readonly ILogger _logger;

		private Logger() {
			using var loggerFactory = LoggerFactory.Create(builder =>
			{
				builder.AddDebug()
				.SetMinimumLevel(LogLevel.Debug);
			});

			_logger = loggerFactory.CreateLogger("[   CustomLogger   ]");
		}

		public static Logger Instance => _instance.Value;

		public void LogInformation(string message) {
			_logger?.LogInformation(message);
		}

		public void LogError(string message, Exception ex) {
			_logger?.LogError(ex, message);
		}

		public void LogDebug(string message) {
			_logger?.LogDebug(message);
		}

	}
}
