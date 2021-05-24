using FlatRedBall;
using FlatRedBall.Input;
namespace Super_Marios_Bros.Screens
{
	public partial class GameScreen
	{
		private bool checkforit = false;

		void CustomInitialize()
		{
			CombinedShapeCollection.InsertCollidables(A_BrickList);
			CombinedShapeCollection.InsertCollidables(Lucky_blockList);
			Camera.Main.Y = -120;
			Camera.Main.X = 140;
		}
		void CustomActivity(bool firstTimeCalled)
		{
			Mario_Main_GUI.AnimateSelf();
			if (MarioInstance.X > 140 && MarioInstance.X < 3232)
			{
				Camera.Main.X = MarioInstance.X;
			}
			if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.R))
			{
				this.RestartScreen(true, true);
			}
			if (checkforit == true)
			{
				Deadactivity();
			}
			if (MarioInstance.Y <= -300)
			{
				HandleMarioDead();
			}
			if (MarioInstance.X >= 3232)
			{
				PassonClass.win = true;
				PassonClass.lifes = -1;
				MoveToScreen("GameoverScreen");
			}
			CheatCodes();
			TimeActivity();
			GuiActivity(); //AT THE END OR ELSE IT WILL GET BUGGY
		}
		void CustomDestroy()
		{


		}
		static void CustomLoadStaticContent(string contentManagerName)
		{


		}
		void Deadactivity()
		{

		}
		void TimeActivity()
		{
			if (checkforit == false)
			{
				PassonClass.TimeTillTheEnd -= TimeManager.SecondDifference;
				if (PassonClass.TimeTillTheEnd <= 0)
				{
					HandleMarioDead();
				}
			}
			if (PassonClass.TimeToGo)
			{
				PassonClass.TimeToGo = false;
				MoveToScreen("GameoverScreen");
			}
		}
		void GuiActivity()
		{
			Mario_Main_GUI.Score.Text = PassonClass.Score.ToString();
			Mario_Main_GUI.Score1.Text = PassonClass.Coins.ToString();
			Mario_Main_GUI.TextInstance5.Text = PassonClass.TimeTillTheEnd.ToString("0");
		}
		private void HandleMarioDead()
		{
			DeadMarioInstance.X = MarioInstance.X;
			DeadMarioInstance.Y = MarioInstance.Y;
			DeadMarioInstance.DEAD();
			MarioInstance.Destroy();
			checkforit = true;
		}
		public void AnimEnd()
		{
			RestartScreen(true, true);
		}
		void CheatCodes() //yes i have played games that old
		{
			//KONAMI CODE UP UP DOWN DOWN LEFT RIGHT LEFT RIGHT A B
			if (true) //up
			{

			}
			if (true) //up
			{

			}
			if (true) //down
			{

			}
			if (true) //down
			{

			}
			if (true) //left
			{

			}
			if (true) //right
			{

			}
			if (true) //left
			{

			}
			if (true) //right
			{

			}
			if (true) //a
			{

			}
			if (true) //b
			{

			}
		}
	}
}
