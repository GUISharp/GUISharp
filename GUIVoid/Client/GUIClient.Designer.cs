using static GUIVoid.Constants.ThereIsGConstants;

namespace GUIVoid.Client
{
	partial class GUIClient
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		private void InitializaComponent()
		{

			Universe.SetUpUniverse();
			// check if the game is the single one process or not.
			if (Actions.IsSingleOne() || !this.RunSingleInstance)
			{
				//AppSettings.DECoder = new DECoder();
				// check if we can manage to create a single-one
				// provider peeker or not.
				// this method should try to create a memory space for us,
				// which will be visible to another instances.
				if (Actions.CreateSingleOne() || !this.RunSingleInstance)
				{
					// it means the game is the single-instance,
					// so you can now run the game.
					// so, create a new instance of the game client.
					// set the verified property to true,
					// to show the single-instance has been verified.
					this._g = new(true);
				}
				else
				{
					return;
				}
			}
			else
			{
				try
				{
					// it means this process is not the single-one,
					// and another game process is already running, so
					// send a request to another universe and tell them:
					// make your ass up and active your planet :/
					Universe.Universe_Request();
				}
				catch
				{
					;
				}

				return;
			}
			//---------------------------------------------
			//news:
			
			//---------------------------------------------
			//names:
			//fontAndTextAligns:
			//priorities:
			//sizes:
			//ownering:
			//locations:
			//movements:
			//colors:
			//test.ChangeForeColor(Color.Red);
			//enableds:
			//texts:
			//images:
			//applyAndShow:
			//events:
			//---------------------------------------------
			//addRanges:
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
		public virtual void Start()
		{
			this._g?.Run();
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