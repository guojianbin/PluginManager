using PluginManager.Client;
using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Loader
{
	/// <summary>
	/// Isolates a plugin within an AppDomain
	/// </summary>
	public class AppDomainPluginHost : IPluginHost
	{
		//////////////////////////////////////////////////////////////////////

		#region Members

		/// <summary>
		/// The base directory for app domains to read from
		/// </summary>
		private readonly string baseDirectory;

		/// <summary>
		/// The underlying loader to use to load the plugin
		/// </summary>
		private readonly IPluginLoader loader;

		/// <summary>
		/// AppDomain's for the loaded plugins
		/// </summary>
		private readonly Dictionary<PluginKey, AppDomain> appDomains;

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region Constructor

		public AppDomainPluginHost(string baseDirectory, IPluginLoader loader)
		{
			if (baseDirectory == null) throw new ArgumentNullException("baseDirectory");
			if (loader == null) throw new ArgumentNullException("loader");

			this.baseDirectory = baseDirectory;
			this.loader = loader;
			appDomains = new Dictionary<PluginKey, AppDomain>();
		}

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region IPluginHost Methods

		public void Load(PluginKey pluginKey)
		{
			//
			// Create a new domain
			//
			AppDomainSetup setup = new AppDomainSetup()
			{
				ApplicationBase = baseDirectory,
				PrivateBinPath = pluginKey.ToString()
			};

			AppDomain appDomain = AppDomain.CreateDomain(pluginKey.ToString(), null, setup);

			appDomain.DoCallBack(() => 
			{
				loader.Load(pluginKey);
			});

			appDomains.Add(pluginKey, appDomain);
		}

		public void Unload(PluginKey pluginKey)
		{
			if (pluginKey == null) throw new ArgumentNullException("pluginKey");

			AppDomain appDomain;

			//
			// Attempt to unload the app domain
			//
			if (appDomains.TryGetValue(pluginKey, out appDomain))
			{
				appDomain.DoCallBack(() =>
				{
					loader.Unload(pluginKey);
				});

				AppDomain.Unload(appDomain);
			}
			else
			{
				throw new Exception(String.Format("Plugin '{0}' is not loaded", pluginKey));
			}
		}

		#endregion

		//////////////////////////////////////////////////////////////////////
	}
}