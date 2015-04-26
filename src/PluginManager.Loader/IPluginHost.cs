using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Loader
{
	/// <summary>
	/// Defines a host for plugins to be loaded into
	/// </summary>
	public interface IPluginHost
	{
		/// <summary>
		/// Loads the given plugin into the host
		/// </summary>
		void Load(PluginKey pluginKey);

		/// <summary>
		/// Unload the plugin into the host
		/// </summary>
		void Unload(PluginKey pluginKey);
	}
}
