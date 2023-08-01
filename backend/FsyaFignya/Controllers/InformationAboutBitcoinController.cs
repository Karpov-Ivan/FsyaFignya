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
    /// Контроллер для работы с информацией о биткоине.
    /// </summary>
    [ApiController]
    [Route(template: "api/[controller]")]
    public class InformationAboutBitcoinController : Controller
    {
        private readonly IRepository _repository;

        protected readonly IMapper _mapper;

        /// <summary>
        /// Конструктор контроллера InformationAboutBitcoinController.
        /// </summary>
        /// <param name="repository">Интерфейс репозитория, через который осуществляется доступ к данным об информации о биткоине.</param>
        /// <param name="mapper">Объект AutoMapper для маппинга данных между объектами.</param>
        public InformationAboutBitcoinController(IRepository repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        /// <summary>
        /// Получает информацию о биткоине, включая его текущую цену и время запроса.
        /// </summary>
        /// <returns>Результат выполнения операции. Возвращает список с информацией о биткоине в формате JSON.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpGet]
        public async Task<IActionResult> GetAllInformationAboutBitcoin()
        {
            IActionResult response;

            try
            {
                await this._repository.AddInformationAboutBitcoin(new _InformationAboutBitcoin()
                {
                    Price = await new CoinDeskApi().GetThePriceOfBitcoin(),
                    RequestDate = await new CoinDeskApi().GetRequestTime()
                });

                var informationAboutBitcoin = await _repository.GetListInformationAboutBitcoin();

                var informationAboutBitcoinDto = _mapper.Map<List<InformationAboutBitcoinDto>>(informationAboutBitcoin);

                response = Ok(new List<InformationAboutBitcoinDto>() {
                                  informationAboutBitcoinDto[informationAboutBitcoinDto.Count() - 1] });
            }
            catch (Exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        /// <summary>
        /// Добавляет информацию о биткоине, включая его текущую цену и время запроса, в базу данных.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <exception cref="Status200OK">Успешное выполнение запроса.</exception>
        /// <exception cref="Status500InternalServerError">Внутренняя ошибка сервера.</exception>
        [HttpPost]
        public async Task<IActionResult> AddInformationAboutBitcoin()
        {
            IActionResult response;

            try
            {
                await this._repository.AddInformationAboutBitcoin(new _InformationAboutBitcoin()
                {
                    Price = await new CoinDeskApi().GetThePriceOfBitcoin(),
                    RequestDate = await new CoinDeskApi().GetRequestTime()
                });

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