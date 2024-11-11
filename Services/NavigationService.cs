using iOSNavStackRemoveCrash.Common.Enums;
using iOSNavStackRemoveCrash.Interfaces;
using iOSNavStackRemoveCrash.ViewModels;
using iOSNavStackRemoveCrash.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iOSNavStackRemoveCrash.Services
{
    public class NavigationService : INavigationService
    {

        private readonly IViewFactory viewFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        public NavigationService(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        public Task PushToRootAsync<TViewModel>(Action<TViewModel> activateAction)
    where TViewModel : BaseViewModel
        {
            return Task.Factory.StartNew(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = new BaseNavigationPage(
                        viewFactory.CreatePage(activateAction)
                    );
                });

            });
        }
        /// <summary>
        /// Pushes page asynchronous.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="activateAction">The activate action.</param>
        /// <returns></returns>
        public Task PagePushAsync<TViewModel>(Action<TViewModel> activateAction)
            where TViewModel : BaseViewModel
        {
            return Task.Factory.StartNew(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        await PushPage(activateAction);
                    }
                    catch (Exception ex)
                    {
                    }
                });
            });
        }

        private async Task PushPage<TViewModel>(Action<TViewModel> activateAction) where TViewModel : BaseViewModel
        {
            try
            {
                Page page = viewFactory.CreatePage(activateAction);
                var navigationService = GetNavigationService();

                await navigationService.PushAsync(page);
            }
            catch (Exception ex)
            {
                // Log exception 
            }

        }

        /// <summary>
        /// Fetches navigation services
        /// </summary>
        public INavigation GetNavigationService()
        {
            var navigationService = Application.Current?.MainPage?.Navigation;
            if (navigationService != null)
            {
                navigationService = (Application.Current.MainPage).Navigation;
            }

            return navigationService;
        }

        /// <summary>
        /// To resolve barcode surface holder issue android, need to manipulate the navigation stack by removing and re-pushing barcode page.
        /// </summary>
        public void RemovePage<TViewModel>(Action<TViewModel> activateAction)
                        where TViewModel : BaseViewModel
        {
            Page page = viewFactory.CreatePage(activateAction);
            INavigation navigationService = GetNavigationService();
            Page pageObj = navigationService.NavigationStack?.FirstOrDefault(x => x.GetType() == page.GetType());

            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    navigationService.RemovePage(pageObj);
                }
                catch (Exception ex)
                {
                }
            });
        }
        public void ManipulateNavStack(PageTypeEnum startPageType, PageTypeEnum endPageType)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    var removePageIndex = -1;
                    var index = 0;

                    INavigation navService = GetNavigationService();

                    PageTypeEnum pageElementType = ((BaseViewModel)navService.NavigationStack[index].BindingContext).PageType;

                    MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        while (pageElementType != endPageType)
                        {
                            if (pageElementType == startPageType)
                            {
                                removePageIndex = index + 1;
                            }
                            else if (removePageIndex > 0)
                            {
                                try
                                {
                                    //var temp = navService.NavigationStack[removePageIndex];
                                    //Application.Current.Dispatcher.Dispatch(() =>
                                    //{
                                    navService.RemovePage(navService.NavigationStack[removePageIndex]);
                                    //});

                                    index--;
                                }
                                catch (Exception ex)
                                {
                                    // Log exception 
                                }
                            }

                            index++;

                            if (index < navService.NavigationStack.Count)
                            {
                                pageElementType = ((BaseViewModel)navService.NavigationStack[index].BindingContext).PageType;
                            }
                            else
                            {
                                break;
                            }
                        }
                    });
                });
            }
            catch (Exception ex)
            {
            }
        }

    }
}
