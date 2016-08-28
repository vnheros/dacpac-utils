//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="SQLProj.com">
//         Copyright © 2012 SQLProj.com - All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
namespace SqlProj.Utils.Dac.Checksum
{
    using System;
    using CommandLine;
    using SqlProj.Common;

    /// <summary>
    /// Entrypoint class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entrypoint method
        /// </summary>
        /// <param name="args">command line arguments</param>
        internal static void Main(string[] args)
        {
            Environment.ExitCode = ExitCode.NothingSucceeded.AsInt();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler
                ((sender, o) =>
                    {
                        LogWriter.WriteError("Unhandled exception occured");
                        LogWriter.WriteError(o.ExceptionObject as Exception);
                    }
                );
                
            try
            {
                var parsedArgs = new AppArgs();
                //if (string.IsNullOrEmpty(parsedArgs.InputFilename)) parsedArgs.InputFilename = @"B2BCopy.bacpac";
                //if (string.IsNullOrEmpty(parsedArgs.ReplaceModel)) parsedArgs.ReplaceModel = @"E:\working\loour\features\newreqs\dac-master\dacchksum\bin\Debug\model.xml";
                //if (string.IsNullOrEmpty(parsedArgs.ReplaceOrigin)) parsedArgs.ReplaceOrigin = @"E:\working\loour\features\newreqs\dac-master\dacchksum\bin\Debug\Origin.xml";
                if (Parser.ParseArguments(args, parsedArgs))
                {
                    if (parsedArgs.VersionInfo || parsedArgs.Help)
                    {
                        if (parsedArgs.VersionInfo)
                            Helpers.DisplayVersionInfo();

                        if (parsedArgs.Help)
                            Console.Write(Parser.ArgumentsUsage(typeof(AppArgs)));

                        return;
                    }

                    var app = new DacChkSum(parsedArgs);
                    app.Run();

                    Environment.ExitCode = ExitCode.Success.AsInt(); 
                }
                else
                {
                    Console.Write(Parser.ArgumentsUsage(typeof(AppArgs)));
                    Environment.ExitCode = ExitCode.UnrecognizedCommand.AsInt();
                }
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(DacChkSumResource.ErrorInvalidParameter, ex.Message);
                Environment.ExitCode = ExitCode.PartialSuccess.AsInt();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(DacChkSumResource.ErrorFileNotFound, ex.FileName);
                Environment.ExitCode = ExitCode.PartialSuccess.AsInt();
            }
            catch (System.Exception ex)
            {
                LogWriter.WriteError(ex);
                Environment.ExitCode = ExitCode.NothingSucceeded.AsInt();
            }

            return;
        }
    }
}
