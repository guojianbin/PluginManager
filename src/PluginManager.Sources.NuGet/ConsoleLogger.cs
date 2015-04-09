using NuGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Source.NuGet
{
	public class ConsoleLogger : ILogger
	{
		public void Log(MessageLevel level, string message, params object[] args)
		{
			Console.Out.WriteLine(String.Format("NuGet: {0} {1}", level, String.Format(message, args)));
		}

		public FileConflictResolution ResolveFileConflict(string message)
		{
			return FileConflictResolution.Ignore;
		}
	}
}
