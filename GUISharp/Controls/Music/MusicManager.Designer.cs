
#if __WINDOWS__

using System.IO;

namespace GUISharp.Controls.Music
{
	internal partial class MusicManager
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		private void InitializeComponent()
		{
			//---------------------------------------------
			//news:
			this.MyRes = new(typeof(MusicManager));
			//---------------------------------------------
		}
		#endregion
		//-------------------------------------------------
		#region Graphical Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region event Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		public Stream GetNoiceStream(Noises noise)
		{
			if (noise == Noises.NoNoise)
			{
				return null;
			}
			switch (noise)
			{
				case Noises.ClickNoise:
				{
					if (this.MyRes != null)
					{
						return this.MyRes.AllocateMemoryStream(ClickNoise_FileNameInRes);
					}
					break;
				}
				default:
				{
					return null;
				}
			}
			return null;
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
	}
}

#endif //__WINDOWS__