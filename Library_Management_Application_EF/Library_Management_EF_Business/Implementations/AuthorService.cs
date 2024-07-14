using Library_Management_EF_Business.Interfaces;
using Library_Management_EF_Core.Models;
using Library_Management_EF_Core.Repositories;
using Library_Management_EF_Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_EF_Business.Implementations;

public class AuthorService : IAuthorService
{
    private IAuthorRepository _repository;
    public AuthorService()
    {
        _repository = new AuthorRepository();
    }

    public async Task CreateAuthorAsync(Author author)
    {
        await _repository.Insert(author);
        await _repository.CommitAsync();
    }

    //public async Task CreateBookAsync(Book book)
    //{
    //    await _repository.Insert(book);
    //    await _repository.CommitAsync();
    //}

    public async Task DeleteAuthorAsync(int id)
    {
        var wantedaut = await _repository.GetAsync(id);
        if (wantedaut == null)
        {
            throw new NullReferenceException();
        }
        _repository.Delete(wantedaut);
        await _repository.CommitAsync();
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        return await _repository.GetAll().ToListAsync();
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        var data = await _repository.GetAsync(author.Id);
        if (data == null)
        {
            throw new NullReferenceException();
        }
        data.Name = author.Name;
        await _repository.CommitAsync();
    }

}
