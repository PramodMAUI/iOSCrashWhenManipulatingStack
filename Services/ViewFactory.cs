
using iOSNavStackRemoveCrash.Common;
using iOSNavStackRemoveCrash.Interfaces;
using iOSNavStackRemoveCrash.ViewModels;

namespace iOSNavStackRemoveCrash.Services
{
    public class ViewFactory : IViewFactory
    {
        private readonly IReadOnlyDictionary<Type, Type> modelToPageMapping;

        public ViewFactory() => modelToPageMapping = ViewModelMappingCollection.BuildMappingFromViewModelToPage();

        public Page CreatePage<TViewModel>(Action<TViewModel> activateAction = null)
            where TViewModel : BaseViewModel
        {
            var type = modelToPageMapping[typeof(TViewModel)];
            var page = (Page)Resolver.Resolve(type);
            var viewModel = Resolver.Resolve<TViewModel>();
            activateAction?.Invoke(viewModel);
            page.BindingContext = viewModel;
            return page;
        }
    }
}
