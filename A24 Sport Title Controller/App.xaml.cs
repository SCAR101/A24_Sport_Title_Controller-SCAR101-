using A24_Sport_Title_Controller.ViewModels;
using A24_Sport_Title_Controller.Views;
using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace A24_Sport_Title_Controller
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TitleControlViewModel titleControlViewModel;
        private MainWindowViewModel mainWindowViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var menu = new Menu();
            var titleControl = new TitleControl();

            var application = new Core.Application();
            var tCPOperations = new Core.Operations.TCPOperations();

            //1. Создайте менеджер навигации
            var navigationManager = new NavigationManager(mainWindow.CurrentPage);
            var navigationManager1 = new NavigationManager(menu.fPageMain);

            mainWindowViewModel = new MainWindowViewModel(navigationManager, application, tCPOperations);
            mainWindow.DataContext = mainWindowViewModel;

            var menuViewModel = new MenuViewModel(navigationManager, application);
            menu.DataContext = menuViewModel;

            titleControlViewModel = new TitleControlViewModel(navigationManager, application, tCPOperations);
            titleControl.DataContext = titleControlViewModel;


            //2. Определите правила навигации: зарегистрируйте ключ (строку) с соответствующими View и ViewModel для него
            //navigationManager.Register<MainWindow>("MainWindowKey", () => new MainWindowViewModel(navigationManager, application));
            navigationManager1.Register<MainWindow>("MainWindowKey", () => mainWindowViewModel);
            navigationManager.Register("MenuKey", () => new MenuViewModel(navigationManager1, application), () => menu);;
            navigationManager1.Register<TitleControl>("TitleControlKey", () => titleControlViewModel);

          //  GC.Collect();

            //3. Отобразите стартовый UI
            navigationManager.Navigate("MenuKey");

            mainWindow.Show();


        }
    }
}
