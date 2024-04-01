namespace DisasterResponseSystem.Models
{
    public class AidRequest
    {
        public long Id { set; get; }
        public int Rank { set; get; }
        public int Status { set; get; }
        public float RequestedDonations{ set; get; }
        public string Name { set; get; }
        public string Brief { set; get; }

        public virtual ICollection<ProcessingAidRequests> ProcessingAidRequests { set; get; }
    }
}
