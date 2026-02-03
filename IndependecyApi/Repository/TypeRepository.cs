using System;
using AutoMapper;
using IndependecyApi.Repository.IRepository;

namespace IndependecyApi.Repository;

public class TypeRepository : ITypeRepository
{
    private readonly ApplicationDbContext _db;

    public TypeRepository(ApplicationDbContext dbContext)
    {
        _db=dbContext; 
    }
    public bool CreateType(Type type)
    {
        if (type==null)
        {
            return false;
        }

        type.Creation_Date=DateTime.Now;
        _db.Types.Add(type);

        return save();
        
    }

    public bool DeleteType(Type type)
    {
        _db.Types.Remove(type);
        return save();
    }

    public Type? GetType(int id)
    {
       return _db.Types.FirstOrDefault(t => t.TypeId == id);
    }

      public Type? GetType(string name)
    {
       return _db.Types.FirstOrDefault(t => t.Name.ToLower().Trim()==name.ToLower().Trim());
    }


    public ICollection<Type> GetTypes()
    {
        return _db.Types.OrderBy(t => t.Name).ToList();
    }

    public bool save()
    {
       return _db.SaveChanges()>=0 ? true:false;
        
    }

    public bool TypeExists(string name)
    {
        if(_db.Types.Any(t=> t.Name.ToLower().Trim()==name.ToLower().Trim()))
        {
            return true;
        }
        return  false;
    }

    public bool TypeExists(int id)
    {
        if(id<=0)
        {
            return false;
        }

        return _db.Types.Any(t => t.TypeId==id);
    }

    public bool UpdateType(Type type)
    {
        if(type==null)
        {
            return false;
        }

        type.Update_Date = DateTime.Now;

        _db.Types.Update(type);
        return save();
    }
}
