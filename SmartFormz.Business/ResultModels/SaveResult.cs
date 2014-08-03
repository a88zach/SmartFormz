namespace SmartFormz.Business.ResultModels
{
    public class SaveResult<T>
    {
        public T Model { get; set; }
        public SaveResultStatus SaveResultStatus { get; set; }
        public T CurrentEntry { get; set; }

        public SaveResult(T model, SaveResultStatus saveResultStatus) : this(model, saveResultStatus, model)
        {

        }

        public SaveResult(T model, SaveResultStatus saveResultStatus, T currentEntry)
        {
            Model = model;
            SaveResultStatus = saveResultStatus;
            CurrentEntry = currentEntry;
        } 
    }
}
