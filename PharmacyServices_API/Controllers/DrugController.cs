using Microsoft.AspNetCore.Mvc;
using PharmacyServices_API.Repository;
using PharmacyServices_API.Models.DTOs;

namespace PharmacyServices_API.Controllers
{
    [Route("api/drug")]
    public class DrugController : ControllerBase
    {
        protected ResponseDTO _response;
        private IDrugRepository _drugRepository;

        public DrugController(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DrugDTO> drugDTOs = await _drugRepository.GetDrugList();
                _response.Result = drugDTOs;
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
                DrugDTO drugDTO = await _drugRepository.GetDrugById(id);
                _response.Result = drugDTO;
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
        [Route("cat/{cid}")]
        public async Task<object> GetDrugByCategory(int cid)
        {
            try
            {
                List<DrugDTO> drugDTO = await _drugRepository.GetDrugByCatId(cid);
                _response.Result = drugDTO;
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
        [Route("type/{tid}")]
        public async Task<object> GetDrugByType(int tid)
        {
            try
            {
                List<DrugDTO> drugDTO = await _drugRepository.GetDrugByTypeId(tid);
                _response.Result = drugDTO;
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
        [Route("sup/{sid}")]
        public async Task<object> GetDrugBySupplier(int sid)
        {
            try
            {
                List<DrugDTO> drugDTO = await _drugRepository.GetDrugBySupId(sid);
                _response.Result = drugDTO;
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
        [Route("name/{name}")]
        public async Task<object> GetDrugByName(string name)
        {
            try
            {
                List<DrugDTO> drugDTO = await _drugRepository.GetDrugByName(name);
                _response.Result = drugDTO;
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
        [Route("order/{order}")]
        public async Task<object> GetDrugOrder(string order)
        {
            try
            {
                List<DrugDTO> drugDTO = await _drugRepository.GetDrugByOrder(order);
                _response.Result = drugDTO;
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
        [Route("druglist/{did}")]
        public async Task<object> GetDrugListByDId(int did)
        {
            try
            {
                List<DrugListDTO> drugListDTO = await _drugRepository.GetDrugListByPId(did);
                _response.Result = drugListDTO;
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
        public async Task<object> Post([FromBody] DrugDTO drugDTO)
        {
            try
            {
                DrugDTO model = await _drugRepository.CreateUpdateDrug(drugDTO);
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
        public async Task<object> Put([FromBody] DrugDTO drugDTO)
        {
            try
            {
                DrugDTO model = await _drugRepository.CreateUpdateDrug(drugDTO);
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

        [HttpPost]
        [Route("druglist")]
        public async Task<object> PostDrugList([FromBody] DrugListDTO drugListDTO)
        {
            try
            {
                DrugListDTO model = await _drugRepository.CreateUpdateDrugList(drugListDTO);
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
        [Route("druglist")]
        public async Task<object> PutDrugList([FromBody] DrugListDTO drugListDTO)
        {
            try
            {
                DrugListDTO model = await _drugRepository.CreateUpdateDrugList(drugListDTO);
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
                bool isSuccess = await _drugRepository.DeleteDrug(id);
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

        [HttpDelete]
        [Route("deldruglist/{id}")]
        public async Task<object> DeleteDrugList(int id)
        {
            try
            {
                bool isSuccess = await _drugRepository.DeleteDrugList(id);
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
