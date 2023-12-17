using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phototagger.UserOptions
{
    public class OptionRunnerFactory
    {
        #region Helpers
        /// <summary>
        /// Validate user options and return type
        /// </summary>
        private static OptionEnum UserOptionType(string[] args)
        {
            if (args.Length == 0) throw new ArgumentException();

            if (string.Equals(args[0], OptionEnum.Highlight.ToString(), StringComparison.InvariantCultureIgnoreCase)
                && args.Length == 3)
            {
                return OptionEnum.Highlight;
            }

            if (string.Equals(args[0], OptionEnum.Extract.ToString(), StringComparison.InvariantCultureIgnoreCase)
                && args.Length == 3)
            {
                return OptionEnum.Extract;
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Build usage string
        /// </summary>
        public static string Usage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Phototagger.exe [option] [additional options]*");
            sb.AppendLine("Supported options:");
            sb.AppendLine("    highlight [input image filename] [output image filename]");
            sb.AppendLine("    extract [input image filename] [output filename_prefix]");

            return sb.ToString();
        }
        #endregion Helpers

        /// <summary>
        /// Throw
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws ArgumentException on invalid Option</exception>
        public static IOptionRunner Build(string[] args)
        {
            OptionEnum option = UserOptionType(args);

            switch (option)
            {
                case OptionEnum.Highlight:
                    return new HighlightRunner(args[1], args[2]);
                case OptionEnum.Extract:
                    return new FaceExtractorRunner(args[1], args[2]);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
