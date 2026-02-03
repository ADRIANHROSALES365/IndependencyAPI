namespace IndependecyApi.Repository.IRepository
{
    public interface ITypeRepository
    {
        ICollection<Type> GetTypes();
        
        Type? GetType(string name);
        
        Type? GetType(int id);

        bool TypeExists(string name);

        bool TypeExists(int id);

        bool CreateType(Type type);

        bool  UpdateType(Type type);

        bool DeleteType(Type type);

        bool save();

    }
}