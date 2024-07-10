namespace BaseAPI.Abstraction
{
    public interface ICRUD<T>
    {
        T GetById(int id);
        IList<T> GetAll();

        IList<T> GetAllByPage(int _page, int _countByPage);

        T Save(T entity);
           
        T Update(T entity);

        void DeleteById(int id); 

    }
}