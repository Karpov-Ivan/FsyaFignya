using AutoMapper;
using FsyaFignya.Dto;
using GettingDataViaAPI;
using Microsoft.AspNetCore.Mvc;
using FsyaFignya.Models.Models;
using System.Text.RegularExpressions;
using FsyaFignya.Adapter.MyException;
using FsyaFignya.Interfaces.Repository;

namespace VsyaFignya.Controllers
{
    /// <summary>
    /// Контроллер для работы со списком названий серий сериала "The Big Bang Theory".
    /// </summary>
    [ApiController]
    [Route(template: "api/[controller]")]
    public class ListOfSeriesTitlesOfTheBigBangTheoryController : Controller
    {
        private readonly IRepository _repository;

        protected readonly IMapper _mapper;

        /// <summary>
        /// Конструктор контроллера ListOfSeriesTitlesOfTheBigBangTheoryController.
        /// </summary>
        /// <param name="repository">Интерфейс репозитория, через который осуществляется доступ к данным о списке названий серий сериала.</param>
        /// <param name="mapper">Объект AutoMapper для маппинга данных между объектами.</param>
        public ListOfSeriesTitlesOfTheBigBangTheoryController(IRepository repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        /// <summary>
        /// Получает список названий серий сериала "The Big Bang Theory".
        /// </summary>
        /// <returns>Результат выполнения операции. Возвращает список с названиями серий в формате JSON.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpGet]
        public async Task<IActionResult> GetListOfSeriesTitlesOfTheBigBangTheory()
        {
            IActionResult response;

            try
            {
                var seriesTitlesList = new List<_ListOfSeriesTitlesOfTheBigBangTheory>();

                foreach (var title in await new Parser().GetListOfSeriesTitlesOfTheBigBangTheory())
                {
                    seriesTitlesList.Add(new _ListOfSeriesTitlesOfTheBigBangTheory
                    {
                        SeriesName = FormatString(title)
                    });
                }

                await this._repository.AddListOfSeriesTitlesOfTheBigBangTheory(seriesTitlesList);

                var listOfSeriesTitlesOfTheBigBangTheory = await _repository.GetListOfSeriesTitlesOfTheBigBangTheory();

                var listOfSeriesTitlesOfTheBigBangTheoryDto = _mapper.Map<List<ListOfSeriesTitlesOfTheBigBangTheoryDto>>(listOfSeriesTitlesOfTheBigBangTheory);

                response = Ok(listOfSeriesTitlesOfTheBigBangTheoryDto);
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        /// <summary>
        /// Обновляет список названий серий сериала "The Big Bang Theory" в базе данных.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpPut]
        public async Task<IActionResult> UpdateListOfSeriesTitlesOfTheBigBangTheory()
        {
            IActionResult response;

            try
            {
                var seriesTitlesList = new List<_ListOfSeriesTitlesOfTheBigBangTheory>();

                foreach (var title in await new Parser().GetListOfSeriesTitlesOfTheBigBangTheory())
                {
                    seriesTitlesList.Add(new _ListOfSeriesTitlesOfTheBigBangTheory
                    {
                        SeriesName = FormatString(title)
                    });
                }

                await this._repository.AddListOfSeriesTitlesOfTheBigBangTheory(seriesTitlesList);

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

        private static string FormatString(string inputString)
        {
            string formattedString = Regex.Replace(inputString, @"\[\d+\]", "");

            formattedString = Regex.Replace(formattedString, "\"\\s*\"", "\", \"");

            return formattedString;
        }
    }
}