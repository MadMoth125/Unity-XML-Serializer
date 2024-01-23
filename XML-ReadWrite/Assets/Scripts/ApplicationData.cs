namespace SerializedXML.Data
{
	/// <summary>
	/// Simple struct to represent the application data.
	/// Contains data for the application's theme, language, and window size.
	/// Cannot update data once past construction.
	/// </summary>
	public struct ApplicationData
	{
		// constructor
		public ApplicationData(Theme theme, Language language, WindowSize size)
		{
			AppTheme = theme;
			AppLanguage = language;
			AppWindowSize = size;
		}
		
		public Theme AppTheme { get; private set; }
		public Language AppLanguage { get; private set; }
		public WindowSize AppWindowSize { get; private set; }

		/// <summary>
		/// Simple enum to represent the color theme of the application.
		/// </summary>
		public enum Theme
		{
			Light = 0,
			Dark = 1
		}
		
		/// <summary>
		/// Simple enum to represent the display language of the application.
		/// </summary>
		public enum Language
		{
			English = 0,
			Espanol = 1
		}
		
		/// <summary>
		/// Simple enum to represent the window size of the application.
		/// </summary>
		public enum WindowSize
		{
			Small = 0,
			Medium = 1,
			Large = 2
		}
	}
}