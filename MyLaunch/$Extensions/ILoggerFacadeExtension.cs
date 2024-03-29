﻿using MyBase.Logging;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyLaunch
{
    public static class ILoggerFacadeExtension
    {
        public static void Log(this ILoggerFacade self, string message, Category category)
            => self.Log(message, category, Priority.None);

        public static void Log(this ILoggerFacade self, string message, Category category, Exception exception)
            => self.Log($"{message}{Environment.NewLine}{string.Join(Environment.NewLine, exception.ToString().Split(Environment.NewLine).Select(s => $"\t{s}"))}", category);

        public static void Debug(this ILoggerFacade self, string message, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int? callerLineNumber = null)
            => self.Log($"[{callerFilePath}, {callerMemberName}, {callerLineNumber?.ToString() ?? "<unknown>"}] {message}", Category.Debug);
    }
}
