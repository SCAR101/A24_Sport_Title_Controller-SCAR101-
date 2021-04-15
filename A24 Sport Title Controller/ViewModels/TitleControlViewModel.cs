using A24_Sport_Title_Controller.Core;
using A24_Sport_Title_Controller.Core.Operations;
using A24_Sport_Title_Controller.Models;
using Egor92.MvvmNavigation.Abstractions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml;

namespace A24_Sport_Title_Controller.ViewModels
{
    class TitleControlViewModel : OnPropertyChangedClass, INavigatedToAware
    {
        private readonly INavigationManager _navigationManager;

        private readonly IApplication _application;

        private readonly TCPOperations _tCPOperations;

        DispatcherTimer _timer = new DispatcherTimer();
        DispatcherTimer TtimerDel1T1 = new DispatcherTimer();
        DispatcherTimer TtimerDel2T1 = new DispatcherTimer();
        DispatcherTimer TtimerDel3T1 = new DispatcherTimer();
        DispatcherTimer TtimerDel1T2 = new DispatcherTimer();
        DispatcherTimer TtimerDel2T2 = new DispatcherTimer();
        DispatcherTimer TtimerDel3T2 = new DispatcherTimer();

        public TitleControlViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                throw new Exception("Конструктор предназначен только для Времени Разработки!");
        }
        public TitleControlViewModel(INavigationManager navigationManager, IApplication application, TCPOperations tCPOperations)
        {
            _navigationManager = navigationManager;
            _application = application;
            _tCPOperations = tCPOperations;
            FrameOpacity = 1;
            TbClockMinutes = "00";
            TbClockSeconds = "00";
            TbButtonStartTime = "Старт";
            TxbIntervalTimer = "1000";
            TxbTimeEnd = "00";
            TxbTimeStart = "00";

            ImageScoreTeam1 = _application.ImageTeam1;
            ImageScoreTeam2 = _application.ImageTeam2;

            TbScoreTeam1 = "0";
            TbScoreTeam2 = "0";
            TbFoulsTeam1 = "0";
            TbFoulsTeam2 = "0";
            ShowFoulsKind = "Show";
            ShowFoulsColor = "#FF406787";
            TbShowFouls = "Показать";
            TbPeriod = "1";
            _timer.Tick += new EventHandler(tTimer_Tick);
            TtimerDel1T1.Tick += new EventHandler(tTimerDel1T1_Tick);
            TtimerDel2T1.Tick += new EventHandler(tTimerDel2T1_Tick);
            TtimerDel3T1.Tick += new EventHandler(tTimerDel3T1_Tick);
            TtimerDel1T2.Tick += new EventHandler(tTimerDel1T2_Tick);
            TtimerDel2T2.Tick += new EventHandler(tTimerDel2T2_Tick);
            TtimerDel3T2.Tick += new EventHandler(tTimerDel3T2_Tick);
            ChbxReplacementTeam1Enable = true;
            ChbxReplacementTeam2Enable = true;
            ShowSignatureEnabled = true;
            ShowSignatureGoalEnabled = true;
            ShowSignatureYellowEnabled = true;
            ShowSignatureYellow2Enabled = true;
            ShowSignatureRedEnabled = true;
            TablePlayerList1Enabled = true;
            TablePlayerList2Enabled = true;
            ShowUpTitleColor = "#FF406787";
            TbShowUpTitle = "Показать верхний титр";
            ShowUpTitleKind = "Show";
            TbShowTrainerTeam1 = "Показать тренера 1 команды";
            TbShowTrainerTeam2 = "Показать тренера 2 команды";
            ShowTrainerTeam1Color = "White";
            ShowTrainerTeam2Color = "White";
            ShowTrainerTeam1Enabled = true;
            ShowTrainerTeam2Enabled = true;
            TbShowCoach = "Показать";
            ShowCoachKind = "Show";
            ShowCoachColor = "#FF406787";
            ChbxReversTimeEnabled = true;
            TxbIntervalTimerEnabled = true;
            ResetTimeEnabled = true;
            TxbTimeStartEnabled = true;
            TxbTimeEndEnabled = true;
            TbStatTimeBallTeam1 = "0";
            TbStatTimeBallTeam2 = "0";
            TbStatYellowTeam1 = "0";
            TbStatYellowTeam2 = "0";
            TbStatDeleteTeam1 = "0";
            TbStatDeleteTeam2 = "0";
            TbShotsOnTargetTeam1 = "0";
            TbShotsOnTargetTeam2 = "0";
            TbOffsideTeam1 = "0";
            TbOffsideTeam2 = "0";
            TbCornerTeam1 = "0";
            TbCornerTeam2 = "0";
            TbPenaltyTeam1 = "0";
            TbPenaltyTeam2 = "0";
            TbShowStat = "Показать";
            ShowStatKind = "Show";
            ShowStatColor = "#FF406787";
            ShowDelete1Team1Kind = "Show";
            ShowDelete2Team1Kind = "Show";
            ShowDelete3Team1Kind = "Show";
            ShowDelete1Team2Kind = "Show";
            ShowDelete2Team2Kind = "Show";
            ShowDelete3Team2Kind = "Show";
            ShowDelete1Team1Color = "#FF406787";
            ShowDelete2Team1Color = "#FF406787";
            ShowDelete3Team1Color = "#FF406787";
            ShowDelete1Team2Color = "#FF406787";
            ShowDelete2Team2Color = "#FF406787";
            ShowDelete3Team2Color = "#FF406787";
            md1t1 = 0;
            TbDelete1MiniteTeam1 = "00";
            sd1t1 = 0;
            TbDelete1SecondTeam1 = "00";
            md2t1 = 0;
            TbDelete2MiniteTeam1 = "00";
            sd2t1 = 0;
            TbDelete2SecondTeam1 = "00";
            md3t1 = 0;
            TbDelete3MiniteTeam1 = "00";
            sd3t1 = 0;
            TbDelete3SecondTeam1 = "00";
            md1t2 = 0;
            TbDelete1MiniteTeam2 = "00";
            sd1t2 = 0;
            TbDelete1SecondTeam2 = "00";
            md2t2 = 0;
            TbDelete2MiniteTeam2 = "00";
            sd2t2 = 0;
            TbDelete2SecondTeam2 = "00";
            md3t2 = 0;
            TbDelete3MiniteTeam2 = "00";
            sd3t2 = 0;
            TbDelete3SecondTeam2 = "00";
            ChbxUpdateScoreCheck = false;
            ChbxUpdateScoreEnabled = false;
            UpdateScoreEnabled = false;
            _application.ChangePathToTWaterPolo("");
            _application.ChangePathToTHandBall("");
            _application.ChangePathToTMiniSoccer("");
            _application.ChangePathToTSoccer("");
            _application.ChangePathToTBasketBall("");
            _application.ChangePathToTJudo("");
        }

        int s, m, sc1, sc2, md1t1, md2t1, md3t1, md1t2, md2t2, md3t2, sd1t1, sd2t1, sd3t1, sd1t2, sd2t2, sd3t2;
        int p = 1;
        string TypeGame = "";

        public ObservableCollection<TablePlayerList1Model> TablePlayerList1TC { get; }
         = new ObservableCollection<TablePlayerList1Model>();

        public ObservableCollection<TablePlayerList1Model> TablePlayerList1 { get; }
         = new ObservableCollection<TablePlayerList1Model>();

        public ObservableCollection<TablePlayerList2Model> TablePlayerList2TC { get; }
        = new ObservableCollection<TablePlayerList2Model>();

