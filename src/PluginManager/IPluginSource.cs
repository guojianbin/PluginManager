using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
	/// <summary>
	/// Represents a source for discovering and installing plugins
	/// </summary>
	public interface IPluginSource
	{
		/// <summary>
		/// Searches for plugins matching the given search parameters
		/// </summary>
		/// <param name="searchParameters">The parameters to use when searching plugins</param>
		/// <returns>An <see cref="IQueryable"/> of <see cref="PluginMetadata"/> instances</returns>
		IQueryable<PluginMetadata> SearchPlugins(PluginMetadataSearchParameters searchParameters);

		/// <summary>
		/// Installs a plugin by its key
		/// </summary>
		/// <param name="key"></param>
		void InstallPlugin(PluginKey key);

		/// <summary>
		/// Updates a plugin by it's key
		/// </summary>
		/// <param name="key"></param>
		void UpdatePlugin(PluginKey key);

		/// <summary>
		/// Checks for updates to the given plugins
		/// </summary>
		/// <param name="plugins">The plugins to check for updates to</param>
		/// <returns>The plugins which have an update available</returns>
		IEnumerable<PluginMetadata> CheckForUpdates(IEnumerable<PluginKey> plugins, bool includePreReleaseVersions);
	}
}
