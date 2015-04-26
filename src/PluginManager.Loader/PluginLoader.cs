using PluginManager.Client;
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
	/// An implementation of <see cref="PluginManager.Loader.IPluginHost"/> must be set before calling <see cref="Load()"/>
	/// </remarks>
	public class PluginLoader
	{
		//////////////////////////////////////////////////////////////////////

		#region Properties

		/// <summary>
		/// Gets and sets the host under which plugins will be loaded and executed
		/// </summary>
		public IPluginHost Host { get; set; }

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
			if (Host == null)
			{
				throw new Exception("Host must be set before calling Load()");
			}
			
		}

		#endregion

		//////////////////////////////////////////////////////////////////////
	}
}
