using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO.AddDTO
{
    public partial class AppSettingsAddUpdateDTO
    {
        public int Id { get; set; }
        public string AboutUsTitle { get; set; }
        public string AboutUsDescription { get; set; }
        public string AboutUsVision { get; set; }
        public string AboutUsMision { get; set; }
        public string ContactUsEmail { get; set; }
        public string ContactUsMobileNo { get; set; }
        public string ContactUsLatitude { get; set; }
        public string ContactUsLongitude { get; set; }
        public string ContactUsTitle { get; set; }
        public string ContactUsTitleAR { get; set; }
        public string AboutUsTitleAR { get; set; }
        public string AboutUsDescriptionAR { get; set; }
        public string AboutUsVisionAR { get; set; }
        public string AboutUsMisionAR { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }

    }
}
