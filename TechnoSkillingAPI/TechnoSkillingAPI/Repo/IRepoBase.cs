namespace TechnoSkillingAPI.Repo
{
    public interface IRepoBase<T,TRes>
    {
        TRes Get(Guid id);
        IList<TRes> GetAll();
        IList<TRes> GetByParentId(Guid ParentId);
        bool Add(T item);
        bool Update(Guid id,T item);
        bool Delete(Guid Id);
    }
}
