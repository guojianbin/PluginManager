using PluginManager.Client;
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
		/// Loads a plugin with the given key
		/// </summary>
		void Load(PluginKey key);

		/// <summary>
		/// Unloads a plugin with the given key
		/// </summary>
		/// <param name="key"></param>
		void Unload(PluginKey key);
	}
}
