using System.Collections.Generic;
using System.Threading.Tasks;
using Covid19.Bussiness.ViewModels;

namespace Covid19.Business.Services.Interfaces
{
    public interface ICovid19BLL
    {
        Task<IList<CovidTOPContries>> CovidTOPContries();
    }
}