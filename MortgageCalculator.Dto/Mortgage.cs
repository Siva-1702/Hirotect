using System;
using System.Collections.Generic;

namespace MortgageCalculator.Dto
{
    public class Mortgage
    {
        public int MortgageId { get; set; }
        public string Name { get; set; }
        public MortgageType MortgageType { get; set; }
        public InterestRepayment InterestRepayment { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public int TermsInMonths { get; set; }
        public decimal CancellationFee { get; set; }
        public decimal EstablishmentFee { get; set; }
        public Guid SchemaIdentifier { get; internal set; }
    }

    public enum MortgageType
    {
        Variable,
        Fixed
    }

    public enum InterestRepayment
    {
        InterestOnly,
        PrincipalAndInterest
    }


    // Simulated data context with test data
    public class MortgageDataContext : IDisposable
    {
        public List<Mortgage> Mortgages { get; set; }

        public MortgageDataContext()
        {
            Mortgages = new List<Mortgage>
            {
                new Mortgage
                {
                    MortgageId = 1,
                    Name = "Home Loan Basic",
                    MortgageType = MortgageType.Fixed,
                    InterestRepayment = InterestRepayment.PrincipalAndInterest,
                    EffectiveStartDate = new DateTime(2023, 01, 01),
                    EffectiveEndDate = new DateTime(2028, 01, 01),
                    TermsInMonths = 60,
                    CancellationFee = 500,
                    EstablishmentFee = 1000
                },
                new Mortgage
                {
                    MortgageId = 2,
                    Name = "Flexible Mortgage Plan",
                    MortgageType = MortgageType.Variable,
                    InterestRepayment = InterestRepayment.PrincipalAndInterest,
                    EffectiveStartDate = new DateTime(2022, 06, 01),
                    EffectiveEndDate = new DateTime(2027, 06, 01),
                    TermsInMonths = 60,
                    CancellationFee = 300,
                    EstablishmentFee = 800
                }
            };
        }

        public void Dispose()
        {
            // Nothing to dispose in a mock context
        }
    }
}