        public ObservableCollection<TablePlayerList2Model> TablePlayerList2 { get; }
        = new ObservableCollection<TablePlayerList2Model>();

        public ObservableCollection<TLSListModel> TLSList { get; }
        = new ObservableCollection<TLSListModel>();



        #region Private

        private double _frameOpacity;
        private string _tbClockMinutes;
        private string _tbClockSeconds;
        private string _txbTimeStart;
        private string _txbTimeEnd;
        private string _tbButtonStartTime;
        private bool _chbxReversTimeCheck;
        private string _txbIntervalTimer;
        private string _tbScoreTeamName1;
        private string _tbScoreTeamName2;
        private string _tbScoreTeam1;
        private string _tbScoreTeam2;
        private string _imageScoreTeam1;
        private string _imageScoreTeam2;
        private string _tbPeriod;
        private string _txbSignatureSelectedPlayer;
        private int _selectedValueTablePlayerList1TC;
        private int _selectedValueTablePlayerList2TC;
        private TablePlayerList1Model _selectedItemTablePlayerList1TC;
        private TablePlayerList2Model _selectedItemTablePlayerList2TC;
        private int _selectedIndexTablePlayerList1TC;
        private int _selectedIndexTablePlayerList2TC;
        private bool _chbxReplacementTeam1Check;
        private bool _chbxReplacementTeam2Check;
        private bool _chbxReplacementTeam1Enable;
        private bool _chbxReplacementTeam2Enable;
        private bool _chbxUpdateScoreCheck;
        private bool _chbxUpdateScoreEnabled;
        private bool _updateScoreEnabled;
        private string _tbSelectedPlayerYellow;
        private string _tbSelectedPlayerYellowTime;
        private string _tbSelectedPlayerRed;
        private string _tbSelectedPlayerRedTime;
        private string _tbSelectedPlayerGoals;
        private string _tbSelectedPlayerGoalsTime;
        private string _tbSelectedPlayerShotsOnTarget;
        private string _tbSelectedPlayerPinalty;
        private string _tbSelectedPlayerGoalPinalty;
        private bool _showSignatureEnabled;
        private bool _showSignatureGoalEnabled;
        private bool _showSignatureYellowEnabled;
        private bool _showSignatureYellow2Enabled;
        private bool _showSignatureRedEnabled;
        private bool _tablePlayerList1Enabled;
        private bool _tablePlayerList2Enabled;
        private string _showUpTitleColor;
        private string _tbShowUpTitle;
        private string _showUpTitleKind;
        private string _txbShortTeamName1;
        private string _txbShortTeamName2;
        private string _tbShowTrainerTeam1;
        private string _tbShowTrainerTeam2;
        private string _showTrainerTeam1Color;
        private string _showTrainerTeam2Color;
        private bool _showTrainerTeam1Enabled;
        private bool _showTrainerTeam2Enabled;
        private string _tbShowCoach;
        private string _showCoachKind;
        private string _showCoachColor;
        private bool _chbxReversTimeEnabled;
        private bool _txbIntervalTimerEnabled;
        private bool _resetTimeEnabled;
        private bool _txbTimeStartEnabled;
        private bool _txbTimeEndEnabled;
        private string _tbFoulsTeamName1;
        private string _tbFoulsTeamName2;
        private string _tbFoulsTeam1;
        private string _tbFoulsTeam2;
        private string _showFoulsKind;
        private string _showFoulsColor;
        private string _tbShowFouls;
        private string _tbStatTeamName1;
        private string _tbStatTeamName2;
        private string _tbDeleteTeamName1;
        private string _tbDeleteTeamName2;
        private string _tbPlayerListTeamName1;
        private string _tbPlayerListTeamName2;
        private string _tbStatTimeBallTeam1;
        private string _tbStatTimeBallTeam2;
        private string _tbStatYellowTeam1;
        private string _tbStatYellowTeam2;
        private string _tbStatDeleteTeam1;
        private string _tbStatDeleteTeam2;
        private string _tbShotsOnTargetTeam1;
        private string _tbShotsOnTargetTeam2;
        private string _tbOffsideTeam1;
        private string _tbOffsideTeam2;
        private string _tbCornerTeam1;
        private string _tbCornerTeam2;
        private string _tbPenaltyTeam1;
        private string _tbPenaltyTeam2;
        private string _tbShowStat;
        private string _showStatKind;
        private string _showStatColor;
        private string _tbDelete1MiniteTeam1;
        private string _tbDelete1SecondTeam1;
        private string _tbDelete2MiniteTeam1;
        private string _tbDelete2SecondTeam1;
        private string _tbDelete3MiniteTeam1;
        private string _tbDelete3SecondTeam1;
        private string _tbDelete1MiniteTeam2;
        private string _tbDelete1SecondTeam2;
        private string _tbDelete2MiniteTeam2;
        private string _tbDelete2SecondTeam2;
        private string _tbDelete3MiniteTeam2;
        private string _tbDelete3SecondTeam2;
        private string _showDelete1Team1Kind;
        private string _showDelete2Team1Kind;
        private string _showDelete3Team1Kind;
        private string _showDelete1Team2Kind;
        private string _showDelete2Team2Kind;
        private string _showDelete3Team2Kind;
        private string _showDelete1Team1Color;
        private string _showDelete2Team1Color;
        private string _showDelete3Team1Color;
        private string _showDelete1Team2Color;
        private string _showDelete2Team2Color;
        private string _showDelete3Team2Color;
        private int _selectedIndexCbxUpTitle;
        private TLSListModel _selectedItemCbxUpTitle;
        private string _selectedValueCbxUpTitle;
        private int _selectedIndexCbxSignature;
        private TLSListModel _selectedItemCbxSignature;
        private string _selectedValueCbxSignature;
        private int _selectedIndexCbxFouls;
        private TLSListModel _selectedItemCbxFouls;
        private string _selectedValueCbxFouls;
        private int _selectedIndexCbxAnnouncement;
        private TLSListModel _selectedItemCbxAnnouncement;
        private string _selectedValueCbxAnnouncement;
        private int _selectedIndexCbxCoach;
        private TLSListModel _selectedItemCbxCoach;
        private string _selectedValueCbxCoach;
        private int _selectedIndexCbxPlayerList;
        private TLSListModel _selectedItemCbxPlayerList;
        private string _selectedValueCbxPlayerList;
        private int _selectedIndexCbxStat;
        private TLSListModel _selectedItemCbxStat;
        private string _selectedValueCbxStat;
        private int _selectedIndexCbxQuantityAdditionalTime;
        private TLSListModel _selectedItemCbxQuantityAdditionalTime;
        private string _selectedValueCbxQuantityAdditionalTime;
        private int _selectedIndexCbxAdditionalTime;
        private TLSListModel _selectedItemCbxAdditionalTime;
        private string _selectedValueCbxAdditionalTime;
        private int _selectedIndexCbxDelete1Team1;
        private TLSListModel _selectedItemCbxDelete1Team1;
        private string _selectedValueCbxDelete1Team1;
        private int _selectedIndexCbxDelete2Team1;
        private TLSListModel _selectedItemCbxDelete2Team1;
        private string _selectedValueCbxDelete2Team1;
        private int _selectedIndexCbxDelete3Team1;
        private TLSListModel _selectedItemCbxDelete3Team1;
        private string _selectedValueCbxDelete3Team1;
        private int _selectedIndexCbxDelete1Team2;
        private TLSListModel _selectedItemCbxDelete1Team2;
        private string _selectedValueCbxDelete1Team2;
        private int _selectedIndexCbxDelete2Team2;
        private TLSListModel _selectedItemCbxDelete2Team2;
        private string _selectedValueCbxDelete2Team2;
        private int _selectedIndexCbxDelete3Team2;
        private TLSListModel _selectedItemCbxDelete3Team2;
        private string _selectedValueCbxDelete3Team2;
        private bool _chbxPlayerListWithLogoCheck;
        private bool _chbxAnnouncementWithLogoCheck;
        private bool _chbxTrainerWithLogoCheck;
        private int _selectedIndexCbxYellow;
        private TLSListModel _selectedItemCbxYellow;
        private string _selectedValueCbxYellow;
        private int _selectedIndexCbxYellow2;
        private TLSListModel _selectedItemCbxYellow2;
        private string _selectedValueCbxYellow2;
        private int _selectedIndexCbxRed;
        private TLSListModel _selectedItemCbxRed;
        private string _selectedValueCbxRed;
        #endregion

