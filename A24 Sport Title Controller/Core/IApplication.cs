using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Sport_Title_Controller.Core
{
    public interface IApplication
    {
        string User { get; }

        event EventHandler UserChanged;
        void ChangeUser(string name);

        string ImageTeam1 { get; }

        event EventHandler ImageTeam1Changed;
        void ChangeImageTeam1(string path);

        string ImageTeam2 { get; }

        event EventHandler ImageTeam2Changed;
        void ChangeImageTeam2(string path);

        string TeamName1 { get; }

        event EventHandler TeamName1Changed;
        void ChangeTeamName1(string name);

        string TeamName2 { get; }

        event EventHandler TeamName2Changed;
        void ChangeTeamName2(string name);

        string CityTeam1 { get; }

        event EventHandler CityTeam1Changed;
        void ChangeCityTeam1(string city);

        string CityTeam2 { get; }

        event EventHandler CityTeam2Changed;
        void ChangeCityTeam2(string city);

        string MainTrainerTeam1 { get; }

        event EventHandler MainTrainerTeam1Changed;
        void ChangeMainTrainerTeam1(string city);

        string MainTrainerTeam2 { get; }

        event EventHandler MainTrainerTeam2Changed;
        void ChangeMainTrainerTeam2(string city);

        string StadiumName { get; }

        event EventHandler StadiumNameChanged;
        void ChangeStadiumName(string name);

        string GameType { get; }

        event EventHandler GameTypeChanged;
        void ChangeGameType(string game);

        string Coach1 { get; }

        event EventHandler Coach1Changed;
        void ChangeCoach1(string coach);

        string Coach2 { get; }

        event EventHandler Coach2Changed;
        void ChangeCoach2(string coach);

        string DelMin { get; }

        event EventHandler DelMinChanged;
        void ChangeDelMin(string coach);

        string DelSec { get; }

        event EventHandler DelSecChanged;
        void ChangeDelSec(string coach);

        string PathToTHandBall { get; }

        event EventHandler PathToTHandBallChanged;
        void ChangePathToTHandBall(string path);

        string PathToTMiniSoccer { get; }

        event EventHandler PathToTMiniSoccerChanged;
        void ChangePathToTMiniSoccer(string path);

        string PathToTSoccer { get; }

        event EventHandler PathToTSoccerChanged;
        void ChangePathToTSoccer(string path);

        string PathToTWaterPolo { get; }

        event EventHandler PathToTWaterPoloChanged;
        void ChangePathToTWaterPolo(string path);

        string PathToTBasketBall { get; }

        event EventHandler PathToTBasketBallChanged;
        void ChangePathToTBasketBall(string path);

        string PathToTJudo { get; }

        event EventHandler PathToTJudoChanged;
        void ChangePathToTJudo(string path);

        string CasparConnected { get; }

        event EventHandler CasparConnectedChanged;
        void ChangeCasparConnected(string path);
    }
}
