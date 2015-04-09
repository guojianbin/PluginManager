using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Core
{
	/// <summary>
	/// Represents a plugin which can be loaded into an application
	/// </summary>
	public interface IPlugin
	{
		/// <summary>
		/// Initialises the plugin
		/// </summary>
		void Initialise();
	}
}
