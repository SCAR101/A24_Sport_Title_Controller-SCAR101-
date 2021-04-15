using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Sport_Title_Controller.Core
{
    public class Application : IApplication
    {
        private string _user;
        public string User
        {
            get { return _user; }
            private set
            {
                _user = value;
                RaiseUserChanged();
            }
        }


        private string _imageTeam1;
        public string ImageTeam1
        {
            get { return _imageTeam1; }
            private set
            {
                _imageTeam1 = value;
                RaiseUserChanged();
            }
        }


        private string _imageTeam2;
        public string ImageTeam2
        {
            get { return _imageTeam2; }
            private set
            {
                _imageTeam2 = value;
                RaiseUserChanged();
            }
        }


        private string _teamName1;
        public string TeamName1
        {
            get { return _teamName1; }
            private set
            {
                _teamName1 = value;
                RaiseUserChanged();
            }
        }


        private string _teamName2;
        public string TeamName2
        {
            get { return _teamName2; }
            private set
            {
                _teamName2 = value;
                RaiseUserChanged();
            }
        }


        private string _cityTeam1;
        public string CityTeam1
        {
            get { return _cityTeam1; }
            private set
            {
                _cityTeam1 = value;
                RaiseUserChanged();
            }
        }


        private string _cityTeam2;
        public string CityTeam2
        {
            get { return _cityTeam2; }
            private set
            {
                _cityTeam2 = value;
                RaiseUserChanged();
            }
        }


        private string _mainTrainerTeam1;
        public string MainTrainerTeam1
        {
            get { return _mainTrainerTeam1; }
            private set
            {
                _mainTrainerTeam1 = value;
                RaiseUserChanged();
            }
        }


        private string _mainTrainerTeam2;
        public string MainTrainerTeam2
        {
            get { return _mainTrainerTeam2; }
            private set
            {
                _mainTrainerTeam2 = value;
                RaiseUserChanged();
            }
        }


        private string _stadiumName;
        public string StadiumName
        {
            get { return _stadiumName; }
            private set
            {
                _stadiumName = value;
                RaiseUserChanged();
            }
        }


        private string _gameType;
        public string GameType
        {
            get { return _gameType; }
            private set
            {
                _gameType = value;
                RaiseUserChanged();
            }
        }


        private string _coach1;
        public string Coach1
        {
            get { return _coach1; }
            private set
            {
                _coach1 = value;
                RaiseUserChanged();
            }
        }


        private string _coach2;
        public string Coach2
        {
            get { return _coach2; }
            private set
            {
                _coach2 = value;
                RaiseUserChanged();
            }
        }


        private string _delMin;
        public string DelMin
        {
            get { return _delMin; }
            private set
            {
                _delMin = value;
                RaiseUserChanged();
            }
        }


        private string _delSec;
        public string DelSec
        {
            get { return _delSec; }
            private set
            {
                _delSec = value;
                RaiseUserChanged();
            }
        }


        private string _pathToTHandBall;
        public string PathToTHandBall
        {
            get { return _pathToTHandBall; }
            private set
            {
                _pathToTHandBall = value;
                RaiseUserChanged();
            }
        }


        private string _pathToTMiniSoccer;
        public string PathToTMiniSoccer
        {
            get { return _pathToTMiniSoccer; }
            private set
            {
                _pathToTMiniSoccer = value;
                RaiseUserChanged();
            }
        }


        private string _pathToTSoccer;
        public string PathToTSoccer
        {
            get { return _pathToTSoccer; }
            private set
            {
                _pathToTSoccer = value;
                RaiseUserChanged();
            }
        }


        private string _pathToTWaterPolo;
        public string PathToTWaterPolo
        {
            get { return _pathToTWaterPolo; }
            private set
            {
                _pathToTWaterPolo = value;
                RaiseUserChanged();
            }
        }


        private string _pathToTBasketBall;
        public string PathToTBasketBall
        {
            get { return _pathToTBasketBall; }
            private set
            {
                _pathToTBasketBall = value;
                RaiseUserChanged();
            }
        }


        private string _pathToTJudo;
        public string PathToTJudo
        {
            get { return _pathToTJudo; }
            private set
            {
                _pathToTJudo = value;
                RaiseUserChanged();
            }
        }


        private string _casparConnected;
        public string CasparConnected
        {
            get { return _casparConnected; }
            private set
            {
                _casparConnected = value;
                RaiseUserChanged();
            }
        }



        public event EventHandler UserChanged;
        public event EventHandler ImageTeam1Changed;
        public event EventHandler ImageTeam2Changed;
        public event EventHandler TeamName1Changed;
        public event EventHandler TeamName2Changed;
        public event EventHandler CityTeam1Changed;
        public event EventHandler CityTeam2Changed;
        public event EventHandler MainTrainerTeam1Changed;
        public event EventHandler MainTrainerTeam2Changed;
        public event EventHandler StadiumNameChanged;
        public event EventHandler GameTypeChanged;
        public event EventHandler Coach1Changed;
        public event EventHandler Coach2Changed;
        public event EventHandler DelMinChanged;
        public event EventHandler DelSecChanged;
        public event EventHandler PathToTHandBallChanged;
        public event EventHandler PathToTMiniSoccerChanged;
        public event EventHandler PathToTSoccerChanged;
        public event EventHandler PathToTWaterPoloChanged;
        public event EventHandler PathToTBasketBallChanged;
        public event EventHandler PathToTJudoChanged;
        public event EventHandler CasparConnectedChanged;

        protected virtual void RaiseUserChanged()
        {
            UserChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseImageTeam1Changed()
        {
            ImageTeam1Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseImageTeam2Changed()
        {
            ImageTeam2Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseTeamName1Changed()
        {
            TeamName1Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseTeamName2Changed()
        {
            TeamName2Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseCityTeam1Changed()
        {
            CityTeam1Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseCityTeam2Changed()
        {
            CityTeam2Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseMainTrainerTeam1Changed()
        {
            MainTrainerTeam1Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseMainTrainerTeam2Changed()
        {
            MainTrainerTeam2Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseStadiumNameChanged()
        {
            StadiumNameChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseGameTypeChanged()
        {
            GameTypeChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseCoach1Changed()
        {
            Coach1Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseCoach2Changed()
        {
            Coach2Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseDelMinChanged()
        {
            DelMinChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseDelSecChanged()
        {
            DelSecChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaisePathToTHandBallChanged()
        {
            PathToTHandBallChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaisePathToTMiniSoccerChanged()
        {
            PathToTMiniSoccerChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaisePathToTSoccerChanged()
        {
            PathToTSoccerChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaisePathToTWaterPoloChanged()
        {
            PathToTWaterPoloChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaisePathToTBasketBallChanged()
        {
            PathToTBasketBallChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaisePathToTJudoChanged()
        {
            PathToTJudoChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseCasparConnectedChanged()
        {
            CasparConnectedChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangeUser(string name)
        {
            if (User == name)
            {
                return;
            }

            if (name == null)
            {
                return;
            }

            User = name;
        }

        public void ChangeImageTeam1(string path)
        {
            if (ImageTeam1 == path)
            {
                return;
            }

            if (path == null)
            {
                return;
            }

            ImageTeam1 = path;
        }

        public void ChangeImageTeam2(string path)
        {
            if (ImageTeam2 == path)
            {
                return;
            }

            if (path == null)
            {
                return;
            }

            ImageTeam2 = path;
        }

        public void ChangeTeamName1(string name)
        {
            if (TeamName1 == name)
            {
                return;
            }

            if (name == null)
            {
                return;
            }

            TeamName1 = name;
        }

        public void ChangeTeamName2(string name)
        {
            if (TeamName2 == name)
            {
                return;
            }

            if (name == null)
            {
                return;
            }

            TeamName2 = name;
        }

        public void ChangeCityTeam1(string city)
        {
            if (CityTeam1 == city)
            {
                return;
            }

            if (city == null)
            {
                return;
            }

            CityTeam1 = city;
        }

        public void ChangeCityTeam2(string city)
        {
            if (CityTeam2 == city)
            {
                return;
            }

            if (city == null)
            {
                return;
            }

            CityTeam2 = city;
        }

        public void ChangeMainTrainerTeam1(string mainTrainer)
        {
            if (MainTrainerTeam1 == mainTrainer)
            {
                return;
            }

            if (mainTrainer == null)
            {
                return;
            }

            MainTrainerTeam1 = mainTrainer;
        }

        public void ChangeMainTrainerTeam2(string mainTrainer)
        {
            if (MainTrainerTeam2 == mainTrainer)
            {
                return;
            }

            if (mainTrainer == null)
            {
                return;
            }

            MainTrainerTeam2 = mainTrainer;
        }

        public void ChangeStadiumName(string name)
        {
            if (StadiumName == name)
            {
                return;
            }

            if (name == null)
            {
                return;
            }

            StadiumName = name;
        }

        public void ChangeGameType(string game)
        {
            if (GameType == game)
            {
                return;
            }

            if (game == null)
            {
                return;
            }

            GameType = game;
        }

        public void ChangeCoach1(string coach)
        {
            if (Coach1 == coach)
            {
                return;
            }

            if (coach == null)
            {
                return;
            }

            Coach1 = coach;
        }

        public void ChangeCoach2(string coach)
        {
            if (Coach2 == coach)
            {
                return;
            }

            if (coach == null)
            {
                return;
            }

            Coach2 = coach;
        }

        public void ChangeDelMin(string min)
        {
            if (DelMin == min)
            {
                return;
            }

            if (min == null)
            {
                return;
            }

            DelMin = min;
        }

        public void ChangeDelSec(string sec)
        {
            if (DelSec == sec)
            {
                return;
            }

            if (sec == null)
            {
                return;
            }

            DelSec = sec;
        }

        public void ChangePathToTHandBall(string path)
        {
            if (PathToTHandBall == path)
            {
                return;
            }

            if (path == null)
            {
                return;
            }

            PathToTHandBall = path;
        }

        public void ChangePathToTMiniSoccer(string path)
        {
            if (PathToTMiniSoccer == path)
            {
                return;
            }

            if (path == null)
            {
                return;
            }

            PathToTMiniSoccer = path;
        }

        public void ChangePathToTSoccer(string path)
        {
            if (PathToTSoccer == path)
            {
                return;
            }

            if (path == null)
            {
                return;
            }

            PathToTSoccer = path;
        }

        public void ChangePathToTWaterPolo(string path)
        {
            if (PathToTWaterPolo == path)
            {
                return;
            }

            if (path == null)
            {
                return;
            }

            PathToTWaterPolo = path;
        }

        public void ChangePathToTBasketBall(string path)
        {
            if (PathToTBasketBall == path)
            {
                return;
            }

            if (path == null)
            {
                return;
            }

            PathToTBasketBall = path;
        }

        public void ChangePathToTJudo(string path)
        {
            if (PathToTJudo == path)
            {
                return;
            }

            if (path == null)
            {
                return;
            }

            PathToTJudo = path;
        }

        public void ChangeCasparConnected(string connect)
        {
            if (CasparConnected == connect)
            {
                return;
            }

            if (connect == null)
            {
                return;
            }

            CasparConnected = connect;
        }

    }


}
