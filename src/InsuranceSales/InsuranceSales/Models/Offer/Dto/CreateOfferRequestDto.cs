using System;
using System.Collections.Generic;

namespace InsuranceSales.Models.Offer.Dto
{
    public class CreateOfferRequestDto
    {
        public string ProductCode { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public IEnumerable<string> SelectedCovers { get; set; }

        public IEnumerable<QuestionAnswerModel> Answers { get; set; }
    }
}
