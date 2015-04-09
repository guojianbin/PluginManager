using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Loader.Mef
{
	/// <summary>
	/// An implementation of <see cref="PluginManager.Loader.IPluginLoader"/> which uses <see cref="System.ComponentModel.Composition"/> (MEF)
	/// </summary>
	public class MefPluginLoader : IPluginLoader
	{
		//////////////////////////////////////////////////////////////////////

		#region Members

		/// <summary>
		/// The container to load plugins out of
		/// </summary>
		private CompositionContainer container;

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region Constructors

		/// <summary>
		/// Initialises the MefPluginLoader with a <see cref="System.ComponentModel.Composition.Hosting.CompositionContainer"/>
		/// </summary>
		/// <param name="container"></param>
		public MefPluginLoader(CompositionContainer container)
		{
			if (container == null) throw new ArgumentNullException("container");

			this.container = container;
		}

		/// <summary>
		/// Initialises the MefPluginLoader with a directory to load plugins from
		/// </summary>
		/// <param name="pluginDirectory">The directory to load plugins out of</param>
		public MefPluginLoader(string pluginDirectory)
		{
			if (pluginDirectory == null) throw new ArgumentNullException("pluginDirectory");

			DirectoryCatalog catalog = new DirectoryCatalog(pluginDirectory);

			container = new CompositionContainer(catalog);			
		}

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region IPluginLoader Members

		/// <summary>
		/// Loads plugins from the MEF container
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IPlugin> Load()
		{
			return container.GetExportedValues<IPlugin>();
		}

		#endregion

		//////////////////////////////////////////////////////////////////////		
	}
}
