using System;

namespace HighSign.Common.Plugins
{
	public interface IPluginManager
	{
		IPluginInfo FindPluginByClassAndFilename(string PluginClass, string PluginFilename);
		bool PluginExists(string PluginClass, string PluginFilename);
		bool LoadPlugins();
		IPluginInfo[] Plugins { get; }
	}
}
