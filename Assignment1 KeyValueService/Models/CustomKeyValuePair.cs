using System.ComponentModel.DataAnnotations;

namespace Assignment1_KeyValueService.Models
{
    public class CustomKeyValuePair
    {
        [Key] 
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
