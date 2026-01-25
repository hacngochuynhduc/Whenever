using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class ApplicationLog : BaseEntity<Guid>
{
    /// <summary>
    /// Log level: Information, Warning, Error, Critical
    /// </summary>
    public string LogLevel { get; set; }
    
    /// <summary>
    /// Log source/category (e.g., "Application", "Database", "Authentication", "FileStorage")
    /// </summary>
    public string Category { get; set; }
    
    /// <summary>
    /// Log message
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// Exception details if error/exception occurred
    /// </summary>
    public string? Exception { get; set; }
    
    /// <summary>
    /// Stack trace for debugging
    /// </summary>
    public string? StackTrace { get; set; }
    
    /// <summary>
    /// Request path (for HTTP requests)
    /// </summary>
    public string? RequestPath { get; set; }
    
    /// <summary>
    /// Request method (GET, POST, etc.)
    /// </summary>
    public string? RequestMethod { get; set; }
    
    /// <summary>
    /// User ID who triggered the action
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// IP address of the user
    /// </summary>
    public string? IpAddress { get; set; }
    
    /// <summary>
    /// User agent (browser/device info)
    /// </summary>
    public string? UserAgent { get; set; }
    
    /// <summary>
    /// Machine name (server/PC name where log was generated)
    /// </summary>
    public string? MachineName { get; set; }
    
    /// <summary>
    /// Operating system information
    /// </summary>
    public string? OperatingSystem { get; set; }
    
    /// <summary>
    /// Request/Response duration in milliseconds (for performance tracking)
    /// </summary>
    public long? DurationMs { get; set; }
    
    /// <summary>
    /// HTTP response status code (for HTTP requests)
    /// </summary>
    public int? StatusCode { get; set; }
    
    /// <summary>
    /// Additional metadata in JSON format
    /// </summary>
    public string? Metadata { get; set; }
    
    /// <summary>
    /// Timestamp when log was created
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}