namespace DisasterResponseSystem.ResponseModels
{
    public class AidRequestResponse
    {
        public long Id { set; get; }
        public string Brief { set; get; }
        public string Name { set; get; }
        public string Status { set; get; }
        public string Rank { set; get; }
        public float CollectedDonations { set; get; }
        public float RequestedDonations { set; get; }

    }
}
