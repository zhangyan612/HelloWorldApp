using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace HelloWorldApp
{
        public sealed class CsvReader : IDisposable
        {
            private long __rowno = 0;
            private TextReader __reader;
            private static Regex rexCsvSplitter = new Regex(@",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))");
            private static Regex rexRunOnLine = new Regex(@"^[^""]*(?:""[^""]*""[^""]*)*""[^""]*$");
            public long RowIndex { get { return __rowno; } }

            public CsvReader(string fileName) : this(new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
            }

            public CsvReader(Stream stream)
            {
                __reader = new StreamReader(stream);
            }

            public IEnumerable RowEnumerator
            {
                get
                {
                    if (null == __reader)
                        throw new ApplicationException("Cannot start reading without CSV input.");

                    __rowno = 0;
                    string sLine;
                    string sNextLine;

                    while (null != (sLine = __reader.ReadLine()))
                    {
                        while (rexRunOnLine.IsMatch(sLine) && null != (sNextLine = __reader.ReadLine()))
                            sLine += "\n" + sNextLine;

                        __rowno++;
                        string[] values = rexCsvSplitter.Split(sLine);

                        for (int i = 0; i < values.Length; i++)
                            values[i] = Csv.Unescape(values[i]);

                        yield return values;
                    }
                    __reader.Close();
                }
            }

            public void Dispose()
            {
                if (null != __reader) __reader.Dispose();
            }

        }

        public static class Csv
        {
            private const string QUOTE = "\"";
            private const string ESCAPED_QUOTE = "\"\"";
            private static char[] CHARACTERS_THAT_MUST_BE_QUOTED = { ',', '"', '\n' };

            public static string Escape(string s)
            {
                if (s.Contains(QUOTE))
                    s = s.Replace(QUOTE, ESCAPED_QUOTE);

                if (s.IndexOfAny(CHARACTERS_THAT_MUST_BE_QUOTED) > -1)
                    s = QUOTE + s + QUOTE;

                return s;
            }

            public static string Unescape(string s)
            {
                if (s.StartsWith(QUOTE) && s.EndsWith(QUOTE))
                {
                    s = s.Substring(1, s.Length - 2);

                    if (s.Contains(ESCAPED_QUOTE))
                        s = s.Replace(ESCAPED_QUOTE, QUOTE);
                }
                return s;
            }

        }
}
