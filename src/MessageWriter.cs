// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageWriter.cs" company="Elegant Software Solutions, LLC">
//   MIT License
//   Copyright Elegant Software Solutions, LLC
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LogOrganizer
{
    using System;

    /// <summary>
    ///     The message writer.
    /// </summary>
    public static class MessageWriter
    {
        /// <summary>
        /// The write message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
            Console.Read();
        }
    }
}