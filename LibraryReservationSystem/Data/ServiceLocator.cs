using System;
using System.Configuration;

namespace LibraryReservationSystem.Data
{
    public static class ServiceLocator
    {
        private static IBookRepository _repository;

        public static IBookRepository GetBookRepository()
        {
            if (_repository == null)
            {
                string repoType = ConfigurationManager.AppSettings["RepositoryType"];

                if (!string.IsNullOrEmpty(repoType) && repoType.Equals("File", StringComparison.OrdinalIgnoreCase))
                {
                    _repository = new FileBookRepository();
                }
                else if (!string.IsNullOrEmpty(repoType) && repoType.Equals("Database", StringComparison.OrdinalIgnoreCase))
                {
                    _repository = new DbBookRepository();
                }
                else
                {
                    _repository = new InMemoryBookRepository();
                }
            }

            return _repository;
        }
    }
}
