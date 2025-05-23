using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Web.Repos
{
    public interface IMortgageRepo
    {
        List<Mortgage> GetAllMortgages();
    }

    public class MortgageRepo : IMortgageRepo
    {
        public List<Mortgage> GetAllMortgages()
        {
            using (var context = new MortgageDataContext())
            {
                var mortgages = context.Mortgages.ToList();
                List<Mortgage> result = new List<Mortgage>();
                foreach (var mortgage in mortgages)
                {
                    result.Add(new Mortgage()
                    {
                        MortgageId = mortgage.MortgageId,
                        Name = mortgage.Name,
                        MortgageType = mortgage.MortgageType,
                        InterestRepayment = mortgage.InterestRepayment,
                        EffectiveStartDate = mortgage.EffectiveStartDate,
                        EffectiveEndDate = mortgage.EffectiveEndDate,
                        TermsInMonths = mortgage.TermsInMonths,
                        CancellationFee = mortgage.CancellationFee,
                        EstablishmentFee = mortgage.EstablishmentFee
                        //TermsInMonths = mortgage.TermsInMonths
                    }
                    );
                }
                return result;
            }
        }
    }
}