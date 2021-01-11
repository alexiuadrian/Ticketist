using System.ComponentModel.DataAnnotations;

namespace Ticketist.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        [Display(Name = "Search")]
        public string SearchString { get; set; }
    }
}