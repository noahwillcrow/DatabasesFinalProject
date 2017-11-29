using NwcLib.EntityFrameworkGenerics;

namespace DatabaseBridge.Managers
{
    public class DataManager<T> : GenericDataManager<T, DataContext> where T : GenericModel
    {
    }
}
