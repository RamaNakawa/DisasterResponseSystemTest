using DisasterResponseSystem.PostModels;
using DisasterResponseSystem.ResponseModels;

namespace DisasterResponseSystem.Service
{
    public interface ILogicService 
    {
        long CreateAidRequest(AidRequestPost post);

        List<AidRequestResponse> GetAllAidRequests(int? Rank, int? Status, int Length, int Skip, out int Total);

        long EditAidRequest(long Id, EditAidRequestPost post);

        long CreateDonation(DonaitPost post);

        long ProcessAidRequest(long Id, ProcessAidRequestPost post);

    }
}
