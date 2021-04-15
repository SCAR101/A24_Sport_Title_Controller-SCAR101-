using A24_Sport_Title_Controller.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Sport_Title_Controller.Models
{
    class TablePlayerList2Model : OnPropertyChangedClass
    {
        private int _playerNumber;
        private string _playerFIO;
        private string _playerPosition;
        private bool _playerReserve;
        private string _playerYellow;
        private string _playerYellowTime;
        private string _playerRed;
        private string _playerRedTime;
        private string _playerGoals;
        private string _playerGoalsTime;
        private string _playerShotsOnTarget;
        private string _playerPinalty;
        private string _playerGoalPinalty;

        public int PlayerNumber { get => _playerNumber; set => SetProperty(ref _playerNumber, value); }
        public string PlayerFIO { get => _playerFIO; set => SetProperty(ref _playerFIO, value?.Trim()); }
        public string PlayerPosition { get => _playerPosition; set => SetProperty(ref _playerPosition, value?.Trim()); }
        public bool PlayerReserve { get => _playerReserve; set => SetProperty(ref _playerReserve, value); }
        public string PlayerYellow { get => _playerYellow; set => SetProperty(ref _playerYellow, value); }
        public string PlayerYellowTime { get => _playerYellowTime; set => SetProperty(ref _playerYellowTime, value); }
        public string PlayerRed { get => _playerRed; set => SetProperty(ref _playerRed, value); }
        public string PlayerRedTime { get => _playerRedTime; set => SetProperty(ref _playerRedTime, value); }
        public string PlayerGoals { get => _playerGoals; set => SetProperty(ref _playerGoals, value); }
        public string PlayerGoalsTime { get => _playerGoalsTime; set => SetProperty(ref _playerGoalsTime, value); }
        public string PlayerShotsOnTarget { get => _playerShotsOnTarget; set => SetProperty(ref _playerShotsOnTarget, value); }
        public string PlayerPinalty { get => _playerPinalty; set => SetProperty(ref _playerPinalty, value); }
        public string PlayerGoalPinalty { get => _playerGoalPinalty; set => SetProperty(ref _playerGoalPinalty, value); }
        public TablePlayerList2Model() { }
    }
}