        #region Public
        public double FrameOpacity
        {
            get { return _frameOpacity; }
            set
            {
                _frameOpacity = value;
                OnPropertyChanged("FrameOpacity");
            }
        }
        public int SelectedIndexCbxUpTitle
        {
            get { return _selectedIndexCbxUpTitle; }
            set
            {
                _selectedIndexCbxUpTitle = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxUpTitle
        {
            get => _selectedItemCbxUpTitle;
            set => SetProperty(ref _selectedItemCbxUpTitle, value);
        }
        public string SelectedValueCbxUpTitle
        {
            get { return _selectedValueCbxUpTitle; }
            set
            {
                _selectedValueCbxUpTitle = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxSignature
        {
            get { return _selectedIndexCbxSignature; }
            set
            {
                _selectedIndexCbxSignature = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxSignature
        {
            get => _selectedItemCbxSignature;
            set => SetProperty(ref _selectedItemCbxSignature, value);
        }
        public string SelectedValueCbxSignature
        {
            get { return _selectedValueCbxSignature; }
            set
            {
                _selectedValueCbxSignature = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxFouls
        {
            get { return _selectedIndexCbxFouls; }
            set
            {
                _selectedIndexCbxFouls = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxFouls
        {
            get => _selectedItemCbxFouls;
            set => SetProperty(ref _selectedItemCbxFouls, value);
        }
        public string SelectedValueCbxFouls
        {
            get { return _selectedValueCbxFouls; }
            set
            {
                _selectedValueCbxFouls = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxAnnouncement
        {
            get { return _selectedIndexCbxAnnouncement; }
            set
            {
                _selectedIndexCbxAnnouncement = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxAnnouncement
        {
            get => _selectedItemCbxAnnouncement;
            set => SetProperty(ref _selectedItemCbxAnnouncement, value);
        }
        public string SelectedValueCbxAnnouncement
        {
            get { return _selectedValueCbxAnnouncement; }
            set
            {
                _selectedValueCbxAnnouncement = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxCoach
        {
            get { return _selectedIndexCbxCoach; }
            set
            {
                _selectedIndexCbxCoach = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxCoach
        {
            get => _selectedItemCbxCoach;
            set => SetProperty(ref _selectedItemCbxCoach, value);
        }
        public string SelectedValueCbxCoach
        {
            get { return _selectedValueCbxCoach; }
            set
            {
                _selectedValueCbxCoach = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxPlayerList
        {
            get { return _selectedIndexCbxPlayerList; }
            set
            {
                _selectedIndexCbxPlayerList = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxPlayerList
        {
            get => _selectedItemCbxPlayerList;
            set => SetProperty(ref _selectedItemCbxPlayerList, value);
        }
        public string SelectedValueCbxPlayerList
        {
            get { return _selectedValueCbxPlayerList; }
            set
            {
                _selectedValueCbxPlayerList = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxStat
        {
            get { return _selectedIndexCbxStat; }
            set
            {
                _selectedIndexCbxStat = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxStat
        {
            get => _selectedItemCbxStat;
            set => SetProperty(ref _selectedItemCbxStat, value);
        }
        public string SelectedValueCbxStat
        {
            get { return _selectedValueCbxStat; }
            set
            {
                _selectedValueCbxStat = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxQuantityAdditionalTime
        {
            get { return _selectedIndexCbxQuantityAdditionalTime; }
            set
            {
                _selectedIndexCbxQuantityAdditionalTime = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxQuantityAdditionalTime
        {
            get => _selectedItemCbxQuantityAdditionalTime;
            set => SetProperty(ref _selectedItemCbxQuantityAdditionalTime, value);
        }
        public string SelectedValueCbxQuantityAdditionalTime
        {
            get { return _selectedValueCbxQuantityAdditionalTime; }
            set
            {
                _selectedValueCbxQuantityAdditionalTime = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxAdditionalTime
        {
            get { return _selectedIndexCbxAdditionalTime; }
            set
            {
                _selectedIndexCbxAdditionalTime = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxAdditionalTime
        {
            get => _selectedItemCbxAdditionalTime;
            set => SetProperty(ref _selectedItemCbxAdditionalTime, value);
        }
        public string SelectedValueCbxAdditionalTime
        {
            get { return _selectedValueCbxAdditionalTime; }
            set
            {
                _selectedValueCbxAdditionalTime = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxDelete1Team1
        {
            get { return _selectedIndexCbxDelete1Team1; }
            set
            {
                _selectedIndexCbxDelete1Team1 = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxDelete1Team1
        {
            get => _selectedItemCbxDelete1Team1;
            set => SetProperty(ref _selectedItemCbxDelete1Team1, value);
        }
        public string SelectedValueCbxDelete1Team1
        {
            get { return _selectedValueCbxDelete1Team1; }
            set
            {
                _selectedValueCbxDelete1Team1 = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxDelete2Team1
        {
            get { return _selectedIndexCbxDelete2Team1; }
            set
            {
                _selectedIndexCbxDelete2Team1 = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxDelete2Team1
        {
            get => _selectedItemCbxDelete2Team1;
            set => SetProperty(ref _selectedItemCbxDelete2Team1, value);
        }
        public string SelectedValueCbxDelete2Team1
        {
            get { return _selectedValueCbxDelete2Team1; }
            set
            {
                _selectedValueCbxDelete2Team1 = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxDelete3Team1
        {
            get { return _selectedIndexCbxDelete3Team1; }
            set
            {
                _selectedIndexCbxDelete3Team1 = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxDelete3Team1
        {
            get => _selectedItemCbxDelete3Team1;
            set => SetProperty(ref _selectedItemCbxDelete3Team1, value);
        }
        public string SelectedValueCbxDelete3Team1
        {
            get { return _selectedValueCbxDelete3Team1; }
            set
            {
                _selectedValueCbxDelete3Team1 = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxDelete1Team2
        {
            get { return _selectedIndexCbxDelete1Team2; }
            set
            {
                _selectedIndexCbxDelete1Team2 = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxDelete1Team2
        {
            get => _selectedItemCbxDelete1Team2;
            set => SetProperty(ref _selectedItemCbxDelete1Team2, value);
        }
        public string SelectedValueCbxDelete1Team2
        {
            get { return _selectedValueCbxDelete1Team2; }
            set
            {
                _selectedValueCbxDelete1Team2 = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxDelete2Team2
        {
            get { return _selectedIndexCbxDelete2Team2; }
            set
            {
                _selectedIndexCbxDelete2Team2 = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxDelete2Team2
        {
            get => _selectedItemCbxDelete2Team2;
            set => SetProperty(ref _selectedItemCbxDelete2Team2, value);
        }
        public string SelectedValueCbxDelete2Team2
        {
            get { return _selectedValueCbxDelete2Team2; }
            set
            {
                _selectedValueCbxDelete2Team2 = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxDelete3Team2
        {
            get { return _selectedIndexCbxDelete3Team2; }
            set
            {
                _selectedIndexCbxDelete3Team2 = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxDelete3Team2
        {
            get => _selectedItemCbxDelete3Team2;
            set => SetProperty(ref _selectedItemCbxDelete3Team2, value);
        }
        public string SelectedValueCbxDelete3Team2
        {
            get { return _selectedValueCbxDelete3Team2; }
            set
            {
                _selectedValueCbxDelete3Team2 = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxYellow
        {
            get { return _selectedIndexCbxYellow; }
            set
            {
                _selectedIndexCbxYellow = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxYellow
        {
            get => _selectedItemCbxYellow;
            set => SetProperty(ref _selectedItemCbxYellow, value);
        }
        public string SelectedValueCbxYellow
        {
            get { return _selectedValueCbxYellow; }
            set
            {
                _selectedValueCbxYellow = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxYellow2
        {
            get { return _selectedIndexCbxYellow2; }
            set
            {
                _selectedIndexCbxYellow2 = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxYellow2
        {
            get => _selectedItemCbxYellow2;
            set => SetProperty(ref _selectedItemCbxYellow2, value);
        }
        public string SelectedValueCbxYellow2
        {
            get { return _selectedValueCbxYellow2; }
            set
            {
                _selectedValueCbxYellow2 = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedIndexCbxRed
        {
            get { return _selectedIndexCbxRed; }
            set
            {
                _selectedIndexCbxRed = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public TLSListModel SelectedItemCbxRed
        {
            get => _selectedItemCbxRed;
            set => SetProperty(ref _selectedItemCbxRed, value);
        }
        public string SelectedValueCbxRed
        {
            get { return _selectedValueCbxRed; }
            set
            {
                _selectedValueCbxRed = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete1MiniteTeam1
        {
            get { return _tbDelete1MiniteTeam1; }
            set
            {
                _tbDelete1MiniteTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete1SecondTeam1
        {
            get { return _tbDelete1SecondTeam1; }
            set
            {
                _tbDelete1SecondTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete2MiniteTeam1
        {
            get { return _tbDelete2MiniteTeam1; }
            set
            {
                _tbDelete2MiniteTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete2SecondTeam1
        {
            get { return _tbDelete2SecondTeam1; }
            set
            {
                _tbDelete2SecondTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete3MiniteTeam1
        {
            get { return _tbDelete3MiniteTeam1; }
            set
            {
                _tbDelete3MiniteTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete3SecondTeam1
        {
            get { return _tbDelete3SecondTeam1; }
            set
            {
                _tbDelete3SecondTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete1MiniteTeam2
        {
            get { return _tbDelete1MiniteTeam2; }
            set
            {
                _tbDelete1MiniteTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete1SecondTeam2
        {
            get { return _tbDelete1SecondTeam2; }
            set
            {
                _tbDelete1SecondTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete2MiniteTeam2
        {
            get { return _tbDelete2MiniteTeam2; }
            set
            {
                _tbDelete2MiniteTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete2SecondTeam2
        {
            get { return _tbDelete2SecondTeam2; }
            set
            {
                _tbDelete2SecondTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete3MiniteTeam2
        {
            get { return _tbDelete3MiniteTeam2; }
            set
            {
                _tbDelete3MiniteTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDelete3SecondTeam2
        {
            get { return _tbDelete3SecondTeam2; }
            set
            {
                _tbDelete3SecondTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete1Team1Kind
        {
            get { return _showDelete1Team1Kind; }
            set
            {
                _showDelete1Team1Kind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete2Team1Kind
        {
            get { return _showDelete2Team1Kind; }
            set
            {
                _showDelete2Team1Kind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete3Team1Kind
        {
            get { return _showDelete3Team1Kind; }
            set
            {
                _showDelete3Team1Kind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete1Team2Kind
        {
            get { return _showDelete1Team2Kind; }
            set
            {
                _showDelete1Team2Kind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete2Team2Kind
        {
            get { return _showDelete2Team2Kind; }
            set
            {
                _showDelete2Team2Kind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete3Team2Kind
        {
            get { return _showDelete3Team2Kind; }
            set
            {
                _showDelete3Team2Kind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete1Team1Color
        {
            get { return _showDelete1Team1Color; }
            set
            {
                _showDelete1Team1Color = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete2Team1Color
        {
            get { return _showDelete2Team1Color; }
            set
            {
                _showDelete2Team1Color = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete3Team1Color
        {
            get { return _showDelete3Team1Color; }
            set
            {
                _showDelete3Team1Color = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete1Team2Color
        {
            get { return _showDelete1Team2Color; }
            set
            {
                _showDelete1Team2Color = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete2Team2Color
        {
            get { return _showDelete2Team2Color; }
            set
            {
                _showDelete2Team2Color = value;
                OnPropertyChanged("");
            }
        }
        public string ShowDelete3Team2Color
        {
            get { return _showDelete3Team2Color; }
            set
            {
                _showDelete3Team2Color = value;
                OnPropertyChanged("");
            }
        }
        public string TbShowStat
        {
            get { return _tbShowStat; }
            set
            {
                _tbShowStat = value;
                OnPropertyChanged("");
            }
        }
        public string ShowStatKind
        {
            get { return _showStatKind; }
            set
            {
                _showStatKind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowStatColor
        {
            get { return _showStatColor; }
            set
            {
                _showStatColor = value;
                OnPropertyChanged("");
            }
        }
        public string TbStatTeamName1
        {
            get { return _tbStatTeamName1; }
            set
            {
                _tbStatTeamName1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbStatTeamName2
        {
            get { return _tbStatTeamName2; }
            set
            {
                _tbStatTeamName2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDeleteTeamName1
        {
            get { return _tbDeleteTeamName1; }
            set
            {
                _tbDeleteTeamName1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbDeleteTeamName2
        {
            get { return _tbDeleteTeamName2; }
            set
            {
                _tbDeleteTeamName2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbPlayerListTeamName1
        {
            get { return _tbPlayerListTeamName1; }
            set
            {
                _tbPlayerListTeamName1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbPlayerListTeamName2
        {
            get { return _tbPlayerListTeamName2; }
            set
            {
                _tbPlayerListTeamName2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbStatTimeBallTeam1
        {
            get { return _tbStatTimeBallTeam1; }
            set
            {
                _tbStatTimeBallTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbStatTimeBallTeam2
        {
            get { return _tbStatTimeBallTeam2; }
            set
            {
                _tbStatTimeBallTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbStatYellowTeam1
        {
            get { return _tbStatYellowTeam1; }
            set
            {
                _tbStatYellowTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbStatYellowTeam2
        {
            get { return _tbStatYellowTeam2; }
            set
            {
                _tbStatYellowTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbStatDeleteTeam1
        {
            get { return _tbStatDeleteTeam1; }
            set
            {
                _tbStatDeleteTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbStatDeleteTeam2
        {
            get { return _tbStatDeleteTeam2; }
            set
            {
                _tbStatDeleteTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbShotsOnTargetTeam1
        {
            get { return _tbShotsOnTargetTeam1; }
            set
            {
                _tbShotsOnTargetTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbShotsOnTargetTeam2
        {
            get { return _tbShotsOnTargetTeam2; }
            set
            {
                _tbShotsOnTargetTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbOffsideTeam1
        {
            get { return _tbOffsideTeam1; }
            set
            {
                _tbOffsideTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbOffsideTeam2
        {
            get { return _tbOffsideTeam2; }
            set
            {
                _tbOffsideTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbCornerTeam1
        {
            get { return _tbCornerTeam1; }
            set
            {
                _tbCornerTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbCornerTeam2
        {
            get { return _tbCornerTeam2; }
            set
            {
                _tbCornerTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbPenaltyTeam1
        {
            get { return _tbPenaltyTeam1; }
            set
            {
                _tbPenaltyTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbPenaltyTeam2
        {
            get { return _tbPenaltyTeam2; }
            set
            {
                _tbPenaltyTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbClockMinutes
        {
            get { return _tbClockMinutes; }
            set
            {
                _tbClockMinutes = value;
                OnPropertyChanged("");
            }
        }
        public string TbClockSeconds
        {
            get { return _tbClockSeconds; }
            set
            {
                _tbClockSeconds = value;
                OnPropertyChanged("");
            }
        }
        public string TxbTimeStart
        {
            get { return _txbTimeStart; }
            set
            {
                _txbTimeStart = value;
                OnPropertyChanged("");
            }
        }
        public string TxbTimeEnd
        {
            get { return _txbTimeEnd; }
            set
            {
                _txbTimeEnd = value;
                OnPropertyChanged("");
            }
        }
        public string TbFoulsTeamName1
        {
            get { return _tbFoulsTeamName1; }
            set
            {
                _tbFoulsTeamName1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbFoulsTeamName2
        {
            get { return _tbFoulsTeamName2; }
            set
            {
                _tbFoulsTeamName2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbFoulsTeam1
        {
            get { return _tbFoulsTeam1; }
            set
            {
                _tbFoulsTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbFoulsTeam2
        {
            get { return _tbFoulsTeam2; }
            set
            {
                _tbFoulsTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string ShowFoulsKind
        {
            get { return _showFoulsKind; }
            set
            {
                _showFoulsKind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowFoulsColor
        {
            get { return _showFoulsColor; }
            set
            {
                _showFoulsColor = value;
                OnPropertyChanged("");
            }
        }
        public string TbShowFouls
        {
            get { return _tbShowFouls; }
            set
            {
                _tbShowFouls = value;
                OnPropertyChanged("");
            }
        }
        public string TbButtonStartTime
        {
            get { return _tbButtonStartTime; }
            set
            {
                _tbButtonStartTime = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxReversTimeCheck
        {
            get { return _chbxReversTimeCheck; }
            set
            {
                _chbxReversTimeCheck = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxReversTimeEnabled
        {
            get { return _chbxReversTimeEnabled; }
            set
            {
                _chbxReversTimeEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool TxbIntervalTimerEnabled
        {
            get { return _txbIntervalTimerEnabled; }
            set
            {
                _txbIntervalTimerEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool ResetTimeEnabled
        {
            get { return _resetTimeEnabled; }
            set
            {
                _resetTimeEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool TxbTimeStartEnabled
        {
            get { return _txbTimeStartEnabled; }
            set
            {
                _txbTimeStartEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool TxbTimeEndEnabled
        {
            get { return _txbTimeEndEnabled; }
            set
            {
                _txbTimeEndEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxUpdateScoreCheck
        {
            get { return _chbxUpdateScoreCheck; }
            set
            {
                _chbxUpdateScoreCheck = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxUpdateScoreEnabled
        {
            get { return _chbxUpdateScoreEnabled; }
            set
            {
                _chbxUpdateScoreEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool UpdateScoreEnabled
        {
            get { return _updateScoreEnabled; }
            set
            {
                _updateScoreEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxPlayerListWithLogoCheck
        {
            get { return _chbxPlayerListWithLogoCheck; }
            set
            {
                _chbxPlayerListWithLogoCheck = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxAnnouncementWithLogoCheck
        {
            get { return _chbxAnnouncementWithLogoCheck; }
            set
            {
                _chbxAnnouncementWithLogoCheck = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxTrainerWithLogoCheck
        {
            get { return _chbxTrainerWithLogoCheck; }
            set
            {
                _chbxTrainerWithLogoCheck = value;
                OnPropertyChanged("");
            }
        }
        public string TxbIntervalTimer
        {
            get { return _txbIntervalTimer; }
            set
            {
                _txbIntervalTimer = value;
                OnPropertyChanged("");
            }
        }
        public string TbScoreTeamName1
        {
            get { return _tbScoreTeamName1; }
            set
            {
                _tbScoreTeamName1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbScoreTeamName2
        {
            get { return _tbScoreTeamName2; }
            set
            {
                _tbScoreTeamName2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbScoreTeam1
        {
            get { return _tbScoreTeam1; }
            set
            {
                _tbScoreTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbScoreTeam2
        {
            get { return _tbScoreTeam2; }
            set
            {
                _tbScoreTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string ImageScoreTeam1
        {
            get { return _imageScoreTeam1; }
            set
            {
                _imageScoreTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string ImageScoreTeam2
        {
            get { return _imageScoreTeam2; }
            set
            {
                _imageScoreTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string TbPeriod
        {
            get { return _tbPeriod; }
            set
            {
                _tbPeriod = value;
                OnPropertyChanged("");
            }
        }
        public string TxbSignatureSelectedPlayer
        {
            get { return _txbSignatureSelectedPlayer; }
            set
            {
                _txbSignatureSelectedPlayer = value;
                OnPropertyChanged("");
            }
        }
        public int SelectedValueTablePlayerList1TC
        {
            get { return _selectedValueTablePlayerList1TC; }
            set
            {
                _selectedValueTablePlayerList1TC = value; OnPropertyChanged("SelectionValue");
                foreach (var item in TablePlayerList1TC.Where(q => q.PlayerNumber == SelectedValueTablePlayerList1TC))
                {
                    SelectedValueTablePlayerList2TC = 0;
                    TxbSignatureSelectedPlayer = item.PlayerNumber.ToString() + " " + item.PlayerFIO;
                    TbSelectedPlayerYellow = item.PlayerYellow;
                    TbSelectedPlayerYellowTime = item.PlayerYellowTime;
                    TbSelectedPlayerRed = item.PlayerRed;
                    TbSelectedPlayerRedTime = item.PlayerRedTime;
                    TbSelectedPlayerGoals = item.PlayerGoals;
                    TbSelectedPlayerGoalsTime = item.PlayerGoalsTime;
                    TbSelectedPlayerShotsOnTarget = item.PlayerShotsOnTarget;
                    TbSelectedPlayerPinalty = item.PlayerPinalty;
                    TbSelectedPlayerGoalPinalty = item.PlayerGoalPinalty;
                }
            }
        }
        public int SelectedValueTablePlayerList2TC
        {
            get { return _selectedValueTablePlayerList2TC; }
            set
            {
                _selectedValueTablePlayerList2TC = value; OnPropertyChanged("SelectionValue");
                foreach (var item in TablePlayerList2TC.Where(q => q.PlayerNumber == SelectedValueTablePlayerList2TC))
                {
                    SelectedValueTablePlayerList1TC = 0;
                    TxbSignatureSelectedPlayer = item.PlayerNumber.ToString() + " " + item.PlayerFIO;
                    TbSelectedPlayerYellow = item.PlayerYellow;
                    TbSelectedPlayerYellowTime = item.PlayerYellowTime;
                    TbSelectedPlayerRed = item.PlayerRed;
                    TbSelectedPlayerRedTime = item.PlayerRedTime;
                    TbSelectedPlayerGoals = item.PlayerGoals;
                    TbSelectedPlayerGoalsTime = item.PlayerGoalsTime;
                    TbSelectedPlayerShotsOnTarget = item.PlayerShotsOnTarget;
                    TbSelectedPlayerPinalty = item.PlayerPinalty;
                    TbSelectedPlayerGoalPinalty = item.PlayerGoalPinalty;
                }
            }
        }
        public TablePlayerList1Model SelectedItemTablePlayerList1TC
        {
            get => _selectedItemTablePlayerList1TC;
            set => SetProperty(ref _selectedItemTablePlayerList1TC, value);
        }
        public TablePlayerList2Model SelectedItemTablePlayerList2TC
        {
            get => _selectedItemTablePlayerList2TC;
            set => SetProperty(ref _selectedItemTablePlayerList2TC, value);
        }
        public int SelectedIndexTablePlayerList1TC
        {
            get { return _selectedIndexTablePlayerList1TC; }
            set
            {
                _selectedIndexTablePlayerList1TC = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public int SelectedIndexTablePlayerList2TC
        {
            get { return _selectedIndexTablePlayerList2TC; }
            set
            {
                _selectedIndexTablePlayerList2TC = value;
                OnPropertyChanged("SelectionValue");
            }
        }
        public bool ChbxReplacementTeam1Check
        {
            get { return _chbxReplacementTeam1Check; }
            set
            {
                _chbxReplacementTeam1Check = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxReplacementTeam2Check
        {
            get { return _chbxReplacementTeam2Check; }
            set
            {
                _chbxReplacementTeam2Check = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxReplacementTeam1Enable
        {
            get { return _chbxReplacementTeam1Enable; }
            set
            {
                _chbxReplacementTeam1Enable = value;
                OnPropertyChanged("");
            }
        }
        public bool ChbxReplacementTeam2Enable
        {
            get { return _chbxReplacementTeam2Enable; }
            set
            {
                _chbxReplacementTeam2Enable = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerYellow
        {
            get { return _tbSelectedPlayerYellow; }
            set
            {
                _tbSelectedPlayerYellow = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerYellowTime
        {
            get { return _tbSelectedPlayerYellowTime; }
            set
            {
                _tbSelectedPlayerYellowTime = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerRed
        {
            get { return _tbSelectedPlayerRed; }
            set
            {
                _tbSelectedPlayerRed = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerRedTime
        {
            get { return _tbSelectedPlayerRedTime; }
            set
            {
                _tbSelectedPlayerRedTime = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerGoals
        {
            get { return _tbSelectedPlayerGoals; }
            set
            {
                _tbSelectedPlayerGoals = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerGoalsTime
        {
            get { return _tbSelectedPlayerGoalsTime; }
            set
            {
                _tbSelectedPlayerGoalsTime = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerShotsOnTarget
        {
            get { return _tbSelectedPlayerShotsOnTarget; }
            set
            {
                _tbSelectedPlayerShotsOnTarget = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerPinalty
        {
            get { return _tbSelectedPlayerPinalty; }
            set
            {
                _tbSelectedPlayerPinalty = value;
                OnPropertyChanged("");
            }
        }
        public string TbSelectedPlayerGoalPinalty
        {
            get { return _tbSelectedPlayerGoalPinalty; }
            set
            {
                _tbSelectedPlayerGoalPinalty = value;
                OnPropertyChanged("");
            }
        }
        public bool ShowSignatureEnabled
        {
            get { return _showSignatureEnabled; }
            set
            {
                _showSignatureEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool ShowSignatureGoalEnabled
        {
            get { return _showSignatureGoalEnabled; }
            set
            {
                _showSignatureGoalEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool ShowSignatureYellowEnabled
        {
            get { return _showSignatureYellowEnabled; }
            set
            {
                _showSignatureYellowEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool ShowSignatureYellow2Enabled
        {
            get { return _showSignatureYellow2Enabled; }
            set
            {
                _showSignatureYellow2Enabled = value;
                OnPropertyChanged("");
            }
        }
        public bool ShowSignatureRedEnabled
        {
            get { return _showSignatureRedEnabled; }
            set
            {
                _showSignatureRedEnabled = value;
                OnPropertyChanged("");
            }
        }
        public bool TablePlayerList1Enabled
        {
            get { return _tablePlayerList1Enabled; }
            set
            {
                _tablePlayerList1Enabled = value;
                OnPropertyChanged("");
            }
        }
        public bool TablePlayerList2Enabled
        {
            get { return _tablePlayerList2Enabled; }
            set
            {
                _tablePlayerList2Enabled = value;
                OnPropertyChanged("");
            }
        }
        public string ShowUpTitleColor
        {
            get { return _showUpTitleColor; }
            set
            {
                _showUpTitleColor = value;
                OnPropertyChanged("");
            }
        }
        public string TbShowUpTitle
        {
            get { return _tbShowUpTitle; }
            set
            {
                _tbShowUpTitle = value;
                OnPropertyChanged("");
            }
        }
        public string ShowUpTitleKind
        {
            get { return _showUpTitleKind; }
            set
            {
                _showUpTitleKind = value;
                OnPropertyChanged("");
            }
        }
        public string TxbShortTeamName1
        {
            get { return _txbShortTeamName1; }
            set
            {
                _txbShortTeamName1 = value;
                OnPropertyChanged("");
                string DataStr;
                string str3 = "\\";

                DataStr = "CG 1-50 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"n1" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TxbShortTeamName1 + str3 + "\"/></componentData></templateData>\"";
                string message = DataStr;
                bool sm = _tCPOperations.SendMessage(message);
            }
        }
        public string TxbShortTeamName2
        {
            get { return _txbShortTeamName2; }
            set
            {
                _txbShortTeamName2 = value;
                OnPropertyChanged("");
                string DataStr;
                string str3 = "\\";

                DataStr = "CG 1-50 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"n2" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TxbShortTeamName2 + str3 + "\"/></componentData></templateData>\"";
                string message = DataStr;
                bool sm = _tCPOperations.SendMessage(message);
            }
        }
        public string TbShowTrainerTeam1
        {
            get { return _tbShowTrainerTeam1; }
            set
            {
                _tbShowTrainerTeam1 = value;
                OnPropertyChanged("");
            }
        }
        public string TbShowTrainerTeam2
        {
            get { return _tbShowTrainerTeam2; }
            set
            {
                _tbShowTrainerTeam2 = value;
                OnPropertyChanged("");
            }
        }
        public string ShowTrainerTeam1Color
        {
            get { return _showTrainerTeam1Color; }
            set
            {
                _showTrainerTeam1Color = value;
                OnPropertyChanged("");
            }
        }
        public string ShowTrainerTeam2Color
        {
            get { return _showTrainerTeam2Color; }
            set
            {
                _showTrainerTeam2Color = value;
                OnPropertyChanged("");
            }
        }
        public bool ShowTrainerTeam1Enabled
        {
            get { return _showTrainerTeam1Enabled; }
            set
            {
                _showTrainerTeam1Enabled = value;
                OnPropertyChanged("");
            }
        }
        public bool ShowTrainerTeam2Enabled
        {
            get { return _showTrainerTeam2Enabled; }
            set
            {
                _showTrainerTeam2Enabled = value;
                OnPropertyChanged("");
            }
        }
        public string TbShowCoach
        {
            get { return _tbShowCoach; }
            set
            {
                _tbShowCoach = value;
                OnPropertyChanged("");
            }
        }
        public string ShowCoachKind
        {
            get { return _showCoachKind; }
            set
            {
                _showCoachKind = value;
                OnPropertyChanged("");
            }
        }
        public string ShowCoachColor
        {
            get { return _showCoachColor; }
            set
            {
                _showCoachColor = value;
                OnPropertyChanged("");
            }
        }


        #endregion

        #region ICommand

        #endregion


        #region Void
        public async void SlowOpacity(string Page, object arg)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.05)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
                _navigationManager.Navigate(Page, arg);

                for (double i = 0.0; i < 1.1; i += 0.05)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }
        private void tTimer_Tick(object sender, EventArgs e)
        {

            if (ChbxReversTimeCheck == true)
            {

                if (s > 0)
                {
                    s--;
                    if (s < 10)
                    {
                        TbClockSeconds = "0" + s.ToString();
                    }
                    else
                    {
                        TbClockSeconds = s.ToString();
                    }
                }
                else
                {
                    if (m > 0)
                    {
                        m--;
                        if (m < 10)
                        {
                            TbClockMinutes = "0" + m.ToString();
                        }
                        else
                        {
                            TbClockMinutes = m.ToString();
                        }
                        s = 59;
                        TbClockSeconds = "59";
                    }
                    else
                    {
                        m = 0;
                        TbClockSeconds = "00";
                    }
                }


            }
            else
            {

                if (Convert.ToInt32(TbClockMinutes) < Convert.ToInt32(TxbTimeEnd))
                {

                    if (s < 59)
                    {
                        s++;
                        if (s < 10)
                        {
                            TbClockSeconds = "0" + s.ToString();
                        }
                        else
                        {
                            TbClockSeconds = s.ToString();
                        }
                    }
                    else
                    {
                        if (m < 59)
                        {
                            m++;
                            if (m < 10)
                            {
                                TbClockMinutes = "0" + m.ToString();
                            }
                            else
                            {
                                TbClockMinutes = m.ToString();
                            }
                            s = 0;
                            TbClockSeconds = "00";
                        }
                        else
                        {
                            m = 0;
                            TbClockMinutes = "00";
                        }
                    }


                }
                else
                {
                    _timer.Stop();
                    TbButtonStartTime = "Старт";
                    ChbxReversTimeEnabled = true;
                    TxbIntervalTimerEnabled = true;
                    ResetTimeEnabled = true;
                    TxbTimeStartEnabled = true;
                    TxbTimeEndEnabled = true;
                    return;
                }

            }
            string DataStr;
            string str3 = "\\";

            DataStr = "CG 1-50 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"t1" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TbClockMinutes + " : " + TbClockSeconds + str3 + "\"/></componentData></templateData>\"";
            string message = DataStr;
            bool sm = _tCPOperations.SendMessage(message);
        }
        private void tTimerDel1T1_Tick(object sender, EventArgs e)
        {
            if (sd1t1 > 0)
            {
                sd1t1--;
                if (sd1t1 < 10)
                {
                    TbDelete1SecondTeam1 = "0" + sd1t1.ToString();
                }
                else
                {
                    TbDelete1SecondTeam1 = sd1t1.ToString();
                }
            }
            else
            {
                if (md1t1 > 0)
                {
                    md1t1--;
                    if (md1t1 < 10)
                    {
                        TbDelete1MiniteTeam1 = "0" + md1t1.ToString();
                    }
                    else
                    {
                        TbDelete1MiniteTeam1 = md1t1.ToString();
                    }
                    sd1t1 = 59;
                    TbDelete1SecondTeam1 = "59";
                }
                else
                {
                    TtimerDel1T1.Stop();
                    ShowDelete1Team1Kind = "Show";
                    ShowDelete1Team1Color = "#FF406787";
                    md1t1 = Convert.ToInt32(_application.DelMin);
                    TbDelete1MiniteTeam1 = _application.DelMin;
                    sd1t1 = Convert.ToInt32(_application.DelSec);
                    TbDelete1SecondTeam1 = _application.DelSec;
                    string TitleNmae = "Title_Del1T1";
                    bool sm1 = _tCPOperations.SendMessage("CG 1-11 STOP 1 \"" + TitleNmae + "\"");

                    return;
                }
            }
            string DataStr;
            string str3 = "\\";
            DataStr = "CG 1-11 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"t11" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TbDelete1MiniteTeam1 + " : " + TbDelete1SecondTeam1 + str3 + "\"/></componentData></templateData>\"";
            string message = DataStr;
            bool sm = _tCPOperations.SendMessage(message);
        }
        private void tTimerDel2T1_Tick(object sender, EventArgs e)
        {
            if (sd2t1 > 0)
            {
                sd2t1--;
                if (sd2t1 < 10)
                {
                    TbDelete2SecondTeam1 = "0" + sd2t1.ToString();
                }
                else
                {
                    TbDelete2SecondTeam1 = sd2t1.ToString();
                }
            }
            else
            {
                if (md2t1 > 0)
                {
                    md2t1--;
                    if (md2t1 < 10)
                    {
                        TbDelete2MiniteTeam1 = "0" + md2t1.ToString();
                    }
                    else
                    {
                        TbDelete2MiniteTeam1 = md2t1.ToString();
                    }
                    sd2t1 = 59;
                    TbDelete2SecondTeam1 = "59";
                }
                else
                {
                    TtimerDel2T1.Stop();
                    ShowDelete2Team1Kind = "Show";
                    ShowDelete2Team1Color = "#FF406787";
                    md2t1 = Convert.ToInt32(_application.DelMin);
                    TbDelete2MiniteTeam1 = _application.DelMin;
                    sd2t1 = Convert.ToInt32(_application.DelSec);
                    TbDelete2SecondTeam1 = _application.DelSec;
                    string TitleNmae = "Title_Del2T1";
                    bool sm1 = _tCPOperations.SendMessage("CG 1-12 STOP 1 \"" + TitleNmae + "\"");

                    return;
                }
            }
            string DataStr;
            string str3 = "\\";
            DataStr = "CG 1-12 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"t12" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TbDelete2MiniteTeam1 + " : " + TbDelete2SecondTeam1 + str3 + "\"/></componentData></templateData>\"";
            string message = DataStr;
            bool sm = _tCPOperations.SendMessage(message);
        }
        private void tTimerDel3T1_Tick(object sender, EventArgs e)
        {
            if (sd3t1 > 0)
            {
                sd3t1--;
                if (sd3t1 < 10)
                {
                    TbDelete3SecondTeam1 = "0" + sd3t1.ToString();
                }
                else
                {
                    TbDelete3SecondTeam1 = sd3t1.ToString();
                }
            }
            else
            {
                if (md3t1 > 0)
                {
                    md3t1--;
                    if (md3t1 < 10)
                    {
                        TbDelete3MiniteTeam1 = "0" + md3t1.ToString();
                    }
                    else
                    {
                        TbDelete3MiniteTeam1 = md3t1.ToString();
                    }
                    sd3t1 = 59;
                    TbDelete3SecondTeam1 = "59";
                }
                else
                {
                    TtimerDel3T1.Stop();
                    ShowDelete3Team1Kind = "Show";
                    ShowDelete3Team1Color = "#FF406787";
                    md3t1 = Convert.ToInt32(_application.DelMin);
                    TbDelete3MiniteTeam1 = _application.DelMin;
                    sd3t1 = Convert.ToInt32(_application.DelSec);
                    TbDelete3SecondTeam1 = _application.DelSec;
                    string TitleNmae = "Title_Del3T1";
                    bool sm1 = _tCPOperations.SendMessage("CG 1-13 STOP 1 \"" + TitleNmae + "\"");

                    return;
                }
            }
            string DataStr;
            string str3 = "\\";
            DataStr = "CG 1-13 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"t13" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TbDelete3MiniteTeam1 + " : " + TbDelete3SecondTeam1 + str3 + "\"/></componentData></templateData>\"";
            string message = DataStr;
            bool sm = _tCPOperations.SendMessage(message);
        }
        private void tTimerDel1T2_Tick(object sender, EventArgs e)
        {
            if (sd1t2 > 0)
            {
                sd1t2--;
                if (sd1t2 < 10)
                {
                    TbDelete1SecondTeam2 = "0" + sd1t2.ToString();
                }
                else
                {
                    TbDelete1SecondTeam2 = sd1t2.ToString();
                }
            }
            else
            {
                if (md1t2 > 0)
                {
                    md1t2--;
                    if (md1t2 < 10)
                    {
                        TbDelete1MiniteTeam2 = "0" + md1t2.ToString();
                    }
                    else
                    {
                        TbDelete1MiniteTeam2 = md1t2.ToString();
                    }
                    sd1t2 = 59;
                    TbDelete1SecondTeam2 = "59";
                }
                else
                {
                    TtimerDel1T2.Stop();
                    ShowDelete1Team2Kind = "Show";
                    ShowDelete1Team2Color = "#FF406787";
                    md1t2 = Convert.ToInt32(_application.DelMin);
                    TbDelete1MiniteTeam2 = _application.DelMin;
                    sd1t2 = Convert.ToInt32(_application.DelSec);
                    TbDelete1SecondTeam2 = _application.DelSec;
                    string TitleNmae = "Title_Del1T2";
                    bool sm1 = _tCPOperations.SendMessage("CG 1-21 STOP 1 \"" + TitleNmae + "\"");

                    return;
                }
            }
            string DataStr;
            string str3 = "\\";
            DataStr = "CG 1-21 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"t21" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TbDelete1MiniteTeam2 + " : " + TbDelete1SecondTeam2 + str3 + "\"/></componentData></templateData>\"";
            string message = DataStr;
            bool sm = _tCPOperations.SendMessage(message);
        }
        private void tTimerDel2T2_Tick(object sender, EventArgs e)
        {
            if (sd2t2 > 0)
            {
                sd2t2--;
                if (sd2t2 < 10)
                {
                    TbDelete2SecondTeam2 = "0" + sd2t2.ToString();
                }
                else
                {
                    TbDelete2SecondTeam2 = sd2t2.ToString();
                }
            }
            else
            {
                if (md2t2 > 0)
                {
                    md2t2--;
                    if (md2t2 < 10)
                    {
                        TbDelete2MiniteTeam2 = "0" + md2t2.ToString();
                    }
                    else
                    {
                        TbDelete2MiniteTeam2 = md2t2.ToString();
                    }
                    sd2t2 = 59;
                    TbDelete2SecondTeam2 = "59";
                }
                else
                {
                    TtimerDel2T2.Stop();
                    ShowDelete2Team2Kind = "Show";
                    ShowDelete2Team2Color = "#FF406787";
                    md2t2 = Convert.ToInt32(_application.DelMin);
                    TbDelete2MiniteTeam2 = _application.DelMin;
                    sd2t2 = Convert.ToInt32(_application.DelSec);
                    TbDelete2SecondTeam2 = _application.DelSec;
                    string TitleNmae = "Title_Del2T2";
                    bool sm1 = _tCPOperations.SendMessage("CG 1-22 STOP 1 \"" + TitleNmae + "\"");

                    return;
                }
            }
            string DataStr;
            string str3 = "\\";
            DataStr = "CG 1-22 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"t22" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TbDelete2MiniteTeam2 + " : " + TbDelete2SecondTeam2 + str3 + "\"/></componentData></templateData>\"";
            string message = DataStr;
            bool sm = _tCPOperations.SendMessage(message);
        }
        private void tTimerDel3T2_Tick(object sender, EventArgs e)
        {
            if (sd3t2 > 0)
            {
                sd3t2--;
                if (sd3t2 < 10)
                {
                    TbDelete3SecondTeam2 = "0" + sd3t2.ToString();
                }
                else
                {
                    TbDelete3SecondTeam2 = sd3t2.ToString();
                }
            }
            else
            {
                if (md3t2 > 0)
                {
                    md3t2--;
                    if (md3t2 < 10)
                    {
                        TbDelete3MiniteTeam2 = "0" + md3t2.ToString();
                    }
                    else
                    {
                        TbDelete3MiniteTeam2 = md3t2.ToString();
                    }
                    sd3t2 = 59;
                    TbDelete3SecondTeam2 = "59";
                }
                else
                {
                    TtimerDel3T2.Stop();
                    ShowDelete3Team2Kind = "Show";
                    ShowDelete3Team2Color = "#FF406787";
                    md3t2 = Convert.ToInt32(_application.DelMin);
                    TbDelete3MiniteTeam2 = _application.DelMin;
                    sd3t2 = Convert.ToInt32(_application.DelSec);
                    TbDelete3SecondTeam2 = _application.DelSec;
                    string TitleNmae = "Title_Del3T2";
                    bool sm1 = _tCPOperations.SendMessage("CG 1-23 STOP 1 \"" + TitleNmae + "\"");

                    return;
                }
            }
            string DataStr;
            string str3 = "\\";
            DataStr = "CG 1-23 UPDATE 1 \"<templateData><componentData id=" + str3 + "\"t23" + str3 + "\"><data id=" + str3 + "\"text" + str3 + "\"" + " value=" + str3 + "\"" + TbDelete3MiniteTeam2 + " : " + TbDelete3SecondTeam2 + str3 + "\"/></componentData></templateData>\"";
            string message = DataStr;
            bool sm = _tCPOperations.SendMessage(message);
        }

        private CancellationTokenSource _ctSource;
        public Dispatcher Dispatcher { get; } = System.Windows.Application.Current.Dispatcher;
        public async void OnNavigatedTo(object arg)
        {
            if (arg == null)
                return;

            _ctSource?.Cancel();
            _ctSource = new CancellationTokenSource();
            var token = _ctSource.Token;

            List<string> calledList = await Task.Run(_tCPOperations.GetList);

            await Dispatcher.BeginInvoke(new Action(() =>
            {
                TLSList.Clear();

                foreach (var item in calledList)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    if (item != "")
                    {
                        var tls1 = new TLSListModel()
                        {
                            TLSName = item
                        };
                        TLSList.Add(tls1);
                    }
                }
            }));

            var tLSListFirst = TLSList.First();

            await Task.Run(() =>
            {
                SelectedItemCbxUpTitle = tLSListFirst;
                SelectedItemCbxSignature = tLSListFirst;
                SelectedItemCbxYellow = tLSListFirst;
                SelectedItemCbxYellow2 = tLSListFirst;
                SelectedItemCbxRed = tLSListFirst;
                SelectedItemCbxFouls = tLSListFirst;
                SelectedItemCbxAnnouncement = tLSListFirst;
                SelectedItemCbxCoach = tLSListFirst;
                SelectedItemCbxPlayerList = tLSListFirst;
                SelectedItemCbxStat = tLSListFirst;
                SelectedItemCbxQuantityAdditionalTime = tLSListFirst;
                SelectedItemCbxAdditionalTime = tLSListFirst;
                SelectedItemCbxDelete1Team1 = tLSListFirst;
                SelectedItemCbxDelete2Team1 = tLSListFirst;
                SelectedItemCbxDelete3Team1 = tLSListFirst;
                SelectedItemCbxDelete1Team2 = tLSListFirst;
                SelectedItemCbxDelete2Team2 = tLSListFirst;
                SelectedItemCbxDelete3Team2 = tLSListFirst;
            });


        }
        #endregion
    }
}
