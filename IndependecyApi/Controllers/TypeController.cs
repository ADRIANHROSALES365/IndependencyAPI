using AutoMapper;
using IndependecyApi.Repository;
using IndependecyApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace IndependecyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository ;
        private readonly IMapper _mapper;

        public TypeController(ITypeRepository typeRepository , IMapper mapper)
        {
            _typeRepository=typeRepository;
            _mapper=mapper;
        }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]

    public IActionResult GetTypes()
        {
            var types= _typeRepository.GetTypes();

            //Using automaper on each element of types

            var typeDto= new List<TypeDto>();

            foreach(var type in types)
            {
                typeDto.Add(_mapper.Map<TypeDto>(type));
            }

        return Ok(typeDto);

        }

     //Endopoint created in order to get a Type from the types table
     [HttpGet("{id:int}",Name="GetCategory")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     [ProducesResponseType(StatusCodes.Status401Unauthorized)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]

     public IActionResult GetType(int id)

    {
        if(!_typeRepository.TypeExists(id))
            {
                ModelState.AddModelError("CustomError","Type does not exist in the database");
                return BadRequest(ModelState);
            }
            var typevar = new Type();
            typevar=_typeRepository.GetType(id);

            if(typevar==null)
            {
                ModelState.AddModelError("CustomError","Something went wrong trying to get the type from the database");
                return BadRequest(ModelState);
            }

            var typeDto= new TypeDto();
            typeDto=_mapper.Map<TypeDto>(typevar);

            return Ok(typeDto);

            
    }

     [HttpGet("byname/{name}",Name="GetCategoryByName")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     [ProducesResponseType(StatusCodes.Status401Unauthorized)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]

     public IActionResult GetTypeByName(string name)
        {
            var typebyname= new Type();
            typebyname =_typeRepository.GetType(name);

            if(typebyname==null)
            {
                ModelState.AddModelError("Custom Error","Something went wrong trying to get the Type from Database");
                return BadRequest(ModelState);
            }

            var typebynamedto = new TypeDto();
            typebynamedto=_mapper.Map<TypeDto>(typebyname);

                return Ok(typebynamedto);
        }

      [HttpPatch("{id:int}",Name="UpdateType")]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult Updatetype(int id, CreateTypeDto updateTypeDto)
        {
            if(!_typeRepository.TypeExists(id))
            {
                return NotFound("Type Does not exists into the database");
            }

            if(updateTypeDto==null)
            {
                ModelState.AddModelError("CustomError","Type is null");
                return BadRequest(ModelState);
            }
            var type=_mapper.Map<Type>(updateTypeDto);
            type.TypeId=id;

            if (!_typeRepository.UpdateType(type))
            {
                ModelState.AddModelError("CustomError",$"Something went wrong trying to Update the type with id: {id}");
                return StatusCode(500,ModelState);
            }

            return NoContent();

        }


        [HttpDelete("{id:int}",Name="DeleteType")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult DeleteType(int id, TypeDto removetypeDto)
        {
            if(removetypeDto==null)
            {
                ModelState.AddModelError("CustomError","Type is Empty");
                return BadRequest(ModelState); 
            }

            if (!_typeRepository.TypeExists(id))
            {
                return NotFound($"The Type with the id: {id} doesn't exists in the database");
            }

            var typeobject=_mapper.Map<Type>(removetypeDto);
            typeobject.TypeId=id;

            if (!_typeRepository.DeleteType(typeobject))
            {
                ModelState.AddModelError("CustomError",$"Something wrong ocurred while trying to remove the registre with the ID: {id}");
                return StatusCode(500,ModelState);
            }

            return NoContent();
            
        }

     // Endpoint created in order to Create a type into the Types table
      [HttpPost]
      [ProducesResponseType(StatusCodes.Status403Forbidden)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      public IActionResult CreateType([FromBody] CreateTypeDto createTypeDto)
      {
        if (createTypeDto == null)
            {
                return BadRequest(ModelState);
            }
        if(_typeRepository.TypeExists(createTypeDto.Name))
            {
                ModelState.AddModelError("CustomError","Type already exists");
                return BadRequest(ModelState);
            }

            //Converting CreateTypeDto Object to plain Type Object with automapper in order to save it into database
            var type = _mapper.Map<Type>(createTypeDto);

           if(!_typeRepository.CreateType(type))
            {
                ModelState.AddModelError("CustomError","Something went wrong on the creation of this type");
                return StatusCode(500,ModelState);
            }

            return CreatedAtRoute("GetType",new {id=type.TypeId},type);

      }
      
    }
}
