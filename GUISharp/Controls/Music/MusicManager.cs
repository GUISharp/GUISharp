
using GUISharp.GUIObjects.Resources;

namespace GUISharp.Controls.Music
{
	/// <summary>
	/// Music manager of GUISharp library.
	/// It's for internal usages only.
	/// </summary>
	internal sealed partial class MusicManager : IRes
	{
		//-------------------------------------------------
		#region Constant's Region
		public const string ClickNoise_FileNameInRes = "m__1u_2__1";
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		public WotoRes MyRes { get; set; }
		#endregion
		//-------------------------------------------------
		#region static field's Region
		private static MusicManager manager;
		#endregion
		//-------------------------------------------------
		#region field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static event field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region event field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		private MusicManager()
		{
			InitializeComponent();
		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static generation methods
		internal static MusicManager GetMusicManager()
		{
			manager ??= new();
			return manager;
		}
		#endregion
		//-------------------------------------------------

	}
}