using A24_Sport_Title_Controller.Core;
using A24_Sport_Title_Controller.Core.Operations;
using A24_Sport_Title_Controller.Views;
using Egor92.MvvmNavigation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace A24_Sport_Title_Controller.ViewModels
{
    class MainWindowViewModel : OnPropertyChangedClass
    {
        private readonly INavigationManager _navigationManager;

        private readonly IApplication _application;

        private readonly TCPOperations _tCPOperations;

        public MainWindowViewModel(INavigationManager navigationManager, IApplication application, TCPOperations tCPOperations)
        {
            _application = application;
            _navigationManager = navigationManager;
            _tCPOperations = tCPOperations;
            FrameOpacity = 1;
            TxbServerAddress = Properties.Settings.Default.TxbServerAddress;
            TxbPort = Properties.Settings.Default.TxbPort;
            VisBtnDisconnect = "Collapsed";
            _application.ChangePathToTHandBall("");
            _application.ChangePathToTMiniSoccer("");
            _application.ChangePathToTSoccer("");
            _application.ChangePathToTWaterPolo("");
            _application.ChangePathToTBasketBall("");
            _application.ChangePathToTJudo("");
        }

        #region Private

        private double _frameOpacity;
        private string _visBtnConnect;
        private string _visBtnDisconnect;
        private string _tbStatusServer;
        private string _tbForegroundStatusServer;
        private string _txbServerAddress;
        private string _txbPort;

        #endregion

        #region Public
        public string TbForegroundStatusServer
        {
            get { return _tbForegroundStatusServer; }
            set
            {
                _tbForegroundStatusServer = value;
                OnPropertyChanged("");
            }
        }

        public string TxbServerAddress
        {
            get { return _txbServerAddress; }
            set
            {
                _txbServerAddress = value;
                OnPropertyChanged("");
            }
        }

        public string TxbPort
        {
            get { return _txbPort; }
            set
            {
                _txbPort = value;
                OnPropertyChanged("");
            }
        }

        public string VisBtnConnect
        {
            get { return _visBtnConnect; }
            set
            {
                _visBtnConnect = value;
                OnPropertyChanged("");
            }
        }

        public string VisBtnDisconnect
        {
            get { return _visBtnDisconnect; }
            set
            {
                _visBtnDisconnect = value;
                OnPropertyChanged("");
            }
        }

        public string TbStatusServer
        {
            get { return _tbStatusServer; }
            set
            {
                _tbStatusServer = value;
                OnPropertyChanged("");
            }
        }

        public double FrameOpacity
        {
            get { return _frameOpacity; }
            set
            {
                _frameOpacity = value;
                OnPropertyChanged("FrameOpacity");
            }
        }

       

        public ICommand ClickConnect
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    try
                    {
                        bool Con = _tCPOperations.Connect(TxbServerAddress, TxbPort);
                        if (Con == true)
                        {
                            TbStatusServer = "CONNECTED";                         
                            VisBtnConnect = "Collapsed";
                            VisBtnDisconnect = "Visible";
                            TbForegroundStatusServer = "#FF7EC772";
                            Properties.Settings.Default.TxbServerAddress = TxbServerAddress;
                            Properties.Settings.Default.TxbPort = TxbPort;
                            Properties.Settings.Default.Save();
                            _application.ChangeCasparConnected("true");
                        }
                        else
                        {
                            TbStatusServer = "NOT CONNECTED";
                            TbForegroundStatusServer = "#FFB25F5F";
                            _application.ChangeCasparConnected("false");
                        }
                    }
                    catch (Exception)
                    {
                        TbStatusServer = "UNABLE TO CONNECTE";
                        TbForegroundStatusServer = "White";
                        _application.ChangeCasparConnected("false");
                    }
                });
            }
        }

        public ICommand ClickDisconnect
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    _tCPOperations.Disconnect();
                    if (VisBtnConnect.Equals("Collapsed"))
                    {
                        VisBtnConnect = "Visible";
                        VisBtnDisconnect = "Collapsed";
                        TbStatusServer = "NOT CONNECTED";
                        TbForegroundStatusServer = "#FFB25F5F";
                        _application.ChangeCasparConnected("false");
                    }
                });
            }
        }

        #endregion

        #region Void
        public async void SlowOpacity(string Page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.02)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
                _navigationManager.Navigate(Page);
                for (double i = 0.0; i < 1.1; i += 0.02)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }
        #endregion
    }
}

