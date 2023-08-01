using AutoMapper;
using FsyaFignya.Dto;
using Microsoft.AspNetCore.Mvc;
using FsyaFignya.Models.Models;
using GettingDataViaAPI.ApiHandler;
using System.Text.RegularExpressions;
using FsyaFignya.Adapter.MyException;
using FsyaFignya.Interfaces.Repository;

namespace VsyaFignya.Controllers
{
    /// <summary>
    /// Контроллер для работы с фактами о собаках.
    /// </summary>
    [ApiController]
    [Route(template: "api/[controller]")]
    public class FactsAboutDogsController : Controller
    {
        private readonly IRepository _repository;

        protected readonly IMapper _mapper;

        /// <summary>
        /// Конструктор контроллера FactsAboutDogsController.
        /// </summary>
        /// <param name="repository">Интерфейс репозитория, через который осуществляется доступ к данным о фактах о собаках.</param>
        /// <param name="mapper">Объект AutoMapper для маппинга данных между объектами.</param>
        public FactsAboutDogsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        /// <summary>
        /// Получает определенное количество фактов о собаках.
        /// </summary>
        /// <param name="count">Количество фактов о собаках, которое требуется получить. Допустимые значения: 1 или 5.</param>
        /// <returns>Результат выполнения операции. Возвращает список фактов о собаках в формате JSON.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpGet("{count}")]
        public async Task<IActionResult> GetAllFactsAboutDogs(int count)
        {
            IActionResult response;

            try
            {
                if (count == 1)
                {
                    await this._repository.AddFactsAboutDogs(new List<_FactsAboutDogs>()
                    {
                        new _FactsAboutDogs()
                        {
                            FactAboutDogs = RemoveBrackets(await new DogFactsApi().GetOneFactAboutDog())
                        }
                    });
                }
                else if (count == 5)
                {
                    var factsAboutDogsList = new List<_FactsAboutDogs>();

                    foreach (var fact in await new DogFactsApi().GetSomeFactsAboutDogs())
                        factsAboutDogsList.Add(new _FactsAboutDogs()
                        {
                            FactAboutDogs = RemoveBrackets(fact)
                        });

                    await this._repository.AddFactsAboutDogs(factsAboutDogsList);
                }

                var factsAboutDogs = await _repository.GetListFactsAboutDogs();

                var factsAboutDogsDto = _mapper.Map<List<FactsAboutDogsDto>>(factsAboutDogs);

                response = Ok(factsAboutDogsDto.Skip(Math.Max(0, factsAboutDogsDto.Count() - 5)));
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        /// <summary>
        /// Добавляет определенное количество новых фактов о собаках.
        /// </summary>
        /// <param name="count">Количество фактов о собаках, которое требуется добавить. Допустимые значения: 1 или 5.</param>
        /// <returns>Результат выполнения операции.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpPost("{count}")]
        public async Task<IActionResult> AddFactsAboutDogs(int count)
        {
            IActionResult response;

            try
            {
                if (count == 1)
                {
                    await this._repository.AddFactsAboutDogs(new List<_FactsAboutDogs>()
                    {
                        new _FactsAboutDogs()
                        {
                            FactAboutDogs = RemoveBrackets(await new DogFactsApi().GetOneFactAboutDog())
                        }
                    });
                }
                else if (count == 5)
                {
                    var factsAboutDogsList = new List<_FactsAboutDogs>();

                    foreach (var fact in await new DogFactsApi().GetSomeFactsAboutDogs())
                        factsAboutDogsList.Add(new _FactsAboutDogs()
                        {
                            FactAboutDogs = RemoveBrackets(fact)
                        });

                    await this._repository.AddFactsAboutDogs(factsAboutDogsList);
                }

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

        /// <summary>
        /// Удаляет все факты о собаках из базы данных.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpDelete]
        public async Task<IActionResult> DeleteAllFactsAboutDogs()
        {
            IActionResult response;

            try
            {
                await _repository.DeleteFactsAboutDogs();

                response = Ok();
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        private static string RemoveBrackets(string input)
        {
            string pattern = @"\[\s*""(.*?)""\s*\]";
            string replacement = "\"$1\"";
            string result = Regex.Replace(input, pattern, replacement);

            return result;
        }
    }
}