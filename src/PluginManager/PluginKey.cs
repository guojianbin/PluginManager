using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
	/// <summary>
	/// Represents the key for a plugin
	/// </summary>
	public class PluginKey
	{
		/// <summary>
		/// Gets and sets the id of the plugin
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets and sets the version of the plugin. Versioning should use Semver versioning (http://semver.org/).
		/// </summary>
		public string Version { get; set; }
	}
}
