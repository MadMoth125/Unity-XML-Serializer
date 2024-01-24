using System;
using System.Collections;
using System.Collections.Generic;
using SerializedXML.Data;
using SerializedXML.Events;
using SerializedXML.Serializer;
using UnityEngine;

namespace SerializedXML.Settings
{
	public class SettingsManager : MonoBehaviour
	{
		// const defaults
		public const ApplicationData.WindowSize DefaultWindowSize = ApplicationData.WindowSize.Large;
		public const ApplicationData.Language DefaultLanguage = ApplicationData.Language.English;
		public const ApplicationData.Theme DefaultTheme = ApplicationData.Theme.Light;

		[Header("Event References")]
		[SerializeField]
		private SettingsEvents settingsEvents;

		// private currents
		private ApplicationData.WindowSize appWindowSize;
		private ApplicationData.Language appLanguage;
		private ApplicationData.Theme appTheme;

		#region Unity Methods

		private void OnEnable()
		{
			settingsEvents.OnThemeChanged += OnThemeChanged;
			settingsEvents.OnLanguageChanged += OnLanguageChanged;
			settingsEvents.OnWindowSizeChanged += OnWindowSizeChanged;
			
			settingsEvents.OnSettingsApplied += OnSettingsApplied;
			settingsEvents.OnSettingsReverted += OnSettingsReverted;
			
			if (XML.DeserializeAndLoad(out ApplicationData data))
			{
				settingsEvents.ChangeWindowSize(data.appWindowSize);
				settingsEvents.ChangeLanguage(data.appLanguage);
				settingsEvents.ChangeTheme(data.appTheme);
				
				settingsEvents.ApplyWindowSize(data.appWindowSize);
				settingsEvents.ApplyLanguage(data.appLanguage);
				settingsEvents.ApplyTheme(data.appTheme);
				
				Debug.Log("Loaded settings from file.");
			}
			else
			{
				settingsEvents.ChangeWindowSize(DefaultWindowSize);
				settingsEvents.ChangeLanguage(DefaultLanguage);
				settingsEvents.ChangeTheme(DefaultTheme);
				
				settingsEvents.ApplyWindowSize(DefaultWindowSize);
				settingsEvents.ApplyLanguage(DefaultLanguage);
				settingsEvents.ApplyTheme(DefaultTheme);
				
				Debug.Log("Loaded default settings.");
			}
		}

		private void OnDisable()
		{
			settingsEvents.OnThemeChanged -= OnThemeChanged;
			settingsEvents.OnLanguageChanged -= OnLanguageChanged;
			settingsEvents.OnWindowSizeChanged -= OnWindowSizeChanged;
			
			settingsEvents.OnSettingsApplied -= OnSettingsApplied;
			settingsEvents.OnSettingsReverted -= OnSettingsReverted;
		}

		#endregion
		
		private void OnThemeChanged(ApplicationData.Theme theme) => appTheme = theme;

		private void OnLanguageChanged(ApplicationData.Language language) => appLanguage = language;

		private void OnWindowSizeChanged(ApplicationData.WindowSize size) => appWindowSize = size;

		private void OnSettingsApplied()
		{
			XML.SerializeAndSave(new ApplicationData(appTheme, appLanguage, appWindowSize));
			
			Debug.Log("Saved settings to file.");
			
			settingsEvents.ApplyTheme(appTheme);
			settingsEvents.ApplyLanguage(appLanguage);
			settingsEvents.ApplyWindowSize(appWindowSize);
		}

		private void OnSettingsReverted()
		{
			settingsEvents.ChangeWindowSize(DefaultWindowSize);
			settingsEvents.ChangeLanguage(DefaultLanguage);
			settingsEvents.ChangeTheme(DefaultTheme);
			
			settingsEvents.ApplyWindowSize(DefaultWindowSize);
			settingsEvents.ApplyLanguage(DefaultLanguage);
			settingsEvents.ApplyTheme(DefaultTheme);
				
			Debug.Log("Loaded default settings.");
		}
	}
}