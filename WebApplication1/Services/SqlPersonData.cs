using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SqlPersonData
    {
        private WebApplication1DbContext _context;

        public SqlPersonData(WebApplication1DbContext context)
        {
           _context = context;
        }

        public void Add(Person newPerson)
        {
            _context.Add(newPerson);
            _context.SaveChanges();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
