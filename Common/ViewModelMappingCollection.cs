using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace iOSDisplayAlertHiddenIssue.Common
{
    public static class ViewModelMappingCollection
    {
        private static readonly object LockObject;
        private static IReadOnlyDictionary<Type, Type> _readOnlyDictionary;

        static ViewModelMappingCollection() => LockObject = new object();

        private const string ViewModelPostfix = "ViewModel";
        private const string PagePostfix = "Page";

        public static IReadOnlyDictionary<Type, Type> BuildMappingFromViewModelToPage()
        {
            if (_readOnlyDictionary != null)
            {
                return _readOnlyDictionary;
            }

            lock (LockObject)
            {
                if (_readOnlyDictionary == null)
                {
                    var assembly = typeof(ViewModelMappingCollection).GetTypeInfo().Assembly;
                    var definedTypes = assembly.DefinedTypes.ToArray();

                    var viewModels = definedTypes
                        .Where(x => x.Name.EndsWith(ViewModelPostfix) && !x.IsAbstract)
                        .Select(x => new
                        {
                            Name = x.Name.Replace(ViewModelPostfix, string.Empty),
                            x.FullName,
                            Type = x
                        })
                        .ToDictionary(x => x.Name, v => v.Type);

                    var pages = definedTypes
                        .Where(x => x.Name.EndsWith(PagePostfix) && !x.IsAbstract)
                        .Select(x => new
                        {
                            Name = x.Name.Replace(PagePostfix, string.Empty),
                            x.FullName,
                            Type = x
                        })
                        .ToDictionary(x => x.Name, v => v.Type);

                    var modelToPageMapping = viewModels.ToDictionary(x => x.Value.AsType(), v => pages[v.Key].AsType());
                    _readOnlyDictionary = modelToPageMapping;
                }

                return _readOnlyDictionary;
            }
        }
    }
}
