using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db.task {
    public class LoadCountyForUI : IDAOTask<County> {
        public void perform(County entity) {
            // Get the count of each list so that they are loaded.
            int attributeCount = entity.Attributes.Count;
            int phoneNumberCount = entity.PhoneNumbers.Count;
            int websiteCount = entity.Websites.Count;
        }
    }
}