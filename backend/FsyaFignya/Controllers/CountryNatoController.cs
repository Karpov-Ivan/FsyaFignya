using System;
using AutoMapper;
using FsyaFignya.Dto;
using GettingDataViaAPI;
using Microsoft.AspNetCore.Mvc;
using FsyaFignya.Models.Models;
using FsyaFignya.Adapter.MyException;
using FsyaFignya.Interfaces.Repository;

namespace VsyaFignya.Controllers
{
    /// <summary>
    /// Контроллер для работы с информацией о странах в НАТО.
    /// </summary>
    [ApiController]
    [Route(template: "api/[controller]")]
    public class CountryNatoController : Controller
    {
        private readonly IRepository _repository;

        protected readonly IMapper _mapper;

        /// <summary>
        /// Конструктор контроллера CountryNatoController.
        /// </summary>
        /// <param name="repository">Интерфейс репозитория, через который осуществляется доступ к данным о странах НАТО.</param>
        /// <param name="mapper">Объект AutoMapper для маппинга данных между объектами.</param>
        public CountryNatoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        /// <summary>
        /// Получает список всех стран в НАТО и их дату вхождения.
        /// </summary>
        /// <returns>Результат выполнения операции. Возвращает список стран в НАТО и их дат вхождения в формате JSON.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpGet]
        public async Task<IActionResult> GetAllCountryNato()
        {
            IActionResult response;

            try
            {
                var countryNatoList = new List<_CountryNato>();

                foreach (var country in await new Parser().GetListOfNameCountryNato())
                    countryNatoList.Add(new _CountryNato
                    {
                        CountryName = country[0],
                        DateOfEntry = Convert.ToInt32(country[1])
                    });

                await this._repository.AddListOfCountryNato(countryNatoList);

                var countryNato = await _repository.GetListOfCountryNato();

                var countryNatoDto = _mapper.Map<List<CountryNatoDto>>(countryNato);

                response = Ok(countryNatoDto);
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        /// <summary>
        /// Обновляет список стран в НАТО и их дату вхождения.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpPut]
        public async Task<IActionResult> UpdateCountryNato()
        {
            IActionResult response;

            try
            {
                var countryNatoList = new List<_CountryNato>();

                foreach (var country in await new Parser().GetListOfNameCountryNato())
                    countryNatoList.Add(new _CountryNato
                    {
                        CountryName = country[0],
                        DateOfEntry = Convert.ToInt32(country[1])
                    });

                await this._repository.AddListOfCountryNato(countryNatoList);

                response = Ok();
            }
            catch (RequestException)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}