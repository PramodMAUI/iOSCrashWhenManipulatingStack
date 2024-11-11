using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iOSNavStackRemoveCrash.Views
{
    public class BaseNavigationPage : NavigationPage
    {
        #region Private Variable

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNavigationPage"/> class.
        /// </summary>
        /// <param name="root">The root.</param>
        public BaseNavigationPage(Page root)
            : base(root)
        {
            this.BarBackgroundColor = Color.FromHex("#262A34");

            this.BarTextColor = Colors.White;
            this.Popped += this.OnPagePopped;
            this.Pushed += this.OnPagePushed;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Event that is raised when the back button is pressed.
        /// </summary>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override bool OnBackButtonPressed()
        {
            if (this.Navigation.NavigationStack.Count == 1 && Device.RuntimePlatform == Device.Android)
            {
            }
            else
            {
                this.Navigation.PopAsync();
            }

            return true;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Called when [page popped].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        private void OnPagePopped(object sender, NavigationEventArgs e)
        {
            if (this.Navigation.NavigationStack.Count == 1)
            {
                // As of now nothing to do here.                      
            }
        }

        /// <summary>
        /// Called when [page pushed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        private void OnPagePushed(object sender, NavigationEventArgs e)
        {
            this.BarBackgroundColor = Color.FromHex("#262A34");
            if (this.Navigation.NavigationStack.Count > 1)
            {
                // As of now nothing to do here.
            }
        }

        #endregion
    }
}
