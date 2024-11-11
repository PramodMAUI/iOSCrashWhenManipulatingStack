using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iOSNavStackRemoveCrash.Common.Enums;
using iOSNavStackRemoveCrash.Interfaces;
using iOSNavStackRemoveCrash.Models;

namespace iOSNavStackRemoveCrash.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        protected INavigationService NavigationService { get; set; }
        public PageTypeEnum PageType { get; set; }
        protected BaseViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }
        protected BaseViewModel()
        {
                
        }
    }
}
