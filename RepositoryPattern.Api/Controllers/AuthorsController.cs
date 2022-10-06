using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Api.Core.Models;
using RepositoryPattern.Api.Core.Repositories;

namespace RepositoryPattern.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
	const int MAX_PAGE_SIZE = 20;

	private readonly IAuthorRepository _authors;

	public AuthorsController(IAuthorRepository authors)
	{
		_authors = authors;
	}

	[HttpGet]
	public async Task<ActionResult<List<Author>>> GetAllAuthors(int pageIndex, int pageSize)
	{
		if (pageSize > MAX_PAGE_SIZE)
			pageSize = MAX_PAGE_SIZE;

		var authors = await _authors.GetAll();
		return authors.ToList();
	}
}
