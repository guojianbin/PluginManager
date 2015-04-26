using NuGet;
using PluginManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.Source.NuGet
{
	/// <summary>
	/// Provides a NuGet plugin source
	/// </summary>
	public class NuGetPluginSource : IPluginSource
	{
		//////////////////////////////////////////////////////////////////////

		#region Members

		/// <summary>
		/// Repository for finding and downloading packages
		/// </summary>
		private AggregateRepository repository;

		/// <summary>
		/// Path to install packages
		/// </summary>
		private string installPath;

		/// <summary>
		/// Logger for NuGet actions
		/// </summary>
		private ILogger logger;

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region Constructor

		/// <summary>
		/// Initialises the NuGetPluginSource with an enumerable of package sources and an install path
		/// </summary>
		/// <param name="packageSources"></param>
		public NuGetPluginSource(IEnumerable<string> packageSources, string installPath)
			: this(packageSources, installPath, NullLogger.Instance)
		{
		}

		/// <summary>
		/// Initialises the NuGetPluginSource with an enumerable of package sources, 
		/// install path and a logger
		/// </summary>
		/// <param name="packageSources"></param>
		public NuGetPluginSource(IEnumerable<string> packageSources, string installPath, ILogger logger)
		{
			if (packageSources == null) throw new ArgumentNullException("packageSources");
			if (installPath == null) throw new ArgumentNullException("installPath");
			if (logger == null) throw new ArgumentNullException("logger");

			this.installPath = installPath;
			this.logger = logger;

			repository = new AggregateRepository(PackageRepositoryFactory.Default, packageSources, false);
			repository.Logger = this.logger;
		}

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region IPluginSource Members

		public IQueryable<PluginMetadata> SearchPlugins(PluginMetadataSearchParameters searchParameters)
		{
			IQueryable<IPackage> packages = repository.Search(searchParameters.Search, searchParameters.IncludePrerelease ?? false);

			return packages.Select(p => CreateMetadata(p)).AsQueryable();
			
			//List<PluginMetadata> plugins = new List<PluginMetadata>();

			//foreach (IPackage package in packages)
			//{
			//	plugins.Add(new PluginMetadata()
			//	{
			//		Id = package.Id,
			//		Name = package.Title ?? package.Id,
			//		Description = package.Description,
			//		Version = package.Version.ToString(),
			//		ProvidedBy = package.Owners != null && package.Owners.Count() > 0 ? package.Owners.Aggregate((acc, s) => acc == null ? s : ", " + s) : "Unknown",
			//		Url = package.ProjectUrl != null ? package.ProjectUrl.ToString() : null
			//	});
			//}

			//return plugins.AsQueryable();
		}

		public void InstallPlugin(PluginKey key)
		{
			if (key == null) throw new ArgumentNullException("key");

			IPackage package = repository.FindPackage(key.Id, new SemanticVersion(key.Version));

			if (package == null)
			{
				throw new Exception(String.Format("Plugin '{0}' could not be found", key.Id));
			}

			PackageManager manager = new PackageManager(repository, installPath);
			manager.Logger = logger;
			manager.InstallPackage(package, false, false);
		}

		public void UpdatePlugin(PluginKey key)
		{
			if (key == null) throw new ArgumentNullException("key");

			IPackage package = repository.FindPackage(key.Id, new SemanticVersion(key.Version));

			if (package == null)
			{
				throw new Exception(String.Format("Plugin '{0}' could not be found", key.Id));
			}

			PackageManager manager = new PackageManager(repository, installPath);
			manager.Logger = logger;
			manager.UpdatePackage(package, true, false);
		}

		public IEnumerable<PluginMetadata> CheckForUpdates(IEnumerable<PluginKey> plugins, bool includePreReleaseVersions)
		{
			if (plugins == null) throw new ArgumentNullException("plugins");

			IEnumerable<IPackageName> packages = plugins.Select(pm => new PackageName(pm.Id, new SemanticVersion(pm.Version)));

			IEnumerable<IPackage> updatedPackages = repository.GetUpdates(packages, includePreReleaseVersions, false, null, null);

			return updatedPackages.Select(p => CreateMetadata(p));
		}

		#endregion

		//////////////////////////////////////////////////////////////////////

		#region Private Methods

		/// <summary>
		/// Creates <see cref="PluginMetadata"/> from a NuGet <see cref="NuGet.IPackage"/>
		/// </summary>
		/// <param name="package"></param>
		/// <returns></returns>
		private PluginMetadata CreateMetadata(IPackage package)
		{
			if (package == null) throw new ArgumentNullException("package");

			return new PluginMetadata()
			{
				Id = package.Id,
				Name = package.Title ?? package.Id,
				Description = package.Description,
				Version = package.Version.ToString(),
				ReleaseNotes = package.ReleaseNotes,
				ProvidedBy = package.Owners != null && package.Owners.Count() > 0 ? package.Owners.Aggregate((acc, s) => acc == null ? s : ", " + s) : "Unknown",
				Url = package.ProjectUrl != null ? package.ProjectUrl.ToString() : null
			};
		}

		#endregion

		//////////////////////////////////////////////////////////////////////
	}
}
