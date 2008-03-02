namespace edu.uwec.cs.cs355.group4.et.db.task {
    internal interface IDAOTask<T> {
        void perform(T entity);
    }
}