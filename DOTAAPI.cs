using Dota2GSI;
using System;

//documentation
//https://github.com/antonpup/Dota2GSI
namespace DOTA_CUE
{
	class DOTAAPI
	{
		public GameStateListener gsl { get; private set; }

		/// <summary>
		/// Starts the Dota2GSI connection
		/// </summary>
		/// <param name="ip"></param>
		public void connectToDota(string ip)
		{
			try
			{
				gsl = new GameStateListener($"http://{ip}/");
				gsl.NewGameState += new NewGameStateHandler(OnNewGameState);
				if (gsl.Start())
				{
					Console.Write("Game Listener Started\n");
				}
				else
				{
					Console.Write("Couldn't Start Game Listener. Try running as admin.\n");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception occured in starting Game Listener!");
				Console.WriteLine("Message: " + ex.Message.ToString());
			}
		}

		/// <summary>
		/// Handle a new gamestate
		/// </summary>
		/// <param name="gs"></param>
		public void OnNewGameState(GameState gs)
		{
			Core.handleGameState(gs);
		}
	}
}
