using NuGet.Versioning;
using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
	/// <summary>
	/// Represents metadata about a plugin
	/// </summary>
	public class PluginMetadata : PluginKey
	{
		/// <summary>
		/// Gets and sets the name of the plugin
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets and sets the description of the plugin
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets and sets release notes associated with a release of a plugin
		/// </summary>
		public string ReleaseNotes { get; set; }

		/// <summary>
		/// Gets and sets who the plugin is provided by
		/// </summary>
		public string ProvidedBy { get; set; }

		/// <summary>
		/// Url associated with the plugin
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Gets whether the version of the plugin is a pre-release version, as dictated by its <see cref="Version"/> property
		/// </summary>
		public bool IsPrerelease
		{
			get
			{
				SemanticVersion semver;

				if (SemanticVersion.TryParse(Version, out semver))
				{
					return semver.IsPrerelease;
				}

				return false;
			}
		}
	}
}
