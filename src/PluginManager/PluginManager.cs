using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
	/// <summary>
	/// Provides an implementation of IPluginManager that uses a IPluginMetadataStore to store plugin metadata
	/// </summary>
	public class PluginManager : IPluginManager
	{
		public IPluginSource Source
		{
			get;
			set;
		}

		public void Install(PluginKey pluginKey)
		{
			throw new NotImplementedException();
		}

		public void Update(PluginKey pluginKey)
		{
			throw new NotImplementedException();
		}

		public void Enable(PluginKey pluginKey)
		{
			throw new NotImplementedException();
		}

		public void Disable(PluginKey pluginKey)
		{
			throw new NotImplementedException();
		}

		public void Rollback(PluginKey pluginKey, string version)
		{
			throw new NotImplementedException();
		}
	}
}
