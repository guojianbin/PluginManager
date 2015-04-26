using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
	/// <summary>
	/// Represents the state of an installed plugin
	/// </summary>
	public enum PluginState
	{
		/// <summary>
		/// The plugin is being installed
		/// </summary>
		Installing		= 1,

		/// <summary>
		/// The plugin is being configured
		/// </summary>
		Configuring		= 2,

		/// <summary>
		/// The plugin is installed and enabled
		/// </summary>
		Installed		= 3,

		/// <summary>
		/// The plugin is being updated
		/// </summary>
		Updating		= 4
	}

	/// <summary>
	/// Represents a plugin which is installed into the manager
	/// </summary>
	public class Plugin : PluginMetadata
	{
		/// <summary>
		/// Gets and sets a newer version of the plugin which could be updated to. Versioning should use Semver v2 versioning (http://semver.org/).
		/// </summary>
		public string NewVersion { get; set; }

		/// <summary>
		/// Gets whether an update to the plugin is available
		/// </summary>
		public bool UpdateAvailable
		{
			get
			{
				if (NewVersion == null || Version == null)
				{
					return false;
				}

				SemanticVersion newSemVer, oldSemVer;

				if (SemanticVersion.TryParse(Version, out oldSemVer) &&
					SemanticVersion.TryParse(NewVersion, out newSemVer))
				{
					return newSemVer > oldSemVer;
				}

				return false;
			}
		}

		/// <summary>
		/// Gets and sets the release notes for the version of the plugin corresponding with <see cref="NewVersion"/>
		/// </summary>
		public string NewReleaseNotes { get; set; }

		/// <summary>
		/// Gets and sets the state of the plugin
		/// </summary>
		public PluginState State { get; set; }

		/// <summary>
		/// Gets and sets whether the plugin is enabled
		/// </summary>
		public bool IsEnabled { get; set; }
	}
}
