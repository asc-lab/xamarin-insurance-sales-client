using System;
using System.Collections.Generic;

namespace InsuranceSales.Models.Offer.Dto
{
    public class CreateOfferRequest
    {
        public string ProductCode { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public IList<string> SelectedCovers { get; set; }

        public IList<QuestionAnswerModel> Answers { get; set; }
    }
}
