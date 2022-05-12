using System.Collections.Generic;

namespace SchoolProject.Repository
{
    public interface ICRUD_Repository<T> where T : class
    {
        int Delete(int id);
        List<T> Getall();
        //List<T> GetByLvlId(int id);
        T GetById(int id);
        int Insert(T obj);
        int Update(T entity);
    }
}