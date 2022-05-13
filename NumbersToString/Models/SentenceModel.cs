using System.ComponentModel.DataAnnotations.Schema;

namespace NumbersToString.Web.Models
{
    public class SentenceModel
    {

        public double NumberToConvert { get; set; }
        public string ConvertedNumber { get; set; }
    }
}
