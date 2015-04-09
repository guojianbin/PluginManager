using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Loader
{
	/// <summary>
	/// Allows for loading of plugins from multiple <see cref="IPluginLoader"/> instances
	/// </summary>
	public class AggregatePluginLoader : IPluginLoader
	{
		//////////////////////////////////////////////////////////////////////

		#region Members

		/// <summary>
		/// The loaders
		/// </summary>
		private IEnumerable<IPluginLoader> loaders;

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region Constructor

		/// <summary>
		/// Initialises a new instance of the AggregatePluginLoader
		/// </summary>
		/// <param name="loaders"></param>
		public AggregatePluginLoader(IEnumerable<IPluginLoader> loaders)
		{
			if (loaders == null) throw new ArgumentNullException("loaders");

			this.loaders = loaders;
		}

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region IPluginLoader Members

		/// <summary>
		/// Loads plugins from all inner loaders
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IPlugin> Load()
		{
			return loaders.SelectMany(pl => pl.Load());
		} 

		#endregion

		//////////////////////////////////////////////////////////////////////
	}
}
