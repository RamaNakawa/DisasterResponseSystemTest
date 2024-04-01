namespace DisasterResponseSystem.PostModels
{
    public class AidRequestPost
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public string Brief { set; get; }
        public float RequestedDonation { set; get; }
    }
}
