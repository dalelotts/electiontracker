namespace KnightRider.ElectionTracker.db.task {
    public interface IDAOTask<T>
    {
        void perform(T entity);
    }
}