using System;
using SerializedXML.Data;
using SerializedXML.Events;
using TMPro;
using UnityEngine;

namespace SerializedXML.Settings
{
	/// <summary>
	/// A simple class to handle the window size of the application.
	/// Also handles other aspects related to the window size, like the text and the anchor points.
	/// </summary>
	public class WindowSizeHandler : MonoBehaviour
	{
		[Header("Event References")]
		[SerializeField]
		private SettingsEvents settingsEvents;

		[Header("Component References")] 
		[SerializeField]
		private TextMeshProUGUI windowSizeText;
		
		[SerializeField]
		private RectTransform windowTransform;

		[Header("Window Sizes")]
		[SerializeField]
		private string largeWindowText = "Large Window";
		
		[SerializeField]
		private Vector2 largeAnchorMin = new Vector2(0.1f, 0.1f);
	
		[SerializeField]
		private Vector2 largeAnchorMax = new Vector2(0.9f, 0.9f);
	
		[Space(10)]
		[SerializeField]
		private string mediumWindowText = "Medium Window";
		
		[SerializeField]
		private Vector2 mediumAnchorMin = new Vector2(0.15f, 0.15f);
	
		[SerializeField]
		private Vector2 mediumAnchorMax = new Vector2(0.85f, 0.85f);
	
		[Space(10)]
		[SerializeField]
		private string smallWindowText = "Small Window";
		
		[SerializeField]
		private Vector2 smallAnchorMin = new Vector2(0.2f, 0.2f); 
	
		[SerializeField]
		private Vector2 smallAnchorMax = new Vector2(0.8f, 0.8f);
	
		#region Unity Methods

		private void OnEnable() => settingsEvents.OnWindowSizeApplied += OnWindowSizeChanged;

		private void OnDisable() => settingsEvents.OnWindowSizeApplied -= OnWindowSizeChanged;

		#endregion
	
		private void OnWindowSizeChanged(ApplicationData.WindowSize size)
		{
			switch (size)
			{
				case ApplicationData.WindowSize.Small:
					SetSmallWindowSize();
					break;
				case ApplicationData.WindowSize.Medium:
					SetMediumWindowSize();
					break;
				case ApplicationData.WindowSize.Large:
					SetLargeWindowSize();
					break;
				default:
					break;
			}

			void SetSmallWindowSize()
			{
				windowTransform.anchorMin = smallAnchorMin;
				windowTransform.anchorMax = smallAnchorMax;
				windowSizeText.text = smallWindowText;
			}
			
			void SetMediumWindowSize()
			{
				windowTransform.anchorMin = mediumAnchorMin;
				windowTransform.anchorMax = mediumAnchorMax;
				windowSizeText.text = mediumWindowText;
			}
			
			void SetLargeWindowSize()
			{
				windowTransform.anchorMin = largeAnchorMin;
				windowTransform.anchorMax = largeAnchorMax;
				windowSizeText.text = largeWindowText;
			}
		}
	}
}