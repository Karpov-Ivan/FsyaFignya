using System;
using AutoMapper;
using System.Linq;
using System.Text;
using FsyaFignya.Adapter;
using FsyaFignya.DataBase;
using System.Threading.Tasks;
using FsyaFignya.Models.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FsyaFignya.Adapter.MyException;
using FsyaFignya.Interfaces.Repository;
using FsyaFignya.DataBase.Models.Models;
using System.Security.Cryptography.X509Certificates;

namespace FsyaFignya.Adapter.Implementations
{
    public class Repository : BaseRepository, IRepository
    {
        public Repository(Context context, IMapper mapper) : base(context, mapper) { }

        public Task<List<_AgeByNameOrCountry>> GetListAgeByNameOrCountry()
        {
            try
            {
                return Task.FromResult(_mapper.Map<List<_AgeByNameOrCountry>>(_context.AgeByNameOrCountry.ToList()));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task AddAgeByNameOrCountry(_AgeByNameOrCountry ageByNameOrCountry)
        {
            try
            {
                if (ageByNameOrCountry == null)
                    throw new ArgumentNullException();

                if (ageByNameOrCountry.Name == "" || ageByNameOrCountry.Age < 0)
                    throw new ArgumentNullException();

                var ageByNameOrCountryList = _context.AgeByNameOrCountry.ToList();
;
                if (ageByNameOrCountryList.Where(x => x.Name == ageByNameOrCountry.Name
                                      && x.Age == ageByNameOrCountry.Age).Count() == 0)
                {
                    _context.AgeByNameOrCountry.Add(_mapper.Map<AgeByNameOrCountry>(ageByNameOrCountry));
                    await _context.SaveChangesAsync();
                }
            }
            catch (RequestException exception)
            {
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<List<_CountryNato>> GetListOfCountryNato()
        {
            try
            {
                return Task.FromResult(_mapper.Map<List<_CountryNato>>(_context.CountryNato.ToList()));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task AddListOfCountryNato(List<_CountryNato> listOfCountryNato)
        {
            try
            {
                if (listOfCountryNato == null)
                    throw new ArgumentNullException();

                var listOfCountryNameDB = _context.CountryNato.ToList();

                foreach (var country in listOfCountryNato)
                {
                    if (country.CountryName == "" || country.DateOfEntry < 0)
                        throw new RequestException();

                    if (listOfCountryNameDB.Find(x => x.CountryName
                                      .Contains(country.CountryName)) != null)
                        continue;
                    else
                    {
                        _context.CountryNato.Add(_mapper.Map<CountryNato>(country));
                        _context.CountryNato.OrderBy(x => x.CountryName);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (RequestException exception)
            {
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<List<_FactsAboutDogs>> GetListFactsAboutDogs()
        {
            try
            {
                return Task.FromResult(_mapper.Map<List<_FactsAboutDogs>>(_context.FactsAboutDogs.ToList()));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task AddFactsAboutDogs(List<_FactsAboutDogs> factsAboutDogs)
        {
            try
            {
                if (factsAboutDogs == null)
                    throw new ArgumentNullException();

                var factsAboutDogsList = _context.FactsAboutDogs.ToList();

                foreach (var factAboutDogs in factsAboutDogs)
                {
                    if (factAboutDogs.FactAboutDogs == "")
                        throw new RequestException();

                    if (factsAboutDogsList.Where(x => x.FactAboutDogs == factAboutDogs.FactAboutDogs).Count() != 0)
                        continue;

                    else
                    {
                        _context.FactsAboutDogs.Add(_mapper.Map<FactsAboutDogs>(factAboutDogs));
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (RequestException exception)
            {
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task DeleteFactsAboutDogs()
        {
            try
            {
                _context.FactsAboutDogs.RemoveRange(_context.FactsAboutDogs.ToList());

                await _context.SaveChangesAsync();
            }
            catch (RequestException exception)
            {
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<List<_InformationAboutBitcoin>> GetListInformationAboutBitcoin()
        {
            try
            {
                return Task.FromResult(_mapper.Map<List<_InformationAboutBitcoin>>(_context.InformationAboutBitcoin.ToList()));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task AddInformationAboutBitcoin(_InformationAboutBitcoin informationAboutBitcoin)
        {
            try
            {
                if (informationAboutBitcoin == null)
                    throw new ArgumentNullException();

                if (informationAboutBitcoin.Price < 0 || informationAboutBitcoin.RequestDate == "")
                    throw new ArgumentNullException();

                _context.InformationAboutBitcoin.Add(_mapper.Map<InformationAboutBitcoin>(informationAboutBitcoin));
                await _context.SaveChangesAsync();
            }
            catch (RequestException exception)
            {
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<List<_ListOfSeriesTitlesOfTheBigBangTheory>> GetListOfSeriesTitlesOfTheBigBangTheory()
        {
            try
            {
                return Task.FromResult(_mapper.Map<List<_ListOfSeriesTitlesOfTheBigBangTheory>>(_context.ListOfSeriesTitlesOfTheBigBangTheory.ToList()));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task AddListOfSeriesTitlesOfTheBigBangTheory(List<_ListOfSeriesTitlesOfTheBigBangTheory> listOfSeriesTitlesOfTheBigBangTheory)
        {
            try
            {
                if (listOfSeriesTitlesOfTheBigBangTheory == null)
                    throw new ArgumentNullException();

                var listOfSeriesTitlesOfTheBigBangTheoryDB = _context.ListOfSeriesTitlesOfTheBigBangTheory.ToList();

                foreach (var seriesTitlesOfTheBigBangTheory in listOfSeriesTitlesOfTheBigBangTheory)
                {
                    if (seriesTitlesOfTheBigBangTheory.SeriesName == "")
                        throw new RequestException();

                    if (listOfSeriesTitlesOfTheBigBangTheoryDB.Find(x => x.SeriesName
                                      .Contains(seriesTitlesOfTheBigBangTheory.SeriesName)) != null)
                        continue;
                    else
                    {
                        _context.ListOfSeriesTitlesOfTheBigBangTheory.Add(_mapper.Map<ListOfSeriesTitlesOfTheBigBangTheory>(seriesTitlesOfTheBigBangTheory));
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (RequestException exception)
            {
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}