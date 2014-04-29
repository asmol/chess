using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace chess
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormMain form = new FormMain();

            Game game = new Game(form,  CreatePlayers(), new SimpleTurnProcessor());
            Thread gameThread = new Thread(new ThreadStart(game.StartGame));
            gameThread.IsBackground = true;
<<<<<<< HEAD
            gameThread.SetApartmentState(ApartmentState.STA);
=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
            gameThread.Start();

            Application.Run(form);

        }


        static Player[] CreatePlayers()
        {
            return new Player[]{
                new Player(ETeam.White,  600),
                //new Player(ETeam.Black,600)
<<<<<<< HEAD
                new Player(ETeam.Black,  600)
            };
        }
    }
}
=======
                new ComputerDefault(ETeam.Black,  600)
            };
        }
    }
}
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
