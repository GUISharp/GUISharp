/*
 * This file is part of GUISharp Project (https://github.com/GUISharp/GUISharp).
 * Copyright (c) 2021 GUISharp Authors.
 *
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * This library is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this source code of library. 
 * If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.WotoProvider.Enums;
using GUISharp.WotoProvider.EventHandlers;
using GUISharp.SandBox;
using GUISharp.Controls;
using GUISharp.GUIObjects.Texts;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Graphics;
using GUISharp.GUIObjects.Resources;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace GUISharp.Client
{
	partial class GClient
	{
		//-------------------------------------------------
		#region MainForm Region

		//-------------------------------------------------
		#region Initialize Region
		/// <summary>
		/// MainForm Initialize Component.
		/// </summary>
		private void MF_InitializeComponents()
		{
			//try
			//{
			//	// HttpListener _listener = new HttpListener();
			//	TcpClient _tcp = new TcpClient();
			//	NetworkStream _stream;
			//	_tcp.Connect("localhost", 37372);
			//	_stream = _tcp.GetStream();
			//	byte[] _b = new byte[512];
			//	var _result = _stream.Read(_b);
			//	var _str = System.Text.Encoding.UTF8.GetString(_b).TrimEnd();
			//	Console.WriteLine("got something! :" + _str + " - " + _str.Length + " - "+ _b.Length);
			//}
			//catch
			//{
			//	
			//}
			
#if BUTTON_TEST_1
			//---------------------------------------------
			//news:
			this.MyRes = new WotoRes(typeof(GClient));
			this.FirstFlatElement = new FlatElement(this, ElementMovements.HorizontalMovements);
			ButtonElement test = new ButtonElement(this);
			FlatElement _f1 = new FlatElement(this, ElementMovements.VerticalHorizontalMovements);
			FlatElement _f2 = new FlatElement(this, ElementMovements.HorizontalMovements);
			this.LoadMFBackGround();
			//---------------------------------------------
			//names:
			this.FirstFlatElement.SetLabelName(FirstLabelNameInRes);

			//fontAndTextAligns:
			this.FirstFlatElement.ChangeFont(this.FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 19));
			test.ChangeFont(this.FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 19));
			_f1.ChangeFont(this.FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 19));
			_f2.ChangeFont(this.FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 19));
			
			this.FirstFlatElement.ChangeAlignmation(StringAlignmation.MiddleCenter);
			test.ChangeAlignmation(StringAlignmation.MiddleCenter);
			_f1.ChangeAlignmation(StringAlignmation.MiddleCenter);
			_f2.ChangeAlignmation(StringAlignmation.MiddleCenter);
			//priorities:
			this.FirstFlatElement.ChangePriority(ElementPriority.Normal);
			_f1.ChangePriority(ElementPriority.Normal);
			_f2.ChangePriority(ElementPriority.VeryHigh);
			test.ChangePriority(ElementPriority.High);
			//sizes:
			this.FirstFlatElement.ChangeSize(this.Width / 6, this.Height / 6);
			test.ChangeSize(150, 46);
			_f1.ChangeSize(200, 300);
			_f2.ChangeSize(100, 100);
			//ownering:
			_f2.SetOwner(_f1);
			//locations:
			this.FirstFlatElement.ChangeLocation((Width - FirstFlatElement.Width) -
				(2 * SandBoxBase.from_the_edge),
				(Height - FirstFlatElement.Height) - SandBoxBase.from_the_edge);

			test.ChangeLocation(100f, 100f);
			_f1.ChangeLocation(300f, 200f);
			_f2.ChangeLocation(10f, 10f);
			//movements:
			this.FirstFlatElement.ChangeMovements(ElementMovements.VerticalMovements);
			_f1.ChangeMovements(ElementMovements.VerticalHorizontalMovements);
			//colors:
			// this.FirstFlatElement.ChangeBackColor(Color.Red);
			this.FirstFlatElement.ChangeForeColor(Color.DarkSeaGreen);
			test.ChangeBorder(WotoProvider.Enums.ButtonColors.WhiteSmoke);
			_f1.ChangeBackColor(new Color(Color.Orange, 0.5f));
			_f2.ChangeBackColor(Color.Blue);
			_f2.ChangeForeColor(new Color(Color.Red, 0.7f));
			//test.ChangeForeColor(Color.Red);
			//enableds:
			test.EnableMouseEnterEffect();
			//texts:
			this.FirstFlatElement.SetLabelText();
			test.SetLabelText("Test");
			//_f1.SetLabelText("F1");
			_f2.SetLabelText("Flat2");
			//images:
			this.FirstFlatElement.ChangeImage();
			
			
			//applyAndShow:
			this.FirstFlatElement.Apply();
			this.FirstFlatElement.Show();
			_f2.Apply();
			_f2.Show();
			_f1.Apply();
			_f1.Show();

			test.Apply();
			test.Show();
			//events:
			this.GameUniverse.WotoPlanet.MouseDown += WotoPlanet_MouseDown;
			this.GameUniverse.WotoPlanet.MouseUp += WotoPlanet_MouseUp;
			this.Window.TextInput += Window_TextInput;
			//---------------------------------------------
			//addRanges:
			this.ElementManager.Add(this.FirstFlatElement);
			this.ElementManager.Add(test);
			this.ElementManager.Add(_f1);
			//---------------------------------------------
#endif
			//---------------------------------------------
			//news:
			this.MyRes = new WotoRes(typeof(GClient));
			this.FirstFlatElement = new FlatElement(this, 
				ElementMovements.NoMovements);
			//LoginProfileSandBox test = new();
			//ProfileWrongSandBox test = new();
			InputElement testInput = new(this);
			//this.LoadMFBackGround();
			//---------------------------------------------
			//names:
			this.FirstFlatElement.SetLabelName(FirstLabelNameInRes);
			//status:
			testInput.SetStatus(1);
			//fontAndTextAligns:
			this.FirstFlatElement.ChangeFont(this.FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 26));
			testInput.ChangeFont(this.FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 25));
			this.FirstFlatElement.ChangeAlignmation(StringAlignmation.MiddleCenter);
			testInput.ChangeAlignmation(StringAlignmation.MiddleCenter);
			//priorities:
			this.FirstFlatElement.ChangePriority(ElementPriority.Normal);
			testInput.ChangePriority(ElementPriority.Normal);
			//sizes:
			this.FirstFlatElement.ChangeSize(this.Width / 6, this.Height / 6);
			testInput.ChangeSize();
			//ownering:
			//locations:
			this.FirstFlatElement.ChangeLocation((Width - FirstFlatElement.Width) -
				(2 * SandBoxBase.from_the_edge),
				(Height - FirstFlatElement.Height) - SandBoxBase.from_the_edge);
			testInput.ChangeLocation(400, 200);
			//movements:
			//colors:
			testInput.ChangeBorder(InputBorders.Goldenrod);
			testInput.ChangeForeColor(Color.WhiteSmoke);
			this.FirstFlatElement.ChangeForeColor(Color.DarkSeaGreen);
			//enableds:
			this.FirstFlatElement.Enable(true);
			testInput.Enable(true);
			testInput.EnableMouseEnterEffect();
			//testInput.Focus(true);
			//texts:
			this.FirstFlatElement.SetLabelText();
			this.FirstFlatElement.SetLabelText(this.FirstFlatElement.Text);
			//images:
			this.FirstFlatElement.ChangeImage();
			//applyAndShow:
			this.FirstFlatElement.Apply();
			this.FirstFlatElement.Show();
			//test.Apply();
			//test.Show();
			testInput.Apply();
			testInput.Show();
			//events:
			this.InitializeMainEvents();
			//---------------------------------------------
			//addRanges:
			this.ElementManager.AddRange(
				this.FirstFlatElement,
				//test,
				testInput);
			//---------------------------------------------
			//finalBlow:
			//---------------------------------------------
		}

		
		private void InitializeComponents()
		{
			//---------------------------------------------
			
			//---------------------------------------------
			//names:
			//status:
			//fontAndTextAligns:
			//priorities:
			//sizes:
			//ownering:
			//locations:
			//movements:
			//colors:
			//enableds:
			//testInput.Focus(true);
			//texts:
			//images:
			//applyAndShow:
			//test.Apply();
			//test.Show();
			//events:
			//---------------------------------------------
			//addRanges:
			//---------------------------------------------
			//finalBlow:
			//---------------------------------------------
		}

		
		/// <summary>
		/// add the main events.
		/// </summary>
		private void InitializeMainEvents()
		{
			//---------------------------------------------
			this.GameUniverse.MouseDown		-= WotoPlanet_MouseDown;
			this.GameUniverse.MouseUp		-= WotoPlanet_MouseUp;
			this.Window.KeyDown				-= Window_KeyDown;
			this.Window.KeyUp				-= Window_KeyUp;
			this.Window.TextInput			-= Window_TextInput;
			this.GameUniverse.MouseDown		+= WotoPlanet_MouseDown;
			this.GameUniverse.MouseUp		+= WotoPlanet_MouseUp;
			this.Window.KeyDown				+= Window_KeyDown;
			this.Window.KeyUp				+= Window_KeyUp;
			this.Window.TextInput			+= Window_TextInput;
			//---------------------------------------------
			#if SETVER_TEST
			System.Net.Http.HttpClient test = new System.Net.Http.HttpClient();
			test.BaseAddress = new Uri("https://GUISharp-game.herokuapp.com");
			System.Net.Http.HttpRequestMessage ro = new System.Net.Http.HttpRequestMessage();
			ro.Headers.Add("test", "    HELLO!!!!!!!");
			var _res = test.Send(ro);

			Stream receiveStream = _res.Content.ReadAsStream();
			StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
			var text1 = readStream.ReadToEnd();

			ro = new System.Net.Http.HttpRequestMessage();
			_res = test.Send(ro);

			receiveStream = _res.Content.ReadAsStream();
			readStream = new StreamReader(receiveStream, Encoding.UTF8);
			var text2 = readStream.ReadToEnd();
			#endif
		}
		/// <summary>
		/// Load the Main Form Background of the game.
		/// </summary>
		/// <param name="_loading"></param>
		private void LoadMFBackGround(bool _loading = true)
		{
			if (_loading)
			{
				this.BackGroundTexture?.Dispose();
				var _num = DateTime.Now.Second % EntryCount;
				var _name = "EntryPicNameInRes" + _num.ToString();
				var _b = (byte[]) this.MyRes.GetObject(_name);
				using (var m = new MemoryStream(_b))
				{
					this.BackGroundTexture = Texture2D.FromStream(GraphicsDevice, m);
				}
			}
			else
			{
				// Not Completed
				this.BackGroundTexture?.Dispose();
				using (var m = this.MyRes.GetStream("AincradNameInRes"))
				{
					this.BackGroundTexture = Texture2D.FromStream(GraphicsDevice, m);
				}
			}
			
		}
		#endregion
		//-------------------------------------------------

		#endregion
		//-------------------------------------------------
		#region GClient Region

		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		/// <summary>
		/// Returns a string that represents the current GClient 
		/// of GUISharp library.
		/// </summary>
		/// <returns>
		/// A string that represents the current 
		///  GClient of GUISharp library.
		/// </returns>
		public override string ToString()
		{
			return ToStringValue;
		}
		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			//---------------------------------------------
			//news:
			this.FontManager ??= FontManager.GenerateManager(this);
			this.ElementManager ??= new ElementManager();
			this.MyRes ??= new WotoRes(typeof(GClient));
#if __WINDOWS__
			this.MusicManager = MusicManager.GetMusicManager();
#endif //__WINDOWS__
			this.InitializeMainEvents();
			
			GraphicsDM.PreferredBackBufferWidth = GameUniverse.DefaultWidth;
			GraphicsDM.PreferredBackBufferHeight = GameUniverse.DefaultHeight;
			base.Initialize();
			// check if the game window position is zero or not.
			if (Window.Position != GameUniverse.DefaultPoint)
			{
				// set the game window position to the default
				// value that we set before starting.
				Window.Position = GameUniverse.DefaultPoint;
			}
			GraphicsDM.ApplyChanges();

			if (Universe.IsUnix && this.GUIClient.RunSingleInstance)
			{
				// check if game universe have to check the 
				// __mmf__ assist file or not.
				if (!this.GameUniverse._checkFile)
				{
					this.GameUniverse._checkFile = true;
				}
			}
			
			this.GUIClient.InitializeComponents();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			//---------------------------------------------
			//news:
			this.MySprite = new SpriteWoto(GraphicsDevice);
			//---------------------------------------------
		}
		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			//---------------------------------------------
			this.Unloading?.Invoke();
			//---------------------------------------------
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				this.Exit();
			}
			
			// update the game universe, so it can handle its own events.
			this.GameUniverse?.UpdateUniverse();
			// check the requests came from outside of the envinment of the Game. 
			this.CheckRequests();
			// check mouse actions of the elements.
			this.MouseActions();
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			this.GraphicsDevice.Clear(Color.Black);
			this.MySprite.Start();
			this.DrawBackGround();
			this.ElementManager?.Draw(gameTime, this.MySprite);
			this.MySprite.Finish();
			base.Draw(gameTime);
		}
		#endregion
		//-------------------------------------------------
		#region Background Method's Region
		/// <summary>
		/// allow the <see cref="GClient"/> to draw its background.
		/// </summary>
		private void DrawBackGround()
		{
			if (this.BackGroundTexture == null || this.BackGroundTexture.IsDisposed)
			{
				return;
			}
			//this.MySprite.Begin();
			this.MySprite.Draw(this.BackGroundTexture, this.GameUniverse.XRectangle, 
				this.BackGroundTexture.Bounds, 
				Color.White);
			//this.MySprite.End();
		}
		#endregion
		//-------------------------------------------------
		#region Odrinary Method's Region
		private void CheckRequests()
		{
			// chec if there is a request from the universe or not.
			if (this.Universe_Request)
			{
				switch (Request)
				{
					case RequestType.None:
						break;
					case RequestType.Activate:
					{
						try
						{
							this.Universe_Request = false;
							this.Request = RequestType.None;
							// this.GameUniverse.WotoPlanet?.Show();
							// this.GameUniverse.WotoPlanet?.BringToFront();
							// this.GameUniverse.WotoPlanet?.Activate();
							// this.GameUniverse.WotoPlanet?.Focus();
							this.GraphicsDM.ToggleFullScreen();
						}
						catch
						{
							// the activating was not successful,
							// so what should we do??
							// here was the last step that we could avtive the
							// holy planet of woto, but it failed, 
							// it means there is no further steps.
							// so the story will end right here right now.
						}
						break;
					}
					default:
						break;
				}

			}
		}
		private void MouseActions()
		{
			this.LastMouseState = this.CurrentState;
			this.CurrentState = Mouse.GetState();
			if (this.ElementManager != null)
			{
				if (this.ElementManager.MouseContains())
				{
					this.ElementManager.MouseChange();
				}
			}
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		public void ActivateInputable(IInputable inputElement, bool focus = true)
		{
			if (inputElement == null || inputElement == this.InputElement)
			{
				return;
			}
			this.InputElement = inputElement;
			if (focus)
			{
				this.InputElement.Focus(true);
			}
		}
		public void DeactiveInputable()
		{
			if (this.InputElement != null)
			{
				this.InputElement?.UnFocus();
				this.InputElement = null;
			}
		}
		#endregion
		//-------------------------------------------------
		#region event Method's Region
		private void WotoPlanet_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.IsLeftDown)
				{
					this.PreviousLeftDownPoint = this.LeftDownPoint;
					this.LeftDownPoint = null;
					this.IsLeftDown = false;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				if (this.IsRightDown)
				{
					this.PreviousRightDownPoint = this.RightDownPoint;
					this.RightDownPoint = null;
					this.IsRightDown = false;
				}
			}
		}

		private void WotoPlanet_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (!this.IsLeftDown)
				{
					this.LeftDownPoint = this.CurrentState.Position;
					this.IsLeftDown = true;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				if (!this.IsRightDown)
				{
					this.RightDownPoint = this.CurrentState.Position;
					this.IsRightDown = true;
				}
			}
		}

		private void Window_TextInput(object sender, TextInputEventArgs e)
		{
			this.InputElement?.InputEvent(sender, e);
		}
		private void Window_KeyDown(object sender, InputKeyEventArgs e)
		{
			var k = e.Key;
			if (k == Keys.LeftControl || k == Keys.RightControl)
			{
				this.IsCtrlDown = true;
			}
			if (this.IsCtrlDown && 
				(this.InputElement != null && this.InputElement.IsShortcutKey(e)))
			{
				this.InputElement?.ShortcutEvent(sender, e, this.IsCtrlDown);
			}
		}
		private void Window_KeyUp(object sender, InputKeyEventArgs e)
		{
			var k = e.Key;
			if (k == Keys.LeftControl || k == Keys.RightControl)
			{
				this.IsCtrlDown = false;
				return;
			}
		}
		#endregion
		//-------------------------------------------------
	}
}
