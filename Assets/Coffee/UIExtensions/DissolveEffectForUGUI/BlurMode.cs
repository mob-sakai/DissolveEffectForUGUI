namespace Coffee.UIExtensions
{
	/// <summary>
	/// Blur effect mode.
	/// </summary>
	public enum BlurMode
	{
		[System.Obsolete("Use FastBlur instead (UnityUpgradable) -> FastBlur")]
		Fast = 1,
		[System.Obsolete("Use MediumBlur instead (UnityUpgradable) -> MediumBlur")]
		Medium = 2,
		[System.Obsolete("Use DetailBlur instead (UnityUpgradable) -> DetailBlur")]
		Detail = 3,

		None = 0,
		FastBlur = 1,
		MediumBlur = 2,
		DetailBlur = 3,
	}
}