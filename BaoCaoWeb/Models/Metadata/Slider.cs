using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    [MetadataTypeAttribute(typeof(SliderMetadata))]
    public partial class Slider
    {
        internal sealed class SliderMetadata
        {
            [DisplayName("ID")]
            public int sliderId { get; set; }
            [DisplayName("Tên Slider")]
            public string sliderName { get; set; }
            [DisplayName("Ảnh Slider")]
            public string slider_image { get; set; }
        }
    }
}