using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Loader
{
	/// <summary>
	/// Provides plugin loading
	/// </summary>
	/// <remarks>
	/// An implementation of <see cref="PluginManager.Loader.IPluginLoader"/> must be set before calling <see cref="Load()"/>
	/// </remarks>
	public class PluginLoader
	{
		//////////////////////////////////////////////////////////////////////

		#region Properties

		/// <summary>
		/// Gets and sets the underlying loader
		/// </summary>
		public IPluginLoader Loader { get; set; }

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region Constructor

		/// <summary>
		/// Initialises a new instance of the PluginLoader
		/// </summary>
		public PluginLoader()
		{
		}

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region Public Methods

		/// <summary>
		/// Loads plugins
		/// </summary>
		public void Load()
		{ 
			if (Loader == null)
			{
				throw new Exception("Loader must be set before calling Load()");
			}

			IEnumerable<IPlugin> plugins = Loader.Load();

			foreach (IPlugin plugin in plugins)
			{
				plugin.Initialise();
			}
		}

		#endregion

		//////////////////////////////////////////////////////////////////////
	}
}
