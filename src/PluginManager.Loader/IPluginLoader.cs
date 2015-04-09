using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Loader
{
	/// <summary>
	/// Defines a component that can load <see cref="PluginManager.Core.IPlugin"/> instances
	/// </summary>
	public interface IPluginLoader
	{
		/// <summary>
		/// Loads plugins
		/// </summary>
		IEnumerable<IPlugin> Load();
	}
}
