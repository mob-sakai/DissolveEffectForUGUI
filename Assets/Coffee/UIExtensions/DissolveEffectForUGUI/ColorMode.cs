namespace Coffee.UIExtensions
{
	/// <summary>
	/// Color effect mode.
	/// </summary>
	public enum ColorMode
	{
		[System.Obsolete("Use Multiply instead (UnityUpgradable) -> Multiply")]
		None = 0,
		[System.Obsolete("Use Fill instead (UnityUpgradable) -> Fill")]
		Set = 1,
		[System.Obsolete("Use Subtract instead (UnityUpgradable) -> Subtract")]
		Sub = 3,

		Multiply = 0,
		Fill = 1,
		Add = 2,
		Subtract = 3,
	}
}