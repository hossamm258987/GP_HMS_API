using Microsoft.AspNetCore.Mvc;
using PharmacyServices_API.Models.DTOs;
using PharmacyServices_API.Repository;

namespace PharmacyServices_API.Controllers
{
    [Route("api/drugcategory")]
    public class CategoryController : ControllerBase
    {
        protected ResponseDTO _response;
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<CategoryDTO> categoryDTOs = await _categoryRepository.GetCategoryList();
                _response.Result = categoryDTOs;
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
                CategoryDTO categoryDTO = await _categoryRepository.GetCategoryById(id);
                _response.Result = categoryDTO;
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
                IEnumerable<CategoryDTO> categoryDTOs = await _categoryRepository.GetCategoryByName(name);
                _response.Result = categoryDTOs;
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
        public async Task<object> Post([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                CategoryDTO model = await _categoryRepository.CreateUpdateCategory(categoryDTO);
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
        public async Task<object> Put([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                CategoryDTO model = await _categoryRepository.CreateUpdateCategory(categoryDTO);
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
                bool isSuccess = await _categoryRepository.DeleteCategory(id);
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
