using DvdLibraryWebApi.Data.Interface;
using DvdLibraryWebApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Data
{
    public static class DvdRepositoryFactory
    {
        public static IDvdRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "ADO":
                    return new DvdRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
