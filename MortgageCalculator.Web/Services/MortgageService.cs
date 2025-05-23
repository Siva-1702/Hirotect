using MortgageCalculator.Dto;
using MortgageCalculator.Web.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Web.Services
{
    public interface IMortgageService
    {
        List<Mortgage> GetAllMortgages();
    }

    public class MortgageService : IMortgageService
    {

        private readonly IMortgageRepo _mortgageRepo;
        public MortgageService() : this(new MortgageRepo())
        { }

        public MortgageService(IMortgageRepo mortgageRepo)
        {
            this._mortgageRepo = mortgageRepo;
        }

        public List<Mortgage> GetAllMortgages()
        {
            return _mortgageRepo.GetAllMortgages();
        }
    }
}