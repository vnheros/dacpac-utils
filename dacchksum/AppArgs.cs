//------------------------------------------------------------------------------
// <copyright file="AppArgs.cs" company="SQLProj.com">
//         Copyright © 2013 SQLProj.com - All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
namespace SqlProj.Utils.Dac.Checksum
{
    using CommandLine;

    internal class AppArgs
    {
        [Argument(ArgumentType.AtMostOnce, LongName = "InputFilename", ShortName = "i")]
        public string InputFilename { get; set; }

        [Argument(ArgumentType.AtMostOnce, LongName = "Update", ShortName = "u")]
        public bool Update { get; set; }

        [Argument(ArgumentType.AtMostOnce, LongName = "ReplaceModel", ShortName = "rm")]
        public string ReplaceModel { get; set; }

        [Argument(ArgumentType.AtMostOnce, LongName = "ReplaceOrigin", ShortName = "ro")]
        public string ReplaceOrigin { get; set; }

        [Argument(ArgumentType.AtMostOnce, LongName = "Verbose", ShortName = "v")]
        public bool Verbose { get; set; }

        [Argument(ArgumentType.AtMostOnce, LongName = "VersionInfo", ShortName = "vi")]
        public bool VersionInfo { get; set; }

        [Argument(ArgumentType.AtMostOnce, LongName = "Help", ShortName = "?")]
        public bool Help { get; set; }

        public AppArgs()
        {
            this.InputFilename = null;
            this.Update = false;
            this.ReplaceModel = null;
            this.ReplaceOrigin = null;
            this.Verbose = false;
            this.VersionInfo = false;
            this.Help = false;
        }
    }
}
