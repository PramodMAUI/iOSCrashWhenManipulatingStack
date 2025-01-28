using Autofac;

namespace iOSDisplayAlertHiddenIssue
{
    public static class Resolver
    {
        public static IComponentContext ComponentContext { private get; set; } //Autofac.IContainer, IComponentContext

        public static bool IsSet => ComponentContext != null;

        public static T Resolve<T>() => ComponentContext.Resolve<T>();

        public static object Resolve(Type t) => ComponentContext.Resolve(t);
    }
}
