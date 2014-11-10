﻿using AppGet.PackageRepository;
using NLog;

namespace AppGet.PackageSearch
{
    public interface IPackageSearchService
    {
        void DisplayResults(string query);
    }

    public class PackageSearchService : IPackageSearchService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly Logger _logger;

        public PackageSearchService(IPackageRepository packageRepository, Logger logger)
        {
            _packageRepository = packageRepository;
            _logger = logger;
        }

        public void DisplayResults(string query)
        {
            var results = _packageRepository.Search(query);

            _logger.Info("Found {0} package(s)", results.Count);

            foreach (var package in results)
            {
                _logger.Info(package);
            }
        }
    }
}