using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HighSign.Configuration.IO
{
	public static class FileManager
	{
		#region Constructors

		static FileManager()
		{
			// Wireup event in settings class to replace specified paths
			Properties.Settings.Default.SettingsLoaded += (o, e) =>
				{
					// Check data and plugins path for empty and replace them with default path (create path if it doesn't exist)
					if (String.IsNullOrEmpty(Properties.Settings.Default.DataStoragePath))
					{
						// Set data path to users AppData folder (to bypass Vista UAC)
						string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
						string combinedDataPath = Path.Combine(dataPath, "High Sign\\Data");
						Properties.Settings.Default.DataStoragePath = combinedDataPath;
						if (!Directory.Exists(Properties.Settings.Default.DataStoragePath))
							Directory.CreateDirectory(Properties.Settings.Default.DataStoragePath);
					}

					if (String.IsNullOrEmpty(Properties.Settings.Default.PluginStoragePath))
					{
						// Look for plugins in program directory
						Properties.Settings.Default.PluginStoragePath = Path.GetFullPath("Plugins");
						if (!Directory.Exists(Properties.Settings.Default.PluginStoragePath))
							Directory.CreateDirectory(Properties.Settings.Default.PluginStoragePath);
					}

					Properties.Settings.Default.Save();
				};
		}

		#endregion

		#region Public Methods

		public static bool SaveObject<T>(object SerializableObject, string Filename)
		{
			return SaveObject<T>(SerializableObject, Filename, null);
		}

		public static bool SaveObject<T>(object SerializableObject, string Filename, IEnumerable<Type> KnownTypes)
		{
			try
			{
				// Create json serializer to serialize json file
				DataContractJsonSerializer jSerial = KnownTypes != null ? new DataContractJsonSerializer(typeof(T), KnownTypes) : new DataContractJsonSerializer(typeof(T));

				// Open json file
				StreamWriter sWrite = new StreamWriter(Path.Combine(Properties.Settings.Default.DataStoragePath, Filename));

				// Serialize actions into json file
				jSerial.WriteObject(sWrite.BaseStream, SerializableObject);

				// Close file
				sWrite.Close();

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public static T LoadObject<T>(string Filename)
		{
			return LoadObject<T>(Filename, null);
		}

		public static T LoadObject<T>(string Filename, IEnumerable<Type> KnownTypes)
		{
			try
			{
				// Create stream reader to load Xml file
				StreamReader sRead = new StreamReader(Path.Combine(Properties.Settings.Default.DataStoragePath, Filename));

				// Create json serializer to deserialize json file
				DataContractJsonSerializer jSerial = KnownTypes != null ? new DataContractJsonSerializer(typeof(T), KnownTypes) : new DataContractJsonSerializer(typeof(T));

				// Deserialize json file into actions list
				T objBuffer = (T)jSerial.ReadObject(sRead.BaseStream);

				// Close xml file
				sRead.Close();

				// Return results of serialization
				return objBuffer;
			}
			catch (Exception ex)
			{
				return default(T);
			}
		}

		#endregion
	}
}
