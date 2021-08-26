using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Covid19.Business.Services.Interfaces;
using Covid19.Bussiness.Services.Models;
using Covid19.Bussiness.ViewModels;
using Covid19.Models.Models;
using Newtonsoft.Json;

namespace Covid19.Business.Services.Concrete
{
    public class Covid19BLL : ICovid19BLL
    {
        public Covid19BLL()
        {
            _httpClient = new HttpClient();
        }

        protected HttpClient _httpClient;
        
        public async Task<IList<CovidTOPContries>> CovidTOPContries()
        {
            var response = await _httpClient.GetAsync("https://api.covid19api.com/summary");
            var json = await response.Content.ReadAsStringAsync();
            
            var covid19ApiModel = JsonConvert.DeserializeObject<Covid19ApiModel>(json);

            return (from ct in covid19ApiModel.Countries
                orderby (ct.TotalConfirmed - ct.TotalRecovered) descending 
                    select new CovidTOPContries
                    {
                        RankingPosition = ct.ID,
                        CountryName = ct.CountryName,
                        TotalCases = (ct.TotalConfirmed - ct.TotalRecovered)
                    }).Take(10).ToList();
        }
    }
}