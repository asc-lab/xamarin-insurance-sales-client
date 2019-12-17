namespace InsuranceSales.Models.Policy.Dto
{
    public class CreatePolicyRequestDto
    {
        public string OfferNumber { get; set; }

        public PersonModel PolicyHolder { get; set; }

        public AddressModel PolicyHolderAddress { get; set; }
    }
}
