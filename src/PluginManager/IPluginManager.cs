using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
	/// <summary>
	/// Represents a manager for plugins
	/// </summary>
	public interface IPluginManager
	{
		/// <summary>
		/// Gets and sets the plugin source
		/// </summary>
		IPluginSource Source { get; set; }

		/// <summary>
		/// Installs a plugin
		/// </summary>
		/// <param name="pluginKey"></param>
		void Install(PluginKey pluginKey);

		/// <summary>
		/// Updates a plugin
		/// </summary>
		/// <param name="pluginKey"></param>
		void Update(PluginKey pluginKey);

		/// <summary>
		/// Enables a plugin
		/// </summary>
		/// <param name="pluginKey"></param>
		void Enable(PluginKey pluginKey);

		/// <summary>
		/// Disables a plugin
		/// </summary>
		/// <param name="pluginKey"></param>
		void Disable(PluginKey pluginKey);

		/// <summary>
		/// Rolls back the plugin to the given installed version
		/// </summary>
		/// <param name="pluginKey"></param>
		/// <param name="version"></param>
		void Rollback(PluginKey pluginKey);
	}
}
