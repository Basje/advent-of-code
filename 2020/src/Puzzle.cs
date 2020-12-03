﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020
{
    [HelpOption]
    public abstract class Puzzle
    {
        public Puzzle(CommandLineApplication app)
        {
            App = app;
        }

        protected CommandLineApplication App { get; }

        [Option("-v|--verbose")]
        protected bool Verbose { get; private set; }

        public abstract Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken);

        protected void Write(string message)
        {
            App.Out.Write(message);
        }

        protected void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            App.Error.Write(message);
            Console.ResetColor();
        }

        protected void WriteErrorLine(string message = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            App.Error.WriteLine(message);
            Console.ResetColor();
        }

        protected void WriteHeader(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            App.Out.Write(message);
            Console.ResetColor();
        }

        protected void WriteHeaderLine(string message = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            App.Out.WriteLine(message);
            Console.ResetColor();
        }

        protected void WriteLine(string message = "")
        {
            App.Out.WriteLine(message);
        }

        protected void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            App.Out.Write(message);
            Console.ResetColor();
        }

        protected void WriteSuccessLine(string message = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            App.Out.WriteLine(message);
            Console.ResetColor();
        }

        protected void WriteVerbose(string message)
        {
            if (Verbose)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                App.Out.Write(message);
                Console.ResetColor();
            }
            Debug.WriteLine(message);
        }

        protected void WriteVerboseLine(string message = "")
        {
            if (Verbose)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                App.Out.WriteLine(message);
                Console.ResetColor();
            }
            Debug.WriteLine(message);
        }

        protected void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            App.Out.Write(message);
            Console.ResetColor();
        }

        protected void WriteWarningLine(string message = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            App.Out.WriteLine(message);
            Console.ResetColor();
        }
    }
}