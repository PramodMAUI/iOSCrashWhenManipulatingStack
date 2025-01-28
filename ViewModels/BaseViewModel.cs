using System.Windows.Input;
using iOSDisplayAlertHiddenIssue.Common.Enums;
using iOSDisplayAlertHiddenIssue.Controls;
using iOSDisplayAlertHiddenIssue.Interfaces;
using iOSDisplayAlertHiddenIssue.Models;

namespace iOSDisplayAlertHiddenIssue.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        private bool canNavigateBack = false;
        /// <summary>
        /// Gets or sets the CanNavigateBack
        /// </summary>
        public bool CanNavigateBack
        {
            get { return this.canNavigateBack; }
            set { this.SetProperty(ref this.canNavigateBack, value); }
        }

        public static bool isBarcodeScanned = false;

        private CustomCommand barcodeSearchCommand;
        /// <summary>
        /// The Barcode Search action to be performed.
        /// </summary>
        /// <value>
        /// The Barcode Search command action wrapper.
        /// </value>
        public ICommand BarcodeSearchCommand
        {
            get
            {
                if (this.barcodeSearchCommand == null)
                {
                    Action executeAction = async () =>
                    {
                        NavigationService.PopModalAsync();
                        await BarcodeSearch();
                    };

                    this.barcodeSearchCommand = new CustomCommand(executeAction, this.CanExecuteAction);
                }
                return this.barcodeSearchCommand;
            }
        }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Initialize()
        {
            this.OnInitialize();
        }
        protected bool CanExecuteAction()
        {
            return true;
        }
        /// <summary>
        /// Called when the view model is initialized.
        /// </summary>
        protected virtual void OnInitialize()
        {
            // Intentionally left blank
        }
        /// <summary>
        /// Determines whether the command can execute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns>False when the view model IsLoading.</returns>
        protected Boolean CanExecuteAction<T>(T item)
        {
            return this.CanExecuteAction();
        }
        protected INavigationService NavigationService { get; set; }
        public PageTypeEnum PageType { get; set; }
        protected BaseViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }
        protected BaseViewModel()
        {
                
        }

        public virtual void OnViewDisappearing() { }
        public virtual void OnViewAppearing()
        {
            BarcodeSearchCommand.Execute(null);
        }
        protected virtual Task BarcodeSearch()
        {
            return Task.FromResult(0);
        }
    }
}
