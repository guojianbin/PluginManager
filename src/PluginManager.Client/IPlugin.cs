using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Client
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

		/// <summary>
		/// Tears down the plugin
		/// </summary>
		void TearDown();
	}
}
