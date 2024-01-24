using System;
using System.Collections;
using System.Collections.Generic;
using SerializedXML.Data;
using SerializedXML.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SerializedXML.Settings
{
	public class ThemeHandler : MonoBehaviour
	{
		[Header("Event References")]
		[SerializeField]
		private SettingsEvents settingsEvents;
	
		[Header("Component References")]
		[SerializeField]
		private Image backgroundImage;
		
		[SerializeField]
		private TMP_Dropdown themeDropdown;
	
		[Header("Theme Colors")]
		[SerializeField]
		private Color lightBackgroundColor = new Color(0.8f, 0.8f, 0.8f);
	
		[SerializeField]
		private Color darkBackgroundColor = new Color(0.2f, 0.2f, 0.2f);
	
		#region Unity Methods
	
		private void OnEnable() => settingsEvents.OnThemeApplied += OnThemeApplied;

		private void OnDisable() => settingsEvents.OnThemeApplied -= OnThemeApplied;

		#endregion
		
		private void OnThemeApplied(ApplicationData.Theme theme)
		{
			switch (theme)
			{
				case ApplicationData.Theme.Light:
					backgroundImage.color = lightBackgroundColor;
					break;
				case ApplicationData.Theme.Dark:
					backgroundImage.color = darkBackgroundColor;
					break;
				default:
					break;
			}

			if (themeDropdown != null && themeDropdown.value != (int)theme)
			{
				themeDropdown.value = (int) theme;
			}
		}
	}
}