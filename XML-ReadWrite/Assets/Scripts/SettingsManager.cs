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
				settingsEvents.ChangeWindowSize(data.AppWindowSize);
				settingsEvents.ApplyWindowSize(data.AppWindowSize);
				
				settingsEvents.ChangeLanguage(data.AppLanguage);
				settingsEvents.ApplyLanguage(data.AppLanguage);
				
				settingsEvents.ChangeTheme(data.AppTheme);
				settingsEvents.ApplyTheme(data.AppTheme);
			}
			else
			{
				settingsEvents.ChangeWindowSize(DefaultWindowSize);
				settingsEvents.ApplyWindowSize(DefaultWindowSize);
				
				settingsEvents.ChangeLanguage(DefaultLanguage);
				settingsEvents.ApplyLanguage(DefaultLanguage);
				
				settingsEvents.ChangeTheme(DefaultTheme);
				settingsEvents.ApplyTheme(DefaultTheme);
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
			
			settingsEvents.ApplyTheme(appTheme);
			settingsEvents.ApplyLanguage(appLanguage);
			settingsEvents.ApplyWindowSize(appWindowSize);
		}

		private void OnSettingsReverted()
		{
			
		}
	}
}