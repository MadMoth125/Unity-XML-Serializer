using System;
using SerializedXML.Data;
using UnityEngine;

namespace SerializedXML.Events
{
	[CreateAssetMenu(fileName = "SettingsEvents", menuName = "XML/Settings Events")]
	public class SettingsEvents : ScriptableObject
	{
		public event Action<ApplicationData.Theme> OnThemeChanged;
		public event Action<ApplicationData.Theme> OnThemeApplied; 
		public event Action<ApplicationData.Language> OnLanguageChanged;
		public event Action<ApplicationData.Language> OnLanguageApplied;
		public event Action<ApplicationData.WindowSize> OnWindowSizeChanged;
		public event Action<ApplicationData.WindowSize> OnWindowSizeApplied;
		public event Action OnSettingsApplied;
		public event Action OnSettingsReverted;
		
		public void ChangeTheme(ApplicationData.Theme theme) => OnThemeChanged?.Invoke(theme);
		public void ApplyTheme(ApplicationData.Theme theme) => OnThemeApplied?.Invoke(theme);
		
		public void ChangeLanguage(ApplicationData.Language language) => OnLanguageChanged?.Invoke(language);
		public void ApplyLanguage(ApplicationData.Language language) => OnLanguageApplied?.Invoke(language);
		
		public void ChangeWindowSize(ApplicationData.WindowSize windowSize) => OnWindowSizeChanged?.Invoke(windowSize);
		public void ApplyWindowSize(ApplicationData.WindowSize windowSize) => OnWindowSizeApplied?.Invoke(windowSize);
		
		public void ApplySettings() => OnSettingsApplied?.Invoke();
		public void RevertSettings() => OnSettingsReverted?.Invoke();
	}
}