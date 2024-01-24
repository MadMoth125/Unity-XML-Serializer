using System;
using SerializedXML.Data;
using SerializedXML.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SerializedXML.UI
{
	/// <summary>
	/// Simple class to handle the input of the GUI.
	/// Fires events when the settings are changed.
	/// </summary>
	public class SettingsSelectionInput : MonoBehaviour
	{
		[Header("Event References")]
		[SerializeField]
		private SettingsEvents settingsEvents;
		
		[Header("Component References")] 
		[SerializeField]
		private TMP_Dropdown languageDropdown;
		
		[SerializeField]
		private TMP_Dropdown windowSizeDropdown;
		
		[SerializeField]
		private TMP_Dropdown themeDropdown;
		
		[SerializeField]
		private Button applySettingsButton;

		[SerializeField]
		private Button revertDefaultButton;
		
		#region Unity Methods

		private void OnEnable()
		{
			// subscribe to the button click events
			languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
			windowSizeDropdown.onValueChanged.AddListener(OnWindowSizeChanged);
			themeDropdown.onValueChanged.AddListener(OnThemeChanged);
			applySettingsButton.onClick.AddListener(OnSettingsApplied);
			revertDefaultButton.onClick.AddListener(OnSettingsReverted);
		}

		private void OnDisable()
		{
			// unsubscribe from the button click events
			languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
			windowSizeDropdown.onValueChanged.RemoveListener(OnWindowSizeChanged);
			themeDropdown.onValueChanged.RemoveListener(OnThemeChanged);
			applySettingsButton.onClick.RemoveListener(OnSettingsApplied);
			revertDefaultButton.onClick.RemoveListener(OnSettingsReverted);
		}

		#endregion
		
		private void OnLanguageChanged(int language) => settingsEvents.ChangeLanguage((ApplicationData.Language) language);

		private void OnWindowSizeChanged(int size) => settingsEvents.ChangeWindowSize((ApplicationData.WindowSize) size);

		private void OnThemeChanged(int theme) => settingsEvents.ChangeTheme((ApplicationData.Theme) theme);

		private void OnSettingsApplied() => settingsEvents.ApplySettings();

		private void OnSettingsReverted() => settingsEvents.RevertSettings();
	}
}