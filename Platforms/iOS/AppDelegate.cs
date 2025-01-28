using Autofac;
using DeviceDiscoveryExtension;
using Foundation;
using System;
using UIKit;
using IContainer = Autofac.IContainer;

namespace iOSDisplayAlertHiddenIssue
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        private IContainer container;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {


            if (!Resolver.IsSet)
            {
                SetIoc();
            }

            return base.FinishedLaunching(app, options);
        }

        private void SetIoc()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder
                .RegisterModule<ParentModule>();


            container = containerBuilder.Build();
            Resolver.ComponentContext = container;
        }
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
