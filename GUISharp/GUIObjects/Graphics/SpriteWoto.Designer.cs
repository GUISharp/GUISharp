
namespace GUISharp.GUIObjects.Graphics
{
	partial class SpriteWoto
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		// some methods here
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
		public void Start()
		{
			if (!this.IsStarted)
			{
				this.Begin();
				this.IsStarted = true;
			}
		}
		public void Finish()
		{
			if (this.IsStarted)
			{
				this.End();
				this.IsStarted = false;
			}
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
	}
}