using LoggingCS;
using Microsoft.Extensions.Options;
using System.Threading.Tasks.Dataflow;

namespace TradingEngineServer.Logging
{
    public class TextLogger : AbstractLogger, ITextLogger
    {
        private readonly LoggingConfig.LoggingConfig _logginConfig;
        public TextLogger(IOptions<LoggingConfig.LoggingConfig> loggingConfig): base() 
        {
            _logginConfig = loggingConfig.Value ?? throw new ArgumentNullException(nameof(loggingConfig));

            if(_logginConfig.LoggerType != LoggerType.Text) { throw new InvalidOperationException($"{nameof(TextLogger)} doesn't match LoggerType"); }
            var now = DateTime.Now;
            string logDirectory = Path.Combine(_logginConfig.TextLoggerConfig.Directory, $"{now:yyyy-MM-dd}");
            string uniqueBase = $"{_logginConfig.TextLoggerConfig.Filename}-{now:HH_mm_ss}";
            string baseLogName = Path.ChangeExtension(uniqueBase, _logginConfig.TextLoggerConfig.FileExtension);
            string filepath = Path.Combine(logDirectory, baseLogName);
            Directory.CreateDirectory(logDirectory);
            _ = Task.Run(() => LogAsync(filepath, _logQueue, _tokenSource.Token));
        }


        ~TextLogger() { Dispose(false); }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing) {
            lock (_lock)
            {
                if (_disposed) return;
                _disposed = true;
            }
            
            if(disposing) { 

                // Get rid of managed resources
                _tokenSource.Cancel();
                _tokenSource.Dispose();
            }

            // Get rid of any unmanaged resources
        }

        private static async void LogAsync(string filepath, BufferBlock<LogInformation> logQueue, CancellationToken token)
        {
            using var fs = new FileStream(filepath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            using var sw = new StreamWriter(fs) { AutoFlush = true};
            try
            {
                while (true)
                {
                    var logItem = await logQueue.ReceiveAsync(token).ConfigureAwait(false);
                    string formattedMessage = FormatLogItem(logItem);
                    await sw.WriteAsync(formattedMessage).ConfigureAwait(false);    
                }
            }catch (OperationCanceledException) { }
        }

        private static string FormatLogItem(LogInformation logItem)
        {
            return $"[{logItem.Now:HH-mm-ss.fffffff yyyy-MM-dd}] [{logItem.ThreadName,-30}:{logItem.ThreadId:000}]"
                
                + $"[{logItem.LogLevel}] {logItem.Message}";
        }

        protected override void Log(LogLevel level, string module, string message)
        {
            _logQueue.Post(new LogInformation(level, module, message, DateTime.Now, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name));
        }

        private readonly BufferBlock<LogInformation> _logQueue = new BufferBlock<LogInformation>();
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private readonly object _lock = new object();
        private bool _disposed = false;
    }
}
