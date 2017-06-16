using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.ViewModels
{
    public class HomePageViewModel
    {

        private string _name;

        [Required, RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string NameWithSpaces => _name.Aggregate(string.Empty, (c, i) => c + i + ' ');

        public string SortName => string.Concat(_name.OrderBy(c => c));
        
        public string NewName()
        {
            var name = string.Concat(_name.OrderBy(c => c));
            return name.Aggregate(string.Empty, (c, i) => c + i + ' '); 

        }
        
        public string ReturnUrl { get; set; }
    }
}
