using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Loader
{
	/// <summary>
	/// Represents a store of plugin information
	/// </summary>
	public interface IPluginStore
	{
		/// <summary>
		/// Gets plugins which are enabled
		/// </summary>
		/// <returns></returns>
		IEnumerable<PluginKey> GetEnabledPlugins();
	}
}
