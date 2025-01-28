using Autofac;
using iOSDisplayAlertHiddenIssue.Common;
using iOSDisplayAlertHiddenIssue.Interfaces;
using iOSDisplayAlertHiddenIssue.Services;

namespace iOSDisplayAlertHiddenIssue
{
    public class ParentModule : Module
    {
        #region Overriding methods

        /// <summary>
        /// Loading the container with services and viewmodels
        /// </summary>
        /// <param name="containerBuilder"></param>
        protected override void Load(ContainerBuilder containerBuilder)
        {
            ServiceRegister(containerBuilder);
            ViewModelRegister(containerBuilder);
            PageRegister(containerBuilder);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registering app viewmodels
        /// </summary>
        /// <param name="containerBuilder"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private static void ViewModelRegister(ContainerBuilder containerBuilder)
        {
            // Application class registration
            containerBuilder.RegisterType<App>();

            var modelToPageMapping = ViewModelMappingCollection.BuildMappingFromViewModelToPage();
            foreach (var info in modelToPageMapping)
            {
                containerBuilder.RegisterType(info.Key).AsSelf();

            }
        }

        /// <summary>
        /// Registering app services
        /// </summary>
        /// <param name="containerBuilder"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private static void ServiceRegister(ContainerBuilder containerBuilder)
        {
            // Navigation service registration to manipulate as per need to navigate to particular page
            containerBuilder.RegisterType<NavigationService>()
              .As<INavigationService>()
              .SingleInstance();

            containerBuilder.RegisterType<ViewFactory>()
              .As<IViewFactory>()
              .SingleInstance();

        }

        private static void PageRegister(ContainerBuilder containerBuilder)
        {
            var modelToPageMapping = ViewModelMappingCollection.BuildMappingFromViewModelToPage();
            foreach (var info in modelToPageMapping)
            {
                containerBuilder.RegisterType(info.Value).AsSelf();
            }
        }

        #endregion
    }
}
