using Microsoft.AspNetCore.Mvc;
using PharmacyServices_API.Repository;
using PharmacyServices_API.Models.DTOs;

namespace PharmacyServices_API.Controllers
{
    [Route("api/pharmacy")]
    public class PharmacyController : ControllerBase
    {
        protected ResponseDTO _response;
        private IPharmacyRepository _pharmacyRepository;

        public PharmacyController(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PharmacyDTO> pharmacyDTOs = await _pharmacyRepository.GetPharmacyList();
                _response.Result = pharmacyDTOs;
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
                PharmacyDTO pharmacyDTO = await _pharmacyRepository.GetPharmacyById(id);
                _response.Result = pharmacyDTO;
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
        [Route("{hid}")]
        public async Task<object> GetByHId(int hid)
        {
            try
            {
                List<PharmacyDTO> pharmacyDTO = await _pharmacyRepository.GetPharmacyByHId(hid);
                _response.Result = pharmacyDTO;
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
                IEnumerable<PharmacyDTO> pharmacyDTOs = await _pharmacyRepository.GetPharmacyByName(name);
                _response.Result = pharmacyDTOs;
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
        public async Task<object> Post([FromBody] PharmacyDTO pharmacyDTO)
        {
            try
            {
                PharmacyDTO model = await _pharmacyRepository.CreateUpdatePharmacy(pharmacyDTO);
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
        public async Task<object> Put([FromBody] PharmacyDTO pharmacyDTO)
        {
            try
            {
                PharmacyDTO model = await _pharmacyRepository.CreateUpdatePharmacy(pharmacyDTO);
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
                bool isSuccess = await _pharmacyRepository.DeletePharmacy(id);
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
