using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace SerializedXML.Serializer
{
	/// <summary>
	/// Simple class to handle XML serialization and deserialization.
	/// Handles saving data to a file, and loading data from a file.
	/// (idk where it's saved to)
	/// </summary>
	public class XML
	{
		private const string _fileName = "ApplicationData.xml";
		
		/// <summary>
		/// Serializes an object and saves it to a file in XML format.
		/// </summary>
		/// <param name="data">The type of object to serialize (Person, Product, etc.)</param>
		/// <typeparam name="T"></typeparam>
		public static void SerializeAndSave<T>(T data)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (StreamWriter streamWriter = new StreamWriter(_fileName))
			{
				serializer.Serialize(streamWriter, data);
			}
		}

		public static bool DeserializeAndLoad<T>(out T result)
		{
			bool success = true;
			result = default(T);
			
			{
				try
				{
					if (File.Exists(_fileName))
					{
						XmlSerializer serializer = new XmlSerializer(typeof(T));
						using (StreamReader streamReader = new StreamReader(_fileName))
						{
							result = (T)serializer.Deserialize(streamReader);
						}
					}
					else
					{
						success = false;
						Debug.LogError("File does not exist!");
					}
				}
				catch (Exception e)
				{
					Debug.LogError("Error parsing XML file: " + e.Message);
					success = false;
				}
			}

			return success;
		}
	}
}