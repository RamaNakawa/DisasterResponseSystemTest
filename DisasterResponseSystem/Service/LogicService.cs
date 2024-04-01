using DisasterResponseSystem.Core.Exception;
using DisasterResponseSystem.Models;
using DisasterResponseSystem.PostModels;
using DisasterResponseSystem.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Service
{
    public class LogicService : ILogicService
    {
        private readonly DataBaseConext _conext;

        public LogicService(DataBaseConext conext)
        {
            _conext = conext;
        }

        public long CreateAidRequest(AidRequestPost post )
        {
            AidRequest x =  _conext.AidRequests.Add(new AidRequest
            {
                Name = post.Name,
                Brief =  post.Brief,
                Rank = (int)RankEnum.NotRanked,
                Status = (int)StatusEnum.NotStatus,
                RequestedDonations = post.RequestedDonation
            }).Entity;
            _conext.Commit();
            return x.Id;
        }

        public long CreateDonation(DonaitPost post)
        {
            Donation x = _conext.Donations.Add(new Donation
            {
                DonerName =  post.DonerName,
                DonationValue  = post.DonationValue,
            }).Entity;
            _conext.Commit();
            return x.Id;
        }

        public long EditAidRequest(long Id,EditAidRequestPost post)
        {
            var _AidReqiest  = _conext.AidRequests.Where(a => a.Id == Id).FirstOrDefault();
            if (_AidReqiest == null)
                throw new DataNotFoundException();

            _AidReqiest.Status = post.Status;
            _AidReqiest.Rank = post.Rank;
            _conext.Commit();

            return _AidReqiest.Id;
        }

        public  List<AidRequestResponse> GetAllAidRequests(int? Rank,int? Status,int Length,int Skip,out int Total)
        {
            var Query = _conext.AidRequests.Where(a =>
            (Rank == null || Rank == a.Rank)
            && (Status == null || Status == a.Status));

            Total = Query.Count();
            var Result = Query.Include(a => a.ProcessingAidRequests) .Skip(Skip).Take(Length).ToList();

            return Result.Select(a => new AidRequestResponse
            {
                Id = a.Id,
                Brief = a.Brief,
                Name = a.Name,
                Rank = ((RankEnum)a.Rank).ToString(),
                Status = ((StatusEnum)a.Status).ToString(),
                CollectedDonations =  a.ProcessingAidRequests.Select(c => c.Value).Sum(),
                RequestedDonations =  a.RequestedDonations,
            }).ToList();
        }

        public long ProcessAidRequest(long Id, ProcessAidRequestPost post)
        {
            var _AidReqiest = _conext.AidRequests.Where(a => a.Id == Id).FirstOrDefault();
            if (_AidReqiest == null)
                throw new DataNotFoundException();

            var CollectedDontaions = _conext.ProcessingAidRequests.Select(a => a.Value).Sum();
            if (CollectedDontaions + post.Value > _AidReqiest.RequestedDonations)
                throw new BadRequestException("Collected Dontaions For This Case is more than requested Donation");

            var Entity = _conext.ProcessingAidRequests.Add(new ProcessingAidRequests
            {
                Value = post.Value,
                AidRequestId = _AidReqiest.Id,
            }).Entity;

            _conext.Commit();
            return Entity.Id;
        }
    }
}
