using Microsoft.AspNetCore.Mvc;
using PharmacyServices_API.Repository;
using PharmacyServices_API.Models.DTOs;

namespace PharmacyServices_API.Controllers
{
    [Route("api/drugtype")]
    public class DrugTypeController : ControllerBase
    {
        protected ResponseDTO _response;
        private IDrugTypeRepository _drugTypeRepository;

        public DrugTypeController(IDrugTypeRepository drugTypeRepository)
        {
            _drugTypeRepository = drugTypeRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DrugTypeDTO> drugTypeDTOs = await _drugTypeRepository.GetDrugTypeList();
                _response.Result = drugTypeDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                        = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                DrugTypeDTO drugTypeDTO = await _drugTypeRepository.GetDrugTypeById(id);
                _response.Result = drugTypeDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                        = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("name/{name}")]
        public async Task<object> GetByName(string name)
        {
            try
            {
                IEnumerable<DrugTypeDTO> drugTypeDTOs = await _drugTypeRepository.GetDrugTypeByName(name);
                _response.Result = drugTypeDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                        = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] DrugTypeDTO drugTypeDTO)
        {
            try
            {
                DrugTypeDTO model = await _drugTypeRepository.CreateUpdateDrugType(drugTypeDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] DrugTypeDTO drugTypeDTO)
        {
            try
            {
                DrugTypeDTO model = await _drugTypeRepository.CreateUpdateDrugType(drugTypeDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _drugTypeRepository.DeleteDrugType(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
