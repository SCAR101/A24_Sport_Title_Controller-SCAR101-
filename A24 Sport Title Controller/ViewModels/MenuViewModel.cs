using A24_Sport_Title_Controller.Core;
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
    class MenuViewModel : OnPropertyChangedClass, INavigatedToAware
    {
        private readonly INavigationManager _navigationManager;

        private readonly IApplication _application;

        public MenuViewModel(INavigationManager navigationManager, IApplication application)
        {
            _navigationManager = navigationManager;
            _application = application;
            FrameOpacity = 1;
        }

        #region Private

        private double _frameOpacity;
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
       
        #endregion

        #region ICommand

        public ICommand ClickHandball
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (_application.CasparConnected == "true")
                    {
                        GC.Collect();
                        SlowOpacity("TitleControlKey", "HandBall");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Нет подключения к серверу!", "Ошибка!");
                        return;
                    }
                   
                });
            }
        }

        public ICommand ClickMiniSoccer
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (_application.CasparConnected == "true")
                    {
                        GC.Collect();
                        SlowOpacity("TitleControlKey", "MiniSoccer");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Нет подключения к серверу!", "Ошибка!");
                        return;
                    }
                   
                });
            }
        }

        public ICommand ClickSoccer
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (_application.CasparConnected == "true")
                    {
                        GC.Collect();
                        SlowOpacity("TitleControlKey", "Soccer");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Нет подключения к серверу!", "Ошибка!");
                        return;
                    }
                  
                });
            }
        }

        public ICommand ClickWaterPolo
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (_application.CasparConnected == "true")
                    {
                        GC.Collect();
                        SlowOpacity("TitleControlKey", "WaterPolo");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Нет подключения к серверу!", "Ошибка!");
                        return;
                    }
                   
                });
            }
        }

        public ICommand ClickBasketBall
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (_application.CasparConnected == "true")
                    {
                        GC.Collect();
                        SlowOpacity("TitleControlKey", "BasketBall");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Нет подключения к серверу!", "Ошибка!");
                        return;
                    }
                   
                });
            }
        }

        public ICommand ClickJudo
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (_application.CasparConnected == "true")
                    {
                        GC.Collect();
                        SlowOpacity("TitleControlKey", "Judo");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Нет подключения к серверу!", "Ошибка!");
                        return;
                    }
                 
                });
            }
        }

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
        #endregion

        public void OnNavigatedTo(object arg)
        {
            if (arg == null)
                return;
            //var selectedDG = new SelectedDGModel()
            //{
            //    SelectedDG = null,
            //    Text = "ActOfTransfer"
            //};
            //SlowOpacity("GeneralTableKey", selectedDG);
            SlowOpacity("SettingsKey", "SettingsKey");
        }
    }
}
