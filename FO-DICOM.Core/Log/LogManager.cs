﻿// Copyright (c) 2012-2021 fo-dicom contributors.
// Licensed under the Microsoft Public License (MS-PL).

namespace FellowOakDicom.Log
{
    public interface ILogManager
    {
        /// <summary>
        /// Get logger.
        /// </summary>
        /// <param name="name">Classifier name, typically namespace or type name.</param>
        /// <returns>A logger</returns>
        ILogger GetLogger(string name);
    }

    /// <summary>
    /// Main class for logging management.
    /// </summary>
    public abstract class LogManager : ILogManager
    {
        #region METHODS

        /// <summary>
        /// Get logger from the current log manager implementation.
        /// </summary>
        /// <param name="name">Classifier name, typically namespace or type name.</param>
        /// <returns>Logger from the current log manager implementation.</returns>
        protected abstract Logger GetLoggerImpl(string name);

        ILogger ILogManager.GetLogger(string name) => GetLoggerImpl(name);

        #endregion
    }
    
    /// <summary>
    /// Manager for null ("do nothing") loggers.
    /// </summary>
    public class NullLoggerManager : LogManager
    {
        /// <summary>
        /// Singleton instance of null logger manager.
        /// </summary>
        public static readonly LogManager Instance;

        /// <summary>
        /// Initializes the static fields.
        /// </summary>
        static NullLoggerManager()
        {
            Instance = new NullLoggerManager();
        }

        /// <summary>
        /// Initializes an instance of the null logger manager.
        /// </summary>
        public NullLoggerManager()
        {
        }

        /// <summary>
        /// Get logger from the current log manager implementation.
        /// </summary>
        /// <param name="name">Classifier name, typically namespace or type name.</param>
        /// <returns>Logger from the current log manager implementation.</returns>
        protected override Logger GetLoggerImpl(string name)
        {
            return NullLogger.Instance;
        }
    }

    /// <summary>
    /// Null logger, provides a no-op logger implementation.
    /// </summary>
    public class NullLogger : Logger
    {
        /// <summary>
        /// Singleton instance of the <see cref="NullLogger"/> class.
        /// </summary>
        public static readonly Logger Instance;

        /// <summary>
        /// Initializes the static fields of <see cref="NullLogger"/>.
        /// </summary>
        static NullLogger()
        {
            Instance = new NullLogger();
        }

        /// <summary>
        /// Initializes an instance of <see cref="NullLogger"/>.
        /// </summary>
        public NullLogger()
        {
        }

        /// <summary>
        /// Dispatch a log message.
        /// </summary>
        /// <param name="level">Log level.</param>
        /// <param name="msg">Log message format string.</param>
        /// <param name="args">Arguments corresponding to the <paramref name="msg">log message</paramref>.</param>
        /// <remarks>The <see cref="NullLogger"/> Log method overloads do nothing.</remarks>
        public override void Log(LogLevel level, string msg, params object[] args)
        {
            // Do nothing
        }
    }
}