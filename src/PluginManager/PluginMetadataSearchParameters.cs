using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
	/// <summary>
	/// Represents search parameters for plugin metadata
	/// </summary>
	public class PluginMetadataSearchParameters
	{
		/// <summary>
		/// Gets and sets the search term to search by
		/// </summary>
		public string Search { get; set; }

		/// <summary>
		/// Gets and sets whether to search for pre-release plugins
		/// </summary>
		public bool? IncludePrerelease { get; set; }
	}
}
