using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Core
{
	/// <summary>
	/// Defines a part that can be run as a step in a plugin install process.
	/// </summary>
	/// <remarks>
	/// The <see cref="Install()"/> method should be idempotent.
	/// </remarks>
	public interface IPluginInstallPart
	{
		/// <summary>
		/// Gets the version to which this install part applies
		/// </summary>
		string Version { get; }

		/// <summary>
		/// Installs the part
		/// </summary>
		void Install();
	}
}
