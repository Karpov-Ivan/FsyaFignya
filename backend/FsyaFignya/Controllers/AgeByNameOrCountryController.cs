using System;
using AutoMapper;
using FsyaFignya.Dto;
using Microsoft.AspNetCore.Mvc;
using FsyaFignya.Models.Models;
using GettingDataViaAPI.ApiHandler;
using FsyaFignya.Adapter.MyException;
using FsyaFignya.Interfaces.Repository;

namespace VsyaFignya.Controllers
{
    /// <summary>
    /// Контроллер для работы с возрастом по имени или стране.
    /// </summary>
    [ApiController]
    [Route(template: "api/[controller]")]
    public class AgeByNameOrCountryController : Controller
    {
        private readonly IRepository _repository;

        protected readonly IMapper _mapper;

        /// <summary>
        /// Конструктор контроллера AgeByNameOrCountryController.
        /// </summary>
        /// <param name="repository">Интерфейс репозитория для работы с данными о возрасте.</param>
        /// <param name="mapper">Маппер для преобразования моделей.</param>
        public AgeByNameOrCountryController(IRepository repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        /// <summary>
        /// Получает список всех имен и их возрастов.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpGet]
        public async Task<IActionResult> GetAllNamesAndTheirAges()
        {
            IActionResult response;

            try
            {
                var agesByNameOrCountry = await _repository.GetListAgeByNameOrCountry();

                var agesByNameOrCountryDto = _mapper.Map<List<AgeByNameOrCountryDto>>(agesByNameOrCountry);

                response = Ok(agesByNameOrCountryDto);
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        /// <summary>
        /// Добавляет возраст по имени.
        /// </summary>
        /// <param name="name">Имя для добавления возраста.</param>
        /// <returns>Результат выполнения операции.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status400BadRequest">Некорректный аргумент.</exception>
        [HttpPost("{name}")]
        public async Task<IActionResult> AddAgeByName(string name)
        {
            IActionResult response;

            try
            {
                await _repository.AddAgeByNameOrCountry(new _AgeByNameOrCountry()
                {
                    Name = name,
                    Age = await new AgeByNameApi().GetTheAgeByName(name),
                    Country = ""
                });

                response = Ok();
            }
            catch (RequestException)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }

            return response;
        }

        /// <summary>
        /// Добавляет возраст по имени и стране.
        /// </summary>
        /// <param name="name">Имя для добавления возраста.</param>
        /// <param name="country">Страна для добавления возраста.</param>
        /// <returns>Результат выполнения операции.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status400BadRequest">Некорректный аргумент.</exception>
        [HttpGet("{name}/{country}")]
        public async Task<IActionResult> AddAgeByNameAndCountry(string name, string country)
        {
            IActionResult response;

            try
            {
                await _repository.AddAgeByNameOrCountry(new _AgeByNameOrCountry()
                {
                    Name = name,
                    Age = await new AgeByNameApi().GetAgeByNameAndCountry(name, country),
                    Country = country
                });

                var agesByNameOrCountry = await _repository.GetListAgeByNameOrCountry();

                var agesByNameOrCountryDto = _mapper.Map<List<AgeByNameOrCountryDto>>(agesByNameOrCountry);

                List<AgeByNameOrCountryDto> result = agesByNameOrCountryDto
                                                     .Select(x => x)
                                                     .Where(x => x.Name == name && x.Country == country)
                                                     .ToList();

                response = Ok(result);
            }
            catch (RequestException)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }

            return response;
        }
    }
}