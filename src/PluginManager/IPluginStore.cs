using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
	/// <summary>
	/// Defines a store of plugin information
	/// </summary>
	public interface IPluginStore
	{
		/// <summary>
		/// Gets plugin details by its key
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Plugin GetPlugin(PluginKey pluginKey);

		/// <summary>
		/// Searches installed plugins
		/// </summary>
		/// <returns></returns>
		IEnumerable<Plugin> SearchPlugins(PluginSearchParameters searchParameters);
	}
}
